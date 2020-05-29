using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EM.Domain
{
    [Serializable]
    public class MatriculaAlunoInvalidoException : Exception
    {
        public MatriculaAlunoInvalidoException() : base(String.Format("Matrícula deve ter pelo menos 1 e no máximo 9 dígitos")) { 
            
        }
    }
}
