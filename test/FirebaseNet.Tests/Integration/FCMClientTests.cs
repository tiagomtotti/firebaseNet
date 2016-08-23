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
            FCMClient client = new FCMClient("AIzaSyDZsZrrngNYCm2IPCsebgN6hVfTdVKxLGM");

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
            FCMClient client = new FCMClient("AIzaSyD4FQdtb9R603evuoJPkinK5xzxQ6rnhXs");

            var message = new Message()
            {
                To = "/topics/blog-posts",
                Notification = new AndroidNotification()
                {
                    Title = "Tem novo post no APP",
                    Body = "Acessa lá e vê =)",
                    Color = "#000000"
                }

            };

            var result = await client.SendMessageAsync(message);
            
            Assert.NotNull(result);
            Assert.IsType<DownstreamMessageResponse>(result);
        }

    }
}
