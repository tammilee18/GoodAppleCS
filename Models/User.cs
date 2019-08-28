using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GoodApple.Models {
    public abstract class User {

        [Key]
        public int UserId {get;set;}

        [Required(ErrorMessage = "*First name is required")]
        [MinLength(2, ErrorMessage = "First name must be at least 2 letters")]
        [Display(Name = "First Name")]
        public string FirstName {get;set;}

        [Required(ErrorMessage = "*Last name is required")]
        [MinLength(2, ErrorMessage = "Last name must be at least 2 letters")]
        [Display(Name = "Last Name")]
        public string LastName {get;set;}

        [Required(ErrorMessage = "*Email is required")]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email {get;set;}

        [Required(ErrorMessage = "*Password is required")]
        [DataType(DataType.Password)]
        [MinLength(8, ErrorMessage = "Password must be at least 8 characters")]
        [RegularExpression("^((?=.*?[a-zA-Z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-])).{8,}$", ErrorMessage = "Password must have at least 1 letter, 1 number, and 1 special character")]
        [Display(Name = "Password")]
        public string Password {get;set;}


        [NotMapped]
        [Display(Name = "Password Confirmation")]
        [Compare("Password")]
        [DataType(DataType.Password)]
        public string PasswordConfirm {get;set;}

        public DateTime CreatedAt {get;set;} = DateTime.Now;
        public DateTime UpdatedAt {get;set;} = DateTime.Now;
    }
}