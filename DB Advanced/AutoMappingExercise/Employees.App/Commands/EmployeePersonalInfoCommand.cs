using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Employees.Services;

namespace Employees.App.Commands
{
    class EmployeePersonalInfoCommand : ICommand
    {

        private readonly EmployeeService employeeService;

        public EmployeePersonalInfoCommand(EmployeeService employeeService)
        {
            this.employeeService = employeeService;
        }

        public string Execute(params string[] args)
        {
            int employeeId = int.Parse(args[0]);

            var employee = employeeService.PersonalById(employeeId);

            string birthday ="[no birthday specified]";

            if (employee.Birthday != null)
            {
                birthday = employee.Birthday.Value.ToString("dd-MM-yyyy", CultureInfo.InvariantCulture);
            }

            string adress = employee.Address ?? "[no address specified]";

            var result = $"ID: {employeeId} - {employee.FirstName} {employee.LastName} - ${employee.Salary:f2}" + Environment.NewLine +
                         $"Birthday: {birthday}" + Environment.NewLine +
                         $"Address: {adress}";

            return result;

        }
    }
}
