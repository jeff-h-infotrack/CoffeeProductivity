using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CoffeeProductivity.data.Models;
using CoffeeProductivity.data.Services;
using CoffeeProductivity.domain.Models.ViewModels;
using Microsoft.Extensions.Configuration;

namespace CoffeeProductivity.domain.Managers
{
    public class GithubManager : IGithubManager
    {
        private readonly IGithubService _service;
        private readonly string _organisation;

        public GithubManager(IGithubService service, IConfiguration config)
        {
            _service = service;
            var settings = config.GetSection("GithubService");
            _organisation = settings["Organisation"];
        }

        public async Task<List<MemberDetailsVm>> GetOrganisationMembersProductivity()
        {
            // First get members
            // Currently: only get first page due to rate limit and only need for demo purposes
            var members = await _service.GetOrganisationMembers(_organisation, 1);

            var memberDetails = new List<MemberDetailsVm>();
            // For each member, get their events
            foreach (var member in members)
            {
                var mem = await GetMemberEventDetails(member);
                memberDetails.Add(mem);
            }

            return memberDetails;
        }

        private async Task<MemberDetailsVm> GetMemberEventDetails(Member member)
        {
            var mem = new MemberDetailsVm
            {
                Id = member.Id,
                Username = member.Login,
                Url = member.Url,
                TotalCommitsToday = 0
            };

            var page = 1;
            var isObtained = false;

            // Need to call several requests to get all events since fixed page size of 30 
            while (!isObtained)
            {
                var pageEvents = await _service.GetEvents(member.Login, page);
                if (pageEvents.Count > 0)
                {
                    // Only add if within 1 week and is a PushEvent
                    for (int i = 0; i < pageEvents.Count; i++)
                    {
                        var ev = pageEvents[i];
                        // Temporarily obtain just a few days ago
                        var CutOffDay = DateTime.Today.AddDays(-3);
                        var createdAt = DateTime.Parse(pageEvents[i].created_at);

                        //if (DateTime.Compare(createdAt, CutOffDay) > 0)
                        //{
                        //    isObtained = true;
                        //    break;
                        //} 
                        
                        if (ev.Type == "PushEvent")
                        {
                            var repoName = ev.Repo.Name;
                            var cutOffDateString = CutOffDay.ToString("s");
                            cutOffDateString += "Z";

                            await GetMemberCommitsForRepo(ev.Repo.Name, mem, cutOffDateString);
                            //events.Add(ev);
                            AccumulateCommitData(mem, ev);
                        }
                    }

                    page++;
                }
                else
                {
                    isObtained = true;
                }
            }

            return mem;
        }

        private async Task GetMemberCommitsForRepo(string repoName, MemberDetailsVm mem, string since)
        {
            var repoCommits = await _service.GetRepoCommits(repoName, mem.Username, since);
            if (repoCommits.Count > 0)
            {
                // Just use first commit for now to get info
                var firstCommit = repoCommits[0];
                mem.FullName = firstCommit.Commit?.Author?.Name;
                mem.Email = firstCommit.Commit?.Author?.Email;

                // Count commits
                int todayCount = 0;
                int yesterdayCount = 0;
                int dayBeforeCount = 0;
                DateTime createdDate;
                var today = DateTime.Today;
                var yesterday = today.AddDays(-1);
                var dayBefore = today.AddDays(-2);

                foreach (var commit in repoCommits)
                {
                    if (DateTime.TryParse(commit.Commit.Author.Date, out createdDate))
                    {
                        // Temporarily only use day (disregarding month etc for demo purposes)
                        if (createdDate.Day == today.Day) todayCount++;
                        else if (createdDate.Day == yesterday.Day) yesterdayCount++;
                        else if (createdDate.Day == dayBefore.Day) dayBeforeCount++;
                    }
                }

                mem.TotalCommitsToday += todayCount;
                mem.CommitsDailyAvg = (yesterdayCount + dayBeforeCount) / 2;
            }
            else
            {
                mem.CommitsDailyAvg = 0;
            }
        }

        private void AccumulateCommitData(MemberDetailsVm mem, GithubEvent ev)
        {
            foreach (var commit in ev.Payload.Commits)
            {
                // TODO: Login doesnt match email
                if (commit.Author.Email == ev.Actor.Login || commit.Author.Email == ev.Actor.DisplayLogin)
                {
                    mem.TotalCommitsToday++;
                    // TODO: Do another Github request to count lines by using commit.Url's url
                    // Then in resulting response, lok into stats property
                }
            }
        }
    }
}
