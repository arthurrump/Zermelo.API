using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Zermelo.API.Interfaces;
using Zermelo.API.Services;

namespace Zermelo.API.Tests.Services
{
    public class UrlBuilderTests
    {
        [Fact]
        public static void ShouldBuildCorrectUrl()
        {
            UrlBuilder sut = new UrlBuilder();
            string expected = "https://host.zportal.nl/api/v3/announcements";

            string result = sut.GetUrl("host", "announcements");

            Assert.Equal(expected, result, ignoreCase: true);
        }

        [Fact]
        public static void ShouldBuildCorrectUrlWithOptions()
        {
            UrlBuilder sut = new UrlBuilder();
            string expected = "https://host.zportal.nl/api/v3/announcements?user=~me&start=startDate&end=endDate";

            string result = sut.GetUrl("host", "announcements",
                new Dictionary<string, string>
                {
                    { "user", "~me" },
                    { "start", "startDate" },
                    { "end", "endDate" }
                });

            Assert.Equal(expected, result, ignoreCase: true);
        }

        [Fact]
        public static void ShouldBuildCorrectAuthenticatedUrl()
        {
            UrlBuilder sut = new UrlBuilder();
            string expected = "https://host.zportal.nl/api/v3/announcements?access_token=token";

            string result = sut.GetAuthenticatedUrl(new TestAuthentication { Host = "host", Token = "token" }, "announcements");

            Assert.Equal(expected, result, ignoreCase: true);
        }

        [Fact]
        public static void ShouldBuildCorrectAuthenticatedUrlWithOptions()
        {
            UrlBuilder sut = new UrlBuilder();
            string expected = "https://host.zportal.nl/api/v3/announcements?user=~me&start=startDate&end=endDate&access_token=token";

            string result = sut.GetAuthenticatedUrl(new TestAuthentication { Host = "host", Token = "token" },
                "announcements",
                new Dictionary<string, string>
                {
                    { "user", "~me" },
                    { "start", "startDate" },
                    { "end", "endDate" }
                });

            Assert.Equal(expected, result, ignoreCase: true);
        }
    }

    internal class TestAuthentication : IAuthentication
    {
        public string Host { get; set; }
        public string Token { get; set; }
    }
}
