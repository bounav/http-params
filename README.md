http-param
==========

Convienience class wrapping access to an HTTP friendly `System.Collections.Specialized.NameValueCollection` with a fluent interface.

![build status](https://ci.appveyor.com/api/projects/status/8spw3h7j1xaa1v0l?svg=true)

### Usage:

    var parameters = new HttpParams().Add("key", "value")
                                     .Add("otherKey", "otherValue")

	var url = "http://domain.com/controller/action?" + parameters.ToString();

Since the `HttpParams` wraps `System.Collections.Specialized.NameValueCollection` the values are automatically URL encoded when _ToString()_ is called..


### [Nuget](https://www.nuget.org/packages/HttpParamsUtility)

To install HTTP Params Utility, run the following command in the Package Manager Console

    PM> Install-Package HttpParamsUtility
