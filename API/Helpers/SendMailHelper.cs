using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;

namespace API.Helpers
{
    public static class SendMailHelper
    {
        public static bool SendMail(string user)
        {
            try
            {
                SmtpClient SmtpServer = new SmtpClient("smtp.live.com");
                var mail = new MailMessage();
                mail.From = new MailAddress("sentfrommywebsite@hotmail.com");
                mail.To.Add("mogge182@hotmail.com");
                mail.Subject = "inloggad";
                mail.IsBodyHtml = true;
                string htmlBody;
                htmlBody = user + " har loggat in på sidan " + DateTime.Now;
                mail.Body = htmlBody;
                SmtpServer.Port = 587;
                SmtpServer.UseDefaultCredentials = false;
                SmtpServer.Credentials = new System.Net.NetworkCredential("sentfrommywebsite@hotmail.com", "#######");
                SmtpServer.EnableSsl = true;
                SmtpServer.Send(mail);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
          
        }
    }
}