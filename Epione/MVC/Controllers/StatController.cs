using Data;
using Domain.Entity;
using Epione.Data.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Service;
using Service.Stats;
using PdfSharp.Pdf;
using PdfSharp.Drawing;
using Domain.classes;
using System.Data;

namespace MVC.Controllers
{
    public class StatController : Controller
    {
        static IDatabaseFactory dbf = new DatabaseFactory();
        static IUnitOfWork uow = new UnitOfWork(dbf);
        static Context ctx = new Context();
        demandeService ds = new demandeService();
        RdvService rs = new RdvService();
        PatientStat ps = new PatientStat();
        


        // GET: Stat
        public ActionResult Index()
        {

            /*  var query = (from m in dbf.DataContext.demandedoctolibs
                           select m).ToList();
              var all = ds.GetAll();

               ViewBag.REP = query.Count();*/
            /*  System.Diagnostics.Debug.WriteLine("**");
              System.Diagnostics.Debug.WriteLine(query.);
             System.Diagnostics.Debug.WriteLine(all.Count()); */

            /*  string accept = "accepted"; string reject = "rejected";
              var accepted = (from m in dbf.DataContext.rendezvous
                              select m ).ToList();

              List<rendezvou> acceptRDV = new List<rendezvou>();
              List<rendezvou> rejectRDV = new List<rendezvou>();

              foreach (var i in accepted)
              {
                  if (i.state.Contains("accepted"))
                      acceptRDV.Add(i);
                  else rejectRDV.Add(i);

              }*/
            List<int> dataStat = rs.getTauxRdv();

           // ViewBag.REP = accepted.Count();
            ViewBag.ACC = dataStat[0];
            ViewBag.REJ = dataStat[1];


            List<UserData> userData = rs.getUserPer();
            List<string> dates = new List<string>();
            List<int> numbers = new List<int>();

 
            foreach (var x in userData)
            {
                dates.Add(x.date.Month + " "+x.date.Year);
                numbers.Add(x.UserNumber);
                           }

            var userDates = dates;
            var userNumbers = numbers;

            ViewBag.userDates = userDates;
            ViewBag.userNumbers = userNumbers;
            System.Diagnostics.Debug.WriteLine("***********************************");
            System.Diagnostics.Debug.WriteLine("***********************************");
            System.Diagnostics.Debug.WriteLine("***********************************");
            System.Diagnostics.Debug.WriteLine("***********************************");


            return View();
        }

       

        // GET: Stat/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Stat/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Stat/Create
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

        // GET: Stat/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Stat/Edit/5
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

        // GET: Stat/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Stat/Delete/5
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
        public ActionResult GeneratePDF(string email)
        {
            try
            {

                // int id = getPatientByEmail(email);
                int id = ps.getPatientByEmail(email);
                if (id == 0)
                {
                    ViewBag.ERROR = "Patient n'existe pas ";
                    return View();
                }
                else
                {
                    ps.generatePDF(id); 
                    return View();

                }

            }
            catch (InvalidOperationException e)
            {
                ViewBag.ERROR = " Les données de ce patient sont manquantes";
                return View();
            }
        

        }
        

        



        public int getPatientByEmail(String email)
        {
            try
            {
                var resPatient = (from pat in dbf.DataContext.patients
                                  where pat.email.Equals(email)
                                  select pat
                                  ).First();
                if (resPatient == null)
                {
                    return 0;
                }
                else
                {
                    return resPatient.id;
                }
            }
            catch(InvalidOperationException e)
            {
                ViewBag.ERROR = " Patient existe pas ";
                return 0; 
            }
        }
    }
}
