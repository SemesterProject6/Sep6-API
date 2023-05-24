using System.Text.Json.Serialization;

namespace Sep6_API.Models
{
    public class CreditsForMovies
    {
        [JsonPropertyName("id")]
        public int ActorId { get; set; }

        [JsonPropertyName("cast")]
        public List<Movie> Movies { get; set; }
    }
}
