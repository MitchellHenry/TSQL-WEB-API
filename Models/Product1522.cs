using System;
using System.Collections.Generic;

namespace TSQL_WEB_API.Models
{
    public partial class Product1522
    {
        public Product1522()
        {
            Inventory1522 = new HashSet<Inventory1522>();
            Orderline1522 = new HashSet<Orderline1522>();
            Purchaseorder1522 = new HashSet<Purchaseorder1522>();
        }

        public int Productid { get; set; }
        public string Prodname { get; set; }
        public decimal? Buyprice { get; set; }
        public decimal? Sellprice { get; set; }

        public virtual ICollection<Inventory1522> Inventory1522 { get; set; }
        public virtual ICollection<Orderline1522> Orderline1522 { get; set; }
        public virtual ICollection<Purchaseorder1522> Purchaseorder1522 { get; set; }
    }
}
