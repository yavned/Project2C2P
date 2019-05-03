using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project2C2P.Models
{
    public class TransactionView
    {
        public long TransactionID { get; set; }
        public DateTime TransactionDate { get; set; }
        public decimal Amount { get; set; }
        public string CurrencyCode { get; set; }
        public string Status { get; set; }
    }
}
