using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SendGrid
{
    public class SendGridApi
    {
        private readonly ApiClient apiClient;

        /// <summary>
        ///     Create a SendGrid Web API client
        /// </summary>
        /// <param name="apiKey">Personal SendGrid API Key</param>
        public SendGridApi(string apiKey)
        {
            this.apiClient = new ApiClient(apiKey);
        }



    }
}
