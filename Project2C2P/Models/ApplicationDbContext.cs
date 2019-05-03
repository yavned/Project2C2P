using Microsoft.EntityFrameworkCore;
using System;

namespace Project2C2P.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        { }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Transaction> Transactions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>().HasData(
              new Customer { CustomerID = 1, Email = "AnurakBanyen@mail.com", Mobile = 6622134567, Name = "Anurak Banyen" },
              new Customer { CustomerID = 2, Email = "MayAnusorn@mail.com", Mobile = 6624534678, Name = "May Anusorn" },
              new Customer { CustomerID = 3, Email = "DawOnruang@mail.com", Mobile = 6625634789, Name = "Daw Onruang" });

            modelBuilder.Entity<Transaction>().HasData(
                new Transaction { TransactionID = 1, Amount = 100.00M, CurrencyCode = "USD", TransactionDate = DateTime.Now, Status = "Success", CustomerID = 1 },
                new Transaction { TransactionID = 2, Amount = 200.00M, CurrencyCode = "USD", TransactionDate = DateTime.Now, Status = "Success", CustomerID = 1 },
                new Transaction { TransactionID = 3, Amount = 300.00M, CurrencyCode = "USD", TransactionDate = DateTime.Now, Status = "Success", CustomerID = 1 },
                new Transaction { TransactionID = 4, Amount = 400.00M, CurrencyCode = "THB", TransactionDate = DateTime.Now, Status = "Success", CustomerID = 1 },
                new Transaction { TransactionID = 5, Amount = 500.00M, CurrencyCode = "THB", TransactionDate = DateTime.Now, Status = "Success", CustomerID = 1 },
                new Transaction { TransactionID = 6, Amount = 600.00M, CurrencyCode = "THB", TransactionDate = DateTime.Now, Status = "Failed", CustomerID = 2 },
                new Transaction { TransactionID = 7, Amount = 700.00M, CurrencyCode = "THB", TransactionDate = DateTime.Now, Status = "Failed", CustomerID = 2 },
                new Transaction { TransactionID = 8, Amount = 800.00M, CurrencyCode = "JPU", TransactionDate = DateTime.Now, Status = "Failed", CustomerID = 2 },
                new Transaction { TransactionID = 9, Amount = 900.00M, CurrencyCode = "JPU", TransactionDate = DateTime.Now, Status = "Canceled", CustomerID = 2 },
                new Transaction { TransactionID = 10, Amount = 1000.00M, CurrencyCode = "SGD", TransactionDate = DateTime.Now, Status = "Canceled", CustomerID = 3 },
                new Transaction { TransactionID = 11, Amount = 1100.00M, CurrencyCode = "SGD", TransactionDate = DateTime.Now, Status = "Canceled", CustomerID = 3 },
                new Transaction { TransactionID = 12, Amount = 1200.00M, CurrencyCode = "SGD", TransactionDate = DateTime.Now, Status = "Canceled", CustomerID = 3 });
        }
    }
}
