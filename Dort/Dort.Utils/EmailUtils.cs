using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text;

namespace Dort.Utils
{
    public static class EmailUtils
    {
        public static void SendAsync(string from, string to, string content, object parameters = null)
        {
            if(parameters != null)
            {
                foreach (var propertie in parameters.GetType().GetProperties())
                {
                    content.Replace("{{" + propertie.Name + "}}", propertie.GetValue(null).ToString());
                }
            }

            MailMessage mail = new MailMessage()
            {
                From = new MailAddress(from),
            };

            mail.To.Add(new MailAddress(to));

            
        }
    }
}
