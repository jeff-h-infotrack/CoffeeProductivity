using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CoffeeProductivity.data.Models;

namespace CoffeeProductivity.data.Services
{
    public interface IGithubService
    {
        Task<List<GithubEvent>> GetEvents(string user, int page);
        Task<List<Member>> GetOrganisationMembers(string org, int page);
        Task<List<RepositoryCommit>> GetRepoCommits(string repoName, string memName, string since);
    }
}
