using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace CoffeeProductivity.data.Models
{
    public class RepositoryCommit
    {
        public string Sha { get; set; }

        [JsonPropertyName("node_id")]
        public string NodeId { get; set; }
        public RepoCommit Commit { get; set; }
        public string Url { get; set; }

        [JsonPropertyName("html_url")]
        public string HtmlUrl { get; set; }

        [JsonPropertyName("comments_url")]
        public string CommentsUrl { get; set; }
        public GithubUser Author { get; set; }
        public GithubUser Committer { get; set; }
        public List<Parent> Parents { get; set; }
    }
}
