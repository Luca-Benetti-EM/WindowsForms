﻿using System;
using System.Linq;
using EM.Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EM.Repository.Testes
{
    [TestClass]
    public class Testes_Repository
    {
        [TestMethod]
        public void Adiciona_Aluno_A_ColecaoDeAlunos()
        {
            RepositorioAluno repositorio = new RepositorioAluno();

            Aluno aluno = new Aluno(1, "A", new DateTime(25 / 01 / 2000), "", EnumeradorSexo.Masculino);

            repositorio.Add(aluno);

            var colecaoContemAluno = repositorio.GetAll().Contains(aluno);

            Assert.IsTrue(colecaoContemAluno);
        }

        [TestMethod]
        public void Adiciona_Mais_De_Um_CPF_Vazio_A_Colecao_De_Alunos()
        {
            RepositorioAluno repositorio = new RepositorioAluno();

            Aluno aluno = new Aluno(1, "A", new DateTime(2000, 01, 25), "", EnumeradorSexo.Masculino);

            repositorio.Add(aluno);

            Assert.IsTrue(repositorio.GetAll().Contains(aluno));

            aluno = new Aluno(2, "B", new DateTime(2000, 01, 20), "", EnumeradorSexo.Feminino);

            repositorio.Add(aluno);

            var segundoAlunoComCPFVazioAdicionado = repositorio.GetAll().Contains(aluno);

            Assert.IsTrue(segundoAlunoComCPFVazioAdicionado);
        }

        [TestMethod]
        public void Falha_Ao_Inserir_Mesma_Matricula()
        {
            RepositorioAluno repositorio = new RepositorioAluno();

            Aluno aluno = new Aluno(1, "A", new DateTime(25 / 01 / 2000), "", EnumeradorSexo.Masculino);

            repositorio.Add(aluno);

            aluno = new Aluno(1, "B", new DateTime(20 / 01 / 2000), "", EnumeradorSexo.Feminino);

            var ex = Assert.ThrowsException<InconsistenciaException>(() => repositorio.Add(aluno));
            Assert.AreEqual("Matrícula ou CPF já cadastrado!", ex.Message);

        }

        [TestMethod]
        public void Falha_Ao_Inserir_Mesmo_CPF()
        {
            RepositorioAluno repositorio = new RepositorioAluno();

            Aluno aluno = new Aluno(1, "A", new DateTime(25 / 01 / 2000), "412.637.180-00", EnumeradorSexo.Masculino);

            repositorio.Add(aluno);

            aluno = new Aluno(2, "B", new DateTime(20 / 01 / 2000), "412.637.180-00", EnumeradorSexo.Feminino);

            var ex = Assert.ThrowsException<InconsistenciaException>(() => repositorio.Add(aluno));
            Assert.AreEqual("Matrícula ou CPF já cadastrado!", ex.Message);
        }

        [TestMethod]
        public void Remove_Aluno_Da_ColecaoDeAlunos()
        {
            RepositorioAluno _repositorio = new RepositorioAluno();

            Aluno _aluno = new Aluno(1, "A", new DateTime(25 / 01 / 2000), "", EnumeradorSexo.Masculino);

            _repositorio.Add(_aluno);
            var colecaoContemAluno = _repositorio.GetAll().Contains(_aluno);

            Assert.IsTrue(colecaoContemAluno);

            _repositorio.Remove(_aluno);
            colecaoContemAluno = _repositorio.GetAll().Contains(_aluno);

            Assert.IsFalse(colecaoContemAluno);

        }

        [TestMethod]
        public void Atualiza_Aluno_Na_ColecaoDeAlunos()
        {
            RepositorioAluno repositorio = new RepositorioAluno();

            Aluno aluno = new Aluno(1, "A", new DateTime(25 / 01 / 2000), "", EnumeradorSexo.Masculino);

            repositorio.Add(aluno);

            aluno = new Aluno(1, "B", new DateTime(20 / 01 / 2000), "412.637.180-00", EnumeradorSexo.Feminino);

            repositorio.Update(aluno);

            Aluno alunoAtualizado = repositorio.GetByMatricula(1);

            Assert.AreEqual(alunoAtualizado.Nome, aluno.Nome);
            Assert.AreEqual(alunoAtualizado.Sexo, aluno.Sexo);
            Assert.AreEqual(alunoAtualizado.Nascimento, aluno.Nascimento);
            Assert.AreEqual(alunoAtualizado.CPF, "412.637.180-00");

        }


        [TestMethod]
        public void Retorna_ColecaoDeAlunos_De_Alunos()
        {
            RepositorioAluno repositorio = new RepositorioAluno();

            Aluno joao = new Aluno(1, "João", new DateTime(25 / 01 / 2000), "", EnumeradorSexo.Masculino);
            Aluno abraao = new Aluno(2, "Abrãao", new DateTime(25 / 01 / 2000), "", EnumeradorSexo.Masculino);
            Aluno luca = new Aluno(3, "Luca Benetti", new DateTime(25 / 01 / 2000), "", EnumeradorSexo.Masculino);

            repositorio.Add(joao);
            repositorio.Add(abraao);
            repositorio.Add(luca);

            var colecaoDeAlunos = repositorio.GetAll();

            Assert.IsTrue(colecaoDeAlunos.Contains(joao));
            Assert.IsTrue(colecaoDeAlunos.Contains(abraao));
            Assert.IsTrue(colecaoDeAlunos.Contains(luca));
        }


        [TestMethod]
        public void Retorna_Colecao_Determinada_Get()
        {
            Aluno joao = new Aluno(1, "João", new DateTime(2000, 01, 25), "", EnumeradorSexo.Feminino);
            Aluno luis = new Aluno(2, "Luis", new DateTime(2008, 01, 14), "", EnumeradorSexo.Feminino);
            Aluno abraao = new Aluno(3, "Abrãao", new DateTime(1990, 01, 01), "", EnumeradorSexo.Masculino);
            Aluno luca = new Aluno(4, "Luca Benetti", new DateTime(1990, 02, 01), "", EnumeradorSexo.Masculino);

            RepositorioAluno repositorio = new RepositorioAluno();

            repositorio.Add(joao);
            repositorio.Add(luis);
            repositorio.Add(abraao);
            repositorio.Add(luca);

            var colecaoDeAlunosFeminino = repositorio.Get(a => a.Sexo == EnumeradorSexo.Feminino);

            var colecaoDeAlunosMasculino = repositorio.Get(a => a.Sexo == EnumeradorSexo.Masculino);

            Assert.IsTrue(colecaoDeAlunosFeminino.Contains(joao));
            Assert.IsTrue(colecaoDeAlunosFeminino.Contains(luis));
            Assert.IsFalse(colecaoDeAlunosMasculino.Contains(joao));
            Assert.IsFalse(colecaoDeAlunosMasculino.Contains(luis));

            Assert.IsTrue(colecaoDeAlunosMasculino.Contains(abraao));
            Assert.IsTrue(colecaoDeAlunosMasculino.Contains(luca));
            Assert.IsFalse(colecaoDeAlunosFeminino.Contains(abraao));
            Assert.IsFalse(colecaoDeAlunosFeminino.Contains(luca));

        }

        [TestMethod]
        public void Retorna_Aluno_Pela_Matricula()
        {
            RepositorioAluno repositorio = new RepositorioAluno();

            Aluno aluno = new Aluno(1, "A", new DateTime(2000, 01, 25), "", EnumeradorSexo.Masculino);

            repositorio.Add(aluno);
            repositorio.Add(new Aluno(2, "A", new DateTime(2000, 01, 25), "", EnumeradorSexo.Masculino));

            var alunoMatricula1 = repositorio.GetByMatricula(1);
            var alunoMatricula2 = repositorio.GetByMatricula(2);

            Assert.AreEqual(aluno, alunoMatricula1);
            Assert.AreNotEqual(aluno, alunoMatricula2);

        }

        [TestMethod]
        public void Retorna_ColecaoDeAlunos_Pelo_Nome()
        {
            RepositorioAluno repositorio = new RepositorioAluno();

            Aluno joao = new Aluno(1, "João", new DateTime(2000, 01, 25), "", EnumeradorSexo.Masculino);
            Aluno abraao = new Aluno(2, "Abrãao", new DateTime(2000, 01, 25), "", EnumeradorSexo.Masculino);
            Aluno luca = new Aluno(3, "Luca Benetti", new DateTime(2000, 01, 25), "", EnumeradorSexo.Masculino);

            repositorio.Add(joao);
            repositorio.Add(abraao);
            repositorio.Add(luca);

            //Benetti
            var colecaoDeAlunosContendo_Benetti = repositorio.GetByContendoNoNome("Benetti");
            
            Assert.IsFalse(colecaoDeAlunosContendo_Benetti.Contains(joao));
            Assert.IsFalse(colecaoDeAlunosContendo_Benetti.Contains(abraao));
            Assert.IsTrue(colecaoDeAlunosContendo_Benetti.Contains(luca));

            //Joao, João, joao, jOaO
            var colecaoDeAlunosContendo_Joao = repositorio.GetByContendoNoNome("Joao");
            var colecaoDeAlunosContendo_João = repositorio.GetByContendoNoNome("João");
            var colecaoDeAlunosContendo_joao = repositorio.GetByContendoNoNome("joao");
            var colecaoDeAlunosContendo_jOaO = repositorio.GetByContendoNoNome("jOaO");


            Assert.IsTrue(colecaoDeAlunosContendo_Joao.Contains(joao)
                && colecaoDeAlunosContendo_João.Contains(joao)
                && colecaoDeAlunosContendo_joao.Contains(joao)
                && colecaoDeAlunosContendo_jOaO.Contains(joao));

            Assert.IsFalse(colecaoDeAlunosContendo_Joao.Contains(abraao)
                && colecaoDeAlunosContendo_João.Contains(abraao)
                && colecaoDeAlunosContendo_joao.Contains(abraao)
                && colecaoDeAlunosContendo_jOaO.Contains(abraao));

            Assert.IsFalse(colecaoDeAlunosContendo_Joao.Contains(luca)
                && colecaoDeAlunosContendo_João.Contains(luca)
                && colecaoDeAlunosContendo_joao.Contains(luca)
                && colecaoDeAlunosContendo_jOaO.Contains(luca));
        }

    }
}
