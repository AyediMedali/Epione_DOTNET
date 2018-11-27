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
    public class TrieAController : Controller
    {
        // GET: TrieA
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

                        dates.Add(dtDateTime);

                    }
                }

                /**************** trie liste rdv par date *********************/
                System.Diagnostics.Debug.WriteLine(dates);
                List<rendezvousViewModel> trieListe = (List<rendezvousViewModel>)liste;
                var tl = trieListe.OrderBy(rdv => rdv.date).ToList();

                dates.Sort((a, b) => a.CompareTo(b));
                System.Diagnostics.Debug.WriteLine(dates);
                ViewBag.result = tl;
                ViewBag.dates = dates;

            }
            else
            {
                ViewBag.result = "error";
                ViewBag.dates = "error";
            }
            return View(ViewBag.dates);
        }

        // GET: TrieA/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: TrieA/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TrieA/Create
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

        // GET: TrieA/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: TrieA/Edit/5
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

        // GET: TrieA/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: TrieA/Delete/5
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
