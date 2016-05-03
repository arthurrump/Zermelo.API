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

            Assert.Equal(expected, result, new ObservableCollectionTestClassEqualityComparer());
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

    internal class ObservableCollectionTestClassEqualityComparer : IEqualityComparer<ObservableCollection<TestClass>>
    {
        public bool Equals(ObservableCollection<TestClass> x, ObservableCollection<TestClass> y)
        {
            if (x.Count != y.Count)
                return false;

            for (int i = 0; i < x.Count; i++)
                if (x[i].Number != y[i].Number)
                    return false;

            return true;
        }

        public int GetHashCode(ObservableCollection<TestClass> obj)
        {
            return obj.GetHashCode();
        }
    }
}
