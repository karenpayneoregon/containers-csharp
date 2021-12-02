using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VariousUnitTestProject.Extensions
{
    public static class StringArrayExtensions
    {
        public static string[] JoinWithNulls(this string[] sender, string replacement = "(null)") =>
            sender.Select(token => string.IsNullOrWhiteSpace(token) ? replacement : token).ToArray();
    }
}
