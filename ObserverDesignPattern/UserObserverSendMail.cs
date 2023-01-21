using Microsoft.Extensions.Logging;
using Observer_Design_Pattern.DAL.Entities;
using System;
using MailKit.Net.Smtp;
using Microsoft.Extensions.DependencyInjection;
using MimeKit;

namespace Observer_Design_Pattern.ObserverDesignPattern
{
    public class UserObserverSendMail : IUserObserver
    {
        private readonly IServiceProvider _serviceProvider;
        public UserObserverSendMail(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public void CreateUser(AppUser appUser)
        {
            var logger = _serviceProvider.GetRequiredService<ILogger<UserObserverSendMail>>();

            MimeMessage mimeMessage = new MimeMessage();

            MailboxAddress mailboxAddress = new MailboxAddress("Admin", "sahilrzayev200d@gmail.com");
            mimeMessage.From.Add(mailboxAddress);

            MailboxAddress mailboxAddressTo = new MailboxAddress("User", appUser.Email);
            mimeMessage.To.Add(mailboxAddressTo);

            var bodyBuilder = new BodyBuilder();
            bodyBuilder.TextBody =
                "Observer Design Pattern İndirim Mailidir, indirim oranınız %15 olarak belirlendir, indirim kodunuz: GAZIANTEP27";
            mimeMessage.Body = bodyBuilder.ToMessageBody();
            mimeMessage.Subject = "Example Market İndirim";

            SmtpClient smtpClient = new SmtpClient();
            smtpClient.Connect("smtp.gmail.com", 587, false);
            smtpClient.Authenticate("sahilrzayev200d@gmail.com", "ddbrjlnilieqxhqt");
            smtpClient.Send(mimeMessage);
            smtpClient.Disconnect(true);

            logger.LogInformation($"{appUser.Name + " " + appUser.Surname} isimli kullanıcıya indirim maili atıldı");
        }
    }
}
