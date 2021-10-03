using MimeKit;
using MailKit.Net.Smtp;
using System.Threading.Tasks;
namespace WebApplication
{
    public class EmailService
    {
        public static async Task SendEmailAsync(string email, string subject, string message)
        {
            var emailMessage = new MimeMessage();
 
            emailMessage.From.Add(new MailboxAddress("Scammed", "voxsiescammer@yandex.ru"));
            emailMessage.To.Add(new MailboxAddress("Scammed", "i.zheltikov@yandex.ru"));
            emailMessage.Subject = subject;
            emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html)
            {
                Text = message
            };
             
            using (var client = new SmtpClient())
            {
                await client.ConnectAsync("smtp.yandex.ru", 465, true);
                await client.AuthenticateAsync("voxsiescammer", "uzqhgurujjshqijr");
                await client.SendAsync(emailMessage);
 
                await client.DisconnectAsync(true);
            }
        }
    }
}