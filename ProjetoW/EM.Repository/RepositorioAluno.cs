using EM.Domain;
using System.Collections.Generic;
using System.Linq;
using EM.MetodosExtensao;

namespace EM.Repository
{
    public class RepositorioAluno : RepositorioAbstrato<Aluno>
    {
        public Aluno GetByMatricula(int matricula)
        {
            var query = from aluno in ColecaoDeAlunos
                        where aluno.Matricula == matricula
                        select aluno;

            return query.ToList().SingleOrDefault();
    }

        public IEnumerable<Aluno> GetByContendoNoNome(string parteDoNome)
        {

            var query = from aluno in ColecaoDeAlunos
                        where aluno.Nome.ContainsTodasVariacoes(parteDoNome)
                        select aluno;

            return query.ToList();
        }

    }
}
