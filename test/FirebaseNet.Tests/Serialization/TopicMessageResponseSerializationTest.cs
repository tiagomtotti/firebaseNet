using FirebaseNet.Messaging;
using FirebaseNet.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace FirebaseNet.Tests.Serialization
{
    public class TopicMessageResponseSerializationTest
    {
        [Fact]
        public void GivenAJSONContainingATopicMessage_ICanGetATopicMessageResponseObject()
        {

            var json = SerializedMessages.ResourceManager.GetString("TopicMessageResponseJSON");
            var serializer = new JsonNetSerializer();
            var topicMessage = serializer.Deserialize<TopicMessageResponse>(json);


            Assert.NotNull(topicMessage);
            Assert.Equal(-1, topicMessage.MessageId);

        }
    }
}