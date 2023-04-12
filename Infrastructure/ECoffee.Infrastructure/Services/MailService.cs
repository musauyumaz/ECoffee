using ECoffee.Application.Abstractions.Services;
using Microsoft.Extensions.Configuration;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace ECoffee.Infrastructure.Services
{
    public class MailService : IMailService
    {
        private IConfiguration _configuration;

        public MailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task SendMailAsync(string to, string subject, string body, bool isBodyHtml = true)
            => await SendMailAsync(new[] { to }, subject, body);


        public async Task SendMailAsync(string[] tos, string subject, string body, bool isBodyHtml = true)
        {
            SmtpClient smtp = new();
            smtp.Credentials = new NetworkCredential(_configuration["Mail:Username"], _configuration["Mail:Password"]);
            smtp.Port = int.Parse(_configuration["Mail:Port"]);
            smtp.EnableSsl = true;
            smtp.Host = _configuration["Mail:Host"];

            MailMessage mail = new();
            mail.IsBodyHtml = isBodyHtml;
            foreach (string to in tos)
                mail.To.Add(new MailAddress(to));
            mail.Subject = subject;
            mail.Body = body;
            mail.From = new(_configuration["Mail:Username"],"E-Coffee",Encoding.UTF8);
            await smtp.SendMailAsync(mail);
        }

        public async Task WelcomeUserMailAsync(string email, string fullName)
        {
            StringBuilder mail = new StringBuilder();
            mail.Append("Merhaba ");
            mail.Append(fullName);
            mail.Append("<br>   E-Coffee'ye hoş geldiniz! Sizinle tanışmak için çok heyecanlıyız.Hesabınızın başarıyla oluşturulduğunu ve artık siteye giriş yapabileceğinizi bildirmek istiyoruz.");
            mail.Append("<br>Unutmayın, hesabınızda birçok özellik ve avantaj sizi bekliyor.Sitedeki deneyiminizi en üst düzeye çıkarmak için tüm seçenekleri keşfetmenizi öneriyoruz.");
            mail.Append("<br>Sorularınız veya yardıma ihtiyacınız olduğunda, lütfen bizimle iletişime geçmekten çekinmeyin.Yardımcı olmaktan mutluluk duyacağız.");
            mail.Append("<br>İyi günler dileriz!<br>");
            mail.Append("<br>Saygılarımızla");
            mail.Append("<br>E-Coffee Ekibi");
            await SendMailAsync(email,"Hoşgeldiniz :)",mail.ToString());
        }
    }
}
