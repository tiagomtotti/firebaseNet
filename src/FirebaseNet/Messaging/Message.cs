using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirebaseNet.Messaging
{
    public class Message
    {
        #region Targets

        /// <summary>
        /// This parameter specifies the recipient of a message.
        ///The value must be a registration token, notification key, or topic.Do not set this field when sending to multiple topics. See condition.
        /// </summary>
        [JsonProperty(PropertyName = "to")]
        public string To { get; set; }


        /// <summary>
        /// This parameter specifies a list of devices (registration tokens, or IDs) receiving a multicast message. 
        /// It must contain at least 1 and at most 1000 registration tokens.
        /// 
        /// Use this parameter only for multicast messaging, not for single recipients. 
        /// Multicast messages (sending to more than 1 registration tokens) are allowed using HTTP JSON format only.  
        /// </summary>
        [JsonProperty(PropertyName = "registration_ids")]
        public ICollection<string> RegistrationIds { get; set; }


        /// <summary>
        /// This parameter specifies a logical expression of conditions that determine the message target.
        /// 
        /// Supported condition: Topic, formatted as "'yourTopic' in topics". This value is case-insensitive.
        /// 
        /// Supported operators: &&, ||. Maximum two operators per topic message supported.
        /// </summary>
        [JsonProperty(PropertyName = "condition")]
        public string Condition { get; set; }
        #endregion

        #region Options

        /// <summary>
        /// This parameter identifies a group of messages (e.g., with collapse_key: "Updates Available") that can be collapsed, 
        /// so that only the last message gets sent when delivery can be resumed. This is intended to avoid sending too many 
        /// of the same messages when the device comes back online or becomes active (see delay_while_idle).
        /// 
        /// Note that there is no guarantee of the order in which messages get sent.
        /// 
        /// Note: A maximum of 4 different collapse keys is allowed at any given time.
        /// This means a FCM connection server can simultaneously store 4 different send-to-sync messages per client app.
        /// If you exceed this number, there is no guarantee which 4 collapse keys the FCM connection server will keep.
        /// </summary>
        [JsonProperty(PropertyName = "collapse_key")]
        public string CollapseKey { get; set; }


        /// <summary>
        /// Sets the priority of the message. Valid values are "normal" and "high." On iOS, these correspond to APNs priorities 5 and 10.
        /// 
        /// By default, messages are sent with normal priority.Normal priority optimizes the client app's battery consumption 
        /// and should be used unless immediate delivery is required. For messages with normal priority, the app may receive 
        /// the message with unspecified delay.
        ///
        /// When a message is sent with high priority, it is sent immediately, and the app can wake a sleeping device and 
        /// open a network connection to your server.
        /// </summary>
        [JsonProperty(PropertyName = "priority")]
        [JsonConverter(typeof(StringEnumConverter))]
        public MessagePriority? Priority { get; set; }

        /// <summary>
        /// On iOS, use this field to represent content-available in the APNS payload.
        /// When a notification or message is sent and this is set to true, an inactive client app is awoken.
        /// On Android, data messages wake the app by default. On Chrome, currently not supported.
        /// </summary>
        [JsonProperty(PropertyName = "content_available")]
        public bool? ContentAvailable { get; set; }

        /// <summary>
        /// When this parameter is set to true, it indicates that the message should not be sent until the device becomes active.
        /// The default value is false.
        /// </summary>
        [JsonProperty(PropertyName = "delay_while_idle")]
        public bool? DelayWhileIdle { get; set; }


        /// <summary>
        /// This parameter specifies how long (in seconds) the message should be kept in FCM storage if the device is offline. The maximum time to live supported is 4 weeks, and the default value is 4 weeks. 
        /// For more information, see Setting the lifespan of a message.
        /// </summary>
        [JsonProperty(PropertyName = "time_to_live")]
        public long? TimeToLive { get; set; }


        /// <summary>
        /// This parameter specifies the package name of the application where the registration tokens must match in order to receive the message.
        /// </summary>
        [JsonProperty(PropertyName = "restricted_package_name")]
        public string RestrictedPackageName { get; set; }

        /// <summary>
        /// This parameter, when set to true, allows developers to test a request without actually sending a message.
        /// </summary>
        [JsonProperty(PropertyName = "dry_run")]
        public bool? DryRun { get; set; }
        #endregion

        #region Payload
        /// <summary>
        /// This parameter specifies the custom key-value pairs of the message's payload.
        /// For example, with data:{"score":"3x1"}:
        /// On iOS, if the message is sent via APNS, it represents the custom data fields. If it is sent via FCM connection server, it would be represented as key value dictionary in AppDelegate application:didReceiveRemoteNotification:.
        /// On Android, this would result in an intent extra named score with the string value 3x1.
        /// The key should not be a reserved word ("from" or any word starting with "google" or "gcm"). Do not use any of the words defined in this table (such as collapse_key).
        /// Values in string types are recommended. You have to convert values in objects or other non-string data types (e.g., integers or booleans) to string.
        /// </summary>
        [JsonProperty(PropertyName = "data")]
        public IDictionary<string, string> Data { get; set; }

        [JsonProperty(PropertyName = "notification")]
        public INotification Notification { get; set; }
        #endregion


    }
}
