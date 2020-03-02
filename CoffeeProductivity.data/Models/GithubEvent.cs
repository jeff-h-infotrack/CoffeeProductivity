using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeProductivity.data.Models
{
    public class GithubEvents
    {
        public Class1[] Property1 { get; set; }
    }

    public class GithubEvent
    {
        public string id { get; set; }
        public string type { get; set; }
        public Actor actor { get; set; }
        public Repo repo { get; set; }
        public Payload payload { get; set; }
        public bool _public { get; set; }
        public DateTime created_at { get; set; }
    }

    public class Actor
    {
        public int id { get; set; }
        public string login { get; set; }
        public string display_login { get; set; }
        public string gravatar_id { get; set; }
        public string url { get; set; }
        public string avatar_url { get; set; }
    }

    public class Repo
    {
        public int id { get; set; }
        public string name { get; set; }
        public string url { get; set; }
    }

    

    

    

}
