using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace University.Models
{
    public class LoginModel
    {
        [Key]
        [Display(Name ="Email")]
        [Required(ErrorMessage ="Please enter your email")]
        public string Email { set; get; }
        [Required(ErrorMessage ="Please enter your password")]
        [Display(Name ="Password")]
        public string Password { set; get; }
        public bool RememberMe { get; set; }
    }
}