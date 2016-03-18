using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SendGrid.Models.ResponseEmails
{
    public class SpamEmail : ResponseEmail
    {
        public string IpAddress { get; set; }
    }
}
