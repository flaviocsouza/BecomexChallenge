using System;
using System.Collections.Generic;
using System.Text;

namespace App.Business.Models
{
    public class Currency: Entity
    {
        public string code { get; set; }
        public string name { get; set; }
        public string symbol { get; set; }
    }
}
