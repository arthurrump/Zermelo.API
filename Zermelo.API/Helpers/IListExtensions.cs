using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zermelo.API.Helpers
{
    internal static class IListExtensions
    {
        public static string ToCommaSeperatedString<T>(this IList<T> list)
        {
            string s = "";

            foreach (T t in list)
            {
                s += t.ToString();
                s += ",";
            }

            s = s.TrimEnd(',');

            return s;
        }
    }
}
