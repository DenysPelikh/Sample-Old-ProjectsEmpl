using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Xml.Serialization;
using AutoMapper;
using PrEmp.Domain.Employees;
using PrEmpWin.DAL;
using PrEmpWin.DAL.Repository;
using PrEmpWin.ViewModel;

namespace PrEmpWin.Models
{
    public class EmployeeModel
    {
        private const string FilePath = @"..\..\Employees.xml";

        private readonly GenericRepository<Employee> _employeeRepository;

        public EmployeeModel()
        {
            _employeeRepository = new GenericRepository<Employee>();
        }

        public List<EmployeeBase> GetEmployeesFromBd()
        {
            return _employeeRepository.Get().Select(Mapper.Map<EmployeeBase>).ToList();
        }

        public List<EmployeeBase> GetEmployeesFromFile()
        {
            List<EmployeeBase> employees;
            XmlSerializer xmlserialazer = new XmlSerializer(typeof(List<EmployeeBase>));

            using (StreamReader r = new StreamReader(FilePath))
            {
                employees = (List<EmployeeBase>)xmlserialazer.Deserialize(r);
            }

            return employees;
        }

        public void AddEmployee(CreateEmployeeView createEmployeeView)
        {
            EmployeeBase employeeBase = Mapper.Map<EmployeeBase>(createEmployeeView);

            if (createEmployeeView.WriteDatabase)
                AddEmployeeBd(employeeBase);

            if (createEmployeeView.WriteFile)
            {
                Thread thread = new Thread(() => AddEmployeeFile(employeeBase));
                thread.Start();
            }
        }

        public void DeleteEmployee(int id, SourceType source)
        {
            switch (source)
            {
                case SourceType.Database:
                {
                    DeleteEmployeeBd(id);
                    break;
                }
                case SourceType.File:
                {
                    DeleteEmployeeFile(id);
                    break;
                }
            }
        }

        private void AddEmployeeBd(EmployeeBase employee)
        {
            _employeeRepository.Add(Mapper.Map<Employee>(employee));
        }

        private void AddEmployeeFile(EmployeeBase employee)
        {
            List<EmployeeBase> employees;

            try
            {
                employees = GetEmployeesFromFile();
            }
            catch (FileNotFoundException ex)
            {
                employees = new List<EmployeeBase>();
            }

            employee.Id = employees.Count == 0 ? 0 : employees.Max(x => x.Id) + 1;
            employees.Add(employee);

            XmlSerializer xmlserialazer = new XmlSerializer(typeof(List<EmployeeBase>));

            using (TextWriter myStreamWriter = new StreamWriter(FilePath))
            {
                xmlserialazer.Serialize(myStreamWriter, employees);
            }
        }

        private void DeleteEmployeeBd(int id)
        {
            _employeeRepository.Delete(id);
        }

        private void DeleteEmployeeFile(int id)
        {
            List<EmployeeBase> employees = GetEmployeesFromFile();

            employees.RemoveAll(x => x.Id == id);

            XmlSerializer xmlserialazer = new XmlSerializer(typeof(List<EmployeeBase>));

            using (TextWriter myStreamWriter = new StreamWriter(FilePath))
            {
                xmlserialazer.Serialize(myStreamWriter, employees);
            }
        }
    }
}

