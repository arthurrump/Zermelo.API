using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zermelo.API.Interfaces;
using Zermelo.API.Services.Interfaces;

namespace Zermelo.API.Endpoints
{
    class UsersEndpoint : EndpointBase
    {
        internal UsersEndpoint(IAuthentication auth, IUrlBuilder urlBuilder, IHttpService httpService, IJsonService jsonService)
            : base(auth, urlBuilder, httpService, jsonService)
        {

        }
    }
}
