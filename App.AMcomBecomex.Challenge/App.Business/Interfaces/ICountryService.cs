using App.Business.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace App.Business.Interfaces
{
    public interface ICountryService
    {
        Task<IEnumerable<Country>> GetCountriesByName(string name);
        Task<IEnumerable<Country>> GetCountriesByCurrency(string currency);
        Task<Country> GetCountryByCode(string code);
    }
}
