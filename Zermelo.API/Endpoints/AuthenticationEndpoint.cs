using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zermelo.API.Exceptions;
using Zermelo.API.Interfaces;
using Zermelo.API.Models;
using Zermelo.API.Services.Interfaces;

namespace Zermelo.API.Endpoints
{
    /// <summary>
    /// This endpoint will help you with your authentication needs.
    /// </summary>
    /// <remarks>
    /// This endpoint does not have an equivalent at the Zermelo API, it's here only for your convenience.
    /// </remarks>
    /// <seealso cref="Authentication"/>
    /// <seealso cref="ZermeloAuthenticator"/>
    /// <seealso cref="ZermeloConnection"/>
    public class AuthenticationEndpoint : EndpointBase
    {
        internal AuthenticationEndpoint(IAuthentication auth, IUrlBuilder urlBuilder, IHttpService httpService, IJsonService jsonService)
            : base(auth, urlBuilder, httpService, jsonService)
        {    
        }

        /// <summary>
        /// Get the <see cref="Authentication"/> object that's used by the current <see cref="ZermeloConnection"/> object.
        /// The object has information about the host and the token that are used to connect to the Zermelo API.
        /// </summary>
        /// <returns>The currently used <see cref="Authentication"/> object.</returns>
        public Authentication GetAuthentication()
        {
            return _auth as Authentication;
        }

        /// <summary>
        /// Allows you to logout of the Zermelo API and invalidate the used token. This disables the current <see cref="ZermeloConnection"/>
        /// object to connect to the Zermelo API. To connect to the Zermelo API again, create a new <see cref="ZermeloConnection"/> using an
        /// <see cref="Authentication"/> object with an existing token, or a new one retrieved with an authorization code using an
        /// <see cref="ZermeloAuthenticator"/> object.
        /// </summary>
        /// <returns><c>true</c> if the logout request succeeded.</returns>
        public async Task<bool> Logout()
        {
            string url = _urlBuilder.GetAuthenticatedUrl(_auth, "oauth/logout");

            IHttpResponse httpResponse = await _httpService.PostAsync(url, "");

            if (httpResponse.StatusCode != 200)
                throw new ZermeloHttpException(httpResponse);

            return true;
        }

        public async Task<Token> GetCurrentToken()
        {
            IEnumerable<Token> tokens = await GetByCustomUrlOptionsAsync<Token>("tokens/~current", new Dictionary<string, string>());
            return tokens.Single();
        }
    }
}
