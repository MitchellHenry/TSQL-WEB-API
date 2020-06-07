using System;
using System.Collections.Generic;

namespace TSQL_WEB_API.Models
{
    public partial class Order1522
    {
        public Order1522()
        {
            Orderline1522 = new HashSet<Orderline1522>();
        }

        public int Orderid { get; set; }
        public string Shippingaddress { get; set; }
        public DateTime Datetimecreated { get; set; }
        public DateTime? Datetimedispatched { get; set; }
        public decimal Total { get; set; }
        public int Userid { get; set; }

        public virtual Authorisedperson1522 User { get; set; }
        public virtual ICollection<Orderline1522> Orderline1522 { get; set; }
    }
}
