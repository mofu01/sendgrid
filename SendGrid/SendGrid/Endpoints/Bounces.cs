using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SendGrid.Models;
using SendGrid.Models.ResponseEmails;

namespace SendGrid.Endpoints
{
    public class Bounces
    {
        private readonly string endpoint = "v3/suppression/bounces";
        private readonly ApiClient client;

        /// <summary>
        /// SendGrid Bounces object.
        /// https://sendgrid.com/docs/API_Reference/Web_API_v3/bounces.html
        /// </summary>
        /// <param name="client">SendGrid Web API v3 client</param>
        public Bounces(ApiClient client)
        {
            this.client = client;
        }

        public Task<IEnumerable<SupressedEmail>> GetListAsync(DateTime? startTime = null, DateTime? EndTime = null)
        {

        }

        public Task<SupressedEmail> GetAsync(string email)
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
