using Resources;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Mail;
using System.Web;

namespace Sample.Helpers
{
    public class EmailHelper
    {  
        [Serializable]
        public class SerializableMailMessage
        {
            private string From;
            private List<string> To;
            private string Subject;
            private string Body;
            private bool IsBodyHtml;
    
            public bool IsEmpty { get { return To == null; } }
    
            public static SerializableMailMessage Convert(MailMessage n)
            {
                var retval = new SerializableMailMessage { Body = n.Body, To = new List<string>(), From = n.From.Address, Subject = n.Subject, IsBodyHtml = n.IsBodyHtml };
                foreach (var to in n.To)
                    retval.To.Add(to.Address);
                return retval;
            }
    
            public static MailMessage Convert(SerializableMailMessage n)
            {
                var retval = new MailMessage { Body = n.Body, From = new MailAddress(n.From), Subject = n.Subject, IsBodyHtml = n.IsBodyHtml };
                foreach (var address in n.To)
                    retval.To.Add(address);
                return retval;
            }
        }
    }
}
