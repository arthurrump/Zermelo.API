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
    public class ZermeloResponseJsonServiceTests
    {
        [Fact]
        public void ShouldDeserializeDataInResponeData()
        {
            var sut = new ZermeloResponseJsonService();
            ObservableCollection<TestClass> expected = new ObservableCollection<TestClass>
            {
                new TestClass(5),
                new TestClass(3)
            };
            string testData = "{ \"response\": { \"data\": [ { \"Number\": 5 }, { \"Number\": 3 } ] } }";

            ObservableCollection<TestClass> result = sut.DeserializeCollection<TestClass>(testData);

            Assert.Equal(expected.Count, result.Count);
            for (int i = 0; i < expected.Count; i++)
                Assert.Equal(expected[i].Number, result[i].Number);
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
