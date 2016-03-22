using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SendGrid.Common;
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

        public async Task<IEnumerable<SupressedEmail>> GetListAsync(DateTime? startTime = null, DateTime? endTime = null)
        {
            var queryString = new StringBuilder();
            queryString.Append(this.endpoint);

            if (startTime.HasValue)
            {
                queryString.AppendFormat("?start_time={0}", startTime.Value.ToUnixTimestamp());
            }

            if (endTime.HasValue)
            {
                queryString.Append(startTime.HasValue ? "&" : "?");
                queryString.AppendFormat("end_time={0}", endTime.Value.ToUnixTimestamp());
            }

            var response = await this.client.Get(queryString.ToString());
            var responseContent = await response.Content.ReadAsStringAsync();
            if (responseContent == "[]")
            {
                return null;
            }

            return JsonConvert.DeserializeObject<IEnumerable<SupressedEmail>>(responseContent);
        }

        public async Task<IEnumerable<SupressedEmail>> GetAsync(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                throw new ArgumentNullException("email");
            }

            var queryString = new StringBuilder();
            queryString.Append(this.endpoint);
            queryString.AppendFormat("/{0}", email);

            var response = await this.client.Get(queryString.ToString());
            var responseContent = await response.Content.ReadAsStringAsync();
            if (responseContent == "[]")
            {
                return null;
            }

            return JsonConvert.DeserializeObject<IEnumerable<SupressedEmail>>(responseContent);
        }

        public async Task<bool> DeleteAllAsync()
        {
            var response = await this.client.Delete(this.endpoint, JObject.Parse("{ 'delete_all' : true }"));
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
