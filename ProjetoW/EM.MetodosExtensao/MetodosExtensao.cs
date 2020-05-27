using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EM.MetodosExtensao
{
    public static class MetodosExtensao
    {
        public static bool ContainsTodasVariacoes(this string nome, string pesquisa)
        {
            CompareInfo ci = new CultureInfo("pt-BR").CompareInfo;
            CompareOptions co = CompareOptions.IgnoreCase | CompareOptions.IgnoreNonSpace;
            return ci.IndexOf(nome, pesquisa, co) != -1;
        }
    }
}
