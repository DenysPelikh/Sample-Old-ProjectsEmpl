using PrEmpWin.Models;

namespace PrEmpWin.ViewModel
{
    public class EmployeeView
    {
        public int Id { get; set; }
        public string EmployeeName { get; set; }
        public int MonthlyAverageSalary { get; set; }
        public SourceType From { get; set; }
    }
}
