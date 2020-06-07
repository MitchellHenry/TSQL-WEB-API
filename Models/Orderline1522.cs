using System;
using System.Collections.Generic;

namespace TSQL_WEB_API.Models
{
    public partial class Orderline1522
    {
        public int Orderid { get; set; }
        public int Productid { get; set; }
        public int Quantity { get; set; }
        public decimal? Discount { get; set; }
        public decimal Subtotal { get; set; }

        public virtual Order1522 Order { get; set; }
        public virtual Product1522 Product { get; set; }
    }
}
