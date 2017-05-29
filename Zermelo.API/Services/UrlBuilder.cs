using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zermelo.API.Interfaces;
using Zermelo.API.Services.Interfaces;

namespace Zermelo.API.Services
{
    internal class UrlBuilder : IUrlBuilder
    {
        const string _https = "https://";
        const string _baseUrl = "zportal.nl/api";
        const string _apiVersion = "v3";
        const string _accessToken = "access_token";

        public string GetAuthenticatedUrl(IAuthentication auth, string endpoint, Dictionary<string, string> options = null)
        {
            string url = GetUrl(auth.Host, endpoint, options);

            if (url.Contains("?"))
                url += "&";
            else
                url += "?";

            url += $"{_accessToken}={auth.Token}";

            return url;
        }

        public string GetUrl(string host, string endpoint, Dictionary<string, string> options = null)
        {
            string url = $"{_https}{host}.{_baseUrl}/{_apiVersion}/{endpoint}";

            if (options != null)
            {
                url += "?";

                foreach (var x in options)
                {
                    url += $"{x.Key}={x.Value}&";
                }

                url = url.TrimEnd('&');
            }

            return url;
        }
    }
}
