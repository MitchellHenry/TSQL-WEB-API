using System;
using System.Collections.Generic;

namespace TSQL_WEB_API.Models
{
    public partial class Location1522
    {
        public Location1522()
        {
            Inventory1522 = new HashSet<Inventory1522>();
            Purchaseorder1522 = new HashSet<Purchaseorder1522>();
        }

        public string Locationid { get; set; }
        public string Locname { get; set; }
        public string Address { get; set; }
        public string Manager { get; set; }

        public virtual ICollection<Inventory1522> Inventory1522 { get; set; }
        public virtual ICollection<Purchaseorder1522> Purchaseorder1522 { get; set; }
    }
}
