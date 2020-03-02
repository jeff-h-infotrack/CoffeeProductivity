using System.Text.Json.Serialization;

namespace CoffeeProductivity.data.Models
{
    public class Parent
    {
        public string Sha { get; set; }
        public string Url { get; set; }

        [JsonPropertyName("html_url")]
        public string HtmlUrl { get; set; }
    }
}
