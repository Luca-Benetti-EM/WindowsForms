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
        private int _matricula;
        private string _nome;
        private DateTime _nascimento;
        public EnumeradorSexo _sexo;
        private string _cpf;

        public Aluno (int matricula, string nome, DateTime nascimento, string cpf, EnumeradorSexo sexo) {
            Matricula = matricula;
            Nome = nome;
            Nascimento = nascimento;
            CPF = cpf;
            Sexo = sexo;
        }

        public int Matricula
        {
            get 
            {
                return _matricula;
            }

            set 
            {
                _matricula = value;
            }
        }

        public string Nome
        {
            get
            {
                return _nome;
            }

            set
            {
                _nome = value;
            }
        }

        public EnumeradorSexo Sexo
        {
            get
            {
                return _sexo;
            }

            set
            {
                _sexo = value;
            }
        }

        public DateTime Nascimento
        {
            get
            {
                return _nascimento;
            }

            set
            {
                _nascimento = value;
            }
        }


        public string CPF
        {
            get
            {
                return _cpf;
            }

            set
            {
                
                if(value != "") _cpf = value;
            }
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return base.ToString();
        }


    }
}
