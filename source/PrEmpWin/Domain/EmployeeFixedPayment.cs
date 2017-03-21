namespace PrEmpWin.Domain
{
    public class EmployeeFixedPayment : EmployeeBase
    {
        public double MonthlyPayment { get; set; }

        public EmployeeFixedPayment() { }

        public EmployeeFixedPayment(int employeeId, string employeeName, double monthlyPayment)
            : base(employeeId, employeeName)
        {
            MonthlyPayment = monthlyPayment;
        }

        public override double GetAverageMonthlySalary()
        {
            return MonthlyPayment;
        }
    }
}
