using System;
using EM.Domain;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace EM.Repository
{
    public class RepositorioAluno : RepositorioAbstrato<Aluno>
    {
        public Aluno GetByMatricula(int matricula)
        {
            var query = from aluno in lista
                        where aluno.Matricula == matricula
                        select aluno;

            return query.ToList().SingleOrDefault();
    }

        public static IEnumerable<Aluno> GetByContendoNoNome(string parteDoNome)
        {
            List<Aluno> lista = new List<Aluno>();
            return lista;
        }

        
    }
}
