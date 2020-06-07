using System;
using System.Collections.Generic;

namespace TSQL_WEB_API.Models
{
    public partial class Inventory1522
    {
        public int Productid { get; set; }
        public string Locationid { get; set; }
        public int Numinstock { get; set; }

        public virtual Location1522 Location { get; set; }
        public virtual Product1522 Product { get; set; }
    }
}
