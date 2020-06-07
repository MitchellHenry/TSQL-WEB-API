using System;
using System.Collections.Generic;

namespace TSQL_WEB_API.Models
{
    public partial class Clientaccount1522
    {
        public Clientaccount1522()
        {
            Accountpayment1522 = new HashSet<Accountpayment1522>();
            Authorisedperson1522 = new HashSet<Authorisedperson1522>();
        }

        public int Accountid { get; set; }
        public string Acctname { get; set; }
        public decimal Balance { get; set; }
        public decimal Creditlimit { get; set; }

        public virtual ICollection<Accountpayment1522> Accountpayment1522 { get; set; }
        public virtual ICollection<Authorisedperson1522> Authorisedperson1522 { get; set; }
    }
}
