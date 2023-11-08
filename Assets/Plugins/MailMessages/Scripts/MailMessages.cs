using System;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using Plugins.MailMessages.Scripts.Data;
using Plugins.MailMessages.Scripts.Enums;
using Plugins.MailMessages.Scripts.Interfaces;
using UnityEngine;

namespace Plugins.MailMessages.Scripts
{
    public class MailMessages
    {
        public async Task SendEmailAsync(IMailMessagesData data, string subject, string body, 
            Action<SubmissionStatus> statusAction)
        {
            if (data == null)
            {
                Debug.LogError("MailMessagesData is null");
                statusAction?.Invoke(SubmissionStatus.Error);
                return;
            }
            
            var mail = new MailMessage();
            var smtpServer = new SmtpClient(data.Host);

            try
            {
                smtpServer.Credentials = new NetworkCredential(data.Login, data.Password);
                smtpServer.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtpServer.UseDefaultCredentials = false;
                smtpServer.EnableSsl = data.EnableSSL;
                smtpServer.Timeout = data.Timeout;
                smtpServer.Port = data.Port;

                mail.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;
                mail.From = new MailAddress(data.FromMailAddress);

                foreach (var toMailAddress in data.ToMailAddresses)
                {
                    mail.To.Add(new MailAddress(toMailAddress));
                }
                
                mail.Subject = subject;
                mail.Body = body;

                ServicePointManager.ServerCertificateValidationCallback = delegate
                {
                    return true;
                };

                await smtpServer.SendMailAsync(mail);
            }
            catch (Exception e)
            {
                Debug.LogError(e);
                statusAction?.Invoke(SubmissionStatus.Error);
                throw;
            }
            finally
            {
                mail.Dispose();
                smtpServer.Dispose();
            }

            statusAction?.Invoke(SubmissionStatus.Sent);
        }
    }
}