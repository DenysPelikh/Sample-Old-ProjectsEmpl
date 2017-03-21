using AutoMapper;
using PrEmp.Domain.Employees;
using PrEmpWin.DAL;
using PrEmpWin.ViewModel;

namespace PrEmpWin.Models
{
    public class AutoMapperModelConfig
    {
        public static void Configure()
        {
            // For database
            Mapper.CreateMap<Employee, EmployeeHourlyPayment>()
                .ForMember(dest => dest.HourlyRate, opts => opts.MapFrom(src => src.Payment));

            Mapper.CreateMap<Employee, EmployeeFixedPayment>()
               .ForMember(dest => dest.MonthlyPayment, opts => opts.MapFrom(src => src.Payment));

            Mapper.CreateMap<Employee, EmployeeBase>().ConstructUsing(src =>
            {
                switch (src.Type)
                {
                    case (int)PaymentType.HourlyPayment:
                        {
                            return Mapper.Map<EmployeeHourlyPayment>(src);
                        }
                    case (int)PaymentType.FixedPayment:
                        {
                            return Mapper.Map<EmployeeFixedPayment>(src);
                        }
                    default:
                        {
                            return null;
                        }
                }
            });

            Mapper.CreateMap<EmployeeHourlyPayment, Employee>()
               .ForMember(dest => dest.Payment, opts => opts.MapFrom(src => src.HourlyRate));

            Mapper.CreateMap<EmployeeFixedPayment, Employee>()
               .ForMember(dest => dest.Payment, opts => opts.MapFrom(src => src.MonthlyPayment));

            // For EmployeeView
            Mapper.CreateMap<EmployeeBase, EmployeeView>()
                .ForMember(dest => dest.EmployeeName, opts => opts.MapFrom(src => src.Name))
                .ForMember(dest => dest.MonthlyAverageSalary, opts => opts.MapFrom(src => src.GetAverageMonthlySalary()));

            // For CreateEmployeeView
            Mapper.CreateMap<CreateEmployeeView, EmployeeHourlyPayment>()
               .ForMember(dest => dest.HourlyRate, opts => opts.MapFrom(src => src.Payment));

            Mapper.CreateMap<CreateEmployeeView, EmployeeFixedPayment>()
               .ForMember(dest => dest.MonthlyPayment, opts => opts.MapFrom(src => src.Payment));

            Mapper.CreateMap<CreateEmployeeView, EmployeeBase>().ConstructUsing(src =>
            {
                switch (src.PaymentType)
                {
                    case PaymentType.HourlyPayment:
                        {
                            return Mapper.Map<EmployeeHourlyPayment>(src);
                        }
                    case PaymentType.FixedPayment:
                        {
                            return Mapper.Map<EmployeeFixedPayment>(src);
                        }
                    default:
                        {
                            return null;
                        }
                }
            });
        }
    }
}
