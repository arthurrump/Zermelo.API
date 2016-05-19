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
    /// <summary>
    /// A class containing the information used to authenticate a user at the Zermelo API.
    /// To create an <see cref="Authentication"/> object using an authorization code, use the <see cref="ZermeloAuthenticator"/> class.
    /// If you already have a token, you can use the constructor to create an <see cref="Authentication"/> object.
    /// </summary>
    /// <seealso cref="ZermeloAuthenticator"/>
    public class Authentication : IAuthentication
    {
        public Authentication(string host, string token)
        {
            this.Host = host;
            this.Token = token;
        }

        /// <summary>
        /// The host to connect to, usually the name of the school. 
        /// If the url to get to the Zermelo Portal is https://school.zportal.nl, then 'school' is the host.
        /// </summary>
        public string Host { get; }

        /// <summary>
        /// The token that is used to identify the user at the Zermelo API.
        /// </summary>
        public string Token { get; }
    }
}
