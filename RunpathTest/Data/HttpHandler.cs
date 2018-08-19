using Business;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Core.DataHttpClient
{
    public class HttpHandler<T> : IHttpHandler<T> where T:class
    {
        private readonly string endpoint;
        private readonly HttpClient _httpClient;

        public HttpHandler(string endpoint)
        {
            this._httpClient = new HttpClient();
            this.endpoint = endpoint;
        }

        public async Task<IEnumerable<T>> GetResultsAsync()
        {
            var response = await _httpClient.GetAsync(endpoint);
            var data = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<IEnumerable<T>>(data).ToList();
        }
    }
}
