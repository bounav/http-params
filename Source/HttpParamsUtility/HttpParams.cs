using System;
using System.Collections.Specialized;
using System.Globalization;
using System.Web;

namespace HttpParamsUtility
{
    /// <summary>
    /// Convienience class wrapping access to an HTTP friendly <see cref="NameValueCollection"/> with a fluent interface.
    /// </summary>
    public class HttpParams
    {
        private readonly NameValueCollection parameters;

        /// <summary>
        /// Initializes a new instance of the <see cref="HttpParams" /> class.
        /// </summary>
        public HttpParams()
        {
            parameters = HttpUtility.ParseQueryString("");
        }

        /// <summary>
        /// Gets the number of key/value pairs contained in the NameObjectCollectionBase instance.
        /// </summary>
        /// <value>
        /// The count.
        /// </value>
        public int Count
        {
            get { return parameters.Count; }
        }

        /// <summary>
        /// Gets a <see cref="NameObjectCollectionBase.KeysCollection" /> instance that contains all the keys in the NameObjectCollectionBase instance.
        /// </summary>
        /// <value>
        /// The keys.
        /// </value>
        public virtual NameObjectCollectionBase.KeysCollection Keys
        {
            get { return parameters.Keys; }
        }

        /// <summary>
        /// Adds an entry with the specified key and value into the <see cref="NameValueCollection" /> instance.
        /// </summary>
        /// <param name="c">The nave value collection.</param>
        /// <returns></returns>
        public HttpParams Add(NameValueCollection c)
        {
            parameters.Add(c);

            return this;
        }

        /// <summary>
        /// Adds an entry with the specified key and value into the <see cref="NameValueCollection" /> instance.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="value">The int value.</param>
        /// <returns></returns>
        /// <remarks>The value is converted to a string with the <see cref="CultureInfo.InvariantCulture"/> </remarks>
        public HttpParams Add(string name, int value)
        {
            parameters.Add(name, value.ToString(CultureInfo.InvariantCulture));

            return this;
        }

        /// <summary>
        /// Adds an entry with the specified key and value into the <see cref="NameValueCollection" /> instance.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="value">The Int64 value.</param>
        /// <returns></returns>
        /// <remarks>The value is converted to a string with the <see cref="CultureInfo.InvariantCulture"/> </remarks>
        public HttpParams Add(string name, Int64 value)
        {
            parameters.Add(name, value.ToString(CultureInfo.InvariantCulture));

            return this;
        }

        /// <summary>
        /// Adds an entry with the specified key and value into the <see cref="NameValueCollection" /> instance.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public HttpParams Add(string name, string value)
        {
            parameters.Add(name, value);

            return this;
        }

        /// <summary>
        /// Adds an entry with specified key and value into to the <see cref="NameValueCollection"/> only if the value is not null or empty.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public HttpParams AddWhenSet(string name, string value)
        {
            if (!string.IsNullOrEmpty(value))
            {
                parameters.Add(name, value);
            }

            return this;
        }

        /// <summary>
        /// Removes the entries with the specified key from the NameObjectCollectionBase instance.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns></returns>
        public HttpParams Remove(string name)
        {
            parameters.Remove(name);

            return this;
        }

        /// <summary>
        /// Removes all entries from the NameObjectCollectionBase instance.
        /// </summary>
        /// <returns></returns>
        public HttpParams Clear()
        {
            parameters.Clear();

            return this;
        }

        /// <summary>
        /// Serializes this instance as HTTP friendly and encoded parameters.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            return parameters.ToString();
        }

        /// <summary>
        /// Return this instance's internal name value collection.
        /// </summary>
        /// <returns></returns>
        public NameValueCollection ToNameValueCollection()
        {
            return parameters;
        }
    }
}