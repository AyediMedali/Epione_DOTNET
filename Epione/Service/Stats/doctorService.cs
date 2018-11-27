using Domain.Entity;
using Epione.Data.Infrastructure;
using Epione.ServicePattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Stats
{
    public class doctorService : Service<doctor> , IDoctorService
    {
        static IDatabaseFactory dbf = new DatabaseFactory();

        static IUnitOfWork uow = new UnitOfWork(dbf);

        public doctorService() : base(uow)
        {

        }
        public int getDoctorNumber()
        {
            int result = (from m in dbf.DataContext.doctors
                          select m).Count();
            return result; 
        }
        public double getTotalTarif()
        {
            double result = (from m in dbf.DataContext.tarifs
                             select m.tarif1).Sum();

            return result;
        }
        public int getTotalRdv()
        {
            int result = (from m in dbf.DataContext.rendezvous
                          select m).Count();
            return result;
        }
    }
}
