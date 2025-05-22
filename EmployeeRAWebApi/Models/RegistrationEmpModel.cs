using System.ComponentModel.DataAnnotations;

namespace EmployeeRAWebApi.Models
{
    public class RegistrationEmpModel
    {

        [Required(ErrorMessage = "User Name is required")]
        public string EmpUserName { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }
        [EmailAddress]
        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }
    }
}