using FirebaseNet.Messaging;
using FirebaseNet.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace FirebaseNet.Tests.Serialization
{
    public class AndroidMessageSerializationTest
    {
        [Fact]
        public void ASimpleMessageShouldBeSerializedToJSON()
        {

            Message message = new Message()
            {
                To = "bk3RNwTe3H0:CI2k_HHwgIpoDKCIZvvDMExUdFQ3P1...",
                Notification = new AndroidNotification
                {
                    Body = "great match!",
                    Title = "Portugal vs. Denmark",
                    Icon = "myicon"
                 }
            };

            var serializer = new JsonNetSerializer();
            var result = serializer.Serialize(message);

            var expected = SerializedMessages.ResourceManager.GetString("SimpleMessageJSON");
            
            Assert.Equal(expected, result,false,true,true);
        }

        [Fact]
        public void PriorityValuesShouldBeSerializedAsStrings()
        {
            var message = new Message()
            {
                Priority = MessagePriority.normal
            };

            var expected = "{\r\n  \"priority\": \"normal\"\r\n}";

            var serializer = new JsonNetSerializer();
            var result = serializer.Serialize(message);

            Assert.Equal(expected, result, false, true, true);
        }

    }
}
