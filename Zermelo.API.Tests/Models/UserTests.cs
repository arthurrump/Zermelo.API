using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Zermelo.API.Models;

namespace Zermelo.API.Tests.Models
{
    public class UserTests
    {
        #region FullName tests
        [Fact]
        public static void FullnameShouldReturnFirstnamePrefixLastname()
        {
            User test = new User() { FirstName = "Willem", Prefix = "van", LastName = "Oranje" };
            string expected = "Willem van Oranje";

            Assert.Equal(expected, test.FullName);
        }

        [Fact]
        public static void FullnameShouldReturnFirstnameLastname()
        {
            User test = new User() { FirstName = "Willem", LastName = "Oranje" };
            string expected = "Willem Oranje";

            Assert.Equal(expected, test.FullName);
        }

        [Fact]
        public static void FullnameShouldReturnFirstname()
        {
            User test = new User() { FirstName = "Willem" };
            string expected = "Willem";

            Assert.Equal(expected, test.FullName);
        }

        [Fact]
        public static void FullnameShouldReturnPrefixLastname()
        {
            User test = new User() { Prefix = "van", LastName = "Oranje" };
            string expected = "van Oranje";

            Assert.Equal(expected, test.FullName);
        }

        [Fact]
        public static void FullnameShouldReturnLastname()
        {
            User test = new User() { LastName = "Oranje" };
            string expected = "Oranje";

            Assert.Equal(expected, test.FullName);
        }
        #endregion
    }
}
