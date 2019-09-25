using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;

namespace SistemaGCD.Security
{
    public class MailService
    {
        string SMTP_SERVER = "email-smtp.us-east-1.amazonaws.com";
        string SMTP_USER = "AKIAX7HVXRTG4JVNZILW";
        string SMTP_PASS = "BDHvg0ICFiPLc/N7ByEc/hU7k46OMieRVYqnKhGxrvN+";
        string SMTP_ADDRESS = "alvarogudiel@gmail.com";

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
