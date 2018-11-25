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
    public class MessageController : Controller
    {
        // GET: Message
        public ActionResult Index()
        {
            HttpClient Client = new HttpClient();
            Client.BaseAddress = new Uri("http://localhost:18080");
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = Client.GetAsync("Epione-web/rest/messages?doctorId=15").Result;
            if (response.IsSuccessStatusCode)
            {
                List<DateTime> dates = new List<DateTime>();
                IEnumerable<MessageViewModel> liste = response.Content.ReadAsAsync<IEnumerable<MessageViewModel>>().Result;
                foreach (MessageViewModel rdv in liste)
                {
                    System.DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
                    dtDateTime = dtDateTime.AddSeconds(rdv.date / 1000).ToLocalTime();
                    System.Diagnostics.Debug.WriteLine(dtDateTime);
                    dates.Add(dtDateTime);
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

        // GET: Message/Details/5
        public ActionResult Details(int id)
        {
            HttpClient Client = new HttpClient();
            Client.BaseAddress = new Uri("http://localhost:18080");
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = Client.GetAsync("Epione-web/rest/messages?doctorId=15").Result;
            if (response.IsSuccessStatusCode)
            {
                List<DateTime> dates = new List<DateTime>();
                IEnumerable<MessageViewModel> liste = response.Content.ReadAsAsync<IEnumerable<MessageViewModel>>().Result;
                IEnumerable<MessageViewModel> liste2 = response.Content.ReadAsAsync<IEnumerable<MessageViewModel>>().Result;

                foreach (MessageViewModel rdv in liste)
                {
                    System.DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
                    if (rdv.id == id)
                    {
                        ViewBag.details = (MessageViewModel) rdv;  
                    }
                    dtDateTime = dtDateTime.AddSeconds(rdv.date / 1000).ToLocalTime();
                    System.Diagnostics.Debug.WriteLine(dtDateTime);
                    dates.Add(dtDateTime);

                }

                //ViewBag.details = "coucou";
                ViewBag.result = liste;
                ViewBag.dates = dates;
            }
            else
            {
                ViewBag.result = "error";
                ViewBag.dates = "error";
                ViewBag.details = "error";
            }
            return View(ViewBag.dates);
        }

        // GET: Message/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Message/Create
        [HttpPost]
        public ActionResult Create(MessageDELETEViewModel msg)
        {
            try
            {
                // TODO: Add insert logic here
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("http://localhost:18080");
                client.PostAsJsonAsync<MessageDELETEViewModel>("Epione-web/rest/messages?patientId=16&doctorId=15", msg).ContinueWith((postTask) => postTask.Result.EnsureSuccessStatusCode());

                return RedirectToAction("Create");
            }
            catch
            {
                return View();
            }
        }

        // GET: Message/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Message/Edit/5
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

        // GET: Message/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Message/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, MessageDELETEViewModel msg)
        {
            try
            {
                MessageDELETEViewModel m = new MessageDELETEViewModel();
                m.id = id;
                //msg.date = null; 
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("http://localhost:18080");
                client.PostAsJsonAsync<MessageDELETEViewModel>("Epione-web/rest/messages/delete", m);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
