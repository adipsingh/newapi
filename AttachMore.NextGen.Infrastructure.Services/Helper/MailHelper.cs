using AttachMore.NextGen.Core.DomainModels.ApplicationSettings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace AttachMore.NextGen.Infrastructure.Services.Helper
{
    /// <summary>
    /// It will contains all the entities releated to sending a mail.
    /// </summary>
    public static class MailHelper
    {
        /// <summary>
        /// Sends the mail.
        /// </summary>
        /// <param name="toEmail">To email.</param>
        /// <param name="body">The body.</param>
        /// <param name="Subject">The subject.</param>
        /// <exception cref="Exception"></exception>
        public static string SendMail(string toEmail, string body, string Subject)
        {
            try
            {
                MailMessage msg = new MailMessage();
                msg.From = new MailAddress(MailSettings.userName);
                msg.To.Add(toEmail);
                msg.Subject = Subject;
                msg.Body = body;

                SmtpClient smt = new SmtpClient();
                smt.Host = MailSettings.smtpServer;
                System.Net.NetworkCredential ntwd = new NetworkCredential();
                ntwd.UserName = MailSettings.userName; //Your Email ID  
                ntwd.Password = MailSettings.password; // Your Password  
                smt.UseDefaultCredentials = true;
                smt.Credentials = ntwd;
                smt.Port = MailSettings.port;
                smt.EnableSsl = true;
                smt.Send(msg);
                return "Success";
            }
            catch (Exception ex)
            {
                var message = string.Format("{0} {1} {2}", ex.InnerException == null ? ex.Message : ex.InnerException.Message, Environment.NewLine, ex.StackTrace);
                throw new Exception(message);
            }
        }
    }
}
