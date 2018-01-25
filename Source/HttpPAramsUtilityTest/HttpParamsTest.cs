using System;
using Xunit;

namespace HttpParamsUtility
{
    public class HttpParamsTest
    {
        [Fact]
        public void TestCount()
        {
            var parameters = new HttpParams();

            Assert.Equal(0, parameters.Count);

            parameters.Add("key", "value");

            Assert.Equal(1, parameters.Count);
        }

        [Fact]
        public void TestAddNameAndIntValue()
        {
            var parameters = new HttpParams();

            parameters.Add("key", 123);

            Assert.Equal(1, parameters.Count);
            Assert.Equal("key=123", parameters.ToString());
        }

        [Fact]
        public void TestAddNameAndInt64Value()
        {
            var parameters = new HttpParams();

            parameters.Add("key", (Int64)123);

            Assert.Equal(1, parameters.Count);
            Assert.Equal("key=123", parameters.ToString());
        }

        [Fact]
        public void TestAddNameValueCollection()
        {
            var otherParams = new HttpParams().Add("key", "value");

            var parameters = new HttpParams().Add("otherKey", "otherValue").Add(otherParams.ToNameValueCollection());

            Assert.Equal(2, parameters.Count);
            Assert.Equal("otherKey=otherValue&key=value", parameters.ToString());
        }

        [Fact]
        public void TestAddNameValueWhenValueNotSet()
        {
            var paramameters = new HttpParams().AddWhenSet("key1", null)
                                               .AddWhenSet("key2", string.Empty);

            Assert.Equal(0, paramameters.Count);
        }

        [Fact]
        public void TestAddNameValuewhenSet()
        {
            var parameters = new HttpParams().AddWhenSet("key", "value");

            Assert.Equal(1, parameters.Count);
            Assert.Equal("key=value", parameters.ToString());
        }

        [Fact]
        public void TestRemove()
        {
            var parameters = new HttpParams().Add("key", "value")
                                             .Add("otherKey", "otherValue")
                                             .Remove("key");

            Assert.Equal(1, parameters.Count);
            Assert.Equal("otherKey=otherValue", parameters.ToString());
        }

        [Fact]
        public void TestClear()
        {
            var parameters = new HttpParams().Add("key", "value")
                                             .Add("otherKey", "otherValue");

            parameters.Clear();

            Assert.Equal(0, parameters.Count);
        }

        [Fact]
        public void TestValuesAreUrlEncoded()
        {
            var parameters = new HttpParams().Add("url", "http://domain.com/hello/world");

            Assert.Equal("url=http%3a%2f%2fdomain.com%2fhello%2fworld", parameters.ToString());
        }
    }
}
