using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeProductivity.data.Models
{
    public class Payload
    {
        public long push_id { get; set; }
        public int size { get; set; }
        public int distinct_size { get; set; }
        public string _ref { get; set; }
        public string head { get; set; }
        public string before { get; set; }
        public Commit[] commits { get; set; }
        public string ref_type { get; set; }
        public string master_branch { get; set; }
        public object Description { get; set; }
        public string PusherType { get; set; }
    }
}
