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
        }

        [TestMethod]
        public void Verifica_Falha_Equals()
        {
            Aluno A = new Aluno(1, "A", new DateTime(), "A", EnumeradorSexo.Masculino);
            Aluno B = new Aluno(1, "B", new DateTime(), "B", EnumeradorSexo.Masculino);

            Assert.AreEqual(false, A.Equals(B));
        }

        #endregion

        #region Teste GetHashCode
        [TestMethod]
        public void Verifica_Acerto_GetHashCode()
        {
            Aluno A = new Aluno(1, "A", new DateTime(), "A", EnumeradorSexo.Masculino);
            Aluno B = new Aluno(1, "B", new DateTime(), "B", EnumeradorSexo.Masculino);

            Assert.AreEqual(true, A.GetHashCode() == B.GetHashCode());
        }

        [TestMethod]
        public void Verifica_Erro_GetHashCode()
        {
            Aluno A = new Aluno(1, "A", new DateTime(), "A", EnumeradorSexo.Masculino);
            Aluno B = new Aluno(2, "A", new DateTime(), "A", EnumeradorSexo.Masculino);

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
        public void Deve_Lancar_Exception_Ao_Inserir_Numeros_Fora_Do_Range()
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
        public void Deve_Lancar_Exception_Ao_Inserir_Nome_Fora_Do_Range() {

            Assert.ThrowsException<NomeAlunoInvalidoException>(() => new Aluno(123456789, "", new DateTime(), "", EnumeradorSexo.Masculino));

            string nome = "A";

            for(int i = 1; i <= 100; i++)
                nome += "A";

            Assert.ThrowsException<NomeAlunoInvalidoException>(() => new Aluno(123456789, nome, new DateTime(), "", EnumeradorSexo.Masculino));
        }

        #endregion

        [TestMethod]
        public void Deve_Aceitar_Duas_Opcoes_Sexo()
        {

        }

        [TestMethod]
        public void Deve_Aceitar_Apenas_Retroativas_Data()
        {

        }

        [TestMethod]
        public void Deve_Ser_Valido_Ou_Blank_CPF()
        {

        }

    }
}
