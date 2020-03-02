using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeProductivity.domain.Models.ViewModels
{
    public class MemberDetailsVm
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string DisplayLogin { get; set; }
        public string Url { get; set; }
        public int TotalCommitsThisHour { get; set; }
        public int TotalLinesThisHour { get; set; }
        public int TotalCommitsToday { get; set; }
        public int TotalLinesToday { get; set; }
        public double CommitsDailyAvg { get; set; }
        public double LinesDailyAvg { get; set; }
    }
}
