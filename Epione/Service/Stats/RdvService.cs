using Domain.classes;
using Domain.Entity;
using Epione.Data.Infrastructure;
using Epione.ServicePattern;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Stats
{
    
    public class RdvService : Service<rendezvou>, IRdvServices
    {
        static IDatabaseFactory dbf = new DatabaseFactory();

        static IUnitOfWork uow = new UnitOfWork(dbf);
        doctorService ds = new doctorService();

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
            
            
            result.Add(acceptRDV.Count());  result.Add(rejectRDV.Count());
            
            return result;


        }
        public List<UserData> getUserPer()
        {
            var docs = (from m in dbf.DataContext.doctors
                            select m).ToList();
            bool DateExist = false;
            List <UserData> DataSet = new List<UserData>();
            foreach(var set in docs )
            {
                      
                if (DataSet.Count()==0)
                {
                    int users = ds.GetMany(x => x.dateCreation.Value.Month.Equals(set.dateCreation.Value.Month)
                                                && x.dateCreation.Value.Year.Equals(set.dateCreation.Value.Year)).Count();
                    DateTime dateRes = set.dateCreation.Value;
                    DataSet.Add(new UserData(users, dateRes));
                }
                DateExist = false;
                DateTime DateTemp= new DateTime();
                foreach  (var j in DataSet)
                {
                    
                    if(set.dateCreation.Value.Month.Equals(j.date.Month) && set.dateCreation.Value.Year.Equals(j.date.Year) )
                    {
                        DateExist = true;
                    }
                                       
                }
                if (DateExist==false)
                {
                    int users = ds.GetMany(x => x.dateCreation.Value.Month.Equals(set.dateCreation.Value.Month)
                                             && x.dateCreation.Value.Year.Equals(set.dateCreation.Value.Year)).Count();
                    DateTime dateRes = set.dateCreation.Value;
                    DataSet.Add(new UserData(users, dateRes));
                    System.Diagnostics.Debug.WriteLine("***********************************");
                    System.Diagnostics.Debug.WriteLine("users : " + users);

                }
                DateExist = true; 
            }

            return DataSet;
        }




        public List<UserData> getUserNumbers()
        {
            // var docs = (from m in dbf.DataContext.doctors
            //           select m).ToList();
            var docs = ds.GetAll();
            List<UserData> DataSet = new List<UserData>();

            foreach(var i in docs)
            {
                UserData temp = new UserData();
                int number = 0;
                bool test = false;
                if (DataSet.Exists(x => x.date.Month.Equals(i.dateCreation.Value.Month) && x.date.Year.Equals(i.dateCreation.Value.Year)))
                    {
                    test = true;
                     }
                if(!test)
                {
                    foreach (var j in docs)
                    {
                        if (i.dateCreation.Value.Month.Equals(j.dateCreation.Value.Month) && i.dateCreation.Value.Year.Equals(j.dateCreation.Value.Year))
                        {
                            number++;
                        }
                    }

                    temp.date = i.dateCreation.Value;
                    temp.UserNumber = number;
                    DataSet.Add(temp);
                }
                
            }

            return DataSet;
        }




        }
}
