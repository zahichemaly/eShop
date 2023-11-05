using eShop.Core.Entities;
using eShop.Core.Interfaces;
using eShop.Core.Managers;
using Moq;

namespace eShop.UnitTests
{
    public class NotificationManagerTest
    {
        private readonly Mock<IEmailSender> _emailSenderMock;
        private readonly Mock<IAppLogger<EmailManager>> _loggerMock;
        private readonly Mock<IRepository<User>> _userRepositoryMock;

        public NotificationManagerTest()
        {
            _emailSenderMock = new Mock<IEmailSender>();
            _loggerMock = new Mock<IAppLogger<EmailManager>>();
            _userRepositoryMock = new Mock<IRepository<User>>();
        }

        [Fact]
        public async void Emails_Never_Sent_Because_Users_Are_Empty()
        {
            _emailSenderMock.Setup(x => x.SendEmail(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>())).Returns(true);
            _userRepositoryMock.Setup(x => x.GetAllAsync()).ReturnsAsync(new List<User>());
            var notificationManager = new NotificationManager(_emailSenderMock.Object, _loggerMock.Object, _userRepositoryMock.Object);
            await notificationManager.SendEmailsToInactiveUsers();
            _emailSenderMock.Verify(x => x.SendEmail(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()), Times.Never());
        }
    }
}
