using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Zermelo.API.Endpoints;
using Zermelo.API.Services;

namespace Zermelo.API.Tests.Endpoints
{
    public class AppointmentsEndpointTests
    {
        [Fact]
        public static async void ShouldThrowExceptionWhenIncorrectDate()
        {
            var sut = new AppointmentsEndpoint(
                new Authentication("", ""),
                new UrlBuilder(),
                new HttpService(),
                new JsonService());

            DateTimeOffset end = new DateTimeOffset(2016, 5, 6, 17, 05, 42, TimeSpan.Zero);
            DateTimeOffset start = end.AddDays(7);

            ArgumentOutOfRangeException ex = await Assert.ThrowsAsync<ArgumentOutOfRangeException>(() => 
                sut.GetByDateAsync(start, end));

            Assert.Equal("end", ex.ParamName);
        }
    }
}
