using Newtonsoft.Json;

namespace FirebaseNet.Messaging
{
    public class IOSNotification:INotification
    {
        /// <summary>
        /// Indicates notification title. This field is not visible on iOS phones and tablets.
        /// </summary>
        [JsonProperty(PropertyName ="title")]
        public string Title { get; set; }

        /// <summary>
        /// Indicates notification body text.
        /// </summary>
        [JsonProperty(PropertyName = "body")]
        public string Body { get; set; }

        /// <summary>
        /// Indicates a sound to play when the device receives a notification. Sound files can be in the main bundle of the client app or in the Library/Sounds folder of the app's data container.
        /// See the iOS Developer Library for more information.
        /// </summary>
        [JsonProperty(PropertyName = "sound")]
        public string Sound { get; set; }

        /// <summary>
        /// Indicates the badge on the client app home icon.
        /// </summary>
        [JsonProperty(PropertyName = "badge")]
        public string Badge { get; set; }

        /// <summary>
        /// Indicates the action associated with a user click on the notification. Corresponds to category in the APNs payload.
        /// </summary>
        [JsonProperty(PropertyName = "click_action")]
        public string ClickAction { get; set; }


        /// <summary>
        /// Indicates the key to the body string for localization. Corresponds to "loc-key" in the APNs payload.
        /// </summary>
        [JsonProperty(PropertyName = "body_loc_key")]
        public string BodyLocKey { get; set; }

        /// <summary>
        /// Indicates the string value to replace format specifiers in the body string for localization. Corresponds to "loc-args" in the APNs payload.
        /// </summary>
        [JsonProperty(PropertyName = "body_loc_args")]
        public string BodyLocArgs { get; set; }


        /// <summary>
        /// Indicates the key to the title string for localization. Corresponds to "title-loc-key" in the APNs payload.
        /// </summary>
        [JsonProperty(PropertyName = "title_loc_key")]
        public string TitleLocKey { get; set; }


        /// <summary>
        /// Indicates the string value to replace format specifiers in the title string for localization.Corresponds to "title-loc-args" in the APNs payload.
        /// </summary>
        [JsonProperty(PropertyName = "title_loc_args")]
        public string TitleLocArgs { get; set; }
    }
}
