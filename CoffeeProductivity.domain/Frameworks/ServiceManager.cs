using System;
using System.Collections.Generic;
using System.Text;
using CoffeeProductivity.data.Services;
using Microsoft.Extensions.DependencyInjection;

namespace CoffeeProductivity.domain.Frameworks
{
    public class ServiceManager
    {
        public static void InjectServices(IServiceCollection services)
        {
            services.AddHttpClient<IGithubService, GithubService>();
        }
    }
}
