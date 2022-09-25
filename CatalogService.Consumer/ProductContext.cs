using CatalogService.Consumer.Model;
using MailKit.Net.Smtp;
using MimeKit;

public class ProductContext
{
    // private readonly IEmailService _emailService;
    public ProductContext()
    {
        // _emailService = emailService;
    }

    public void Send(Products model)
    {
        var to = Guid.NewGuid().ToString("n").Substring(0, 8) + "@" +
                 Guid.NewGuid().ToString("n").Substring(0, 8) + "." +
                 Guid.NewGuid().ToString("n").Substring(0, 3);
        var subject = DateTime.Now.ToString() + " Send e-mail for " + model.Name;
        var html = subject + " Price: " + model.Price;
        Console.WriteLine(subject);
        // _emailService.Send(to, subject, html, null);

        SendEmailMessage(to, subject, html);
    }

    private void SendEmailMessage(string to, string subject, string html)
    {
        var message = new MimeMessage();
        message.From.Add(new MailboxAddress("Lucius Feeney", "lucius.feeney55@ethereal.email"));
        message.To.Add(new MailboxAddress("Chandler", to));
        message.Subject = subject;

        message.Body = new TextPart("plain")
        {
            Text = html
        };

        using (var client = new SmtpClient())
        {
            client.Connect("smtp.ethereal.email", 587, false);

            // Note: only needed if the SMTP server requires authentication
            client.Authenticate("lucius.feeney55@ethereal.email", "FwsGBgH9auZGtPya6Y");

            client.Send(message);
            client.Disconnect(true);
        }
    }
}