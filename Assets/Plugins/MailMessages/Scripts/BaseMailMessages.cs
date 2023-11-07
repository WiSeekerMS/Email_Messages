using System;
using System.Net;
using System.Net.Mail;
using UnityEngine;

namespace Plugins.MailMessages.Scripts
{
    public enum SubmissionStatus
    {
        Sent, Error
    }
    
    public abstract class BaseMailMessages : MonoBehaviour
    {
        protected MailMessagesConfig _config;
        
        public async void SendEmailAsync(string subject, string body, Action<SubmissionStatus> statusAction)
        {
            if (_config == null)
            {
                Debug.LogError("There is no link to the config");
                statusAction?.Invoke(SubmissionStatus.Error);
                return;
            }
            
            var mail = new MailMessage();
            var smtpServer = new SmtpClient(_config.Host);

            try
            {
                smtpServer.Credentials = new NetworkCredential(_config.Login, _config.Password);
                smtpServer.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtpServer.UseDefaultCredentials = false;
                smtpServer.EnableSsl = _config.EnableSSL;
                smtpServer.Timeout = _config.Timeout;
                smtpServer.Port = _config.Port;

                mail.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;
                mail.From = new MailAddress(_config.FromMailAddress);

                foreach (var toMailAddress in _config.ToMailAddresses)
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