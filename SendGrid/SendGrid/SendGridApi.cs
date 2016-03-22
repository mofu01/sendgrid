using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using SendGrid.Endpoints;

namespace SendGrid
{
    public class SendGridApi
    {
        private readonly ApiClient apiClient;

        /// <summary>
        /// Create a SendGrid Web API client
        /// </summary>
        /// <param name="apiKey">Personal SendGrid API Key</param>
        public SendGridApi(string apiKey)
        {
            this.apiClient = new ApiClient(apiKey);
            this.Init();
        }

        /// <summary>
        /// Create a SendGrid Web API client with username and password
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        public SendGridApi(string username, string password)
        {
            this.apiClient = new ApiClient(username, password);
            this.Init();
        }

        public Bounces Bounces { get; private set; }
        public Blocks Blocks { get; private set; }
        public InvalidEmails InvalidEmails { get; private set; }
        public SpamReports SpamReports { get; private set; }
        public Categories Categories { get; private set; }

        private void Init()
        {
            this.Bounces = new Bounces(this.apiClient);
            this.Blocks = new Blocks(this.apiClient);
            this.InvalidEmails = new InvalidEmails(this.apiClient);
            this.SpamReports = new SpamReports(this.apiClient);
            this.Categories = new Categories(this.apiClient);
        }
    }
}
