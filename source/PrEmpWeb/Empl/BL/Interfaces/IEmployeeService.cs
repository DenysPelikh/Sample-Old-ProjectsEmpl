using System.Collections.Generic;
using Empl.ViewModels;

namespace Empl.BL.Interfaces
{
    public interface IEmployeeService
    {
        EmployeeViewModel GetEmployee(int id);

        List<EmployeeViewModel> GetEmployees();

        IndexViewModel GetFilteredEmployees(string filter, int pageSize, int pageNumber);

        void CreateEmployee(EmployeeViewModel employeeModel);

        void DeleteEmployee(int id);

        void GenerateReport();

        void EditEmployee(EmployeeViewModel employeeModel);
    }
}