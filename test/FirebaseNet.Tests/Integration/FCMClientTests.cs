using FirebaseNet.Exceptions;
using FirebaseNet.Messaging;
using FirebaseNet.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace FirebaseNet.Tests.Integration
{
    public class FCMClientTests
    {

        //place your server api key here for testing purposes
        private const string ServerApiKey = "AIzaSyCogE0Ghw2xcIh6n6b2lIA9ZL6K28lLLCU";

        [Fact]
        public async Task Given_an_invalid_server_key_THEN_I_must_get_an_FCM_exception()
        {
            FCMClient client = new FCMClient("foo");

            var message = new Message()
            {
                DryRun = true,
                To = "1213",
                Notification = new AndroidNotification()
                {
                    Title = "Title",
                    Body = "body",

                }
            };

            var result = await Assert.ThrowsAsync<FCMUnauthorizedException>(() => client.SendMessageAsync(message));
            Assert.Equal(HttpStatusCode.Unauthorized, result.StatusCode);
        }

        [Fact]
        public async Task Given_a_valid_server_key_AND_a_valid_topic_message_THEN_I_must_get_a_valid_response()
        {
            FCMClient client = new FCMClient(ServerApiKey);

            var message = new Message()
            {
                DryRun = true,
                To = "/topics/android",
                Notification = new AndroidNotification()
                {
                    Title = "Title",
                    Body = "body",
                }
            };

            var result = await client.SendMessageAsync(message);

            Assert.NotNull(result);
            Assert.IsType<TopicMessageResponse>(result);
        }

        [Fact]
        public async Task Given_a_valid_server_key_AND_a_valid_downstream_message_THEN_I_must_get_a_valid_response()
        {
            FCMClient client = new FCMClient(ServerApiKey);

            var message = new Message()
            {
                To = "deviceid",
                Notification = new AndroidNotification()
                {
                    Title = "Message title",
                    Body = "Notification body",
                    Color = "#000000"
                }

            };

            var result = await client.SendMessageAsync(message);

            Assert.NotNull(result);
            Assert.IsType<DownstreamMessageResponse>(result);
        }


        [Fact]
        public async Task Given_a_valid_server_key_AND_a_valid_downstream_message_with_data_THEN_I_must_get_a_valid_response()
        {
            FCMClient client = new FCMClient(ServerApiKey);
            
            var message = new Message()
            {
                To = "bk3RNwTe3H0:CI2k_HHwgIpoDKCIZvvDMExUdFQ3P1...",
                Data = new Dictionary<string, string>
                {
                    {"score", "5x1" },
                    {"time", "15:10"}
                }
            };

            var result = await client.SendMessageAsync(message);

            Assert.NotNull(result);
            Assert.IsType<DownstreamMessageResponse>(result);
        }

        [Fact]
        public async Task Given_a_valid_server_key_AND_a_valid_downstream_message_with_data_AND_optional_fields_setTHEN_I_must_get_a_valid_response()
        {
            FCMClient client = new FCMClient(ServerApiKey);

            var message = new Message()
            {
                To = "bk3RNwTe3H0:CI2k_HHwgIpoDKCIZvvDMExUdFQ3P1...",
                CollapseKey = "score_update",
                TimeToLive = 108,
                Data = new Dictionary<string, string>
                {
                    {"score", "5x1" },
                    {"time", "15:10"}
                }
            };

            var result = await client.SendMessageAsync(message);

            Assert.NotNull(result);
            Assert.IsType<DownstreamMessageResponse>(result);
        }

        [Fact]
        public async Task Given_a_valid_server_key_AND_a_valid_topic_message_with_data_AND_optional_fields_set_AND_notification_set_THEN_I_must_get_a_valid_response()
        {
            FCMClient client = new FCMClient(ServerApiKey);

            var message = new Message()
            {
                To = "/topics/android",
                CollapseKey = "score_update",
                TimeToLive = 108,
                Notification = new AndroidNotification()
                {
                    Body = "great match!",
                    Title = "Portugal vss Denmark",
                    Icon = "myIcon"
                },
                Data = new Dictionary<string, string>
                {
                    {"score", "5x1" },
                    {"time", "15:10"}
                }
            };

            var result = await client.SendMessageAsync(message);

            Assert.NotNull(result);
            Assert.IsType<TopicMessageResponse>(result);
        }


    }
}
