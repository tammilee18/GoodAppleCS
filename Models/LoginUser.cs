using System;
using System.ComponentModel.DataAnnotations;

namespace GoodApple.Models {
    public class LoginUser {
        [Required(ErrorMessage = "Email address is required")]
        [EmailAddress(ErrorMessage = "Email address is not valid")]
        public string Email {get;set;}

        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        public string Password {get;set;}
    }
}