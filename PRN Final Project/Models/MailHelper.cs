using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;

namespace PRN_Final_Project.Models
{
    public class MailHelper
    {
        private string v1;
        private string v2;
        private string v3;

        public MailHelper()
        {
        }

        public MailHelper(string v1, string v2, string v3)
        {
            this.v1 = v1;
            this.v2 = v2;
            this.v3 = v3;
        }

        public void SendMail(string toEmailAddress, string subject, string content)
        {
            SmtpClient client = new SmtpClient();
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.EnableSsl = true;
            client.Host = "smtp.gmail.com";
            client.Port = 587;
            // setup Smtp authentication
            System.Net.NetworkCredential credentials =
                new System.Net.NetworkCredential("oneduquiz@gmail.com", "Quizonline123123");
            client.UseDefaultCredentials = false;
            client.Credentials = credentials;
            MailMessage msg = new MailMessage();
            msg.From = new MailAddress("oneduquiz@gmail.com");
            msg.To.Add(new MailAddress(toEmailAddress));
            msg.Subject = subject;
            msg.IsBodyHtml = true;
            string mBody = string.Format(content);
            msg.Body = mBody;
            client.Send(msg);
        }
    }
}