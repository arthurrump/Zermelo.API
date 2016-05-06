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

        public Authentication Authentication { get; private set; }

        public AppointmentsEndpoint Appointments { get; private set; }

        public AnnouncementsEndpoint Announcements { get; private set; }

        public UsersEndpoint Users { get; private set; }
    }
}
