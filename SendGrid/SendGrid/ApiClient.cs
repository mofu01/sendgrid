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
        private readonly Uri baseUri = new Uri("https://api.sendgrid.com/");
        private readonly string mediaType = "application/json";
        private readonly string version = "v3";

        private enum Methods
        {
            GET, POST, PATCH, DELETE
        }

        public ApiClient(string apiKey)
        {
            this.apiKey = apiKey;
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
                try
                {
                    client.BaseAddress = this.baseUri;
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(this.mediaType));
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", this.apiKey);
                    //client.DefaultRequestHeaders.TryAddWithoutValidation("User-Agent", "sendgrid/" + this.version + ";csharp");

                    switch (method)
                    {
                        case Methods.GET:
                            return await client.GetAsync(endpoint);
                        case Methods.POST:
                            return await client.PostAsJsonAsync(endpoint, data);
                        case Methods.PATCH:
                            endpoint = this.baseUri + endpoint;
                            StringContent content = new StringContent(data.ToString(), Encoding.UTF8, this.mediaType);
                            HttpRequestMessage request = new HttpRequestMessage
                            {
                                Method = new HttpMethod("PATCH"),
                                RequestUri = new Uri(endpoint),
                                Content = content
                            };
                            return await client.SendAsync(request);
                        case Methods.DELETE:
                            return await client.DeleteAsync(endpoint);
                        default:
                            HttpResponseMessage response = new HttpResponseMessage();
                            response.StatusCode = HttpStatusCode.MethodNotAllowed;
                            var message = "{\"errors\":[{\"message\":\"Bad method call, supported methods are GET, POST, PATCH and DELETE\"}]}";
                            response.Content = new StringContent(message);
                            return response;
                    }
                }
                catch (Exception ex)
                {
                    HttpResponseMessage response = new HttpResponseMessage();
                    string message;
                    message = (ex is HttpRequestException) ? ".NET HttpRequestException" : ".NET Exception";
                    message = message + ", raw message: \n\n";
                    response.Content = new StringContent(message + ex.Message);
                    return response;
                }
            }
        }

        /// <param name="endpoint">Resource endpoint, do not prepend slash</param>
        /// <returns>The resulting message from the API call</returns>
        public async Task<HttpResponseMessage> Get(string endpoint)
        {
            return await RequestAsync(Methods.GET, endpoint, null);
        }

        /// <param name="endpoint">Resource endpoint, do not prepend slash</param>
        /// <param name="data">An JObject representing the resource's data</param>
        /// <returns>The resulting message from the API call</returns>
        public async Task<HttpResponseMessage> Post(string endpoint, JObject data)
        {
            return await RequestAsync(Methods.POST, endpoint, data);
        }

        /// <param name="endpoint">Resource endpoint, do not prepend slash</param>
        /// <returns>The resulting message from the API call</returns>
        public async Task<HttpResponseMessage> Delete(string endpoint, JObject data = null)
        {
            return await RequestAsync(Methods.DELETE, endpoint, data);
        }

        /// <param name="endpoint">Resource endpoint, do not prepend slash</param>
        /// <param name="data">An JObject representing the resource's data</param>
        /// <returns>The resulting message from the API call</returns>
        public async Task<HttpResponseMessage> Patch(string endpoint, JObject data)
        {
            return await RequestAsync(Methods.PATCH, endpoint, data);
        }
    }
}
