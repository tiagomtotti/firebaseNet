using Newtonsoft.Json;

namespace FirebaseNet.Messaging
{
    public class AndroidNotification : INotification
    {

        /// <summary>
        /// Indicates notification title.
        /// </summary>
        [JsonProperty(PropertyName = "title")]
        public string Title { get; set; }

        /// <summary>
        /// Indicates notification body text.
        /// </summary>
        [JsonProperty(PropertyName = "body")]
        public string Body { get; set; }

        /// <summary>
        /// Indicates notification icon. Sets value to myicon for drawable resource myicon.
        /// </summary>
        [JsonProperty(PropertyName = "icon")]
        public string Icon { get; set; }

        /// <summary>
        /// Indicates a sound to play when the device receives a notification.
        /// Supports default or the filename of a sound resource bundled in the app.
        /// Sound files must reside in /res/raw/.
        /// </summary>
        [JsonProperty(PropertyName = "sound")]
        public string Sound { get; set; }

        /// <summary>
        /// Indicates whether each notification results in a new entry in the notification drawer on Android. 
        /// If not set, each request creates a new notification.
        /// If set, and a notification with the same tag is already being shown, the new notification replaces the existing one in the notification drawer.
         /// </summary>
        [JsonProperty(PropertyName = "tag")]
        public string Tag { get; set; }

        /// <summary>
        /// Indicates color of the icon, expressed in #rrggbb format
        /// </summary>
        [JsonProperty(PropertyName = "color")]
        public string Color { get; set; }

        /// <summary>
        /// Indicates the action associated with a user click on the notification.
        /// When this is set, an activity with a matching intent filter is launched when user clicks the notification.
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
