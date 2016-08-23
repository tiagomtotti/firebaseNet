
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace FirebaseNet.Serialization
{
    internal class JsonNetSerializer : ISerializer
    {

        private static Newtonsoft.Json.JsonSerializerSettings SETTINGS = new JsonSerializerSettings
        {
            Formatting = Formatting.Indented,
            NullValueHandling = NullValueHandling.Ignore,
        };

        static JsonNetSerializer()
        {
            SETTINGS.Converters.Add(new StringEnumConverter());
        }

        public T Deserialize<T>(string json)
        {
            return JsonConvert.DeserializeObject<T>(json);
        }

        public string Serialize<T>(T value)
        {
            return JsonConvert.SerializeObject(value, SETTINGS);
        }
    }
}
