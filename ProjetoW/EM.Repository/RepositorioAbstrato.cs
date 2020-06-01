using System;
using EM.Domain;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace EM.Repository
{
    public abstract class RepositorioAbstrato<T> where T : IEntidade
    {
        protected List<T> ColecaoDeAlunos = new List<T>();

        public void Add(T objeto)
        {
            if (ColecaoDeAlunos.IndexOf(objeto) != -1) throw new InconsistenciaException("Matrícula ou CPF já cadastrado!");

            ColecaoDeAlunos.Add(objeto);
        }

        public void Remove(T objeto)
        {
            if (ColecaoDeAlunos.IndexOf(objeto) == -1) throw new InconsistenciaException("Aluno não existe para ser removido!");

            ColecaoDeAlunos.Remove(objeto);
        }

        public void Update(T objeto)
        {
            Remove(objeto);
            Add(objeto);
        }

        public IEnumerable<T> GetAll()
        {
            return (IEnumerable<T>)ColecaoDeAlunos;
        }

        public IEnumerable<T> Get(Expression<Func<T, bool>> predicate)
        {
            return ColecaoDeAlunos.Where(predicate.Compile());
        }
    }
}
