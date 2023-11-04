using eShop.Core.Interfaces;

namespace eShop.Infrastructure.Services
{
    public class EmailSender : IEmailSender
    {
        public void SendEmail(string email, string subject, string message)
        {
            // TODO: Wire this up to actual email sending logic via SendGrid, local SMTP, etc.
        }
    }
}
