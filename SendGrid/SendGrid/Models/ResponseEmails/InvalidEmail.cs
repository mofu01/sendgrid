using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SendGrid.Models.ResponseEmails
{
    public class InvalidEmail : ResponseEmail
    {
        public string Reason { get; set; }
    }
}
