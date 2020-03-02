using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CoffeeProductivity.domain.Models.ViewModels;

namespace CoffeeProductivity.domain.Managers
{
    public interface IGithubManager
    {
        Task<List<MemberDetailsVm>> GetOrganisationMembersProductivity();
    }
}
