using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zermelo.API.Services.Interfaces;

namespace Zermelo.API.Exceptions
{
    /// <summary>
    /// This exception gets thrown if the statuscode of an HTTP request does not indicate success.
    /// </summary>
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

        /// <summary>
        /// The statuscode of the HTTP request.
        /// </summary>
        public int StatusCode { get; private set; }

        /// <summary>
        /// The status of the HTTP request in words.
        /// </summary>
        public string Status { get; private set; }

        /// <summary>
        /// The content of the response.
        /// </summary>
        public string ResponseContent { get; private set; }
    }
}
