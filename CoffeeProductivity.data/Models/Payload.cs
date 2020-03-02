using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace CoffeeProductivity.data.Models
{
    public class Payload
    {
        [JsonPropertyName("push_id")]
        public long PushId { get; set; }
        public int Size { get; set; }

        [JsonPropertyName("distinct_size")]
        public int DistinctSize { get; set; }

        [JsonPropertyName("_ref")]
        public string Ref { get; set; }
        public string Head { get; set; }
        public string Before { get; set; }
        public List<Commit> Commits { get; set; }

        [JsonPropertyName("ref_type")]
        public string RefType { get; set; }

        [JsonPropertyName("master_branch")]
        public string MasterBranch { get; set; }
        public object Description { get; set; }
        public string PusherType { get; set; }
    }
}
