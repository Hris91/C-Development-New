using System;
using System.Collections.Generic;
using System.Text;
using Employees.Services;

namespace Employees.App.Commands
{
    class ListEmployeesOlderThanCommand : ICommand
    {

        private readonly EmployeeService employeeService;

        public ListEmployeesOlderThanCommand(EmployeeService employeeService)
        {
            this.employeeService = employeeService;
        }

        public string Execute(params string[] args)
        {
            int age = int.Parse(args[0]);

            var employees = employeeService.EmployeeWithAge(age);

            var builder = new StringBuilder();
          
            foreach (var employee in employees)
            {
                var managerName = employee.ManagerName;

                if (managerName == null)
                {
                    managerName = "[no manager]";
                }

                builder.AppendLine($"{employee.FirstName} {employee.LastName} - ${employee.Salary:f2} - Manager:{managerName}");
            }
            return builder.ToString().Trim();
        }
    }
}
