using System.ComponentModel.DataAnnotations;

namespace EmployeeReportingAutherityMVC.Models
{
    public class RegistrationEmpModel
    {
        [Required(ErrorMessage = "Employee User Name is required")]
        public string EmpUserName { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }
        [EmailAddress]
        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }

        public string UserRole { get; set; }
    }
}
