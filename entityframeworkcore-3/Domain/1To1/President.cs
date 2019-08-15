using System;
using System.Collections.Generic;
using System.Text;

namespace Domain._1To1
{
    public class President
    {
        public int PresidentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Birthday { get; set; }
        public Gender Gender { get; set; }//枚举类型


        public int CountryId { get; set; }//外键，总统必须属于一个唯一国家，但国家可以没有总统
        public Country Country { get; set; }
    }
}
