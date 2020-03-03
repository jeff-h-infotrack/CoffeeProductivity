using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
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
            _client.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", _token);
        }

        public async Task<List<Member>> GetOrganisationMembers(string org, int page)
        {
            var path = $"/orgs/{org}/members?page={page}";
            var response = await _client.GetAsync(path);

            if (response.IsSuccessStatusCode)
            {
                var jsonString = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<IEnumerable<Member>>(jsonString);
                return result.ToList();
            }
            else if (response.StatusCode == HttpStatusCode.NotFound) return null;
            else throw new Exception(response.ReasonPhrase);
        }

        public async Task<List<GithubEvent>> GetEvents(string user, int page)
        {
            var path = $"/users/{user}/events?page={page}";
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

        public async Task<List<RepositoryCommit>> GetRepoCommits(string repoName, string memName, string since)
        {
            var path = $"/repos/{repoName}/commits";
            if (memName != null || since != null) path += "?";
            if (memName != null) path += $"author={memName}";
            if (memName != null) path += "&";
            if (since != null) path += $"since={since}";

            var response = await _client.GetAsync(path);

            if (response.IsSuccessStatusCode)
            {
                var jsonString = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<IEnumerable<RepositoryCommit>>(jsonString);
                return result.ToList();
            }
            else if (response.StatusCode == HttpStatusCode.NotFound) return null;
            else throw new Exception(response.ReasonPhrase);
        }
    }
}
