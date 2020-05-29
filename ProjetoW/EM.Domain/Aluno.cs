using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EM.Domain
{
    public enum EnumeradorSexo
    {
        Masculino,
        Feminino
    }

    public class Aluno : IEntidade
    {

        public int Matricula;
        public string Nome;
        public DateTime Nascimento;
        public string CPF;
        public EnumeradorSexo Sexo;


        public Aluno(int matricula, string nome, DateTime nascimento, string cpf, EnumeradorSexo sexo)
        {

            if (!(matricula >= 1 && matricula <= 999999999)) throw new MatriculaAlunoInvalidoException();
            Matricula = matricula;

            if ((string.IsNullOrWhiteSpace(nome) || string.IsNullOrEmpty(nome) || nome.Length > 100)) throw new NomeAlunoInvalidoException();
            Nome = nome;

            if (!(sexo == EnumeradorSexo.Feminino || sexo == EnumeradorSexo.Masculino)) throw new SexoAlunoInvalidoException();
            Sexo = sexo;

            if (nascimento.Date > DateTime.Today) throw new ArgumentOutOfRangeException();
            Nascimento = nascimento;

            if (!ValidaCPF(cpf)) throw new CPFAlunoInvalidoException();
            CPF = cpf;
        }

        public override bool Equals(object obj)
        {
            Aluno aluno = (Aluno)obj;

            return (this.Matricula == aluno.Matricula) && (this.Nome == aluno.Nome) && (this.Nascimento == aluno.Nascimento) && (this.CPF == aluno.CPF) && (this.Sexo == aluno.Sexo);
        }

        public override int GetHashCode()
        {
            return Matricula;
        }

        public override string ToString()
        {
            return base.ToString();
        }

        private bool ValidaCPF(string cpf)
        {
            if (string.IsNullOrEmpty(cpf) || string.IsNullOrWhiteSpace(cpf)) return true;
            if (cpf.Distinct().Count() <= 3) return false;
            int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            string tempCpf;
            string digito;
            int soma;
            int resto;
            cpf = cpf.Trim();
            cpf = cpf.Replace(".", "").Replace("-", "");
            if (cpf.Length != 11)
                return false;
            tempCpf = cpf.Substring(0, 9);
            soma = 0;

            for (int i = 0; i < 9; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = resto.ToString();
            tempCpf = tempCpf + digito;
            soma = 0;
            for (int i = 0; i < 10; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = digito + resto.ToString();
            return cpf.EndsWith(digito);
        }
    }
}
