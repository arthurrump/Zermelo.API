using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zermelo.API.Factories;
using Zermelo.API.Helpers;
using Zermelo.API.Services.Interfaces;

namespace Zermelo.API
{
    /// <summary>
    /// This class gives an object that can be used to generate an <see cref="Authentication"/> object using an authorization code.
    /// The <see cref="Authentication"/> object can than be used to connect to the Zermelo API using an <see cref="ZermeloConnection"/> object.
    /// </summary>
    /// <remarks>
    /// For more information on the authentication flow of the Zermelo API, visit the official documentation 
    /// &lt;a href="https://zermelo.atlassian.net/wiki/display/DEV/Rest+Authentication#RestAuthentication-Obtainanauthorizationcodefromtheuser"&gt;
    /// over here&lt;/a&gt;.
    /// </remarks>
    /// <example><code>
    /// ZermeloAuthenticator authenticator = new ZermeloAuthenticator();
    /// Authentication auth = await authenticator.GetAuthenticationAsync("school", "123456789123");
    /// </code></example>
    /// <seealso cref="Authentication"/>
    /// <seealso cref="ZermeloConnection"/>
    public class ZermeloAuthenticator
    {
        IUrlBuilder _urlBuilder;
        IHttpService _httpService;
        IJsonService _jsonService;

        internal ZermeloAuthenticator(IUrlBuilder urlBuilder, IHttpService httpService, IJsonService jsonService)
        {
            _urlBuilder = urlBuilder;
            _httpService = httpService;
            _jsonService = jsonService;
        }

        /// <summary>
        /// Create a new <see cref="ZermeloAuthenticator"/> object.
        /// </summary>
        /// <example><code>
        /// ZermeloAuthenticator authenticator = new ZermeloAuthenticator();
        /// </code></example>
        public ZermeloAuthenticator()
        {
            DependencyHelper.Initialize(out _urlBuilder, out _httpService, out _jsonService);
        }

        /// <summary>
        /// Get an <see cref="Authentication"/> object using an authorization code.
        /// </summary>
        /// <param name="host">The host to connect to, usually the name of the school. 
        /// If the url to get to the Zermelo Portal is https://school.zportal.nl, then 'school' is the host.</param>
        /// <param name="code">The authentication code. The user can find this code in the portal using the "Koppel App" screen.</param>
        /// <returns>An <see cref="Authentication"/> object that can be used to connect 
        /// to the Zermelo API using a <see cref="ZermeloConnection"/> object.</returns>
        /// <example><code>
        /// Authentication auth = await authenticator.GetAuthenticationAsync("school", "123456789123");
        /// </code></example>
        public async Task<Authentication> GetAuthenticationAsync(string host, string code)
        {
            AuthenticationFactory authFactory = new AuthenticationFactory(_urlBuilder, _httpService, _jsonService);
            return await authFactory.WithCode(host, code);
        }
    }
}
