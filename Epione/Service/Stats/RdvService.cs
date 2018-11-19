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
    public class RdvService : Service<rendezvou>, IRdvServices
    {
        static IDatabaseFactory dbf = new DatabaseFactory();

        static IUnitOfWork uow = new UnitOfWork(dbf);

        public RdvService() : base(uow)
        {

        }

        public List<int> getTauxRdv()
        {
            List<int> result = new List<int>(); 
           // string accept = "accepted"; string reject = "rejected";
            var accepted = (from m in dbf.DataContext.rendezvous
                            select m).ToList();

            List<rendezvou> acceptRDV = new List<rendezvou>();
            List<rendezvou> rejectRDV = new List<rendezvou>();


            foreach (var i in accepted)
            {
                if (i.state.Contains("accepted"))
                    acceptRDV.Add(i);
                else rejectRDV.Add(i);

            }
            result.Add(acceptRDV.Count()); result.Add(rejectRDV.Count());
            return result;


        }


    }
}
