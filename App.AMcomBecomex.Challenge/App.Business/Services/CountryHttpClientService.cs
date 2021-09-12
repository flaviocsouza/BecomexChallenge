using App.Business.Interfaces;
using App.Business.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace App.Business.Services
{
    public class CountryHttpClientService: ICountryHttpClientService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly string _endpoint = "https://restcountries.eu/rest/v2/";

        public CountryHttpClientService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IEnumerable<Country>> GetCountriesByCurrency(string currency)
        {
            string completeURL = string.Concat(_endpoint, "currency/", currency);
            var request = new HttpRequestMessage(HttpMethod.Get, completeURL);
            request.Headers.Add("User-Agent", "HttpClientFactory-Sample");

            var client = _httpClientFactory.CreateClient();
            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                using var responseStream = await response.Content.ReadAsStreamAsync();
                return await JsonSerializer.DeserializeAsync<List<Country>>(responseStream);
            }
            return null;
        }

        public async Task<IEnumerable<Country>> GetCountriesByName(string name)
        {
            string completeURL = string.Concat(_endpoint, "name/", name);
            var request = new HttpRequestMessage(HttpMethod.Get, completeURL);
            request.Headers.Add("User-Agent", "HttpClientFactory-Sample");

            var client = _httpClientFactory.CreateClient();
            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                using var responseStream = await response.Content.ReadAsStreamAsync();
                return await JsonSerializer.DeserializeAsync<List<Country>>(responseStream);
            }
            return null; 

        }

        public async Task<Country> GetCountryByCode(string code)
        {
            string completeURL = string.Concat(_endpoint, "alpha/", code);
            var request = new HttpRequestMessage(HttpMethod.Get, completeURL);
            request.Headers.Add("User-Agent", "HttpClientFactory-Sample");

            var client = _httpClientFactory.CreateClient();
            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                using var responseStream = await response.Content.ReadAsStreamAsync();
                return await JsonSerializer.DeserializeAsync<Country>(responseStream);
            }
            return null;
        }

    }
}
