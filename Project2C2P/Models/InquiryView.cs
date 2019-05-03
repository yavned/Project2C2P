using System.Collections.Generic;

namespace Project2C2P.Models
{
    public class InquiryView
    {
        public long CustomerID {get; set;}
        public string Name { get; set; }
        public string Email { get; set; }
        public long Mobile { get; set; }
        public IEnumerable<Transaction> Transactions { get; set; }
    }
}
