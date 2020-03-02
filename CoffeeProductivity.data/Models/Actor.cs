using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace CoffeeProductivity.data.Models
{
    public class Actor
    {
        public int Id { get; set; }
        public string Login { get; set; }

        [JsonPropertyName("display_login")]
        public string DisplayLogin { get; set; }

        [JsonPropertyName("gravatar_id")]
        public string GravatarId { get; set; }
        public string Url { get; set; }

        [JsonPropertyName("avatar_url")]
        public string AvatarUrl { get; set; }
    }
}
