using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SendGrid.Models.ResponseEmails
{
    public class ResponseEmail
    {
        public DateTime Created { get; set; }
        public string Email { get; set; }
    }
}
