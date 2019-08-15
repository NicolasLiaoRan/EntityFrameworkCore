using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.NToN
{
    public class CompanyDepartment
    {
        public int CompanyId { get; set; }
        public int DepartmentId { get; set; }
        public Company Company { get; set; }
        public Department Department { get; set; }

    }
}
