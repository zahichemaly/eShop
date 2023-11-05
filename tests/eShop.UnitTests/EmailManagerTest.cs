using eShop.Core.Interfaces;
using eShop.Core.Managers;
using Moq;

namespace eShop.UnitTests
{
    public class EmailManagerTest
    {
        private readonly Mock<IEmailSender> _emailSenderMock;
        private readonly Mock<IAppLogger<EmailManager>> _loggerMock;

        public EmailManagerTest()
        {
            _emailSenderMock = new Mock<IEmailSender>();
            _loggerMock = new Mock<IAppLogger<EmailManager>>();
        }

        [Fact]
        public void Is_Email_Sent_If_Valid_Email_And_Not_Empty_Subject()
        {
            _emailSenderMock.Setup(x => x.SendEmail(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>())).Returns(true);
            var emailManager = new EmailManager(_emailSenderMock.Object, _loggerMock.Object);
            var actual = emailManager.TrySend("zahi@test.com", "test", "test");
            Assert.True(actual);
        }
    }
}
