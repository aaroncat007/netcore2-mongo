using System.Threading.Tasks;

namespace netcore2_mongodb.Services.Mailing
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string email, string subject, string message);
    }
}