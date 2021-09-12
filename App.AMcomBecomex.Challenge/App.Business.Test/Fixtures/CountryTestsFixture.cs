using App.Business.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace App.Business.Test.Fixtures
{

    [CollectionDefinition(nameof(CountryCollection))]
    public class CountryCollection : ICollectionFixture<CountryTestsFixture>
    { }
    public class CountryTestsFixture : IDisposable
    {
        public async Task<IEnumerable<Country>> GetACountryList(int size, string countryName)
        {
            List<Country> countries = new List<Country>();

            for (int i = 0; i < size; i++)
            {
                countries.Add( await GetCountry(String.Concat(countryName, i)));
            }

            return countries;
        }

        public async Task<Country> GetCountry(string countryName)
        {
            return new Country
            {
                name = String.Concat(countryName),
                alpha3Code = countryName.Substring(0, 3)
            };
        }

        public async Task<Country> GetNullCountry(string countryName)
        {
            return null;
        }
        public void Dispose()
        {
        }
    }
}
