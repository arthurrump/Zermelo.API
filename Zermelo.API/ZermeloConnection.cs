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
    /// <seealso cref="ZermeloAuthenticator"/>
    /// <seealso cref="AuthenticationEndpoint"/>
    /// <seealso cref="AppointmentsEndpoint"/>
    /// <seealso cref="AnnouncementsEndpoint"/>
    /// <seealso cref="UsersEndpoint"/>
    /// <seealso cref="LocationsEndpoint"/>
    /// <seealso cref="GroupsEndpoint"/>
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

            InitializeEndpoints(authentication);
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

            InitializeEndpoints(authentication);
        }
        #endregion

        private void InitializeEndpoints(IAuthentication auth)
        {
            Authentication = new AuthenticationEndpoint(auth, _urlBuilder, _httpService, _jsonService);
            Appointments = new AppointmentsEndpoint(auth, _urlBuilder, _httpService, _jsonService);
            Announcements = new AnnouncementsEndpoint(auth, _urlBuilder, _httpService, _jsonService);
            Users = new UsersEndpoint(auth, _urlBuilder, _httpService, _jsonService);
            Locations = new LocationsEndpoint(auth, _urlBuilder, _httpService, _jsonService);
            Groups = new GroupsEndpoint(auth, _urlBuilder, _httpService, _jsonService);
        }

        /// <summary>
        /// Use this endpoint to get information about authentication.
        /// Take a look at <see cref="AuthenticationEndpoint"/> for all available methods.
        /// </summary>
        public AuthenticationEndpoint Authentication { get; private set; }

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

        /// <summary>
        /// Use this endpoint to get information about classrooms and other locations in a school.
        /// All available methods are listed in <see cref="LocationsEndpoint"/>.
        /// </summary>
        public LocationsEndpoint Locations { get; private set; }

        /// <summary>
        /// Use this endpoint to get information about groups of students.
        /// Find all available methods in <see cref="GroupsEndpoint"/>.
        /// </summary>
        public GroupsEndpoint Groups { get; private set; }
    }
}
