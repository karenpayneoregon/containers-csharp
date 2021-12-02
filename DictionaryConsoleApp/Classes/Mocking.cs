using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Primitives;
using Moq;

namespace DictionaryConsoleApp.Classes
{
    /// <summary>
    /// WIP
    /// </summary>
    public class Mocking
    {

        public static HttpContext httpContext()
        {
            var request = new Mock<HttpRequest>();
            
            request.Setup(x => x.Scheme).Returns("http");
            request.Setup(x => x.Host).Returns(HostString.FromUriComponent("http://tempuri.org"));
            //request.Setup(x => x.PathBase).Returns(PathString.FromUriComponent("/api"));

            HttpContext httpContext = Mock.Of<HttpContext>( _ =>
                _.Request == request.Object
            );

            

            return httpContext;
        }

        public static void Testing()
        {

            var qps = new Dictionary<string, StringValues>();

            Dictionary<string, StringValues> queryString = QueryHelpers.ParseQuery("?param1=value");

            queryString.Add("param2", "my value");
            queryString.Add("param3", "my other value");

            var context = httpContext();
            

            Debug.WriteLine(context.AddOrReplaceQueryParameters(queryString));

            string[] values = new[] { "Name", "Karen" };
            Debug.WriteLine(context.AddOrReplaceQueryParameter(values));
        }
    }
}
