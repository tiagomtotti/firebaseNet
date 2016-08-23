using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirebaseNet.Messaging
{
    public class TopicMessageResponse : IFCMResponse
    {
        /// <summary>
        /// The topic message ID when FCM has successfully received the request and will attempt to deliver to all subscribed devices.
        /// </summary>
        [JsonProperty(PropertyName = "message_id")]
        public long? MessageId { get; set; }


        /// <summary>
        /// Error that occurred when processing the message. A list of possible values can be found at https://firebase.google.com/docs/cloud-messaging/http-server-ref?hl=en-us#table9.
        /// </summary>
        [JsonProperty(PropertyName = "error")]
        public string Error { get; set; }
    }
}
