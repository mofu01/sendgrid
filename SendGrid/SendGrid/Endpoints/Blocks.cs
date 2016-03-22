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
    public class Blocks
    {
        private readonly string endpoint = "v3/suppression/blocks";
        private readonly ApiClient client;

        /// <summary>
        /// SendGrid Blocks object.
        /// https://sendgrid.com/docs/API_Reference/Web_API_v3/blocks.html
        /// </summary>
        /// <param name="client">SendGrid Web API v3 client</param>
        public Blocks(ApiClient client)
        {
            this.client = client;
        }


        public async Task<IEnumerable<SupressedEmail>> GetListAsync(DateTime? startTime = null, DateTime? endTime = null, int? limit = null, int? offset = null)
        {
            if (limit.HasValue && limit < 1)
            {
                throw new ArgumentException("limit must be greater than 1");
            }

            if (offset.HasValue && offset < 0)
            {
                throw new ArgumentException("offset must be greater or equal 0");
            }

            var firstValueSet = false;
            var queryString = new StringBuilder();
            queryString.Append(this.endpoint);

            if (startTime.HasValue)
            {
                queryString.AppendFormat("?start_time={0}", startTime.Value.ToUnixTimestamp());
                firstValueSet = true;
            }

            if (endTime.HasValue)
            {
                queryString.Append(firstValueSet ? "&" : "?");
                queryString.AppendFormat("end_time={0}", endTime.Value.ToUnixTimestamp());
                firstValueSet = true;
            }

            if (limit.HasValue)
            {
                queryString.Append(firstValueSet ? "&" : "?");
                queryString.AppendFormat("limit={0}", limit);
                firstValueSet = true;
            }

            if (offset.HasValue)
            {
                queryString.Append(firstValueSet ? "&" : "?");
                queryString.AppendFormat("offset={0}", offset);
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
