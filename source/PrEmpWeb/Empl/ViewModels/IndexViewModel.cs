using System.Collections.Generic;

namespace Empl.ViewModels
{
    public class IndexViewModel
    {
        public List<EmployeeViewModel> Employees { get; set; }

        public int FilteredRowsTotal { get; set; }

        public int PageSize { get; set; }

        public int PageNumber { get; set; }

        public string Filter { get; set; }
    }
}