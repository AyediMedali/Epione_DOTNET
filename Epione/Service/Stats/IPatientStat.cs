using Domain.Entity;
using Epione.ServicePattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Stats
{
    interface IPatientStat : IService<patient>
    {
        void generatePDF(int id);
        int getPatientByEmail(string email); 
    }
}
