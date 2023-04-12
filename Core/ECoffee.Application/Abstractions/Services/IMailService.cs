namespace ECoffee.Application.Abstractions.Services
{
    public interface IMailService
    {
        Task SendMailAsync(string to,string subject,string body,bool isBodyHtml = true);
        Task SendMailAsync(string[] tos,string subject,string body,bool isBodyHtml = true);
        Task WelcomeUserMailAsync(string email,string fullName);
    }
}
