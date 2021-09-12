using App.Business.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace App.Business.Interfaces
{
    public interface ICountryHttpClientService
    {
        Task<IEnumerable<Country>> GetCountriesByName(string name);
        Task<Country> GetCountryByCode(string code);
        Task<IEnumerable<Country>> GetCountriesByCurrency(string currency);
    }
}
