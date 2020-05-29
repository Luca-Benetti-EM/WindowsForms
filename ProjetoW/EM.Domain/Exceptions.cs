using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EM.Domain
{
    public class MatriculaAlunoInvalidoException : Exception
    {
        public MatriculaAlunoInvalidoException() : base(String.Format("Matrícula deve ter pelo menos 1 e no máximo 9 dígitos")) { 
            
        }
    }

    public class NomeAlunoInvalidoException : Exception
    {
        public NomeAlunoInvalidoException() : base(String.Format("Nome deve ter pelo menos 1 e no máximo 100 caracteres")) { 
            
        }
    }
}
