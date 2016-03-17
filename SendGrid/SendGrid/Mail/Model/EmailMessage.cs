using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SendGrid.Mail.Model
{
    public class EmailMessage
    {
        public IEnumerable<EmailAddress> To { get; set; }
        public IEnumerable<string> Categories { get; set; }
        public IDictionary<string, string> UniqueArguments { get; set; }
    }
}
