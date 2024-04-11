using System.ComponentModel.DataAnnotations;

namespace WebApp.Models.ViewModels
{
    public class AddressInfoFormViewModel
    {
        [Display(Name = "Address Line 1", Prompt = "Please Enter your  Address Line1", Order = 0)]
        [Required(ErrorMessage = "Address Line 1 is required")]
        public string AddressLine_1 { get; set; } = null;

        [Display(Name = "Address Line 2", Prompt = "Please Enter your Address Line2", Order = 1)]

        public string? AddressLine_2 { get; set; }

        [Display(Name = "Postal Code", Prompt = "Please Enter your Postal Code", Order = 0)]
        [Required(ErrorMessage = "Postal Code Is Required")]
        [DataType(DataType.PostalCode)]
        public string PostalCode { get; set; } = null;

        [Display(Name = "City", Prompt = "Please Enter your City", Order = 3)]
        [Required(ErrorMessage = "City Is Required")]
        public string City { get; set; } = null;
    }
}
