using Infrastructure.Entites;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using System.Text.Json.Serialization;
using WebApp.Models;
using WebApp.Models.ViewModels;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace WebApp.Controllers
{
    public class CoursesController : Controller
    {


        public async Task<IActionResult> Index()
        {
            var viewmodel = new CourseIndexViewModel();
            using var http = new HttpClient();
            var response = await http.GetAsync("http://localhost:5233/api/Courses");
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var data = JsonConvert.DeserializeObject<IEnumerable<CourseViewModel>>(json);
                if(data!=null && data.Any())
                {
                    viewmodel.Courses = data;
                }

              
            }
            return View(viewmodel);
        }
        [Route("/details")]
        public async Task<IActionResult> Details(int id)
        {
            using var http = new HttpClient();
            var response = await http.GetAsync($"http://localhost:5233/api/Courses?id={id}");
            var json = await response.Content.ReadAsStringAsync();
            var data = JsonConvert.DeserializeObject<IEnumerable<CourseEntity>>(json);

            return View(data);
        }



        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CourseRegisterationFormViewModel model)
        {
            if(ModelState.IsValid)
            {
                using var http = new HttpClient();
                var json = JsonConvert.SerializeObject(model);
                using var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await http.PostAsync($"http://localhost:5233/api/Courses",content);
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index", "Courses");
                }
            }
            return View(model);
        }

        //[Route("/subscribe")]
        //public  IActionResult Subscribe()
        //{
        //    ViewData["Subscribed"] = false;
        //    return View();
        //}
        //[Route("/subscribe")]
        //[HttpPost]
        //public async Task<IActionResult> Subscribe(SubscriberEntity entity)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        using var http = new HttpClient();
        //        var json = JsonConvert.SerializeObject(entity);
        //        using var content=new StringContent(json,Encoding.UTF8,"pplication/json");
        //        var response = await http.PostAsync($"http://localhost:5233/api/Subscribers?email={entity.Email}",content);
        //        if (response.IsSuccessStatusCode)
        //        {
        //            ViewData["Subscribed"] = true;
        //        }
        //    }
        //    return View();
        //}


    }
}
