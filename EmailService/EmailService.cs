using System;
using System.IO;
using MailKit.Net.Smtp;
using MailKit.Security;
using MediTech.DataAccess;
using MimeKit;

namespace MediTech.OTP
{
    public sealed class EmailService : IDisposable
    {
        private static readonly Lazy<EmailService> _instance = new Lazy<EmailService>(() => new EmailService());

        private static string smtpEmail;
        private static string smtpPassword;
        private static string smtpServer;
        private static int smtpPort;

        private bool _disposed;

        // Private constructor to prevent instantiation
        private EmailService()
        {
            LoadConfiguration();
        }

        // Public property to get the single instance
        public static EmailService Instance => _instance.Value;


        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        // Load configuration settings using ConfigLoader
        private void LoadConfiguration()
        {
            try
            {
                smtpEmail = ConfigLoader.Instance.GetSmtpEmail();
                smtpPassword = ConfigLoader.Instance.GetSmtpPassword();
                smtpServer = ConfigLoader.Instance.GetSmtpServer();
                smtpPort = ConfigLoader.Instance.GetSmtpPort();
                Logger.Log("Configuration loaded successfully using ConfigLoader.");
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw new ApplicationException("Error loading configuration.");
            }
        }

        // Load HTML template, replace OTP and image placeholders
        private string LoadHtmlTemplate(string UserName, string pass)
        {
            try
            {
                var basePath = AppDomain.CurrentDomain.BaseDirectory;
                var filePath = Path.Combine(basePath, "EmailService", "EmailTemplate.html");
                Console.WriteLine(filePath);

                var htmlTemplate = File.ReadAllText(filePath);

                htmlTemplate = htmlTemplate.Replace("{{UserName}}", UserName);
                htmlTemplate = htmlTemplate.Replace("{{Pass}}", pass);

                var currentDateTime = DateTime.Now.ToString("MMMM dd, yyyy - hh:mm tt");
                htmlTemplate = htmlTemplate.Replace("{{DateTime}}", currentDateTime);

                return htmlTemplate;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw new ApplicationException("Error loading HTML template.");
            }
        }

        // Send email using Gmail SMTP with HTML content synchronously
        public void SendLoginDetailsToEmail(string toEmail, string UserName, string pass)
        {
            var emailMessage = new MimeMessage();
            emailMessage.From.Add(new MailboxAddress("MediTech Pharma", smtpEmail));
            emailMessage.To.Add(new MailboxAddress("", toEmail));
            emailMessage.Subject = "MediTech - Login Details";

            var emailBody = LoadHtmlTemplate(UserName, pass);
            emailMessage.Body = new TextPart("html")
            {
                Text = emailBody
            };

            using (var client = new SmtpClient())
            {
                try
                {
                    client.Connect(smtpServer, smtpPort, SecureSocketOptions.StartTls);
                    client.Authenticate(smtpEmail, smtpPassword);
                    client.Send(emailMessage);
                    Logger.Log($"Login Details sent to {toEmail}");
                    client.Disconnect(true);
                }
                catch (Exception ex)
                {
                    Logger.LogError(ex);
                    throw new ApplicationException("Error sending email.");
                }
            }
        }

        // Protected dispose method
        private void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    // Cleanup resources
                    smtpEmail = null;
                    smtpPassword = null;
                    smtpServer = null;
                }

                _disposed = true;
            }
        }

        // Finalizer in case dispose wasn't called
        ~EmailService()
        {
            Dispose(false);
        }
    }
}