using System.Text.Json.Serialization;

namespace Sep6_API.Models
{

    public class VideoList
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }


        [JsonPropertyName("results")]
        public List<Video> videos { get; set; }
    }


}
