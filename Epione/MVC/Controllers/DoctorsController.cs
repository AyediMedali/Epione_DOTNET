
using MVC.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace MVC.Controllers
{
    public class DoctorsController : Controller
    {
        public ActionResult test()
        {

            ViewBag.result = Request.Form["nom"];
            return View();
        }
        //GET/ Calendrier
        public ActionResult Calendrier()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:18080");
            HttpResponseMessage response = client.GetAsync("Epione-web/rest/doctors/getCalendar?id=" + (int)Session["id"]).Result;
            var jsonString = response.Content.ReadAsStringAsync();
            jsonString.Wait();
            JArray jsonVal = JArray.Parse(jsonString.Result) as JArray;
            dynamic journees = jsonVal;
            ViewBag.result = journees;
            return View();
        }


        public ActionResult getJourneeActuelle()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:18080");
            string date = DateTime.UtcNow.ToString("yyyy/MM/dd",
                                       CultureInfo.InvariantCulture);

            HttpResponseMessage response = client.PostAsync("Epione-web/rest/doctors/getHorairesJournee?date=" + date + "&id=" + (int)Session["id"], null).Result;
            var jsonString = response.Content.ReadAsStringAsync();
            jsonString.Wait();
            if (jsonString.Equals("date n'existe pas"))
            {
                ViewBag.date = date;
                ViewBag.error = 1;
            }
            else
            {
                JArray jsonVal = JArray.Parse(jsonString.Result) as JArray;
                dynamic journees = jsonVal;
                ViewBag.result = journees;
            }


            return PartialView();
        }


        public ActionResult getJourneeSaisie(String date)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:18080");


            HttpResponseMessage response = client.PostAsync("Epione-web/rest/doctors/getHorairesJournee?date=" + date + "&id=" + (int)Session["id"], null).Result;
            var jsonString = response.Content.ReadAsStringAsync();
            jsonString.Wait();
            if (jsonString.Result.Equals("date n'existe pas"))
            {
                ViewBag.date = date;

                ViewBag.error = 1;
            }
            else
            {
                JArray jsonVal = JArray.Parse(jsonString.Result) as JArray;
                dynamic journees = jsonVal;
                ViewBag.date = date;
                ViewBag.result = journees;
            }


            return View();
        }
        public ActionResult getlListMotifs()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:18080");
            HttpResponseMessage response = client.GetAsync("Epione-web/rest/doctors/getListMotifs?id=" + (int)Session["id"]).Result;
            var jsonString = response.Content.ReadAsStringAsync();
            jsonString.Wait();
            JArray jsonVal = JArray.Parse(jsonString.Result) as JArray;
            dynamic mesMotifs = jsonVal;
            ViewBag.mesMotifs = mesMotifs;

            HttpResponseMessage response2 = client.GetAsync("Epione-web/rest/doctors/getAllMotifs").Result;
            var jsonString2 = response2.Content.ReadAsStringAsync();
            jsonString2.Wait();
            JArray jsonVal2 = JArray.Parse(jsonString2.Result) as JArray;
            dynamic allMotifs = jsonVal2;
            ViewBag.allMotifs = allMotifs;
            return View();
        }
        // GET: Doctors
        public ActionResult Index()
        {

            return View();
        }



        // GET: Doctors/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Doctors/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Doctors/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Doctors/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Doctors/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Doctors/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Doctors/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
