using MMInfra.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text;

namespace MMInfra.Service.SMTP
{
    public class SmtpInfra : ISmtpInfra
    {
        public MailMessage mail;
        public SmtpClient client;


        public SmtpInfra(){
            client = new System.Net.Mail.SmtpClient();
            client.Host = "smtp.gmail.com";
            client.Port = 587;
            client.EnableSsl = true;
            client.Credentials = new System.Net.NetworkCredential("mmsfinancas@gmail.com", "Mmalcateia123");
            mail = new MailMessage();
            mail.Sender = new System.Net.Mail.MailAddress("mmsfinancas@gmail.com", "MM's Financas");
            mail.From = new MailAddress("mmsfinancas@gmail.com", "MM's Financas");
        }

        public void SendMail(string mailTo, string subject, string body)
        {
            mail.To.Add(new MailAddress(mailTo));
            mail.Subject = subject;
            mail.Body = body;
            mail.IsBodyHtml = true;

            client.Send(mail);
            mail = null;
        }
    }
}
