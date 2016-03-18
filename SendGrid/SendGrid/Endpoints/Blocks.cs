using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SendGrid.Models;

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


        public Task<IEnumerable<SupressedEmail>> GetListAsync(DateTime? startTime = null, DateTime? EndTime = null, int? limit = null, int? offset = null)
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
