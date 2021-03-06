using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using PaperHelp.Models;

namespace PaperHelp.Models
{


    public partial class EmployeeModelE
    {
        [Key]

        public int Id { get; set; }
        public byte? Employeekind { get; set; }
        public string UsersId { get; set; }
        public string RoleForEmpl { get; set; }
        public ApplicationUser Users { get; set; }

        [Required]
        [Display(Name = "User Name")]
        public string UserName { get; set; }


        [Required]
        [Display(Name = "Roles")]
        public string Roles { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        //[Required]
        //[StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        //[DataType(DataType.Password)]
        //[Display(Name = "Password")]
        //public string Password { get; set; }

        //[DataType(DataType.Password)]
        //[Display(Name = "Confirm password")]
        //[Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        //public string ConfirmPassword { get; set; }
    }

}
