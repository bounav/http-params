using System;
using NUnit.Framework;

namespace HttpParamsUtility
{
    [TestFixture]
    public class HttpParamsTest
    {
        [Test]
        public void TestCount()
        {
            var parameters = new HttpParams();

            Assert.AreEqual(0, parameters.Count);

            parameters.Add("key", "value");

            Assert.AreEqual(1, parameters.Count);
        }

        [Test]
        public void TestAddNameAndIntValue()
        {
            var parameters = new HttpParams();

            parameters.Add("key", 123);

            Assert.AreEqual(1, parameters.Count);
            Assert.AreEqual("key=123", parameters.ToString());
        }

        [Test]
        public void TestAddNameAndInt64Value()
        {
            var parameters = new HttpParams();

            parameters.Add("key", (Int64)123);

            Assert.AreEqual(1, parameters.Count);
            Assert.AreEqual("key=123", parameters.ToString());
        }

        [Test]
        public void TestAddNameValueCollection()
        {
            var otherParams = new HttpParams().Add("key", "value");

            var parameters = new HttpParams().Add("otherKey", "otherValue").Add(otherParams.ToNameValueCollection());

            Assert.AreEqual(2, parameters.Count);
            Assert.AreEqual("otherKey=otherValue&key=value", parameters.ToString());
        }

        [Test]
        public void TestAddNameValueWhenValueNotSet()
        {
            var paramameters = new HttpParams().AddWhenSet("key1", null)
                                               .AddWhenSet("key2", string.Empty);

            Assert.AreEqual(0, paramameters.Count);
        }

        [Test]
        public void TestAddNameValuewhenSet()
        {
            var parameters = new HttpParams().AddWhenSet("key", "value");

            Assert.AreEqual(1, parameters.Count);
            Assert.AreEqual("key=value", parameters.ToString());
        }

        [Test]
        public void TestRemove()
        {
            var parameters = new HttpParams().Add("key", "value")
                                             .Add("otherKey", "otherValue")
                                             .Remove("key");

            Assert.AreEqual(1, parameters.Count);
            Assert.AreEqual("otherKey=otherValue", parameters.ToString());
        }

        [Test]
        public void TestClear()
        {
            var parameters = new HttpParams().Add("key", "value")
                                             .Add("otherKey", "otherValue");

            parameters.Clear();

            Assert.AreEqual(0, parameters.Count);
        }

        [Test]
        public void TestValuesAreUrlEncoded()
        {
            var parameters = new HttpParams().Add("url", "http://domain.com/hello/world");

            Assert.AreEqual("url=http%3a%2f%2fdomain.com%2fhello%2fworld", parameters.ToString());
        }
    }
}
