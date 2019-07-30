using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace WebCore.Model.Base
{
    public class Point
    {
        [JsonProperty("x")]
        [JsonPropertyName("x")]
        public double X { get; set; }

        [JsonProperty("y")]
        [JsonPropertyName("y")]
        public double Y { get; set; }
    }
}
