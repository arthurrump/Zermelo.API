using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zermelo.API.Helpers;
using Zermelo.API.Interfaces;
using Zermelo.API.Services.Interfaces;

namespace Zermelo.API.Factories
{
    internal class AuthenticationFactory
    {
        private IUrlBuilder _urlBuilder;
        private IHttpService _httpService;
        private IJsonService _jsonService;

        internal AuthenticationFactory(IUrlBuilder urlBuilder, IHttpService httpService, IJsonService jsonService)
        {
            _urlBuilder = urlBuilder;
            _httpService = httpService;
            _jsonService = jsonService;
        }

        public async Task<IAuthentication> WithCode(string host, string code)
        {
            const string _endpoint = "oauth/token";

            code = code.RemoveAll(' ');
            host = host.Trim().ToLower();

            Dictionary<string, string> urlOptions = new Dictionary<string, string>
            {
                { "grant_type", "authorization_code" },
                { "code", code }
            };

            string url = _urlBuilder.GetUrl(host, _endpoint, urlOptions);

            IHttpResponse httpResponse = await _httpService.PostAsync(url, "");

            if (httpResponse.StatusCode != 200)
                throw new Exception($"{{ \"ErrorType\": \"HTTP\", \"HttpStatus\": \"{httpResponse.Status}\", \"HttpCode\": {httpResponse.StatusCode} }}");

            string json = httpResponse.Response;
            string token = _jsonService.GetValue<string>(json, "access_token");

            return new Authentication(host, token);
        }
    }
}
