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
        public static Aluno aluno = new Aluno(1, "joao", new DateTime(2000-01-25), "", EnumeradorSexo.Masculino);
        public Aluno GetByMatricula(int matricula)
        {
            /*var query = from Aluno a in lista
                        where aluno.Matricula == matricula
                        select a;

            aluno = query.ToList()[0];*/

            for(int i = 0; i < lista.Count; i++)
            {
                if (lista[i].Matricula == matricula) return lista[i];
            }

            return aluno;
    }

        public static IEnumerable<Aluno> GetByContendoNoNome(string parteDoNome)
        {
            List<Aluno> lista = new List<Aluno>();
            return lista;
        }

        
    }
}
