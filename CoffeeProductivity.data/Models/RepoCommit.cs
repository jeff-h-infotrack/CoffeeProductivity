using System.Text.Json.Serialization;

namespace CoffeeProductivity.data.Models
{
    public class RepoCommit
    {
        public CommitPerson Author { get; set; }
        public CommitPerson Committer { get; set; }
        public string Message { get; set; }
        public Tree Tree { get; set; }
        public string Url { get; set; }

        [JsonPropertyName("comment_count")]
        public int CommentCount { get; set; }
        public Verification Verification { get; set; }
    }
}
