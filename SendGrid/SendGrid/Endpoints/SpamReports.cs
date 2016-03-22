using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
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

        //public Task<IEnumerable<SpamEmail>> GetListAsync(DateTime? startTime = null, DateTime? EndTime = null)
        //{

        //}

        //public Task<SpamEmail> GetAsync(string email)
        //{

        //}

        public async Task<bool> DeleteAllAsync()
        {
            var response = await this.client.Delete(this.endpoint, JObject.Parse("{ delete_all : true }"));
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteListAsync(IEnumerable<string> emails)
        {
            if (emails == null || !emails.Any())
            {
                throw new ArgumentException("emails");
            }

            var response = await this.client.Delete(this.endpoint, new JObject(emails));
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteAsync(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                throw new ArgumentException("email");
            }

            var response = await this.client.Delete(this.endpoint + "/" + email);
            return response.IsSuccessStatusCode;
        }
    }
}
