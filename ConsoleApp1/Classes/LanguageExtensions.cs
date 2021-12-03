using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Classes
{
    public static class LanguageExtensions
    {
        public static string SomeMethod(this int sender) => sender switch
        {
            0 => "abc",
            1 => "def",
            _ => "123"
        };
    }
}
