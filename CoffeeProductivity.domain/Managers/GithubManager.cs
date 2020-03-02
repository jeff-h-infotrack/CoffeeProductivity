using System;
using System.Collections.Generic;
using System.Text;
using CoffeeProductivity.data.Services;

namespace CoffeeProductivity.domain.Managers
{
    public class GithubManager : IGithubManager
    {
        private readonly IGithubService _service;

        public GithubManager(IGithubService service)
        {
            _service = service;
        }
    }
}
