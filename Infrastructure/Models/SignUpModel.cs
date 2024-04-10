using Infrastructure.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Models
{
    public class SignUpModel
    {
        [DataType(DataType.Text)]
        [Display(Name = "First Name", Prompt = "Please Enter your First Name", Order = 0)]
        [Required(ErrorMessage = "Invalid First Name")]
        [MinLength(2, ErrorMessage = "First Name must be more than 2 char")]
        public string FirstName { get; set; } = null;

        [DataType(DataType.Text)]
        [Display(Name = "Last Name", Prompt = "Please Enter your Last Name", Order = 1)]
        [Required(ErrorMessage = "Invalid Last Name")]
        [MinLength(2, ErrorMessage = "Last Name must be more than 2 char")]
        public string LastName { get; set; } = null;

        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email Address", Prompt = "Please Enter your Email", Order = 2)]
        //[Required(ErrorMessage = "Invalid Email")]
        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$", ErrorMessage = "Please enter a valid e-mail adress")]

        public string Eamil { get; set; } = null;

        [DataType(DataType.Password)]
        [Display(Name = "Password", Prompt = "Please Enter your Password", Order = 3)]
        [Required(ErrorMessage = "Invalid Password")]
        public string Password { get; set; } = null;


        [DataType(DataType.Password)]
        [Display(Name = "ConfirmPassword", Prompt = "Please Confirm Passowrd", Order = 4)]
        [Required(ErrorMessage = "Invalid ConfirmPassword")]
        [Compare(nameof(Password), ErrorMessage = "Password Dose not Match")]
        public string ConfirmPassword { get; set; } = null;

        [Display(Name = "Agree With terms and conditions", Order = 5)]

       [TermsCheckBox(ErrorMessage = "you must accept terms & conditions")]
        public bool TermsAndConditions { get; set; } = false;
    }
}
