using Infrastructure.Entites;
using Infrastructure.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApp.Models.ViewModels;

namespace WebApp.Controllers
{
    public class AuthController : Controller
    {
        private readonly UserService _userService;
        private readonly UserManager<UserEntity> _manager;
        private readonly SignInManager<UserEntity> _signInManager;

        public AuthController(UserService userService,UserManager<UserEntity> manager,SignInManager<UserEntity> signInManager)
        {
            _userService = userService;
            _manager = manager;
            _signInManager = signInManager;
        }

        [Route("/SignUp")]
        [HttpGet]
        public IActionResult SignUp()
        {
            if (_signInManager.IsSignedIn(User))
                return RedirectToAction("Details", "Account");
            return View();

        }
        [Route("/SignUp")]
        [HttpPost]
        public async Task<IActionResult> SignUp(SignUpViewModel model)
        {
            if (ModelState.IsValid)
            {
                var exists = await _manager.Users.AnyAsync(x => x.Email == model.Eamil);
                if(exists)
                {
                    ModelState.AddModelError("AlreadyExistes", "User with this email is alerady existes");
                    ViewData["ErrorMessage"] = "User with this email is alerady existes";
                    return View(model);
                }
                var userentity = new UserEntity()
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Email = model.Eamil,
                    UserName = model.Eamil
                };
               var result= await _manager.CreateAsync(userentity, model.Password);
                if (result.Succeeded)
                {
                    return RedirectToAction("SignIn", "Auth");
                }
            }
                return View(model);
           
        
        }

        [Route("/SignIn")]
        [HttpGet]
        public IActionResult SignIn()
        {
            if (_signInManager.IsSignedIn(User))
                return RedirectToAction("Details", "Account");
            return View();
        }
        [Route("/SignIn")]
        [HttpPost]
        public async Task<IActionResult> SignIn(SignInViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result =await _signInManager.PasswordSignInAsync(model.Eamil, model.Password, model.RememberMe,false);
                if (result.Succeeded)
                    return RedirectToAction("Details", "Account");
               
            }
            ModelState.AddModelError("InncorectValus", "Invalid Email or Password");
            ViewData["ErrorMessage"] = "Invalid Email or Password";
            return View(model);
           
           
        }
        [Route("/SignOut")]
        [HttpGet]
        public new async Task<IActionResult> SignOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
