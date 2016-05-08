using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Zermelo.API.Helpers;

namespace Zermelo.API.Tests.Helpers
{
    public class StringExtensionsTests
    {
        [Fact]
        public static void ShouldRemoveAllSpaces()
        {
            string expected = "hello";
            string testData = "  h e l l o  ";

            string result = testData.RemoveAll(' ');

            Assert.Equal(expected, result);
        }
    }
}
