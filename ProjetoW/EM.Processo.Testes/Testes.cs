using System;
using System.Diagnostics;
using EM.Domain;
using EM.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EM.Processo.Testes
{
    [TestClass]
    public class Testes
    {
        #region Testes Matricula
        [TestMethod]
        public void Deve_Aceitar_Apenas_Numeros_Matricula()
        {
            Aluno aluno = new Aluno(123456789, "A", new DateTime(), "", EnumeradorSexo.Masculino);

            var processo = new Processo<Aluno>();

            processo.ValidaAluno(aluno);

            Assert.AreEqual(123456789, aluno.Matricula);
        }

        [TestMethod]
        public void Deve_Lancar_Exception_Ao_Inserir_Numeros_Fora_Do_Range_Matricula()
        {
            var ex = Assert.ThrowsException<EM.Repository.InconsistenciaException>(() => new Aluno(0, "A", new DateTime(), "", EnumeradorSexo.Masculino));
            Assert.AreEqual("Matrícula deve ter pelo menos 1 no máximo 9 dígitos!", ex.Message);

            ex = Assert.ThrowsException<EM.Repository.InconsistenciaException>(() => new Aluno(1234567891, "A", new DateTime(), "", EnumeradorSexo.Masculino));
            Assert.AreEqual("Matrícula deve ter pelo menos 1 no máximo 9 dígitos!", ex.Message);
        }

        #endregion

        #region Testes Nome

        [TestMethod]
        public void Deve_Aceitar_Nome()
        {
            Aluno aluno = new Aluno(123456789, "A", new DateTime(), "", EnumeradorSexo.Masculino);

            Assert.AreEqual("A", aluno.Nome);

            string nome = new string('A', 100);

            aluno = new Aluno(123456789, nome, new DateTime(), "", EnumeradorSexo.Masculino);

            Assert.AreEqual(nome, aluno.Nome);
        }

        [TestMethod]
        public void Deve_Lancar_Exception_Ao_Inserir_Nome_Fora_Do_Range_Nome()
        {

            var ex = Assert.ThrowsException<EM.Repository.InconsistenciaException>(() => new Aluno(123456789, "", new DateTime(), "", EnumeradorSexo.Masculino));
            Assert.AreEqual("Nome deve conter pelo menos 1 e no máximo 100 caracteres!", ex.Message);

            string nome = new string('A', 101);

            ex = Assert.ThrowsException<EM.Repository.InconsistenciaException>(() => new Aluno(123456789, nome, new DateTime(), "", EnumeradorSexo.Masculino));
            Assert.AreEqual("Nome deve conter pelo menos 1 e no máximo 100 caracteres!", ex.Message);
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
        public void Deve_Lancar_Excecao_Adiantada_Data()
        {
            Aluno aluno = new Aluno(123456789, "A", DateTime.Today.AddDays(1), "", EnumeradorSexo.Feminino);

            var processo = new Processo<Aluno>();

            var ex = Assert.ThrowsException<EM.Repository.InconsistenciaException>(() => processo.ValidaAluno(aluno));
            Assert.AreEqual("Data de nascimento futura inválida!", ex.Message);
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
            var processo = new Processo<Aluno>();

            var aluno = new Aluno(123456789, "A", new DateTime(), "1", EnumeradorSexo.Masculino);

            var ex = Assert.ThrowsException<EM.Repository.InconsistenciaException>(() => processo.ValidaAluno(aluno));
            Assert.AreEqual("CPF inválido!", ex.Message);
        }


        [TestMethod]
        public void Falha_Ao_Inserir_Mesma_Matricula()
        {
            RepositorioAluno repositorio = new RepositorioAluno();

            Aluno aluno = new Aluno(4, "A", new DateTime(25 / 01 / 2000), "", EnumeradorSexo.Masculino);

            repositorio.Add(aluno);

            aluno = new Aluno(4, "B", new DateTime(20 / 01 / 2000), "", EnumeradorSexo.Feminino);

            var ex = Assert.ThrowsException<InconsistenciaException>(() => repositorio.Add(aluno));
            Assert.AreEqual("Matrícula ou CPF já cadastrado!", ex.Message);

            repositorio.Remove(repositorio.GetByMatricula(4));
        }

        [TestMethod]
        public void Falha_Ao_Inserir_Mesmo_CPF()
        {
            RepositorioAluno repositorio = new RepositorioAluno();

            repositorio.Add(new Aluno(5, "A", new DateTime(25 / 01 / 2000), "412.637.180-00", EnumeradorSexo.Masculino));

            Aluno aluno = new Aluno(6, "B", new DateTime(20 / 01 / 2000), "412.637.180-00", EnumeradorSexo.Feminino);

            var ex = Assert.ThrowsException<InconsistenciaException>(() => repositorio.Add(aluno));
            Assert.AreEqual("Matrícula ou CPF já cadastrado!", ex.Message);

            repositorio.Remove(repositorio.GetByMatricula(5));
        }

        [TestMethod]
        public void Falha_Ao_Remover_Aluno_Que_Nao_Existe()
        {

            var processo = new Processo<Aluno>();

            Aluno aluno = new Aluno(1, "A", new DateTime(25 / 01 / 2000), "412.637.180-00", EnumeradorSexo.Masculino);

            var ex = Assert.ThrowsException<InconsistenciaException>(() => processo.Remove(aluno));
            Assert.AreEqual("Matrícula não cadastrada!", ex.Message);
        }

        #endregion
    }
}
