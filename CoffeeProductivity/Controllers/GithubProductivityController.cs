using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoffeeProductivity.domain.Managers;
using CoffeeProductivity.domain.Models.ViewModels;
using CoffeeProductivity.RequestModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CoffeeProductivity.Controllers
{
    [Produces("application/json")]
    [Route("api/productivity")]
    [ApiController]
    public class GithubProductivityController : ControllerBase
    {
        private readonly IGithubManager _manager;

        public GithubProductivityController(IGithubManager manager)
        {
            _manager = manager;
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<MemberDetailsVm>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Get()
        {
            var details = await _manager.GetOrganisationMembersProductivity();
            if (details == null) return NotFound(new ErrorResponse(404, $"Organisation member details could not be found."));
            return Ok(details);
        }
    }
}
