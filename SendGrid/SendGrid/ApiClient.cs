using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace SendGrid
{ 
    public class ApiClient
    {
        private readonly string apiKey;
        private readonly string username;
        private readonly string password;

        private readonly Uri baseUri = new Uri("https://api.sendgrid.com/");
        private readonly string mediaType = "application/json";

        private enum Methods
        {
            GET, POST, PATCH, DELETE
        }

        /// <summary>
        /// ApiClient constructor with api key
        /// </summary>
        /// <param name="apiKey"></param>
        public ApiClient(string apiKey)
        {
            this.apiKey = apiKey;
        }

        /// <summary>
        /// ApiClient cunstructor with username and password
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        public ApiClient(string username, string password)
        {
            this.username = username;
            this.password = password;
        }

        /// <param name="endpoint">Resource endpoint, do not prepend slash</param>
        /// <returns>The resulting message from the API call</returns>
        public Task<HttpResponseMessage> Get(string endpoint)
        {
            return this.RequestAsync(Methods.GET, endpoint, null);
        }

        /// <param name="endpoint">Resource endpoint, do not prepend slash</param>
        /// <param name="data">An JObject representing the resource's data</param>
        /// <returns>The resulting message from the API call</returns>
        public Task<HttpResponseMessage> Post(string endpoint, JObject data)
        {
            return this.RequestAsync(Methods.POST, endpoint, data);
        }

        /// <param name="endpoint">Resource endpoint, do not prepend slash</param>
        /// <returns>The resulting message from the API call</returns>
        public Task<HttpResponseMessage> Delete(string endpoint, JObject data = null)
        {
            return this.RequestAsync(Methods.DELETE, endpoint, data);
        }

        /// <param name="endpoint">Resource endpoint, do not prepend slash</param>
        /// <param name="data">An JObject representing the resource's data</param>
        /// <returns>The resulting message from the API call</returns>
        public Task<HttpResponseMessage> Patch(string endpoint, JObject data)
        {
            return this.RequestAsync(Methods.PATCH, endpoint, data);
        }

        /// <summary>
        ///     Create a client that connects to the SendGrid Web API
        /// </summary>
        /// <param name="method">HTTP verb, case-insensitive</param>
        /// <param name="endpoint">Resource endpoint, do not prepend slash</param>
        /// <param name="data">An JObject representing the resource's data</param>
        /// <returns>An asyncronous task</returns>
        private async Task<HttpResponseMessage> RequestAsync(Methods method, string endpoint, JObject data)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = this.baseUri;
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(this.mediaType));

                if (string.IsNullOrWhiteSpace(this.apiKey))
                {
                    var credentials = string.Format("{0}:{1}", this.username, this.password);
                    var toEncodeAsBytes = Portable.Text.ASCIIEncoding.ASCII.GetBytes(credentials);
                    var credentialsBase64 = System.Convert.ToBase64String(toEncodeAsBytes).TrimEnd('=').Replace('+', '-').Replace('/', '_');
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", credentialsBase64);
                }
                else
                {
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", this.apiKey);
                }

                HttpResponseMessage response = null;

                switch (method)
                {
                    case Methods.GET:
                        response = await client.GetAsync(endpoint);
                        break;
                    case Methods.POST:
                        response = await client.PostAsJsonAsync(endpoint, data);
                        break;
                    case Methods.PATCH:
                        endpoint = this.baseUri + endpoint;
                        StringContent content = new StringContent(data.ToString(), Encoding.UTF8, this.mediaType);
                        HttpRequestMessage request = new HttpRequestMessage
                        {
                            Method = new HttpMethod("PATCH"),
                            RequestUri = new Uri(endpoint),
                            Content = content
                        };
                        response = await client.SendAsync(request);
                        break;
                    case Methods.DELETE:
                        response = await client.DeleteAsync(endpoint);
                        break;
                }

                if (response.StatusCode == HttpStatusCode.Forbidden || response.StatusCode == HttpStatusCode.Unauthorized)
                {
                    throw new UnauthorizedAccessException();
                }
                else
                {
                    return response;
                }
            }
        }
    }
}
