using Data;
using MVC.Models;
using Service.Stats;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;

namespace MVC.Controllers
{
    public class DemandeController : Controller
    {
        static Context ctx = new Context();
        demandeService ds = new demandeService();
        // GET: Demande
        public ActionResult Index(String email)
        {
            List<DemandeViewModel> liste = new List<DemandeViewModel>();
            HttpClient Client = new HttpClient();
            Client.BaseAddress = new Uri("http://localhost:18080");
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = Client.GetAsync("Epione-web/rest/doctolib/getDemande").Result;
            if (response.IsSuccessStatusCode)
            {
                ViewBag.result = response.Content.ReadAsAsync<IEnumerable<DemandeViewModel>>().Result;
                foreach (var i in ViewBag.result)
                {
                    liste.Add(i); 
                            
                }
                if (email != null || email!= "") ViewBag.result = ds.GetMany(x => x.email.Contains(email));
                else
                {
                    ViewBag.result = liste;
                    System.Diagnostics.Debug.WriteLine("***********************************");
                    System.Diagnostics.Debug.WriteLine(liste.Count());
                }
            }
            else
            {
                ViewBag.result = "error";
            }

            return View();

            //return View();
        }

        // GET: Demande/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Demande/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Demande/Create
        [HttpPost]
        public ActionResult Create(DemandeViewModel demande)
        {
            try
            {
                if (demande.email.Length > 0 && demande.firstName.Length > 0 && demande.lastName.Length > 0 && demande.specialite.Length > 0 && demande.ville.Length > 0 && demande.email.Length > 0)
                {
                    // TODO: Add insert logic here
                    HttpClient client = new HttpClient();
                    client.BaseAddress = new Uri("http://localhost:18080");
                    // client.PostAsJsonAsync<DemandeViewModel>("Epione-web/rest/doctolib/ajoutDemande", demande)/*.ContinueWith((postTask) => postTask.Result.EnsureSuccessStatusCode())*/;


                    var result = client.PostAsJsonAsync<DemandeViewModel>("Epione-web/rest/doctolib/ajoutDemande", demande).Result;

                    if (result.IsSuccessStatusCode)
                    {
                        return RedirectToAction("ConfirmDemande");
                    }
                    else
                    {
                        ViewBag.result = "Demande existe deja";
                    }
                }else
                {
                    ViewBag.result = "Tout les champs sont obligatoire ! ";
                }
                return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: Demande/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Demande/Edit/5
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

        // GET: Demande/Delete/5
        public ActionResult Delete(string email)
        {
            return View();
        }

        // POST: Demande/Delete/5
        [HttpPost]
        public ActionResult Delete(string email, FormCollection collection)
        {
            try
            {
                DemandeViewModel dem = new DemandeViewModel(); dem.email = email;
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("http://localhost:18080");
                client.PostAsJsonAsync<DemandeViewModel>("Epione-web/rest/doctolib/RejectDemande", dem)/*.ContinueWith((postTask) => postTask.Result.EnsureSuccessStatusCode())*/;

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult ConfirmDemande()
        {
            return View();
        }
    }
}
