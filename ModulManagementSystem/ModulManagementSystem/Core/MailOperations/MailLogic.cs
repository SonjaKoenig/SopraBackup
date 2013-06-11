using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ModulManagementSystem;
using System.Net.Mail;
using System.Net;
using System.Web.UI.WebControls;
using ModulManagementSystem.Account;

namespace ModulManagementSystem.Core.MailOperations
{
    public class MailLogic
    {
        public void  SendMail(string from, string to , string subject, string body)
        {
            SmtpClient client = new SmtpClient("mail.uni-ulm.de", 587); //SMTP Server von Hotmail und Outlook. 
            client.UseDefaultCredentials = false;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;


            MailMessage mail = new MailMessage(from, to, subject, body);
            
            try
            {
                client.Credentials = new NetworkCredential("kiz basis account", "passwort");//Anmeldedaten für den SMTP Server OHNE GEHTS NICHT
                client.EnableSsl = true; //Die meisten Anbieter verlangen eine SSL-Verschlüsselung   
                
                client.Send(mail); //Senden
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }

            //if (regButton.AccessKey == "S")
            //{
            //  for (int i = 0; i < 5; i++)
            //{
            //  client.Send(mailToUser); //Senden
            //client.Send(mailToAdmin);
            //}
            //}
            //else
            //{
            
        }
    }
}