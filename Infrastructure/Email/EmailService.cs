using Domain.Interfaces;

namespace Infrastructure.Email
{
    public class EmailService : IEmailService
    {
        public Task SendEmailAsync(string to, string subject, string body)
        {
            var log = $"To: {to}\nSubject: {subject}\nBody: {body}\n\n";
            File.AppendAllText("notification.txt", log);
            return Task.CompletedTask;
        }
    }
}
