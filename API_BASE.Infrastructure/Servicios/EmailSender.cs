using API_BASE.Application.Interfaces.Servicios;
using API_BASE.Application.Settings;
using AutoMapper.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace API_BASE.Infrastructure.Servicios
{
    public class EmailSender : IEmailSender
    {
        private readonly EmailSettings _settings;

        public EmailSender(IOptions<EmailSettings> options)
        {
            _settings = options.Value;
        }

        public async Task SendEmailAsync(string to, string subject, string htmlBody)
        {
            using var smtp = new SmtpClient(_settings.SmtpServer)
            {
                Port = _settings.Port,
                Credentials = new NetworkCredential(_settings.Username, _settings.Password),
                EnableSsl = _settings.EnableSsl,
            };
            var message = new MailMessage(_settings.From, to, subject, htmlBody)
            {
                IsBodyHtml = true
            };
            message.From = new MailAddress(_settings.From, _settings.DisplayName);

            await smtp.SendMailAsync(message);
        }

        public async Task SendEmailTemplateAsync(string to, string templateKey, object model)
        {
            // Debes implementar lógica para renderizar la plantilla usando ITemplateService (si lo inyectas)
            throw new NotImplementedException("Agrega lógica de plantillas según tu TemplateService");
        }
    }
}