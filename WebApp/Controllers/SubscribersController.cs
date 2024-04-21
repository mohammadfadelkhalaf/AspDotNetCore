using Infrastructure.Entites;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net;
using System.Text;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class SubscribersController : Controller
    {
        public IActionResult Index()
        {
          
            return View(new SubscribeViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Index(SubscribeViewModel viewmodel)
        {
            if (ModelState.IsValid)
            {
                using var http = new HttpClient();
              
                var url = $"http://localhost:5233/api/Subscribers?email={viewmodel.Email}";
                var request = new HttpRequestMessage(HttpMethod.Post,url);
                var response = await http.SendAsync(request);
                if (response.IsSuccessStatusCode)
                {
                   viewmodel.IsSbuscribed = true;
                }
            }
            return RedirectToAction("Index","Home");
        }

        [HttpPost]
        public async Task<IActionResult> Subscribe(SubscribeViewModel entity)
        {
            if (ModelState.IsValid)
            {
                using var http = new HttpClient();
                var json = JsonConvert.SerializeObject(entity);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await http.PostAsync("http://localhost:5233/api/Subscribers", content);
                //var response = await http.PostAsync($"http://localhost:5233/api/Subscribers?email={entity.Email}", content);
                if (response.IsSuccessStatusCode)
                {
                    //  ViewData["Subscribed"] = true;
                    TempData["statusMessage"] = "you are subscribed";
                }
                else if (response.StatusCode == HttpStatusCode.Conflict)
                {
                    TempData["statusMessage"] = "you are already subscribed";
                }

            }
            else
            {
                TempData["statusMessage"] = "InvalidEmailAddress";
            }
            return RedirectToAction("Index", "Subscribers", "Subscribe");
        }


        //public IActionResult UnSubscribe()
        //{
        //    return View(new SubscribeViewModel());
        //}
        [HttpPost]
        public async Task<IActionResult> UnSubscribe(SubscribeViewModel entity)
        {
            using var http = new HttpClient();
            //var json = JsonConvert.SerializeObject(entity);
            //var content = new StringContent(json, Encoding.UTF8, "application/json");
            //var response = await http.DeleteAsync("http://localhost:5233/api/Subscribers",entity.Email);



            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Delete,
                RequestUri = new Uri("http://localhost:5233/api/Subscribers"),
                Content = new StringContent(JsonConvert.SerializeObject(entity), Encoding.UTF8, "application/json")
            };
            var response = await http.SendAsync(request);
            if (response.IsSuccessStatusCode)
            {
                //  ViewData["Subscribed"] = true;
                TempData["statusMessage"] = "you are Unsubscribed";
            }
            else if (response.StatusCode == HttpStatusCode.NotFound)
            {
                TempData["statusMessage"] = "your email is Not exists";
            }
           

            return RedirectToAction("Index", "Subscribers", "Subscribe");
        }





        //[Route("/subscribe")]
        //[HttpPost]
        //public async Task<IActionResult> Subscribe(SubscriberEntity entity)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        using var http = new HttpClient();
        //        var json = JsonConvert.SerializeObject(entity);
        //        using var content = new StringContent(json, Encoding.UTF8, "pplication/json");
        //        var response = await http.PostAsync($"http://localhost:5233/api/Subscribers?email={entity.Email}", content);
        //        if (response.IsSuccessStatusCode)
        //        {
        //            ViewData["Subscribed"] = true;
        //            TempData["statusMessage"] = "you are subscribed";
        //        }
        //        else if (response.StatusCode==HttpStatusCode.Conflict)
        //        {
        //            TempData["statusMessage"] = "you are already subscribed";
        //        }

        //    }
        //    else
        //    {
        //        TempData["statusMessage"] = "InvalidEmailAddress";
        //    }
        //    return RedirectToAction("Index", "Home");
        //}
    }
}
