using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Zermelo.API.Helpers;

namespace Zermelo.API.Tests.Helpers
{
    public class UnixTimeHelpersTests
    {
        [Fact]
        public static void ShouldConvertFromUnixTimeSeconds()
        {
            long testData = 1462118860;
            DateTimeOffset expected = new DateTimeOffset(2016, 5, 1, 16, 7, 40, new TimeSpan(0));

            DateTimeOffset result = UnixTimeHelpers.FromUnixTimeSeconds(testData);

            Assert.Equal(expected, result);
        }

        [Fact]
        public static void ShouldConvertToUnixTimeSeconds()
        {
            DateTimeOffset testData = new DateTimeOffset(2016, 5, 1, 16, 7, 40, new TimeSpan(0));
            long expected = 1462118860;

            long result = UnixTimeHelpers.ToUnixTimeSeconds(testData);

            Assert.Equal(expected, result);
        }

        [Fact]
        public static void ShouldConvertFromUnixTimeMilliseconds()
        {
            long testData = 1462118860000;
            DateTimeOffset expected = new DateTimeOffset(2016, 5, 1, 16, 7, 40, new TimeSpan(0));

            DateTimeOffset result = UnixTimeHelpers.FromUnixTimeMilliseconds(testData);

            Assert.Equal(expected, result);
        }

        [Fact]
        public static void ShouldConvertToUnixTimeMilliseconds()
        {
            DateTimeOffset testData = new DateTimeOffset(2016, 5, 1, 16, 7, 40, new TimeSpan(0));
            long expected = 1462118860000;

            long result = UnixTimeHelpers.ToUnixTimeMilliseconds(testData);

            Assert.Equal(expected, result);
        }
    }
}
