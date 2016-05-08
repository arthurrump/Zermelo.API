using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Zermelo.API.Services;

namespace Zermelo.API.Tests.Services
{
    public class JsonServiceTests
    {
        [Fact]
        public void ShouldDeserializeDataInResponeData()
        {
            var sut = new JsonService();
            List<TestClass> expected = new List<TestClass>
            {
                new TestClass(5),
                new TestClass(3)
            };
            string testData = "{ \"response\": { \"data\": [ { \"Number\": 5 }, { \"Number\": 3 } ] } }";

            List<TestClass> result = sut.DeserializeCollection<TestClass>(testData).ToList();

            Assert.Equal(expected.Count, result.Count);
            for (int i = 0; i < expected.Count; i++)
                Assert.Equal(expected[i].Number, result[i].Number);
        }

        [Fact]
        public void ShouldReturnValue()
        {
            var sut = new JsonService();
            string expected = "value";
            string testData = "{ \"key\": \"value\" }";

            string result = sut.GetValue<string>(testData, "key");

            Assert.Equal(expected, result);
        }
    }

    internal class TestClass
    {
        public TestClass(int number)
        {
            this.Number = number;
        }

        public int Number { get; set; }
    }
}
