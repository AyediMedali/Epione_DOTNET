using Newtonsoft.Json.Linq;
using System;

using System.Net.Http;


using System.Web.Mvc;


namespace MVC.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult LoginDoctor()
        {
            return View();
        }
        [HttpPost]
        public ActionResult LoginDoctor(String email, String password)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:18080");
            HttpResponseMessage response = client.PostAsync("Epione-web/rest/users/logIn?email=" + email + "&password=" + password + "", null).Result;
            var jsonString = response.Content.ReadAsStringAsync();

            jsonString.Wait();
            JObject msg = JObject.Parse(jsonString.Result);

            if ((int)msg["id"] != 0)
            {
                Session["id"] = (int)msg["id"];

                return RedirectToAction("Index", "Doctors");
            }
            else
            {
                return RedirectToAction("Index", "User");
            }


        }
        public ActionResult LogOutDoctor()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:18080");
            HttpResponseMessage response = client.GetAsync("Epione-web/rest/users/logOut?id=" + (int)Session["id"]).Result;
            var jsonString = response.Content.ReadAsStringAsync();
            jsonString.Wait();

            return RedirectToAction("Index", "User");
        }

        [HttpPost]
        public ActionResult LoginPatient(String email, String password)
        {
            HttpClient client = new HttpClient();


            client.BaseAddress = new Uri("http://localhost:18080");
            HttpResponseMessage response = client.PostAsync("Epione-web/rest/users/logIn?email=" + email + "&password=" + password + "", null).Result;
            var jsonString = response.Content.ReadAsStringAsync();

            jsonString.Wait();
            JObject msg = JObject.Parse(jsonString.Result);

            if ((int)msg["id"] != 0)
            {
                Session["id"] = (int)msg["id"];

                return RedirectToAction("Index", "Patient");
            }
            else
            {
                return RedirectToAction("Index", "User");
            }


        }
    }
}