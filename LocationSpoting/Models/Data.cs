using System.Text.Json.Serialization;

namespace LocationSpoting.Models
{
    public class Data
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string? Name { get; set; }

        [JsonPropertyName("position")]
        public Position? Position { get; set; }
    }

}
