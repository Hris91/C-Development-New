using System;
using System.Collections.Generic;
using System.Text;

namespace Employees.DtoModels
{
    public class ManagerDto
    {
        public List<EmployeeDto> ManagedEmloyees { get; set; } = new List<EmployeeDto>();
        public int ManagerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int ManagedEmployeesCount => ManagedEmloyees.Count;
    }
}
