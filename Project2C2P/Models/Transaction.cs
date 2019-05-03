using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Project2C2P.Models
{
    public class Transaction
    {
        [Key]
        public long TransactionID { get; set; }
        public DateTime TransactionDate { get; set; }
        [RegularExpression(@"\d+(\.\d{1,2})?")]
        public decimal Amount { get; set; }
        [MaxLength(3)]
        public string CurrencyCode { get; set; }
        public string Status { get; set; }
        [JsonIgnore]
        public long CustomerID { get; set; }
        [JsonIgnore]
        public Customer Customer { get; set; }
    }
}
