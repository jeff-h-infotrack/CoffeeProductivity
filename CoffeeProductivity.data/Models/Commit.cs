using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeProductivity.data.Models
{
    public class Commit
    {
        public string Sha { get; set; }
        public Author Author { get; set; }
        public string Message { get; set; }
        public bool Distinct { get; set; }
        public string Url { get; set; }
    }
}
