using System;
using System.Collections.Generic;
using System.Text;

namespace Labb2.Models
{
    public class Exchange
    {
        public string Date { get; set; }
        public Dictionary<string, double> Rates { get; set; }
        public string Base { get; set; }
    }
}


