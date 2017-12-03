
using AutoMapper;
using Employees.Models;
using Employees.DtoModels;

namespace Employees.App
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<Employee, EmployeeDto>();
            CreateMap<EmployeeDto, Employee>();
            CreateMap<Employee, EmployeePersonalDto>();
            CreateMap<Employee, ManagerDto>();
            CreateMap<ManagerDto, Employee>();
            CreateMap<Employee, EmployeeWithManagerDto>();
            CreateMap<EmployeeWithManagerDto, Employee>();
        }
    }
}
