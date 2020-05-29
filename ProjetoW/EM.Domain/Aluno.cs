﻿using System;
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


        public Aluno (int matricula, string nome, DateTime nascimento, string cpf, EnumeradorSexo sexo) {
            if (!(matricula >= 1 && matricula <= 999999999)) throw new MatriculaAlunoInvalidoException();
            Matricula = matricula;
            Nome = nome;
            Nascimento = nascimento;
            CPF = cpf;
            Sexo = sexo;
        }

        public override bool Equals(object obj)
        {
            Aluno aluno = (Aluno) obj;

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


    }
}
