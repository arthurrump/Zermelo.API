using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zermelo.API.Interfaces;
using Zermelo.API.Services.Interfaces;

namespace Zermelo.API.Endpoints
{
    abstract internal class EndpointBase
    {
        protected IAuthentication _auth;
        protected IUrlBuilder _urlBuilder;
        protected IHttpService _httpService;
        protected IJsonService _jsonService;

        protected EndpointBase(IAuthentication auth, IUrlBuilder urlBuilder, IHttpService httpService, IJsonService jsonService)
        {
            _auth = auth;
            _urlBuilder = urlBuilder;
            _httpService = httpService;
            _jsonService = jsonService;
        }

        /// <summary>
        /// The list of fields to return. Set to <c>null</c> or an empty list for defaults.
        /// </summary>
        public List<string> Fields { get; set; } = null;
    }
}
