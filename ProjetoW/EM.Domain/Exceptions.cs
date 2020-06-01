using System;

namespace EM.Domain
{
    public class MatriculaAlunoInvalidoException : Exception
    {
        public MatriculaAlunoInvalidoException() : base(String.Format("Matrícula deve ter pelo menos 1 e no máximo 9 dígitos"))
        {

        }
    }

    public class NomeAlunoInvalidoException : Exception
    {
        public NomeAlunoInvalidoException() : base(String.Format("Nome deve ter pelo menos 1 e no máximo 100 caracteres"))
        {

        }
    }

    public class SexoAlunoInvalidoException : Exception
    {
        public SexoAlunoInvalidoException() : base(String.Format("Sexo escolhido deve ser masculino ou feminino"))
        {

        }
    }

    public class CPFAlunoInvalidoException : Exception
    {
        public CPFAlunoInvalidoException() : base(String.Format("CPF inválido"))
        {

        }
    }

    public class MatriculaOuCPFJaCadastrados : Exception
    {
        public MatriculaOuCPFJaCadastrados() : base(String.Format("Matrícula ou CPF já cadastrados"))
        {

        }
    }

    public class AlunoNaoCadastradoException : Exception
    {
        public AlunoNaoCadastradoException() : base(String.Format("Aluno não cadastrado"))
        {

        }
    }

    
}
