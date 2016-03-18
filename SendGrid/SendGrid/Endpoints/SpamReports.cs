using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SendGrid.Models.ResponseEmails;

namespace SendGrid.Endpoints
{
    public class SpamReports
    {
        private readonly string endpoint = "v3/suppression/spam_reports";
        private readonly ApiClient client;

        /// <summary>
        /// SendGrid Bounces object.
        /// https://sendgrid.com/docs/API_Reference/Web_API_v3/spam_reports.html
        /// </summary>
        /// <param name="client">SendGrid Web API v3 client</param>
        public SpamReports(ApiClient client)
        {
            this.client = client;
        }

        public Task<IEnumerable<SpamEmail>> GetListAsync(DateTime? startTime = null, DateTime? EndTime = null)
        {

        }

        public Task<SpamEmail> GetAsync(string email)
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
