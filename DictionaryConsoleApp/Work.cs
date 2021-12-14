using Microsoft.AspNetCore.WebUtilities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using CommonLibrary.LanguageExtensions;


namespace DictionaryConsoleApp
{
    public class Work
    {
        public static void Sample1()
        {
            Dictionary<int, string> dictionary = new ();

            dictionary.Add(1, "Vince");
            dictionary.Add(2, "James");
            dictionary.Add(3, "Dino");

            foreach (var kvp in dictionary)
            {
                Debug.WriteLine($"{kvp.Key, -4:D3}{kvp.Value}");
            }

            DateTime now = DateTime.Now;
            
            StringBuilder builder = new();

            builder.AppendLine($"{now:MM/dd/yyyy}");
            builder.AppendLine($"{Environment.UserName,-10} Hello");
            Debug.WriteLine(builder.ToString());

            try
            {
                dictionary.Add(2, "James");
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }

            int key = 1;
            if (!dictionary.ContainsKey(key))
            {
                dictionary.Add(key, "Nancy");
            }
            else
            {
                Debug.WriteLine($"{key} exists");
            }

            dictionary.TryAdd(1, "Foo");
            dictionary.TryAdd(12, "Foo");


        }

        public static void Sample2()
        {
            Dictionary<int, string> dictionary = new()
            {
                [0] = "Vince",
                [1] = "James"
            };

            for (int index = 0; index < dictionary.Count +1; index++)
            {
                Debug.WriteLine($"{dictionary[index]}");
            }
        }

        public static void Sample3()
        {
            string language = "S";

            Dictionary<string, string> queryArguments = new()
            {
                { "transId", "64440952" },
                { "lang", "E" }
            };

            if (language == "E")
            {
                queryArguments["lang"] = language;
            }

            var results = QueryHelpers
                .AddQueryString("index.html", queryArguments);

            Debug.WriteLine(results);

        }

        public static void Sample4()
        {
            Dictionary<string, string> queryArguments = new()
            {
                { "transId", "64440952" },
                { "lang", "E" }
            };

            queryArguments.RenameKey("lang", "language");
        }
    }
}
