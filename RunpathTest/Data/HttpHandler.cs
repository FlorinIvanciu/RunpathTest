using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Data
{
    public class HttpHandler<T> : IHttpHandler<T> where T:class
    {
        private readonly HttpClient httpClient;

        public HttpHandler(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<IEnumerable<T>> GetResultsAsync(string endPoint)
        {
            var response = await httpClient.GetAsync(endPoint);
            var data = response.Content.ToString();
            return JsonConvert.DeserializeObject<IEnumerable<T>>(data);
        }
    }
}
