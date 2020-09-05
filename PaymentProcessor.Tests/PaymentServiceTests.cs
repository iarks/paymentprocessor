using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentProcessor.Service;

namespace PaymentProcessor.Tests
{
    [TestClass]
    public class PaymentServiceTest
    {

        [TestInitialize]
        public void Setup()
        {

        }

        [TestMethod]
        public void PaymentService_CheckRulesForPayment_Success()
        {
            // This is the business logic as follows.

            var sut = new PaymentService(null, null)
                .CheckRulesForPayments(null);

            Assert.IsTrue(sut.IsSuccess);
        }
    }
}
