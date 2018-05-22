using System;
using MailKit.Net.Smtp;
using MimeKit;

namespace SendEmail
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                //From Address 
                string FromAddress = "fromemail@gmail.com";
                string FromAdressTitle = "Email from Llazar Gjermeni";
                //To Address 
                string ToAddress = "toemail@hotmail.com";
                string ToAdressTitle = "Client email";
                string Subject = "Sending email using this sample app";
                string BodyContent = "Using this console app to send emails from a client email. " +
                    "I am using Mimekit and Mailkit namespace for the app. ";

            //Smtp Server 
            //Outlook            smtp                      port
            //--------------------------------------------------------
            //Outlook            smtp.live.com             587
            //Yahoo              smtp.mail.yahoo.com       465
            //Yahoo mail plus    plus.smtp.mail.yahoo.com  465
            //Hotmail            smtp.live.com             465
            //Office3655         smtp.office365.com        587
            //zoho mail          smtp.zoho.com             465

            //Ensure you`ve enabled access to your account for "unreliable" sources: 
            //https://myaccount.google.com/lesssecureapps when you use smtp from google

                string SmtpServer = "smtp.gmail.com";
                //Smtp Port Number 
                int SmtpPortNumber = 587;

                var mimeMessage = new MimeMessage();
                mimeMessage.From.Add(new MailboxAddress(FromAdressTitle, FromAddress));
                mimeMessage.To.Add(new MailboxAddress(ToAdressTitle, ToAddress));
                mimeMessage.Subject = Subject;
                mimeMessage.Body = new TextPart("plain")
                {
                    Text = BodyContent

                };

                using (var client = new SmtpClient())
                {

                    client.Connect(SmtpServer, SmtpPortNumber, false);
                    // Note: only needed if the SMTP server requires authentication 
                    // Error 5.5.1 Authentication  
                    client.Authenticate("fromemail@gmail.com", "password");
                    client.Send(mimeMessage);
                    Console.WriteLine("The mail has been sent successfully !!");
                    Console.ReadLine();
                    client.Disconnect(true);

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
