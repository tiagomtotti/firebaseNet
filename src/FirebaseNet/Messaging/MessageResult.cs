using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirebaseNet.Messaging
{
    public class MessageResult
    {
        /// <summary>
        /// String specifying a unique ID for each successfully processed message.
        /// </summary>
        [JsonProperty(PropertyName = "message_id")]
        public string MessageId { get; set; }

        /// <summary>
        /// Optional string specifying the canonical registration token for the client app that the message was processed and sent to. Sender should use this value as the registration token for future requests. Otherwise, the messages might be rejected.
        /// </summary>
        [JsonProperty(PropertyName = "registration_id")]
        public string RegistrationId { get; set; }

        /// <summary>
        /// String specifying the error that occurred when processing the message for the recipient. A list of possible values can be found at https://firebase.google.com/docs/cloud-messaging/http-server-ref?hl=en-us#table9
        /// </summary>
        [JsonProperty(PropertyName = "error")]
        public string Error { get; set; }

    }
}
