using System;
using System.Collections.Generic;

namespace TSQL_WEB_API.Models
{
    public partial class Authorisedperson1522
    {
        public Authorisedperson1522()
        {
            Order1522 = new HashSet<Order1522>();
        }

        public int Userid { get; set; }
        public string Firstname { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int Accountid { get; set; }

        public virtual Clientaccount1522 Account { get; set; }
        public virtual ICollection<Order1522> Order1522 { get; set; }
    }
}
