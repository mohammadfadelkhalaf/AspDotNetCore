using Infrastructure.Entites;
using Infrastructure.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebApp.Models.ViewModels;

namespace WebApp.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private readonly AddressManger _addressManger;
        private readonly SignInManager<UserEntity> _signInManager;
        private readonly UserManager<UserEntity> _userManager;

        public AccountController(AddressManger addressManger,SignInManager<UserEntity> signInManager,UserManager<UserEntity> userManager)
        {
            _addressManger = addressManger;
            _signInManager = signInManager;
            _userManager = userManager;
        }



        [Route("/Account/details")]
        [HttpGet]
        public async Task<IActionResult> Details()
        {
            var viewmodel = new AccountDetailsViewModel()
            {
                ProfileInfo = await PopulateProfileInfoAsync()
            };
            
            if (viewmodel.BasicInfo == null)
            {
                viewmodel.BasicInfo =await PopulateBasicInfoAsync();
            }
            if (viewmodel.AddressInfo == null)
            {
                viewmodel.AddressInfo =await PopulateAddressInfoAsync();
            }

            return View(viewmodel);
        }

        [Route("/Account/details")]
        [HttpPost]
        public async Task<IActionResult> Details(AccountDetailsViewModel model)
        {
            
                if (model.BasicInfo != null)
                {
                if (model.BasicInfo.FirstName != null && model.BasicInfo.LastName != null && model.BasicInfo.Eamil != null)
                {
                    var user = await _userManager.GetUserAsync(User);
                    
                        if (user != null)
                        {
                            user.FirstName = model.BasicInfo.FirstName;
                            user.LastName = model.BasicInfo.LastName;
                            user.Email = model.BasicInfo.Eamil;
                            user.PhoneNumber = model.BasicInfo.Phone;
                            user.Bio = model.BasicInfo.Biography;
                            var result = await _userManager.UpdateAsync(user);
                            if (!result.Succeeded)
                            {
                                ModelState.AddModelError("Incorreect Data", "Unable to save data");
                                ViewData["ErrorMessage"] = "Unable to save data";
                            }
                    }
                }
                }
                if (model.AddressInfo != null)
                {
                if (model.AddressInfo.AddressLine_1 != null && model.AddressInfo
                    .City != null && model.AddressInfo.PostalCode != null)
                {
                    var user = await _userManager.GetUserAsync(User);
                   
                      
                        if (user != null)
                        {
                            var address =await _addressManger.GetAddressAsync(user.Id);
                            if(address!=null)
                            {
                                address.AddressLine_1 = model.AddressInfo.AddressLine_1;
                                address.AddressLine_2 = model.AddressInfo.AddressLine_2;
                                address.PostalCode = model.AddressInfo.PostalCode;
                                address.City = model.AddressInfo.City;
                                var result = await _addressManger.UpdateAddressAsync(address);
                                if (!result)
                                {
                                    ModelState.AddModelError("Incorreect Data", "Unable to save data");
                                    ViewData["ErrorMessage"] = "Unable to save data";
                                }
                            }
                            else
                            {
                                address = new AddressEntity()
                                {
                                    UserId=user.Id,
                                    AddressLine_1 = model.AddressInfo.AddressLine_1,
                                    AddressLine_2 = model.AddressInfo.AddressLine_2,
                                    PostalCode = model.AddressInfo.PostalCode,
                                    City = model.AddressInfo.City
                                };
                               var result= await _addressManger.CreateAddressAsync(address);
                                if (!result) {
                                    ModelState.AddModelError("Incorreect Data", "Unable to save data");
                                    ViewData["ErrorMessage"] = "Unable to save data";
                                }
                            }
                         
                        }
                    
                }
            }
             model.ProfileInfo = await PopulateProfileInfoAsync();
            model.BasicInfo ??=await PopulateBasicInfoAsync();
            model.AddressInfo ??=await PopulateAddressInfoAsync();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> SaveBasicInfo(AccountDetailsViewModel model)
        {
            if (TryValidateModel(model.BasicInfo))
            
                return RedirectToAction("Index", "Home");
            return RedirectToAction("Details", "Account",model);
        }

        [HttpPost]
        public IActionResult SaveAddressInfo(AccountDetailsViewModel model)
        {

            if (TryValidateModel(model.BasicInfo))
            {
                return RedirectToAction("Index", "Home");
            }
            return RedirectToAction("Details", "Account", model);

        }
        public async Task<ProfileInfoViewModel> PopulateProfileInfoAsync()
        {
            var userentity = await _userManager.GetUserAsync(User);
            return new ProfileInfoViewModel()
            {

              
                FirstName = userentity!.FirstName,
                LastName = userentity.LastName,
                Email = userentity.Email!
             };

        }
        public async Task<BasicInfoFormViewModel> PopulateBasicInfoAsync()
        {
            var userentity = await _userManager.GetUserAsync(User);
            return new BasicInfoFormViewModel()
            {
              
                    UserId = userentity!.Id,
                    FirstName = userentity.FirstName,
                    LastName = userentity.LastName,
                    Phone = userentity.PhoneNumber,
                    Eamil = userentity.Email!,
                    Biography=userentity.Bio
              

             };
           
        }

        public async Task<AddressInfoFormViewModel> PopulateAddressInfoAsync()
        {

            var user =await _userManager.GetUserAsync(User);
           
            if (user != null)
            {
                var address = await _addressManger.GetAddressAsync(user.Id);
                if (address != null)
                {
                    return new AddressInfoFormViewModel()
                    {
                        AddressLine_1 = address.AddressLine_1,
                        AddressLine_2 = address.AddressLine_2,
                        PostalCode = address.PostalCode,
                        City = address.City

                    };
                }
                else
                {
                    return new AddressInfoFormViewModel()
                    {
                        AddressLine_1 = "",
                        AddressLine_2 = "",
                        PostalCode = "",
                        City = ""

                    };

                }
            }
            return new AddressInfoFormViewModel();
        }

    }
}
