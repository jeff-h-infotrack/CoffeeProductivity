using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace CoffeeProductivity.data.Models
{
    public class GithubEvent
    {
        public string Id { get; set; }
        public string Type { get; set; }
        public Actor Actor { get; set; }
        public Repo Repo { get; set; }
        public Payload Payload { get; set; }

        [JsonPropertyName("_public")]
        public bool Public { get; set; }

        [JsonPropertyName("created_at")]
        public string created_at { get; set; }
    }
}
