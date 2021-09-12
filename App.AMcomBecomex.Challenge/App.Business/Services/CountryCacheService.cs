using App.Business.Interfaces;
using App.Business.Models;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace App.Business.Services
{
    public class CountryCacheService : ICountryCacheService
    {
        private readonly IMemoryCache _memoryCache;
        
        public CountryCacheService(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        public Country GetCountry(string code)
        {
            var countries = _memoryCache.Get<Country>(code);
            return countries;
        }

        public void SetCountry(Country country)
        {
            _memoryCache.Set(country.alpha3Code, country);            
        }
    }
}
