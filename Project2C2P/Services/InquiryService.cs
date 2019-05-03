using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Project2C2P.Models;

namespace Project2C2P.Services
{
    public class InquiryService : IInquiryService
    {
        private ApplicationDbContext _context;

        public InquiryService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<InquiryView> GetByCustomerID(long customerID)
        {
            var customer = await _context.Customers.FindAsync(customerID);

            if (customer == null)
                return null;

            var transactions = await _context.Transactions.Where(x => x.CustomerID == customerID).ToListAsync();

            return new InquiryView
            {
                CustomerID = customer.CustomerID,
                Email = customer.Email,
                Mobile = customer.Mobile,
                Name = customer.Name,
                Transactions = transactions
            };
        }

        public async Task<InquiryView> GetByEmail(string email)
        {
            var customer = await _context.Customers.Where(x => x.Email == email).FirstOrDefaultAsync();

            if (customer == null)
                return null;

            var transactions = await _context.Transactions.Where(x => x.CustomerID == customer.CustomerID).ToListAsync();

            return new InquiryView
            {
                CustomerID = customer.CustomerID,
                Email = customer.Email,
                Mobile = customer.Mobile,
                Name = customer.Name,
                Transactions = transactions
            };
        }
    }
}
