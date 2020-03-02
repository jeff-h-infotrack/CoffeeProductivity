using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
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

                var mem = new MemberDetailsVm
                {
                    Id = member.Id,
                    Name = member.Login,
                    Url = member.Url
                };

                memberDetails.Add(mem);
            }

            return memberDetails;
        }
    }
}
