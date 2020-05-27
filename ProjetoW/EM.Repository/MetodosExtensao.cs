using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EM.Repository
{
    public static class MetodosExtensao
    {
        public static bool CustomContains(this string source, string toCheck)
        {
            CompareInfo ci = new CultureInfo("pt-BR").CompareInfo;
            CompareOptions co = CompareOptions.IgnoreCase | CompareOptions.IgnoreNonSpace;
            return ci.IndexOf(source, toCheck, co) != -1;
        }
    }
}
