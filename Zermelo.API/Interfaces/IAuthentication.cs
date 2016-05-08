using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zermelo.API.Interfaces
{
    internal interface IAuthentication
    {
        string Host { get; }
        string Token { get; }
    }
}
