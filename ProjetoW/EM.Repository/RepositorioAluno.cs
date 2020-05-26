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

        public IEnumerable<Aluno> GetByContendoNoNome(string parteDoNome)
        {

            var query = from aluno in lista
                        where aluno.Nome.Contains(parteDoNome) || aluno.Nome.Contains(parteDoNome.ToLower()) || aluno.Nome.Contains(parteDoNome.ToUpper())
                        select aluno;

            return query.ToList();
        }

        
    }
}
