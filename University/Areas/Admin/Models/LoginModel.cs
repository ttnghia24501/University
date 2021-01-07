using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace University.Areas.Admin.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Please enter Email ")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Please enter Password ")]
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}