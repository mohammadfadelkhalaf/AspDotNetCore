using System.ComponentModel.DataAnnotations;

namespace WebApp.Models.ViewModels
{
    public class BasicInfoFormViewModel
    {
        public string UserId { get; set; } = null!;

        //[DataType(DataType.ImageUrl)]
        //public string? ProfileImage { get; set; }

        [Display(Name = "First Name", Prompt = "Please Enter your First Name", Order = 0)]
        [Required(ErrorMessage = "Invalid First Name")]
        public string FirstName { get; set; } = null;

        [Display(Name = "Last Name", Prompt = "Please Enter your Last Name", Order = 1)]
        [Required(ErrorMessage = "Invalid Last Name")]
        public string LastName { get; set; } = null;

        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email Address", Prompt = "Please Enter your Email", Order = 2)]
        //[Required(ErrorMessage = "Invalid Email")]
        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$", ErrorMessage = "Please enter a valid e-mail adress")]

        public string Eamil { get; set; } = null;
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Phone Number", Prompt = "Please Enter your Phone", Order = 3)]
        [Required(ErrorMessage = " Phone Is Required")]
        public string? Phone { get; set; } 
        [Display(Name = "Bio", Prompt = "Add a short bio", Order = 4)]
        [DataType(DataType.MultilineText)]

        public string? Biography { get; set; }
    }
}
