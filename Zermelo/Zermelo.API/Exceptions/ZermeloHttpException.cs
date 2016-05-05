using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zermelo.API.Services.Interfaces;

namespace Zermelo.API.Exceptions
{
    public class ZermeloHttpException : Exception
    {
        internal ZermeloHttpException(IHttpResponse httpResponse)
            : base()
        {
            SetHttpResponseProps(httpResponse);
        }

        internal ZermeloHttpException(IHttpResponse httpResponse, string message)
            : base(message)
        {
            SetHttpResponseProps(httpResponse);
        }

        internal ZermeloHttpException(IHttpResponse httpResponse, string message, Exception innerException)
            : base(message, innerException)
        {
            SetHttpResponseProps(httpResponse);
        }

        private void SetHttpResponseProps(IHttpResponse httpResponse)
        {
            this.StatusCode = httpResponse.StatusCode;
            this.Status = httpResponse.Status;
            this.ResponseContent = httpResponse.Response;
        }

        public int StatusCode { get; private set; }
        public string Status { get; private set; }
        public string ResponseContent { get; private set; }
    }
}
