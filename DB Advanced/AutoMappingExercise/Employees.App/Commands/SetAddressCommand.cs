﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Employees.Services;

namespace Employees.App.Commands
{
    class SetAddressCommand : ICommand 
    {
        private readonly EmployeeService employeeService;

        public SetAddressCommand(EmployeeService employeeService)
        {
            this.employeeService = employeeService;
        }

        public string Execute(params string[] args)
        {
            int employeeId = int.Parse(args[0]);
            string address = string.Join(" ", args.Skip(1));

            var employeeName = employeeService.SetAddress(employeeId, address);

            return $"{employeeName}'s address was set to {address}";
        }
    }
}
