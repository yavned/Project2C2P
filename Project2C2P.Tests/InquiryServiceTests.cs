using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using Project2C2P.Models;
using Project2C2P.Services;
using System;
using System.Collections.Generic;

namespace Project2C2P.Tests
{
    public class InquiryServiceTests
    {
        [Test]
        public void GetByCustomerID_ReturnsInquiryView_IfIDIsCorrect()
        {
            var inquiryService = new InquiryService(GetContextWithData());

            var result = inquiryService.GetByCustomerID(1);

            Assert.AreEqual(result.Result.CustomerID, 1);
        }

        [Test]
        public void GetByCustomerID_ReturnsNull_IfIDIsIncorrect()
        {
            var inquiryService = new InquiryService(GetContextWithData());

            var result = inquiryService.GetByCustomerID(11);

            Assert.IsNull(result.Result);
        }

        [Test]
        public void GetByEmail_ReturnsInquiryView_IfEmailIsCorrect()
        {
            string email = "AnurakBanyen@mail.com";
            var inquiryService = new InquiryService(GetContextWithData());

            var result = inquiryService.GetByEmail(email);

            Assert.AreEqual(result.Result.Email, email);
        }

        [Test]
        public void GetByEmail_ReturnsNull_IfEmailIsIncorrect()
        {
            string email = "wrong email";
            var inquiryService = new InquiryService(GetContextWithData());

            var result = inquiryService.GetByEmail(email);

            Assert.IsNull(result.Result);
        }

        private ApplicationDbContext GetContextWithData()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                              .Options;
            var context = new ApplicationDbContext(options);

            var customers = new List<Customer>
            {
                new Customer { CustomerID = 1, Email = "AnurakBanyen@mail.com", Mobile = 6622134567, Name = "Anurak Banyen" },
                new Customer { CustomerID = 2, Email = "MayAnusorn@mail.com", Mobile = 6624534678, Name = "May Anusorn" },
                new Customer { CustomerID = 3, Email = "DawOnruang@mail.com", Mobile = 6625634789, Name = "Daw Onruang"}
            };
            var transactions = new List<Transaction>
            {
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
                new Transaction { TransactionID = 12, Amount = 1200.00M, CurrencyCode = "SGD", TransactionDate = DateTime.Now, Status = "Canceled", CustomerID = 3 }
            };
            context.AddRange(customers);
            context.AddRange(transactions);
            context.SaveChanges();

            //context.Customers.Add(new Customer { CustomerID = 1 });
            //context.SaveChanges();

            return context;
        }

        //[Test]
        //public void GetByCustomerID_ReturnsInquiryView()
        //{
        //    var builder = new DbContextOptionsBuilder<ApplicationDbContext>();
        //    builder.UseInMemoryDatabase();
        //    var options = builder.Options;

        //    using (var context = new ApplicationDbContext(options))
        //    {
        //        var geeks = new List<Customer>
        //    {
        //        new Customer { CustomerID = 1}
        //    };

        //        context.AddRange(geeks);
        //        context.SaveChanges();
        //    }

        //    using (var context = new ApplicationDbContext(options))
        //    {
        //        var inquiryService = new InquiryService(context);

        //        var result = inquiryService.GetByCustomerID(1);

        //        Assert.AreEqual(result.Result.CustomerID, 1);
        //    }
        //}
    }
}
