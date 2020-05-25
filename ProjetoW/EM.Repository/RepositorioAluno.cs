using System;
using EM.Domain;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EM.Repository
{
    public class RepositorioAluno : RepositorioAbstrato<Aluno>
    {
        public Aluno GetByMatricula(int matricula)
        {
            return new Aluno(12345789, "Luca", new DateTime(2000 - 01 - 25), "1", EnumeradorSexo.Masculino);
        }

        public IEnumerable<Aluno> GetByContendoNoNome(string parteDoNome)
        {
            List<Aluno> lista = new List<Aluno>();
            return lista;
        }

        
    }
}
