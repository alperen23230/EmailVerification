﻿using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmailConfirmation.Helper
{
    public static class EmailHelper
    {
        public static void SendMail(string email, int Id,string GuideCode)
        {

            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("info@nootelib.com"));
            message.To.Add(new MailboxAddress(email));
            message.Body = new TextPart("html")
            {
                Text = "Hesabınızı onaylamak için aşağıdaki linke tıklayınız... <br/>" +
                "<a href='https://localhost:5001/"+GuideCode+"/"+Id+"'>Onaylama Linki<a/>"
                //Confirmation / Verification /
            };

            using (var client = new MailKit.Net.Smtp.SmtpClient())
            {
                //587
                client.Connect("srvm04.turhost.com", 587, false);
                client.Authenticate("info@nootelib.com", "Qwerty123");
                client.Send(message);
                client.Disconnect(true);
            };


        }
    }
}
