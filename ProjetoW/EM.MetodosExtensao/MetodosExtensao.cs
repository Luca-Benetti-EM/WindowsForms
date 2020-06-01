using System.Globalization;


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
