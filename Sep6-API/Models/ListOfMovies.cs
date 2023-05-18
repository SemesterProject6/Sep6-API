using System.Text.Json.Serialization;

namespace Sep6_API.Models
{
    public class ListOfMovies
    {
        [JsonPropertyName("page")]
        public int CurrentPage { get; set; }

        [JsonPropertyName("results")]
        public List<Movie>? Movies { get; set; }

        [JsonPropertyName("total_pages")]
        public int TotalPage { get; set; }
    }
}
