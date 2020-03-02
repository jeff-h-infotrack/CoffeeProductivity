using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeProductivity.domain.Models.ViewModels
{
    public class MemberDetailsVm
    {
        public int Id { get; set; }

        public string Username { get; set; }
        public string FullName { get; set; }

        public string Email { get; set; }
        public string DefaultGithubEmail { get; set; }

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
