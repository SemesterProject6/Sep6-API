using System.Text.Json.Serialization;

namespace Sep6_API.Models
{
    public class Credits
    {
        [JsonPropertyName("id")]
        public int MovieId { get; set; }

        [JsonPropertyName("cast")]
        public List<Actor> Actors { get; set; }
    }
}
