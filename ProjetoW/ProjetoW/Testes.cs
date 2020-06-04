using System;
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

            A = new Aluno(1, "A", new DateTime(), "412.637.180-00", EnumeradorSexo.Masculino);
            B = new Aluno(1, "A", new DateTime(), "", EnumeradorSexo.Masculino);

            Assert.AreEqual(true, A.Equals(B));

        }

        [TestMethod]
        public void Verifica_Falha_Equals()
        {
            Aluno A = new Aluno(1, "A", new DateTime(), "", EnumeradorSexo.Masculino);
            Aluno B = new Aluno(2, "A", new DateTime(), "", EnumeradorSexo.Masculino);

            Assert.AreEqual(false, A.Equals(B));

            A = new Aluno(1, "A", new DateTime(), "", EnumeradorSexo.Masculino);
            B = new Aluno(2, "A", new DateTime(), "412.637.180-00", EnumeradorSexo.Masculino);

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

        #region Teste ToString

        [TestMethod]
        public void Verifica_Esperado_ToString()
        {
            Aluno aluno = new Aluno(123456789, "A", new DateTime(), "412.637.180-00", EnumeradorSexo.Masculino);

            Assert.AreEqual($"Matricula: {aluno.Matricula}, Nome: {aluno.Nome}, Sexo: {aluno.Sexo}, Nascimento: {aluno.Nascimento}, CPF: {aluno.CPF}", aluno.ToString());
        }

        #endregion

    }
}
