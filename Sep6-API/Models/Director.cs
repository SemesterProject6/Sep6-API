using System.Text.Json.Serialization;

namespace Sep6_API.Models
{
    public class Director
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("profile_path")]
        public string? ProfilePath { get; set; }
    }
}
