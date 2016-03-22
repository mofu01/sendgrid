using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SendGrid.Common;

namespace SendGrid.Models.ResponseEmails
{
    public class ResponseEmail
    {
        public double Created { get; set; }
        public string Email { get; set; }

        public DateTime CreatedAsDateTime
        {
            get
            {
                return DateTimeExtension.UnixTimeStampToDateTime(this.Created);
            }
        }
    }
}
