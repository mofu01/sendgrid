using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SendGrid.Endpoints
{
    public class Categories
    {
        private readonly string endpoint = "v3/categories";
        private readonly ApiClient client;

        /// <summary>
        /// SendGrid Categories object.
        /// https://sendgrid.com/docs/API_Reference/Web_API_v3/Categories/categories.html
        /// </summary>
        /// <param name="client">SendGrid Web API v3 client</param>
        public Categories(ApiClient client)
        {
            this.client = client;
        }

        public async Task<IEnumerable<string>> GetAsync(string query, int limit = 50, int offset = 0)
        {
            var query = HttpUtility.ParseQueryString(string.Empty);

            if (startTime.HasValue)
            {
                query["start_time"] = startTime.Value.Ticks.ToString();
            }

            if (endTime.HasValue)
            {
                query["end_time"] = endTime.Value.Ticks.ToString();
            }

            if (limit.HasValue && limit.Value >= 0)
            {
                query["limit"] = limit.ToString();
            }

            if (offset.HasValue && offset.Value >= 0)
            {
                query["offset"] = offset.ToString();
            }

            var response = query.Keys.Count > 0 ?
                    await this.client.Get(this.endpoint + "?" + query) :
                    await this.client.Get(this.endpoint);

            var categories = await response.Content.ReadAsAsync<IEnumerable<KeyValuePair<string, string>>>();
            return categories.Select(c => c.Value);
        }
    }
}
