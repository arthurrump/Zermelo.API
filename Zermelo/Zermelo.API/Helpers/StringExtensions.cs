using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zermelo.API.Helpers
{
    internal static class StringExtensions
    {
        public static string RemoveAll(this string s, char character)
        {
            while (s.IndexOf(character) != -1)
                s = s.Remove(s.IndexOf(character), 1);
            return s;
        }
    }
}
