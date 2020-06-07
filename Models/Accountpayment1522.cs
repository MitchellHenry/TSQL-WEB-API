using System;
using System.Collections.Generic;

namespace TSQL_WEB_API.Models
{
    public partial class Accountpayment1522
    {
        public int Accountid { get; set; }
        public DateTime Datetimereceived { get; set; }
        public decimal Amount { get; set; }

        public virtual Clientaccount1522 Account { get; set; }
    }
}
