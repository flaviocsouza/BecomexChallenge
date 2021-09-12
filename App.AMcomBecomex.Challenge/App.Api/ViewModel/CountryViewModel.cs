using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Api.ViewModel
{
    public class CountryViewModel
    {        public string name { get; set; }
        public string alpha3Code { get; set; }
        public string flag { get; set; }
        public int population { get; set; }
        public string capital { get; set; }
        public IEnumerable<string> timezones { get; set; }
        public IEnumerable<LanguageViewModel> languages { get; set; }
        public IEnumerable<CurrencyViewModel> currencies { get; set; }
        public IEnumerable<RegionalBlocViewModel> regionalBlocs { get; set; }
        public IEnumerable<string> borders { get; set; }
    }
}
