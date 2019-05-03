using Project2C2P.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project2C2P.Services
{
    public interface IInquiryService
    {
        Task<InquiryView> GetByCustomerID(long customerID);
        Task<InquiryView> GetByEmail(string email);
    }
}
