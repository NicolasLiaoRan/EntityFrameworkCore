using System;
using System.Collections.Generic;
using System.Text;

namespace EFCore.Domain
{
    public class Province
    {
        public Province()
        {
            Cities = new List<City>();
        }
        public int ProvinceId { get; set; }
        public string Name { get; set; }
        public List<City> Cities { get; set; }
    }
}
