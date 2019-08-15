using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.NToN
{
    public class Department
    {
        public int DepartmentId { get; set; }
        public string Name { get; set; }
        //public int CompanyId { get; set; }
        public Company Company { get; set; }
        public List<CompanyDepartment> CompanyDepartments { get; set; }
        public Department()
        {
            CompanyDepartments = new List<CompanyDepartment>();
        }

    }
}
