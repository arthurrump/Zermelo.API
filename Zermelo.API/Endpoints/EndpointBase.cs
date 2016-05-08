using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zermelo.API.Exceptions;
using Zermelo.API.Helpers;
using Zermelo.API.Interfaces;
using Zermelo.API.Services.Interfaces;

namespace Zermelo.API.Endpoints
{
    abstract public class EndpointBase
    {
        internal IAuthentication _auth;
        internal IUrlBuilder _urlBuilder;
        internal IHttpService _httpService;
        internal IJsonService _jsonService;

        internal EndpointBase(IAuthentication auth, IUrlBuilder urlBuilder, IHttpService httpService, IJsonService jsonService)
        {
            _auth = auth;
            _urlBuilder = urlBuilder;
            _httpService = httpService;
            _jsonService = jsonService;
        }

        protected async Task<IEnumerable<T>> GetByCustomUrlOptionsAsync<T>(string endpoint, 
            Dictionary<string, string> urlOptions, List<string> fields = null)
        {
            if (fields != null && fields.Any())
            {
                if (urlOptions == null)
                {
                    urlOptions = new Dictionary<string, string>();
                }

                urlOptions.Add("fields", fields.ToCommaSeperatedString()); 
            }

            string url = _urlBuilder.GetAuthenticatedUrl(_auth, endpoint, urlOptions);

            IHttpResponse httpResponse = await _httpService.GetAsync(url);

            if (httpResponse.StatusCode != 200)
                throw new ZermeloHttpException(httpResponse);

            string json = httpResponse.Response;

            return _jsonService.DeserializeCollection<T>(json);
        }
    }
}
