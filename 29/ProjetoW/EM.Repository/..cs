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
        public static BindingList<T> lista = new BindingList<T>();

        public void Add(T objeto)
        {
            lista.Add(objeto);
        }

        public void Remove(T objeto)
        {
            object cast = objeto;

            Aluno aluno = (Aluno) cast;
            RepositorioAluno repositorioAluno = new RepositorioAluno();

            object recebido = repositorioAluno.GetByMatricula(aluno.Matricula);

            lista.Remove((T)recebido);
        }

        public void Update(T objeto) {

        }

        public IEnumerable<T> GetAll() {
            return (IEnumerable<T>)lista;
        }

        public IEnumerable<T> Get(Expression<Func<T, bool>> predicate) 
        {
            List<T> lista = new List<T>();
            var query = lista.Where(predicate.Compile()).ToList();
                
            return query;
        }
    }
}
