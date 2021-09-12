using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Api.ViewModel
{
    public class CountryListViewModel
    {
        public string name { get; set; }
        public string alpha3Code { get; set; }
        public string flag { get; set; }
        public IEnumerable<CurrencyViewModel> currencies { get; set; }
        public IEnumerable<RegionalBlocViewModel> regionalBlocs { get; set; }
    }
}
