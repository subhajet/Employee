﻿using System.ComponentModel.DataAnnotations;

namespace EmployeeRAWebApi.Models
{
    public class LoginEmpModel
    {
        [Required(ErrorMessage = "User Name is required")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }
    }
}
