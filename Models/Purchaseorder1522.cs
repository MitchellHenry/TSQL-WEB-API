using System;
using System.Collections.Generic;

namespace TSQL_WEB_API.Models
{
    public partial class Purchaseorder1522
    {
        public int Productid { get; set; }
        public string Locationid { get; set; }
        public DateTime Datetimecreated { get; set; }
        public int? Quantity { get; set; }
        public decimal? Total { get; set; }

        public virtual Location1522 Location { get; set; }
        public virtual Product1522 Product { get; set; }
    }
}
