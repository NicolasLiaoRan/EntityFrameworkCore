using System;
using System.Collections.Generic;
using System.Text;

namespace Domain._1To1
{
    public class Country
    {
        public int CountryId { get; set; }
        public string Name { get; set; }
        public President President { get; set; }
    }
}
