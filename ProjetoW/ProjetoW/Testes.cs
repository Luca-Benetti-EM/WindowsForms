using System;
using EM.Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ProjetoW
{
    [TestClass]
    public class Testes_Domain
    {

        [TestMethod]
        public void Verifica_Acerto_Equals() 
        {
            Aluno A = new Aluno(1, "", new DateTime(), "", EnumeradorSexo.Masculino);
            Aluno B = new Aluno(1, "", new DateTime(), "", EnumeradorSexo.Masculino);

            Assert.AreEqual(true, A.Equals(B));
        }

        [TestMethod]
        public void Verifica_Falha_Equals()
        {
            Aluno A = new Aluno(1, "A", new DateTime(), "A", EnumeradorSexo.Masculino);
            Aluno B = new Aluno(1, "B", new DateTime(), "B", EnumeradorSexo.Masculino);

            Assert.AreEqual(false, A.Equals(B));
        }

        [TestMethod]
        public void Deve_Aceitar_Apenas_Numeros_Matricula()
        {
            Aluno aluno = new Aluno(123456789, "", new DateTime(), "", EnumeradorSexo.Masculino);

            Assert.AreEqual(123456789, aluno.Matricula);

        }

        [TestMethod]
        public void Deve_Falhar_Ao_Inserir_Numero_0()
        {

        }

        [TestMethod]
        public void Deve_Falhar_Ao_Inserir_Mais_De_9_Digitos()
        {
            
        }

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
