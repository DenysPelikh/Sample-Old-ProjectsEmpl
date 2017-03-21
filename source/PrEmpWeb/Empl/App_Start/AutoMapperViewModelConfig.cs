using AutoMapper;
using Empl.Models;
using Empl.ViewModels;

namespace Empl.App_Start
{
    public class AutoMapperViewModelConfig
    {
        public static void Configure()
        {
            Mapper.CreateMap<Employee, EmployeeViewModel>();

            Mapper.CreateMap<EmployeeViewModel, Employee>();   
        }                
    }
}