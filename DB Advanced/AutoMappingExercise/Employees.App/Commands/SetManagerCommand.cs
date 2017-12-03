using System;
using System.Collections.Generic;
using System.Text;
using Employees.Services;

namespace Employees.App.Commands
{
    class SetManagerCommand : ICommand
    {
        private readonly EmployeeService employeeService;

        public SetManagerCommand(EmployeeService employeeService)
        {
            this.employeeService = employeeService;
        }

        public string Execute(params string[] args)
        {
            var employeeId = int.Parse(args[0]);
            var managerID = int.Parse(args[1]);

            var result = employeeService.SetManagerByIds(employeeId, managerID);

            return result;
        }
    }
}
