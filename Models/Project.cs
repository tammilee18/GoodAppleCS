using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GoodApple.Models {
    public class Project {

        public class ValidDate : ValidationAttribute
        {
            protected override ValidationResult IsValid(object value, ValidationContext validationContext)
            {
                if((DateTime)value < DateTime.Now)
                {
                    return new ValidationResult ("Date must be set in the future!");
                }
                else
                {
                    return ValidationResult.Success;
                }
            }
        }

        [Key]
        public int ProjectId {get;set;}

        public int CreatorId {get;set;}
        public Teacher Creator {get;set;}

        [Required]
        [MinLength(2, ErrorMessage="Project Name must be at least 2 characters")]
        public string Name {get;set;}

        [Required]
        [MinLength(20, ErrorMessage="Description must be at least 20 characters")]
        public string Description {get;set;}

        [Required]
        public decimal GoalAmount {get;set;}

        public decimal CurrentAmount {get;set;} = 0;

        [Required]
        [ValidDate]
        public DateTime EndDate {get;set;}

        public List<Donation> Donations {get;set;}
        public List<Comment> Comments {get;set;}

        public DateTime CreatedAt {get;set;} = DateTime.Now;
        public DateTime UpdatedAt {get;set;} = DateTime.Now;
    }
}