using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zermelo.API.Endpoints;
using Zermelo.API.Helpers;
using Zermelo.API.Interfaces;
using Zermelo.API.Services;
using Zermelo.API.Services.Interfaces;

namespace Zermelo.API
{
    /// <summary>
    /// This class gives an object that can be used to connect to the Zermelo API.
    /// It has properties for the currently supported endpoints, that can be used to connect to the corresponding endpoint.
    /// </summary>
    /// <seealso cref="API.Authentication"/>
    /// <seealso cref="ZermeloAuthenticator"/>
    /// <seealso cref="AppointmentsEndpoint"/>
    /// <seealso cref="AnnouncementsEndpoint"/>
    /// <seealso cref="UsersEndpoint"/>
    public class ZermeloConnection
    {
        IUrlBuilder _urlBuilder;
        IHttpService _httpService;
        IJsonService _jsonService;

        #region Constructors
        internal ZermeloConnection(IAuthentication authentication, IUrlBuilder urlBuilder, IHttpService httpService, IJsonService jsonService)
        {
            _urlBuilder = urlBuilder;
            _httpService = httpService;
            _jsonService = jsonService;

            InitializeAuth(authentication);
            InitializeEndpoints();
        }

        /// <summary>
        /// Create a new ZermeloConnection.
        /// </summary>
        /// <param name="authentication">An <see cref="Authentication"/> object with a specified host and token. 
        /// This will be used to authenticate the user in the Zermelo API.
        /// An <see cref="Authentication"/> object can be retrieved using the <see cref="ZermeloAuthenticator"/> class
        /// and an authorization code.</param>
        public ZermeloConnection(Authentication authentication)
        {
            DependencyHelper.Initialize(out _urlBuilder, out _httpService, out _jsonService);
            InitializeAuth(authentication);
            InitializeEndpoints();
        }
        #endregion

        #region Initializers
        private void InitializeAuth(IAuthentication auth)
        {
            Authentication = auth as Authentication;
        }

        private void InitializeEndpoints()
        {
            Appointments = new AppointmentsEndpoint(Authentication, _urlBuilder, _httpService, _jsonService);
            Announcements = new AnnouncementsEndpoint(Authentication, _urlBuilder, _httpService, _jsonService);
            Users = new UsersEndpoint(Authentication, _urlBuilder, _httpService, _jsonService);
        }
        #endregion

        /// <summary>
        /// The <see cref="Authentication"/> object, containing the host and token that are used to communicate with the Zermelo API.
        /// </summary>
        public Authentication Authentication { get; private set; }

        /// <summary>
        /// Connects to the Appointments endpoint. Use this endpoint to get schedules. 
        /// See <see cref="AppointmentsEndpoint"/> for all available methods.
        /// </summary>
        public AppointmentsEndpoint Appointments { get; private set; }

        /// <summary>
        /// Connects to the Announcements endpoint. Use this endpoint to get information about announcements.
        /// Take a look at <see cref="AnnouncementsEndpoint"/> for all available methods.
        /// </summary>
        public AnnouncementsEndpoint Announcements { get; private set; }

        /// <summary>
        /// Connects to the Users endpoint. Use this endpoint to get information about users.
        /// See <see cref="UsersEndpoint"/> for all available methods.
        /// </summary>
        public UsersEndpoint Users { get; private set; }
    }
}
