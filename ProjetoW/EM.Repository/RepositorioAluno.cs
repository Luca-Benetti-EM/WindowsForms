using EM.Domain;
using System.Collections.Generic;
using System.Linq;
using EM.MetodosExtensao;

namespace EM.Repository
{
    public class RepositorioAluno : RepositorioAbstrato<Aluno>
    {
        public override void Add(Aluno objeto)
        {

        }

        public override void Remove(Aluno objeto)
        {

        }

        public override void Update(Aluno objeto)
        {

        }

        public override IEnumerable<Aluno> GetAll()
        {

        }

        public abstract IEnumerable<Aluno> Get(Expression<Func<T, bool>> predicate)
        {

        }
        public Aluno GetByMatricula(int matricula)
        {
        }

        public IEnumerable<Aluno> GetByContendoNoNome(string parteDoNome)
        {
        }

    }
}
