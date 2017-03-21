using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AutoMapper;
using Empl.BL.Interfaces;
using Empl.Models;
using Empl.Models.Interfaces;
using Empl.ViewModels;

namespace Empl.BL.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IUnitOfWork _unitOfwork;

        public EmployeeService(IUnitOfWork unitOfwork)
        {
            _unitOfwork = unitOfwork;
        }

        public EmployeeViewModel GetEmployee(int id)
        {
            var employee = _unitOfwork.EmployeeRepository.GetById(id);
            return Mapper.Map<EmployeeViewModel>(employee);
        }

        public List<EmployeeViewModel> GetEmployees()
        {
            var employees = _unitOfwork.EmployeeRepository.Get();
            return employees.Select(Mapper.Map<EmployeeViewModel>).ToList();
        }

        public IndexViewModel GetFilteredEmployees(string filter, int pageSize, int pageNumber)
        {
            var conditions = new Dictionary<string, Func<Employee, bool>>
            {
                {"All", x => x.Status==true || x.Status==false},
                {"Active", x => x.Status},
                {"Not active", x => x.Status == false}
            };

            var pageSkip = pageSize * (pageNumber - 1);
            var employees = _unitOfwork.EmployeeRepository.GetMany(conditions[filter]);
            var numberFilteredEmployees = employees.Count();

            employees = employees.Skip(pageSkip).Take(pageSize);

            IndexViewModel model = new IndexViewModel
            {
                Employees = employees.Select(Mapper.Map<EmployeeViewModel>).ToList(),
                FilteredRowsTotal = (int)Math.Ceiling((decimal)numberFilteredEmployees / pageSize)
            };

            return model;
        }

        public void CreateEmployee(EmployeeViewModel employeeModel)
        {
            Employee employee = Mapper.Map<Employee>(employeeModel);

            _unitOfwork.EmployeeRepository.Add(employee);
            _unitOfwork.Save();
        }

        public void DeleteEmployee(int id)
        {
            var employee = _unitOfwork.EmployeeRepository.GetById(id);
            _unitOfwork.EmployeeRepository.Delete(employee);
            _unitOfwork.Save();
        }

        public void GenerateReport()
        {
            var fileName = string.Format("{0}{1}\\{2}.txt", AppDomain.CurrentDomain.BaseDirectory, "App_Data\\EmployeeFiles", "Report");
            var employees = _unitOfwork.EmployeeRepository.GetMany(x => x.Status);

            double sumSalary = 0;
            double sumTax = 0;
            double sumSalaryMinusTaxes = 0;

            using (var file = new FileStream(fileName, FileMode.Create))
            {
                using (var sw = new StreamWriter(file))
                {
                    sw.WriteLine("Report on employees");
                    sw.WriteLine();
                    sw.WriteLine("{0} {1,10} {2,20} {3,30}", "Name", "Salary", "Tax", "Salary minus taxes");
                    foreach (var empl in employees)
                    {
                        double currTax = 0;
                        double currSalaryMinusTaxes = 0;

                        if (empl.Salary < 10000)
                        {
                            currTax = empl.Salary * 0.1;
                        }
                        else if (empl.Salary > 25000)
                        {
                            currTax = empl.Salary * 0.25;
                        }
                        else
                        {
                            currTax = empl.Salary * 0.15;
                        }

                        currSalaryMinusTaxes = empl.Salary - currTax;

                        sw.WriteLine("{0} {1,10} {2,20} {3,30}", empl.Name, empl.Salary, currTax, currSalaryMinusTaxes);

                        sumSalary += empl.Salary;
                        sumTax += currTax;
                        sumSalaryMinusTaxes += currSalaryMinusTaxes;
                    }

                    sw.WriteLine();
                    sw.WriteLine("Total: {0,10} {1,20} {2,30}", sumSalary , sumTax , sumSalaryMinusTaxes);
                }
            }
        }

        public void EditEmployee(EmployeeViewModel employeeModel)
        {
            Employee employee = Mapper.Map<Employee>(employeeModel);
            _unitOfwork.EmployeeRepository.Update(employee);
            _unitOfwork.Save();
        }
    }
}