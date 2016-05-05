using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zermelo.API.Interfaces;
using Zermelo.API.Helpers;
using Zermelo.API.Services.Interfaces;

namespace Zermelo.API
{
    public class Authentication : IAuthentication
    {
        public Authentication(string host, string token)
        {
            this.Host = host;
            this.Token = token;
        }

        public string Host { get; }
        public string Token { get; }
    }
}
