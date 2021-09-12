using App.Business.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace App.Business.Interfaces
{
    public interface ICountryCacheService
    {
        Country GetCountry(string code);
        void SetCountry(Country country);
    }
}
