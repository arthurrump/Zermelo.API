using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Zermelo.API.Helpers;

namespace Zermelo.API.Tests.Helpers
{
    public class UnixTimeToDateTimeOffsetJsonConverterTests
    {
        [Fact]
        public static void ShouldDeserializeCorrectly()
        {
            string testData = "{ \"Date\": 42364236 }";
            TestClass expected = new TestClass
            {
                Date = UnixTimeHelpers.FromUnixTimeSeconds(42364236)
            };

            TestClass result = JsonConvert.DeserializeObject<TestClass>(testData);

            Assert.Equal(expected.Date, result.Date);
        }
    }

    internal class TestClass
    {
        [JsonConverter(typeof(UnixTimeToDateTimeOffsetJsonConverter))]
        public DateTimeOffset Date { get; set; }
    }
}
