using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
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

        //public Task<IEnumerable<InvalidEmail>> GetListAsync(DateTime? startTime = null, DateTime? EndTime = null, int? limit = null, int? offset = null)
        //{

        //}

        //public Task<InvalidEmail> GetAsync(string email)
        //{

        //}

        public async Task<bool> DeleteAllAsync()
        {
            var response = await this.client.Delete(this.endpoint, new JObject(new { delete_all = true }));
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
