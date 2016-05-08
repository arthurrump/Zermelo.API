using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zermelo.API.Services;
using Zermelo.API.Services.Interfaces;

namespace Zermelo.API.Helpers
{
    internal static class DependencyHelper
    {
        public static void Initialize(out IUrlBuilder urlBuilder, out IHttpService httpService, out IJsonService jsonService)
        {
            urlBuilder = new UrlBuilder();
            httpService = new HttpService();
            jsonService = new JsonService();
        }
    }
}
