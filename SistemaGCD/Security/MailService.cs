using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;

namespace SistemaGCD.Security
{
    public class MailService
    {
        string SMTP_SERVER = "smtp.gmail.com";
        string SMTP_USER = "mobile.apps.notifications@gmail.com";
        string SMTP_PASS = "s3guroDispositivo";
        string SMTP_ADDRESS = "mobile.apps.notifications@gmail.com";

        public string SendMail(string toAddress, string token)
        {
            MailMessage mail = new MailMessage();
            SmtpClient SmtpServer = new SmtpClient(SMTP_SERVER);
            //string token = Guid.NewGuid().ToString();

            mail.From = new MailAddress(SMTP_ADDRESS);
            mail.To.Add(toAddress);
            mail.Subject = "Token de ingreso Sistema De Gestion de Casos";
            mail.Body = "Este es su token de ingreso: \n " + token;
            SmtpServer.Port = 587;
            SmtpServer.Credentials = new System.Net.NetworkCredential(SMTP_USER, SMTP_PASS);
            SmtpServer.EnableSsl = true;

            SmtpServer.Send(mail);
            return "OK";
        }
    }
}
