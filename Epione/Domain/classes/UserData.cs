using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.classes
{
    public class UserData
    {
        public int UserNumber { get; set; }
        public DateTime date { get; set; }
        public UserData(int users , DateTime date2)
        {
            UserNumber = users;
            date = date2;
        }
    }
}
