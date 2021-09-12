using App.Business.Interfaces;
using App.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Business.Services
{

    public class CountryService : ICountryService
    {
        private readonly ICountryHttpClientService _countryHttpClientService;
        private readonly ICountryCacheService _countryCacheService;

        public CountryService(
            ICountryHttpClientService countryHttpClientService, 
            ICountryCacheService countryCacheService
        )
        {
            _countryHttpClientService = countryHttpClientService;
            _countryCacheService = countryCacheService;
        }

        public async Task<IEnumerable<Country>> GetCountriesByName(string name)
        {
            return await _countryHttpClientService.GetCountriesByName(name);
        }

        public async Task<IEnumerable<Country>> GetCountriesByCurrency(string currency)
        {
            return await _countryHttpClientService.GetCountriesByCurrency(currency);
        }

        public async Task<Country> GetCountryByCode(string code)
        {
            var country = _countryCacheService.GetCountry(code);
            if (country != null) return country;

            country = await _countryHttpClientService.GetCountryByCode(code);
            _countryCacheService.SetCountry(country);
            return country;
        }
    }
}
