using System;
using System.Linq;

namespace EM.Domain
{
    public enum EnumeradorSexo
    {
        Masculino = 0,
        Feminino = 1
    }

    public class Aluno : IEntidade
    {

        public int Matricula { get; set; }
        public string Nome { get; set; }

        public EnumeradorSexo Sexo { get; set; }
        public DateTime Nascimento { get; set; }
        public string CPF { get; set; }
        
        

        public Aluno(int matricula, string nome, DateTime nascimento, string cpf, EnumeradorSexo sexo)
        {
            Matricula = matricula;
            Nome = nome;
            Sexo = sexo;
            Nascimento = nascimento;
            CPF = cpf;
        }

        public Aluno ()
        {

        }

        public override bool Equals(object obj)
        {
            Aluno aluno = (Aluno) obj;

            return (Matricula == aluno.Matricula || (CPF == aluno.CPF && !string.IsNullOrEmpty(CPF)));
        }

        public override int GetHashCode()
        {
            return Matricula;
        }

        public override string ToString()
        {   
            return $@"Matricula: {Matricula}, Nome: {Nome}, Sexo: {Sexo}, Nascimento: {Nascimento}, CPF: {CPF}";
        }

    }
}
