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
    public class rendezvousController : Controller
    {
        // GET: rendezvous
        public ActionResult Index()
        {
            HttpClient Client = new HttpClient();
            Client.BaseAddress = new Uri("http://localhost:18080");
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = Client.GetAsync("Epione-web/rest/rendezvous").Result;
            if (response.IsSuccessStatusCode)
            {
                IEnumerable<rendezvousViewModel> liste = response.Content.ReadAsAsync<IEnumerable<rendezvousViewModel>>().Result;
                List<DateTime> dates = new List<DateTime>();
                foreach (rendezvousViewModel rdv in liste)
                {
                    System.DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
                    if (rdv.date != null)
                    {
                        dtDateTime = dtDateTime.AddSeconds(rdv.date / 1000).ToLocalTime();
                        System.Diagnostics.Debug.WriteLine(dtDateTime);
                        dates.Add(dtDateTime);
                    }

                }

                ViewBag.result = liste;
                ViewBag.dates = dates;

            }
            else
            {
                ViewBag.result = "error";
                ViewBag.dates = "error";
            }
            return View(ViewBag.dates);
        }

        // GET: rendezvous/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: rendezvous/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: rendezvous/Create
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

        // GET: rendezvous/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: rendezvous/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, rendezvousDELETEViewModel rdv)
        {
            try
            {
                // TODO: Add insert logic here
                HttpClient client = new HttpClient();
                rdv.identifiant = id;
                client.BaseAddress = new Uri("http://localhost:18080");
                client.PostAsJsonAsync<rendezvousDELETEViewModel>("Epione-web/rest/rendezvous/confirmation", rdv).ContinueWith((postTask) => postTask.Result.EnsureSuccessStatusCode());

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: rendezvous/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: rendezvous/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, rendezvousDELETEViewModel rdv)
        {
            try
            {

                rdv.identifiant = id;
                System.Diagnostics.Debug.WriteLine(rdv.identifiant);
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("http://localhost:18080");
                client.PostAsJsonAsync<rendezvousDELETEViewModel>("Epione-web/rest/rendezvous/delete", rdv);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
