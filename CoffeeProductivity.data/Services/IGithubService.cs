﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CoffeeProductivity.data.Models;

namespace CoffeeProductivity.data.Services
{
    public interface IGithubService
    {
        Task<List<GithubEvent>> GetEvents(int? page);
    }
}
