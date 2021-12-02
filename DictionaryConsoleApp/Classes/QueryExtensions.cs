using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Primitives;

namespace DictionaryConsoleApp.Classes
{
    public static class QueryExtensions
    {

        /// <summary>
        /// If a key does not exists, add it else change the value
        /// </summary>
        /// <param name="context"></param>
        /// <param name="nameValues"></param>
        /// <returns></returns>
        public static string AddOrReplaceQueryParameter(this HttpContext context, params string[] nameValues)
        {
            if (nameValues.Length % 2 != 0)
            {
                throw new Exception("nameValues: has more parameters then values or more values then parameters");
            }

            var qps = new Dictionary<string, StringValues>();

            for (int index = 0; index < nameValues.Length; index += 2)
            {
                qps.Add(nameValues[index], nameValues[index + 1]);
            }

            return context.AddOrReplaceQueryParameters(qps);
        }

        public static string AddOrReplaceQueryParameters(this HttpContext context, Dictionary<string, StringValues> pvs)
        {
            var request = context.Request;
            UriBuilder uriBuilder = new UriBuilder
            {
                Scheme = request.Scheme,
                Host = request.Host.Host,
                Port = request.Host.Port ?? 50,
                Path = request.Path.ToString(),
                Query = request.QueryString.ToString()
            };

            var queryParams = QueryHelpers.ParseQuery(uriBuilder.Query);

            foreach (var (key, stringValues) in pvs)
            {
                queryParams.Remove(key);
                queryParams.Add(key, stringValues);
            }

            uriBuilder.Query = "";

            var allDictionary = queryParams
                .ToDictionary(keyValuePair =>
                    keyValuePair.Key,
                    keyValuePair => keyValuePair.Value.ToString());

            var url = QueryHelpers.AddQueryString(uriBuilder.ToString(), allDictionary);

            return url;
        }

    }
}
