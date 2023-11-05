using eShop.Core.Entities;
using eShop.Core.Interfaces;
using eShop.Core.Managers;
using Moq;

namespace eShop.UnitTests
{
    public class PaymentManagerTest
    {
        private readonly Mock<IPaymentService> _paymentServiceMock;
        private readonly Mock<IAppLogger<PaymentManager>> _appLoggerMock;

        public PaymentManagerTest()
        {
            _paymentServiceMock = new Mock<IPaymentService>();
            _appLoggerMock = new Mock<IAppLogger<PaymentManager>>();
        }

        [Fact]
        public void Is_Amount_Deducted_From_Credit_Card()
        {
            var basket = new Basket("123");
            basket.AddItem(1, 10m, 1);
            var contact = new Contact();
            var creditCard = new CreditCard();
            creditCard.Expiration = DateTime.UtcNow.AddYears(1);
            var order = new Order(basket, contact, creditCard);

            _paymentServiceMock.Setup(x => x.ProcessPayment(It.IsAny<CreditCard>(), It.IsAny<decimal>())).Verifiable();
            _paymentServiceMock.Setup(x => x.GetHoldOfCard(It.IsAny<CreditCard>())).Returns(25m);

            var paymentManager = new PaymentManager(_paymentServiceMock.Object, _appLoggerMock.Object);
            var actual = paymentManager.ValidateAndPlaceOrder(order);
            var expected = 25m - 10m;
            Assert.Equal(expected, actual);
        }
    }
}
