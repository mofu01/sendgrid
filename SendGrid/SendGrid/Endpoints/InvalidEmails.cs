using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SendGrid.Models.ResponseEmails;

namespace SendGrid.Endpoints
{
    public class InvalidEmails
    {
        private readonly string endpoint = "v3/suppression/invalid_emails";
        private readonly ApiClient client;

        /// <summary>
        /// SendGrid Invalid Emails object.
        /// https://sendgrid.com/docs/API_Reference/Web_API_v3/invalid_emails.html
        /// </summary>
        /// <param name="client">SendGrid Web API v3 client</param>
        public InvalidEmails(ApiClient client)
        {
            this.client = client;
        }

        public Task<IEnumerable<InvalidEmail>> GetListAsync(DateTime? startTime = null, DateTime? EndTime = null, int? limit = null, int? offset = null)
        {

        }

        public Task<InvalidEmail> GetAsync(string email)
        {

        }

        public Task<bool> DeleteAllAsync()
        {

        }

        public Task<bool> DeleteListAsync(IEnumerable<string> emails)
        {

        }

        public Task<bool> DeleteAsync(string email)
        {

        }
    }
}
