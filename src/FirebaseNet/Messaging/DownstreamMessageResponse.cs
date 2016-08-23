using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirebaseNet.Messaging
{
    public class DownstreamMessageResponse : IFCMResponse
    {
        /// <summary>
        /// Unique ID (number) identifying the multicast message.
        /// </summary>
        [JsonProperty(PropertyName = "multicast_id")]
        public long MulticastId { get; set; }

        /// <summary>
        /// Number of messages that were processed without an error.
        /// </summary>
        [JsonProperty(PropertyName = "success")]
        public long Success { get; set; }

        /// <summary>
        /// Number of messages that could not be processed.
        /// </summary>
        [JsonProperty(PropertyName = "failure")]
        public long Failure { get; set; }

        /// <summary>
        /// Number of results that contain a canonical registration token.
        /// </summary>
        [JsonProperty(PropertyName = "canonical_ids")]
        public long CanonicalIds { get; set; }

        /// <summary>
        /// Objects representing the status of the messages processed. The objects are listed in the same order as the request (i.e., for each registration ID in the request, its result is listed in the same index in the response).
        /// </summary>
        [JsonProperty(PropertyName = "results")]
        public IList<MessageResult> Results { get; set; }
    }
}
