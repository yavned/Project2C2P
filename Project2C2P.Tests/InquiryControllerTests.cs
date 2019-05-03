using Moq;
using NUnit.Framework;
using Project2C2P.Controllers;
using Project2C2P.Services;
using Microsoft.AspNetCore.Mvc;
using Project2C2P.Models;
using System.Threading.Tasks;

namespace Tests
{
    public class Tests
    {
        private Mock<IInquiryService> inquiryServiceMock;

        [SetUp]
        public void Setup()
        {
            inquiryServiceMock = new Mock<IInquiryService>();
        }

        [Test]
        public void Get_ResturnsInquiryView()
        {
            long customerID = 1;
            string email = "MyEmail@mail.com";
            InquiryView serviceResult = new InquiryView { CustomerID = customerID };
            inquiryServiceMock.Setup(x => x.GetByCustomerID(1)).ReturnsAsync(serviceResult);

            InquiryController controller = new InquiryController(inquiryServiceMock.Object);
            var responce = controller.Get(customerID, email).Result;
            var objectResponse = responce as OkObjectResult;

            Assert.IsInstanceOf<OkObjectResult>(responce);
            Assert.AreEqual(serviceResult, objectResponse.Value);
        }

        [Test]
        public void Get_ResturnsNotFound()
        {
            long customerID = 1;
            string email = "MyEmail@mail.com";
            InquiryView serviceResult = null;
            inquiryServiceMock.Setup(x => x.GetByCustomerID(1)).ReturnsAsync(serviceResult);

            InquiryController controller = new InquiryController(inquiryServiceMock.Object);
            var responce = controller.Get(customerID, email).Result;
            var objectResponse = responce as NotFoundResult;

            Assert.IsInstanceOf<NotFoundResult>(responce);
        }

        [Test]
        public void Get_ResturnsBadRequest()
        {
            long? customerID = null;
            string email = null;
            InquiryView serviceResult = null;
            inquiryServiceMock.Setup(x => x.GetByCustomerID(1)).ReturnsAsync(serviceResult);

            InquiryController controller = new InquiryController(inquiryServiceMock.Object);
            var responce = controller.Get(customerID, email).Result;
            var objectResponse = responce as BadRequestObjectResult;

            Assert.IsInstanceOf<BadRequestObjectResult>(responce);
        }
    }
}