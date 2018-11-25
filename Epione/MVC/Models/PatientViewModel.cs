using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC.Models
{
    public class PatientViewModel
    {
        public int id { get; set; }

        public bool? connected { get; set; }

        public string email { get; set; }

        public string firstName { get; set; }

        public bool? isEnable { get; set; }

        public string lastName { get; set; }

        public string password { get; set; }

        public int phoneNumber { get; set; }

        public string token { get; set; }

        public string codePostal { get; set; }

        public string numAppart { get; set; }

        public string rue { get; set; }

        public string ville { get; set; }

        public string presentation { get; set; }

        public string specialite { get; set; }

        public bool? doctolib { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<rendezvousViewModel> rendezvous { get; set; }
    }
}