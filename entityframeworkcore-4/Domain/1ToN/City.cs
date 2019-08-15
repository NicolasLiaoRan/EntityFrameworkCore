using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class City
    {
        public int CityId { get; set; }
        public string Name { get; set; }
        public string AreaCode { get; set; }
        public int ProvinceId { get; set; }//导航属性,此属性也可以不写，EFCore会根据下面的导航属性自动生成此外键属性
        public Province Province { get; set; }//导航属性
    }
}
