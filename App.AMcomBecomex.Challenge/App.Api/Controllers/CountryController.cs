using App.Api.ViewModel;
using App.Business.Interfaces;
using App.Business.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CountryController : ControllerBase
    {

        private readonly ICountryService _countryService;
        private readonly IMapper _mapper;

        public CountryController(
            ICountryService countryService, 
            IMapper mapper
        )
        {
            _countryService = countryService;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("Name/{name}")]
        async public Task<IEnumerable<CountryListViewModel>> GetListByName(string name)
        {
            return _mapper.Map<IEnumerable<CountryListViewModel>>(await _countryService.GetCountriesByName(name));
        }

        [HttpGet]
        [Route("Code/{code}")]
        async public Task<CountryViewModel> GetByCode(string code)
        {
            if (code.Length != 3) return null;
            return _mapper.Map<CountryViewModel>(await _countryService.GetCountryByCode(code));
        }

        [HttpGet]
        [Route("Currency/{currency}")]
        async public Task<IEnumerable<CountryListViewModel>> GetByCurrency(string currency)
        {
            return _mapper.Map<IEnumerable<CountryListViewModel>>(await _countryService.GetCountriesByCurrency(currency));
        }

    }
}
