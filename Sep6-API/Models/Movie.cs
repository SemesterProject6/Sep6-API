using System.Text.Json.Serialization;
using System.Text.Json;

namespace Sep6_API.Models
{
    public class Movie
    {
        [JsonPropertyName("original_title")]
        public string original_title { get; set; }

        public string title { get; set; }
        [JsonPropertyName("id")]
        public int id { get; set; }
        [JsonPropertyName("genres")]
        public List<Genre> genre { get; set; }
        [JsonPropertyName("overview")]
        public string overview { get;set; }
        [JsonPropertyName("poster_path")]
        public string PosterRoute { get; set; }
        [JsonPropertyName("release_date")]
        public string releaseDate { get; set; }
        [JsonPropertyName("vote_average")]
        public float? Rating { get; set; }
        [JsonPropertyName("vote_count")]
        public int? NrOfVotes { get; set; }

        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }

    }
}
