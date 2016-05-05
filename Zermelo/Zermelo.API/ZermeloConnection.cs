using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zermelo.API.Endpoints;
using Zermelo.API.Factories;
using Zermelo.API.Interfaces;
using Zermelo.API.Services;
using Zermelo.API.Services.Interfaces;

namespace Zermelo.API
{
    class ZermeloConnection
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

        public ZermeloConnection(IAuthentication authentication)
        {
            InitializeServices();
            InitializeAuth(authentication);
            InitializeEndpoints();
        }

        public ZermeloConnection(string host, string code)
        {
            InitializeServices();
            InitializeAuth(host, code);
            InitializeEndpoints();
        }
        #endregion

        #region Initializers
        private void InitializeServices()
        {
            _urlBuilder = new UrlBuilder();
            _httpService = new HttpService();
            _jsonService = new JsonService();
        }

        private void InitializeAuth(IAuthentication auth)
        {
            Authentication = auth;
        }

        private async void InitializeAuth(string host, string code)
        {
            AuthenticationFactory authFactory = new AuthenticationFactory(_urlBuilder, _httpService, _jsonService);
            Authentication = await authFactory.WithCode(host, code);
        }

        private void InitializeEndpoints()
        {
            Appointments = new AppointmentsEndpoint(Authentication, _urlBuilder, _httpService, _jsonService);
            Announcements = new AnnouncementsEndpoint(Authentication, _urlBuilder, _httpService, _jsonService);
            Users = new UsersEndpoint(Authentication, _urlBuilder, _httpService, _jsonService);
        }
        #endregion

        public IAuthentication Authentication { get; private set; }

        public AppointmentsEndpoint Appointments { get; private set; }

        public AnnouncementsEndpoint Announcements { get; private set; }

        public UsersEndpoint Users { get; private set; }
    }
}
