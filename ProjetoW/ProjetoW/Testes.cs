﻿using System;
using EM.Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ProjetoW
{
    [TestClass]
    public class Testes_Domain
    {
        #region Testes Equals

        [TestMethod]
        public void Verifica_Acerto_Equals()
        {
            Aluno A = new Aluno(1, "A", new DateTime(), "", EnumeradorSexo.Masculino);
            Aluno B = new Aluno(1, "A", new DateTime(), "", EnumeradorSexo.Masculino);

            Assert.AreEqual(true, A.Equals(B));
        }

        [TestMethod]
        public void Verifica_Falha_Equals()
        {
            Aluno A = new Aluno(1, "A", new DateTime(), "", EnumeradorSexo.Masculino);
            Aluno B = new Aluno(1, "B", new DateTime(), "", EnumeradorSexo.Masculino);

            Assert.AreEqual(false, A.Equals(B));
        }

        #endregion

        #region Teste GetHashCode
        [TestMethod]
        public void Verifica_Acerto_GetHashCode()
        {
            Aluno A = new Aluno(1, "A", new DateTime(), "", EnumeradorSexo.Masculino);
            Aluno B = new Aluno(1, "B", new DateTime(), "", EnumeradorSexo.Masculino);

            Assert.AreEqual(true, A.GetHashCode() == B.GetHashCode());
        }

        [TestMethod]
        public void Verifica_Erro_GetHashCode()
        {
            Aluno A = new Aluno(1, "A", new DateTime(), "", EnumeradorSexo.Masculino);
            Aluno B = new Aluno(2, "A", new DateTime(), "", EnumeradorSexo.Masculino);

            Assert.AreEqual(false, A.GetHashCode() == B.GetHashCode());
        }

        #endregion

        #region Testes Matricula
        [TestMethod]
        public void Deve_Aceitar_Apenas_Numeros_Matricula()
        {
            Aluno aluno = new Aluno(123456789, "A", new DateTime(), "", EnumeradorSexo.Masculino);

            Assert.AreEqual(123456789, aluno.Matricula);
        }

        [TestMethod]
        public void Deve_Lancar_Exception_Ao_Inserir_Numeros_Fora_Do_Range_Matricula()
        {
            Assert.ThrowsException<MatriculaAlunoInvalidoException>(() => new Aluno(0, "A", new DateTime(), "", EnumeradorSexo.Masculino));
            Assert.ThrowsException<MatriculaAlunoInvalidoException>(() => new Aluno(1234567891, "A", new DateTime(), "", EnumeradorSexo.Masculino));
        }

        #endregion

        #region Testes Nome

        [TestMethod]
        public void Deve_Aceitar_Nome ()
        {
            Aluno aluno = new Aluno(123456789, "A", new DateTime(), "", EnumeradorSexo.Masculino);

            Assert.AreEqual("A", aluno.Nome);

            string nome = "A";

            for (int i = 1; i <= 99; i++)
                nome += "A";

            aluno = new Aluno(123456789, nome, new DateTime(), "", EnumeradorSexo.Masculino);

            Assert.AreEqual(nome, aluno.Nome);
        }

        [TestMethod]
        public void Deve_Lancar_Exception_Ao_Inserir_Nome_Fora_Do_Range_Nome() {

            Assert.ThrowsException<NomeAlunoInvalidoException>(() => new Aluno(123456789, "", new DateTime(), "", EnumeradorSexo.Masculino));

            string nome = "A";

            for(int i = 1; i <= 100; i++)
                nome += "A";

            Assert.ThrowsException<NomeAlunoInvalidoException>(() => new Aluno(123456789, nome, new DateTime(), "", EnumeradorSexo.Masculino));
        }

        #endregion

        #region Testes Sexo
        [TestMethod]
        public void Deve_Aceitar_Duas_Opcoes_Sexo()
        {
            Aluno aluno = new Aluno(123456789, "A", new DateTime(), "", EnumeradorSexo.Masculino);
            Assert.AreEqual(EnumeradorSexo.Masculino, aluno.Sexo);

            aluno = new Aluno(123456789, "A", new DateTime(), "", EnumeradorSexo.Feminino);
            Assert.AreEqual(EnumeradorSexo.Feminino, aluno.Sexo);
        }

        #endregion

        #region Testes Datas
        [TestMethod]
        public void Deve_Lancar_Excecao_Incorreta_Data()
        {
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => new Aluno(123456789, "A", new DateTime(99 - 99 - 9999), "", EnumeradorSexo.Feminino));
        }

        [TestMethod]
        public void Deve_Lancar_Excecao_Adiantada_Data()
        {
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => new Aluno(123456789, "A", DateTime.Today.AddDays(1), "", EnumeradorSexo.Feminino));
        }

        [TestMethod]
        public void Deve_Aceitar_Data()
        {
            Aluno aluno = new Aluno(123456789, "A", new DateTime(), "", EnumeradorSexo.Masculino);

            Assert.AreEqual(new DateTime(), aluno.Nascimento);

            aluno = new Aluno(123456789, "A", DateTime.Today, "", EnumeradorSexo.Masculino);

            Assert.AreEqual(DateTime.Today, aluno.Nascimento);
        }

        #endregion

        #region Testes CPF
        [TestMethod]
        public void Deve_Aceitar_Valido_CPF()
        {
            Aluno aluno = new Aluno(123456789, "A", new DateTime(), "412.637.180-00", EnumeradorSexo.Masculino);
            Assert.AreEqual("412.637.180-00", aluno.CPF);
        }

        [TestMethod]
        public void Deve_Aceitar_Nulo_CPF()
        {
            Aluno aluno = new Aluno(123456789, "A", new DateTime(), "", EnumeradorSexo.Masculino);
            Assert.AreEqual("", aluno.CPF);
        }

        [TestMethod]
        public void Deve_Lancar_Excecao_Invalido_CPF()
        {
            Assert.ThrowsException<CPFAlunoInvalidoException>(() => new Aluno(123456789, "A", new DateTime(), "1", EnumeradorSexo.Masculino));
        }

        #endregion
    }
}
