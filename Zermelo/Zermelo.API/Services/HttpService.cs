using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Zermelo.API.Services.Interfaces;

namespace Zermelo.API.Services
{
    internal class HttpService : IHttpService
    {
        public async Task<IHttpResponse> GetAsync(string requestUri)
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(requestUri);
            string respContent = await response.Content.ReadAsStringAsync();
            return new HttpResponse(respContent, response.StatusCode);
        }

        public async Task<IHttpResponse> PostAsync(string requestUri, string content)
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.PostAsync(requestUri, new StringContent(content));
            string respContent = await response.Content.ReadAsStringAsync();
            return new HttpResponse(respContent, response.StatusCode);
        }
    }

    internal class HttpResponse : IHttpResponse
    {
        public HttpResponse(string response, HttpStatusCode status)
        {
            this.Response = response;
            this.Status = status.ToString();
            this.StatusCode = (int)status;
        }

        public string Response { get; }
        public string Status { get; }
        public int StatusCode { get; }
    }
}
