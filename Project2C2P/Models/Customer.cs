using DataAnnotationsExtensions;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Project2C2P.Models
{
    public class Customer
    {
        [Key]
        [Max(10)]
        public long CustomerID { get; set; }
        [MaxLength(30)]
        public string Name { get; set; }
        [Email]
        [MaxLength(25)]
        public string Email { get; set; }
        [Max(10)]
        public long Mobile { get; set; }

        public ICollection<Transaction> Posts { get; set; }
    }
}
