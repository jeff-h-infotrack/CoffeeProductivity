using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using CoffeeProductivity.data.Models;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace CoffeeProductivity.data.Services
{
    public class GithubService : IGithubService
    {
        private readonly HttpClient _client;
        private IConfigurationSection _settings;
        private readonly string _token;

        public GithubService(IConfiguration config, HttpClient client)
        {
            _client = client;
            _settings = config.GetSection("GithubService");
            _token = _settings["Token"];
            var host = _settings["Host"];

            _client.BaseAddress = new Uri(host);
            _client.DefaultRequestHeaders.Add("Accept", "application/json");
            _client.DefaultRequestHeaders.Add("User-Agent", "CoffeeProductivityAPI");
        }

        public async Task<List<GithubEvent>> GetEvents(int? page)
        {
            var pageNum = page ?? 1;
            var path = $"/api/resource/shopperHistory?token={pageNum}";
            var response = await _client.GetAsync(path);

            if (response.IsSuccessStatusCode)
            {
                var jsonString = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<IEnumerable<GithubEvent>>(jsonString);
                return result.ToList();
            }
            else if (response.StatusCode == HttpStatusCode.NotFound) return null;
            else throw new Exception(response.ReasonPhrase);
        }
    }
}
