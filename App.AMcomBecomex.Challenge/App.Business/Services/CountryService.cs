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

        //public async Task<IEnumerable<Country>> GetLandRoute(string originCountry, string destinationCountryCode)
        public async Task<int> GetLandRoute(string originCode, string destinationCode)
        {
            originCode = originCode.ToUpper();
            destinationCode = destinationCode.ToUpper();

            Queue<string> countriesQueue = new Queue<string>();
            Stack<string> countriesStack = new Stack<string>();
            List<string> visitedCountries = new List<string>();
            LinkedList<string> countries = new LinkedList<string>();

            countriesQueue.Enqueue(originCode);
            visitedCountries.Add(originCode);
            int counterTest = 0;
            var current = countries.AddFirst(originCode);

            while (countriesQueue.Count > 0)
            {   
                string currentCode = countriesQueue.Dequeue();
                current = countries.Find(currentCode);
                countriesStack.Push(currentCode);
                counterTest++;               

                IEnumerable<string> currentBorders = (await GetCountryByCode(currentCode)).borders;
                IEnumerable<string> validBorders = currentBorders.Where(country => !visitedCountries.Contains(country)).ToList();
                
                foreach(string borderCode in validBorders)
                {
                    countries.AddAfter(current, borderCode);
                    if (borderCode == destinationCode)
                    {
                        countriesStack.Push(borderCode);
                        return counterTest;// retorno correto
                    }
                    countriesQueue.Enqueue(borderCode);
                    visitedCountries.Add(borderCode);
                }
                if (!validBorders.Any()) {
                    countries.Remove(currentCode);
                    countriesStack.Pop();
                } 
            }

            return -1;
        }
    }
}
