using System;

namespace EM.Domain
{
    public class InconsistenciaException : ApplicationException
    {
        public InconsistenciaException(string mensagem) : base(mensagem)
        {

        }
    }


    
}
