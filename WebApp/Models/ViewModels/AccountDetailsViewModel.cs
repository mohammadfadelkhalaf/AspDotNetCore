using Infrastructure.Entites;

namespace WebApp.Models.ViewModels
{
    public class AccountDetailsViewModel
    {
        //  public UserEntity User { get; set; } = null!;
        public ProfileInfoViewModel? ProfileInfo { get; set; }
        public BasicInfoFormViewModel? BasicInfo { get; set; }
        public AddressInfoFormViewModel? AddressInfo { get; set; }
    }
}
