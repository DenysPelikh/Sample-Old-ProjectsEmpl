using System;
using System.Xml.Serialization;

namespace PrEmp.Domain.Employees
{
    [Serializable]
    [XmlInclude(typeof(EmployeeHourlyPayment))]
    [XmlInclude(typeof(EmployeeFixedPayment))]
    public abstract class EmployeeBase
    {
        public int Id { get; set; }
        public string Name { get; set; }

        protected EmployeeBase() { }

        protected EmployeeBase(int employeeId, string employeeName)
        {
            Id = employeeId;
            Name = employeeName;
        }

        abstract public double GetAverageMonthlySalary();
    }
}
