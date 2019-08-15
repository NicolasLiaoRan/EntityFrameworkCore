using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.NToN
{
    public class Company
    {
        public int CompanyId { get; set; }
        public string Name { get; set; }
        public DateTime EstablishTime { get; set; }
        public string LegalPerson { get; set; }
        public List<Department> Departments { get; set; }
        public List<CompanyDepartment> CompanyDepartments { get; set; }
        public Company()
        {
            Departments = new List<Department>();
            CompanyDepartments = new List<CompanyDepartment>();
        }
    }
}
