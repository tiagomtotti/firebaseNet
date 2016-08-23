using FirebaseNet.Messaging;
using FirebaseNet.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace FirebaseNet.Tests.Serialization
{
    public class DownstreamMessageResponseSerializationTest
    {
        [Fact]
        public void GivenAJSONContainingADownstreamMessage_ICanGetADOwnstreamMessageResponseObject()
        {

            var json = SerializedMessages.ResourceManager.GetString("DownstreamMessageResponseJSON");
            var serializer = new JsonNetSerializer();
            var downstreamMessage = serializer.Deserialize<DownstreamMessageResponse>(json);


            Assert.NotNull(downstreamMessage);
            Assert.Equal(216, downstreamMessage.MulticastId);
            Assert.Equal(3, downstreamMessage.Success);
            Assert.Equal(3, downstreamMessage.Failure);
            Assert.Equal(1, downstreamMessage.CanonicalIds);

            Assert.Equal(6, downstreamMessage.Results.Count);


        }
    }
}