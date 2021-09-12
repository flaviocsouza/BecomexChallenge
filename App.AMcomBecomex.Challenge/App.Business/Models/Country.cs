using System;
using System.Collections.Generic;
using System.Text;

namespace App.Business.Models
{
    public class Country : Entity
    {
        public string name { get; set; }
        public string alpha3Code { get; set; }
        public string flag { get; set; }
        public int population { get; set; }
        public string capital { get; set; }
        public IEnumerable<string> timezones { get; set; }
        public IEnumerable<Language> languages { get; set; }
        public IEnumerable<Currency> currencies { get; set; }
        public IEnumerable<RegionalBloc> regionalBlocs { get; set; }
        public IEnumerable<string> borders { get; set; }

    }
}