using MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;

namespace MVC.Controllers
{
    public class PatientGeoController : Controller
    {
        // GET: PatientGeo
        public ActionResult Index()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:18080");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = client.GetAsync("Epione-web/rest/patients").Result;
            if (response.IsSuccessStatusCode)
            {


                ViewBag.result = response.Content.ReadAsAsync<List<PatientGeoViewModel>>().Result;


            }
            else
            {
                ViewBag.result = "error";
            }
            return View();
        }

        // GET: PatientGeo/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: PatientGeo/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PatientGeo/Create
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

        // GET: PatientGeo/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PatientGeo/Edit/5
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

        // GET: PatientGeo/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PatientGeo/Delete/5
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
