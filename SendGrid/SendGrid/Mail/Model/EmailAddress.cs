using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SendGrid.Mail.Model
{
    public class EmailAddress
    {
        public EmailAddressType Type { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }

        public EmailAddress() {}

        public EmailAddress(string email, EmailAddressType type, string name = null)
        {
            this.Email = email;
            this.Type = type;
            this.Name = name;
        }
    }
}
 