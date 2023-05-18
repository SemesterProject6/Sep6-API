using System.Text.Json.Serialization;

namespace Sep6_API.Models
{
    public class Actor
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("gender")]
        public int? Gender { get; set; }

        [JsonPropertyName("biography")]
        public string? Biography { get; set; }

        [JsonPropertyName("birthday")]
        public string? Birthday { get; set; }

        [JsonPropertyName("popularity")]
        public float Popularity { get; set; }

        [JsonPropertyName("profile_path")]
        public string? ProfilePath { get; set; }

        [JsonPropertyName("character")]
        public string? Character { get; set; }

        [JsonPropertyName("adult")]
        public bool Adult { get; set; }

        [JsonPropertyName("place_of_birth")]
        public string? PlaceOfBirth { get; set; }

        [JsonPropertyName("deathday")]
        public string? Deathday { get; set; }
    }
}
