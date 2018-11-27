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
    }
}
