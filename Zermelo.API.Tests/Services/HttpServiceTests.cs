using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Zermelo.API.Services;

namespace Zermelo.API.Tests.Services
{
    public class HttpServiceTests
    {
        [Fact]
        public void ShouldHttpResponseConstructorConvertStatusCodeToIntAndString()
        {
            var sut = new HttpResponse("", System.Net.HttpStatusCode.Accepted);

            Assert.Equal(202, sut.StatusCode);
            Assert.Equal("Accepted", sut.Status);
        }
    }
}
