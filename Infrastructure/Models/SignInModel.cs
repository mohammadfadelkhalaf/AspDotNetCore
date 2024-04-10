using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Models
{
    public class SignInModel
    {

        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email Address", Prompt = "Please Enter your Email", Order = 0)]
        //[Required(ErrorMessage = "Invalid Email")]
        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$", ErrorMessage = "Please enter a valid e-mail adress")]

        public string Eamil { get; set; } = null;

        [DataType(DataType.Password)]
        [Display(Name = "Password", Prompt = "Please Enter your Password", Order = 1)]
        [Required(ErrorMessage = "Invalid Password")]
        public string Password { get; set; } = null;


        [Display(Name = "Remember Me", Order = 2)]

        public bool RememberMe { get; set; }
    }
}
