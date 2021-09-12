using App.Api.ViewModel;
using App.Business.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Api.Config
{
    public class AutoMapperConfig: Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<Country, CountryViewModel>().ReverseMap();
            CreateMap<Country, CountryListViewModel>().ReverseMap();
            CreateMap<Currency, CurrencyViewModel>().ReverseMap();
            CreateMap<RegionalBloc, RegionalBlocViewModel>().ReverseMap();
            CreateMap<Language, LanguageViewModel>().ReverseMap();
        }
    }
}
