using System;
using System.Collections.Generic;
using System.Text;

namespace EFCore.Domain
{
    public class City
    {
        public int CityId { get; set; }
        public string Name { get; set; }

        public int ProvinceId { get; set; }//导航属性
        public Province Province { get; set; }//导航属性
    }
}
