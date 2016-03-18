using System;

namespace SendGrid.Models.ResponseEmails
{
    public class SupressedEmail : InvalidEmail
    {
        public string Status { get; set; }
    }
}
