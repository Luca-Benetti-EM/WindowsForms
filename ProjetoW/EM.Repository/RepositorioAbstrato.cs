using System;
using EM.Domain;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.ComponentModel;

namespace EM.Repository
{
    public abstract class RepositorioAbstrato<T> where T : IEntidade
    {
        protected static BindingList<T> ColecaodeAlunos = new BindingList<T>();

        public void Add(T objeto)
        {
            ColecaodeAlunos.Add(objeto);
        }

        public void Remove(T objeto)
        {
            object cast = objeto;

            Aluno aluno = (Aluno) cast;
            RepositorioAluno repositorioAluno = new RepositorioAluno();

            cast = repositorioAluno.GetByMatricula(aluno.Matricula);

            ColecaodeAlunos.Remove((T)cast);
        }

        public void Update(T objeto) {
            Remove(objeto);
            Add(objeto);
        }

        public IEnumerable<T> GetAll() {
            return (IEnumerable<T>)ColecaodeAlunos;
        }

        public IEnumerable<T> Get(Expression<Func<T, bool>> predicate) 
        {
            var query = ColecaodeAlunos.Where(predicate.Compile()).ToList();

            if(query.Count() == 0) return null;

            return query;
        }
    }
}
