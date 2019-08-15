using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Province
    {
        public Province()
        {
            Cities = new List<City>();
        }
        public int ProvinceId { get; set; }
        public string Name { get; set; }
        public int Population { get; set; }
        public List<City> Cities { get; set; }
    }
}
