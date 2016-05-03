using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zermelo.API.Services.Interfaces
{
    internal interface IHttpService
    {
        Task<IHttpResponse> GetStringAsync(string requestUri);
        Task<IHttpResponse> PostAsync(string requestUri, string content);
    }

    internal interface IHttpResponse
    {
        string Response { get; }
        int StatusCode { get; }
        string Status { get; }
    }
}
