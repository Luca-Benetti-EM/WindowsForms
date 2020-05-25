using System;
using EM.Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ProjetoW
{
    [TestClass]
    public class Testes
    {
        [TestMethod]
        public void Deve_Aceitar_Apenas_Numeros_Matricula()
        {
            Aluno aluno = new Aluno(123456789, "Luca", new DateTime(2000 - 01 - 25), "", EnumeradorSexo.Masculino);

            Assert.AreEqual(123456789, aluno.Matricula);
        }

        [TestMethod]
        public void Deve_Aceitar_Um_Ou_100_Caracteres_Nome()
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
