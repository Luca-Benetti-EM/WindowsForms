using System;
using EM.Domain;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace EM.Repository
{
    public abstract class RepositorioAbstrato<T> where T : IEntidade
    {
        public List<T> lista = new List<T>();
        public void Add(T objeto)
        {
            lista.Add(objeto);
        }

        public void Remove(T objeto)
        {

        }

        public void Update(T objeto) {

        }

        public IEnumerable<T> GetAll() {
            return (IEnumerable<T>)lista;
        }

        public IEnumerable<T> Get(Expression<Func<T, bool>> predicate) 
        {
            List<T> lista = new List<T>();
            return lista;
        }
    }
}
