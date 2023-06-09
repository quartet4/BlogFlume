﻿using System.Net.Mail;
using BlogFlume.ViewModels;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit;
using SmtpClient = MailKit.Net.Smtp.SmtpClient;

namespace BlogFlume.Services;

public class EmailService : IBlogEmailSender
{
    private readonly MailSettings _mailSettings;

    public EmailService(IOptions<MailSettings> mailSettings)
    {
        _mailSettings = mailSettings.Value;
    }

    public async Task SendEmailAsync(string emailTo, string subject, string htmlMessage)
    {
        var email = new MimeMessage();
        email.Sender = MailboxAddress.Parse(_mailSettings.Mail);
        email.To.Add(MailboxAddress.Parse(emailTo));
        email.Subject = subject;

        var builder = new BodyBuilder()
        {
            HtmlBody = htmlMessage
        };

        email.Body = builder.ToMessageBody();

        using var smtp = new SmtpClient();
        await smtp.ConnectAsync(_mailSettings.Host, _mailSettings.Port, SecureSocketOptions.StartTls);
        await smtp.AuthenticateAsync(_mailSettings.Mail, _mailSettings.Password);

        await smtp.SendAsync(email);
        
        await smtp.DisconnectAsync(true);

    }

    public Task SendContactEmailAsync(string emailFrom, string name, string subject, string htmlMessage)
    {
        throw new NotImplementedException();
    }
}