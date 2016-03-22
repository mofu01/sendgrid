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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="category"></param>
        /// <param name="limit"></param>
        /// <param name="offset"></param>
        /// <returns></returns>
        public async Task<IEnumerable<string>> GetAsync(string category, int? limit = null, int? offset = null)
        {
            if (string.IsNullOrWhiteSpace(category))
            {
                throw new ArgumentNullException(category);
            }

            var queryString = new StringBuilder();
            queryString.Append(this.endpoint);
            queryString.AppendFormat("?category={0}", category);

            if (limit.HasValue)
            {
                queryString.AppendFormat("&limit={1}", limit);
            }

            if (offset.HasValue)
            {
                queryString.AppendFormat("&offset={1}", limit);
            }

            var response = await this.client.Get(queryString.ToString());
            var responseContent = await response.Content.ReadAsStringAsync();

            return new List<string>();
        }
    }
}
