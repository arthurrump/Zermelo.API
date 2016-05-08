using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zermelo.API.Interfaces;

namespace Zermelo.API.Services.Interfaces
{
    internal interface IUrlBuilder
    {
        string GetAuthenticatedUrl(IAuthentication auth, string endpoint, Dictionary<string, string> options = null);
        string GetUrl(string host, string endpoint, Dictionary<string, string> options = null);
    }
}
