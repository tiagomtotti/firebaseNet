using FirebaseNet.Exceptions;
using FirebaseNet.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace FirebaseNet.Messaging
{
    public class FCMClient
    {
        private static Uri FCM_URI = new Uri("https://fcm.googleapis.com/fcm/send");

        private ISerializer _serializer;

        private string _serverKey { get; set; }

        public FCMClient(string serverKey, ISerializer serializer)
        {
            _serverKey = serverKey;
            _serializer = serializer;
        }

        public FCMClient(string serverKey):this(serverKey, new JsonNetSerializer())
        {

        }

        public async Task<T> SendMessageAsync<T>(Message message) where T: class, IFCMResponse
        {
            var result = await SendMessageAsync(message);
            return result as T;
        }

        public async Task<IFCMResponse> SendMessageAsync(Message message)
        {
            if (TestMode) { message.DryRun = true; }

            var serializedMessage = _serializer.Serialize(message);

            var request = new HttpRequestMessage(HttpMethod.Post, FCM_URI);
            request.Headers.TryAddWithoutValidation("Authorization", "key=" + _serverKey);
            request.Content = new StringContent(serializedMessage, Encoding.UTF8, "application/json");

            var client = HttpClient;
            var result = await client.SendAsync(request);


            if (result.StatusCode != System.Net.HttpStatusCode.OK)
            {

                if (result.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                {
                    throw new FCMUnauthorizedException();
                }


                //TODO: handle retry-timeout for 500 messages
                var errorMessage = await result.Content.ReadAsStringAsync();
                throw new FCMException(result.StatusCode, errorMessage);
            }

            var content = await result.Content.ReadAsStringAsync();

            //if contains a multicast_id field, it's a downstream message
            if (content.Contains("multicast_id"))
            {
                return _serializer.Deserialize<DownstreamMessageResponse>(content);
            }

            //otherwhise it's a topic message
            return _serializer.Deserialize<TopicMessageResponse>(content);

        }


        /// <summary>
        /// Automatically sets all measages as dry_run
        /// </summary>
        public bool TestMode { get; set; }

        private static readonly HttpClient _httpClient = new HttpClient();
        /// <summary>
        /// Gets or sets the HttpClient used by the FCMClient.
        /// Aid for test purposes.
        /// </summary>
        internal HttpClient HttpClient
        {
            get
            {
                return _httpClient;
            }
        }

    }
}
