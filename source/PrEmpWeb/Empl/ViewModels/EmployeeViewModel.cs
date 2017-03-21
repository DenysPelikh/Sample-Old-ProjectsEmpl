using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Empl.ViewModels
{
    public class EmployeeViewModel
    {
        [HiddenInput]
        public int EmployeeId { get; set; }

        [Required]
        [Display(Name = "Name")]
        [StringLength(50, ErrorMessage = "\"{0}\" field should have from {2} to {1} characters", MinimumLength = 1)]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Position")]
        [StringLength(50, ErrorMessage = "\"{0}\" field should have from {2} to {1} characters", MinimumLength = 1)]
        public string Position { get; set; }

        [Required]
        [Display(Name = "Status")]
        [UIHint("Status")]
        public bool Status { get; set; }

        [Required]
        [Display(Name = "Salary")]
        [DataType(DataType.Currency)]
        [Range(0, int.MaxValue, ErrorMessage = "Value is not in range")]
        public int Salary { get; set; }
    }
}