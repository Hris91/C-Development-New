using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Employees.Data;
using Employees.DtoModels;
using Employees.Models;

namespace Employees.Services
{
    public class EmployeeService
    {
        private readonly EmployeesContext context;

        public EmployeeService(EmployeesContext context)
        {
            this.context = context;
        }

        public EmployeeDto ById(int employeeId)
        {
            var employee = context.Employees.Find(employeeId);

            var employeeDto = Mapper.Map<EmployeeDto>(employee);

            return employeeDto;
        }

        public void AddEmployee(EmployeeDto dto)
        {
            var employee = Mapper.Map<Employee>(dto);

            context.Employees.Add(employee);

            context.SaveChanges();
        }

        public string SetBirthday(int employeeId, DateTime date)
        {
            var employee = context.Employees.Find(employeeId);

            employee.Birthday = date;

            context.SaveChanges();

            return $"{employee.FirstName} {employee.LastName}";
        }

        public string SetAddress(int employeeId, string address)
        {
            var employee = context.Employees.Find(employeeId);

            employee.Address = address;

            context.SaveChanges();

            return $"{employee.FirstName} {employee.LastName}";
        }

        public EmployeePersonalDto PersonalById(int employeeId)
        {
            var employee = context.Employees.Find(employeeId);

            var employeeDto = Mapper.Map<EmployeePersonalDto>(employee);

            return employeeDto;
        }

        public string SetManagerByIds(int employeeId, int managerId)
        {
            var employee = context.Employees.Find(employeeId);
            var manager = context.Employees.Find(managerId);

            if (employee == null || manager == null)
            {
                throw new ArgumentException("Invalid employee ids");
            }
            employee.Manager = manager;
            manager.ManagedEmployees.Add(employee);
            context.SaveChanges();

            return $"Employee with id {manager.Id} successfully promoted to manager of employee with id {employee.Id}";

        }

        public ManagerDto ManagerById(int managerId)
        {
            var manager = context.Employees.Find(managerId);

            var managerDto = Mapper.Map<ManagerDto>(manager);

            var employees = context.Employees
                .Where(e => e.ManagerId == managerId)
                .ProjectTo<EmployeeDto>()
                .ToList();

            managerDto.ManagedEmloyees.AddRange(employees);

            return managerDto;
        }

        public List<EmployeeWithManagerDto> EmployeeWithAge(int age)
        {
            var now = DateTime.Now;

            var employees = context.Employees
                .Where(e => now.Year - e.Birthday.Value.Year > age)
                .ProjectTo<EmployeeWithManagerDto>()
                .OrderByDescending(e => e.Salary)
                .ToList();
          
            return employees;
        }
    }
}
