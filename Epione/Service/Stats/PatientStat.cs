using Domain.Entity;
using Epione.Data.Infrastructure;
using Epione.ServicePattern;
using PdfSharp.Drawing;
using PdfSharp.Pdf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Stats
{
    public class PatientStat : Service<patient>, IPatientStat
    {
        static IDatabaseFactory dbf = new DatabaseFactory();

        static IUnitOfWork uow = new UnitOfWork(dbf);

        public PatientStat() : base(uow)
        {

        }

        public void generatePDF(int id)
        {


            var patient = (from pat in dbf.DataContext.patients
                           join par in dbf.DataContext.parcours on pat.parcours_id equals par.id
                           join treat in dbf.DataContext.treatments on par.id equals treat.parcours_id
                           join doc in dbf.DataContext.doctors on par.doctor_id equals doc.id
                           join rdv in dbf.DataContext.rendezvous on pat.id equals rdv.patient_id into RDV_Pat
                           where (pat.id == id)
                           select new
                           {
                               firstName = pat.firstName,
                               lastName = pat.lastName,
                               phoneNumber = pat.phoneNumber,
                               doctorNote = par.doctorNote,
                               justif = par.justification,
                               treat = par.treatments,
                               docName = doc.firstName + " " + doc.lastName,
                               rdv = RDV_Pat.Count()

                           }).First();




            int y = 90;
            int x = 50;
            PdfDocument document = new PdfDocument();
            PdfPage page = document.AddPage();
            XGraphics gfx = XGraphics.FromPdfPage(page);
            XFont title = new XFont("Verdana", 10, XFontStyle.BoldItalic);
            XFont font = new XFont("Verdana", 8, XFontStyle.BoldItalic);
            XFont fontDetails = new XFont("Verdana", 7, XFontStyle.BoldItalic);
            gfx.DrawString("Historique du patient : " + patient.firstName, title, XBrushes.Black, 200, 30);
            gfx.DrawString("Nom Complet du patient : \n" + patient.firstName + " " + patient.lastName,
            font, XBrushes.Black, x, y);
            y += 30;
            gfx.DrawString("Numero de telephone :\n " + patient.phoneNumber,
            font, XBrushes.Black, x, y);
            y += 30;
            gfx.DrawString("Nom de son docteur :\n " + patient.docName,
            font, XBrushes.Black, x, y);
            y += 30;
            gfx.DrawString("Note de son docteur :\n " + patient.doctorNote,
            font, XBrushes.Black, x, y);
            y += 30;
            gfx.DrawString("Justification des traitements :\n " + patient.justif,
            font, XBrushes.Black, x, y);
            y += 30;
            gfx.DrawString("Nombre des rendez vous pris :\n " + patient.rdv,
            font, XBrushes.Black, x, y);
            y += 30;
            gfx.DrawString("Liste des traitements recu :\n ",
            font, XBrushes.Black, x, y);
            foreach (var i in patient.treat)
            {
                y += 20;
                gfx.DrawString("Description :\n " + i.description,
                fontDetails, XBrushes.Black, x + 40, y);
                y += 20;
                gfx.DrawString("Duration :\n " + i.duration,
                fontDetails, XBrushes.Black, x + 40, y);
                y += 20;
                gfx.DrawString("Resultat :\n " + i.result,
                fontDetails, XBrushes.Black, x + 40, y);
                y += 20;
                gfx.DrawString("--------",
                fontDetails, XBrushes.Black, x + 40, y);

            }

            // const string filename = "HelloWorld.pdf";
            document.Save(@"D:\" + patient.firstName + "_" + patient.lastName + ".pdf");



        }



        public int getPatientByEmail(string email)
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
            catch (InvalidOperationException e)
            {
                // ViewBag.ERROR = " Patient existe pas ";
                return 0;
            }
        }

    }
}

