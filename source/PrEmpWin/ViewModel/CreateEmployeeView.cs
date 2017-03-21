using PrEmpWin.Models;

namespace PrEmpWin.ViewModel
{
    public class CreateEmployeeView
    {
        public string Name { get; set; }
        public int Payment { get; set; }
        public PaymentType PaymentType { get; set; }
        public bool WriteDatabase { get; set; }
        public bool WriteFile { get; set; }
    }
}
