using System.Text.RegularExpressions;

namespace AccessApplication.Classes
{
    public static class Extensions
    {
        public static string SplitCamelCase(this string sender)
            => Regex.Replace(Regex.Replace(sender,
                    "(\\P{Ll})(\\P{Ll}\\p{Ll})", "$1 $2"),
                "(\\p{Ll})(\\P{Ll})", "$1 $2");
    }
}