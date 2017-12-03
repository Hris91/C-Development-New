using System;
using System.Collections.Generic;
using System.Text;
using Employees.Services;

namespace Employees.App.Commands
{
    class ManagerInfoCommand : ICommand
    {
        private readonly EmployeeService employeeService;

        public ManagerInfoCommand(EmployeeService employeeService)
        {
            this.employeeService = employeeService;
        }

        public string Execute(params string[] args)
        {
            int managerId = int.Parse(args[0]);

            var manager = employeeService.ManagerById(managerId);
            
            var builder = new StringBuilder();

            builder.AppendLine($"{manager.FirstName} {manager.LastName} | Employees: {manager.ManagedEmployeesCount}");

            foreach (var employee in manager.ManagedEmloyees)
            {
                builder.AppendLine($"{employee.FirstName} {employee.LastName} ${employee.Salary}");
            }
            return builder.ToString().Trim();
        }
    }
}
