using System;
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
            RepositorioAluno _repositorio = new RepositorioAluno();

            Aluno _aluno = new Aluno(1, "A", new DateTime(25/01/2000), "", EnumeradorSexo.Masculino);

            _repositorio.Add(_aluno);

            Assert.IsTrue(_repositorio.GetAll().Contains(_aluno));
        }

        [TestMethod]
        public void Falha_Ao_Inserir_Mesma_Matricula()
        {
            RepositorioAluno _repositorio = new RepositorioAluno();

            Aluno _aluno = new Aluno(1, "A", new DateTime(25 / 01 / 2000), "", EnumeradorSexo.Masculino);

            _repositorio.Add(_aluno);

            _aluno = new Aluno(1, "B", new DateTime(20 / 01 / 2000), "", EnumeradorSexo.Feminino);

            Assert.ThrowsException<MatriculaOuCPFJaCadastrados>(() => _repositorio.Add(_aluno));

        }

        [TestMethod]
        public void Aceita_CPF_Vazio()
        {
            RepositorioAluno _repositorio = new RepositorioAluno();

            Aluno _aluno = new Aluno(1, "A", new DateTime(25 / 01 / 2000), "", EnumeradorSexo.Masculino);

            _repositorio.Add(_aluno);

            Assert.IsTrue(_repositorio.GetAll().Contains(_aluno));

            _aluno = new Aluno(2, "B", new DateTime(20 / 01 / 2000), "", EnumeradorSexo.Feminino);

            _repositorio.Add(_aluno);

            Assert.IsTrue(_repositorio.GetAll().Contains(_aluno));
        }

        [TestMethod]
        public void Falha_Ao_Inserir_Mesmo_CPF()
        {
            RepositorioAluno _repositorio = new RepositorioAluno();

            Aluno _aluno = new Aluno(1, "A", new DateTime(25 / 01 / 2000), "412.637.180-00", EnumeradorSexo.Masculino);

            _repositorio.Add(_aluno);

            _aluno = new Aluno(2, "B", new DateTime(20 / 01 / 2000), "412.637.180-00", EnumeradorSexo.Feminino);

            Assert.ThrowsException<MatriculaOuCPFJaCadastrados>(() => _repositorio.Add(_aluno));
        }

        [TestMethod]
        public void Remove_Aluno_Da_ColecaoDeAlunos()
        {
            RepositorioAluno _repositorio = new RepositorioAluno();

            Aluno _aluno = new Aluno(1, "A", new DateTime(25 / 01 / 2000), "", EnumeradorSexo.Masculino);

            _repositorio.Add(_aluno);

            Assert.IsTrue(_repositorio.GetAll().Contains(_aluno));

            _repositorio.Remove(_aluno);

            Assert.IsFalse(_repositorio.GetAll().Contains(_aluno));

        }

        [TestMethod]
        public void Atualiza_Aluno_Na_ColecaoDeAlunos()
        {
            RepositorioAluno _repositorio = new RepositorioAluno();

            Aluno _aluno = new Aluno(1, "A", new DateTime(25 / 01 / 2000), "", EnumeradorSexo.Masculino);

            _repositorio.Add(_aluno);

            _aluno = new Aluno(1, "B", new DateTime(20 / 01 / 2000), "412.637.180-00", EnumeradorSexo.Feminino);

            _repositorio.Update(_aluno);

            Assert.AreEqual(_repositorio.GetByMatricula(1).Nome, _aluno.Nome);
            Assert.AreEqual(_repositorio.GetByMatricula(1).Sexo, _aluno.Sexo);
            Assert.AreEqual(_repositorio.GetByMatricula(1).Nascimento, _aluno.Nascimento);
            Assert.AreEqual(_repositorio.GetByMatricula(1).CPF, "412.637.180-00");

        }


        [TestMethod]
        public void Retorna_ColecaoDeAlunos_De_Alunos()
        {
            RepositorioAluno _repositorio = new RepositorioAluno();

            Aluno _joao = new Aluno(1, "João", new DateTime(25 / 01 / 2000), "", EnumeradorSexo.Masculino);
            Aluno _abraao = new Aluno(2, "Abrãao", new DateTime(25 / 01 / 2000), "", EnumeradorSexo.Masculino);
            Aluno _luca = new Aluno(3, "Luca Benetti", new DateTime(25 / 01 / 2000), "", EnumeradorSexo.Masculino);

            _repositorio.Add(_joao);
            _repositorio.Add(_abraao);
            _repositorio.Add(_luca);

            Assert.IsTrue(_repositorio.GetAll().Contains(_joao));
            Assert.IsTrue(_repositorio.GetAll().Contains(_abraao));
            Assert.IsTrue(_repositorio.GetAll().Contains(_luca));
        }
        

        [TestMethod]
        public void Retorna_Colecao_Determinada_Get()
        {
            Aluno _joao = new Aluno(1, "João", new DateTime(25 / 01 / 2000), "", EnumeradorSexo.Feminino);
            Aluno _luis = new Aluno(2, "Luis", new DateTime(14 / 01 / 2008), "", EnumeradorSexo.Feminino);
            Aluno _abraao = new Aluno(3, "Abrãao", new DateTime(01 / 01 / 1990), "", EnumeradorSexo.Masculino);
            Aluno _luca = new Aluno(4, "Luca Benetti", new DateTime(01 / 02 / 1990), "", EnumeradorSexo.Masculino);
            
            RepositorioAluno _repositorio = new RepositorioAluno();

            _repositorio.Add(_joao);
            _repositorio.Add(_luis);
            _repositorio.Add(_abraao);
            _repositorio.Add(_luca);

            Assert.IsTrue(_repositorio.Get(a => a.Sexo == EnumeradorSexo.Feminino).Contains(_joao));
            Assert.IsTrue(_repositorio.Get(a => a.Sexo == EnumeradorSexo.Feminino).Contains(_luis));
            Assert.IsFalse(_repositorio.Get(a => a.Sexo == EnumeradorSexo.Masculino).Contains(_joao));
            Assert.IsFalse(_repositorio.Get(a => a.Sexo == EnumeradorSexo.Masculino).Contains(_luis));

            Assert.IsTrue(_repositorio.Get(a => a.Sexo == EnumeradorSexo.Masculino).Contains(_abraao));
            Assert.IsTrue(_repositorio.Get(a => a.Sexo == EnumeradorSexo.Masculino).Contains(_luca));
            Assert.IsFalse(_repositorio.Get(a => a.Sexo == EnumeradorSexo.Feminino).Contains(_abraao));
            Assert.IsFalse(_repositorio.Get(a => a.Sexo == EnumeradorSexo.Feminino).Contains(_luca));

        }

        [TestMethod]
        public void Retorna_Aluno_Pela_Matricula()
        {
            RepositorioAluno _repositorio = new RepositorioAluno();

            Aluno _aluno = new Aluno(1, "A", new DateTime(25 / 01 / 2000), "", EnumeradorSexo.Masculino);

            _repositorio.Add(_aluno);
            _repositorio.Add(new Aluno(2, "A", new DateTime(25 / 01 / 2000), "", EnumeradorSexo.Masculino));

            Assert.AreEqual(_aluno, _repositorio.GetByMatricula(1));

            Assert.AreNotEqual(_aluno, _repositorio.GetByMatricula(2));

            
        }

        [TestMethod]
        public void Retorna_ColecaoDeAlunos_Pelo_Nome()
        {
            RepositorioAluno _repositorio = new RepositorioAluno();

            Aluno _joao = new Aluno(1, "João", new DateTime(25 / 01 / 2000), "", EnumeradorSexo.Masculino);
            Aluno _abraao = new Aluno(2, "Abrãao", new DateTime(25 / 01 / 2000), "", EnumeradorSexo.Masculino);
            Aluno _luca = new Aluno(3, "Luca Benetti", new DateTime(25 / 01 / 2000), "", EnumeradorSexo.Masculino);

            _repositorio.Add(_joao);
            _repositorio.Add(_abraao);
            _repositorio.Add(_luca);

            //Benetti
            Assert.IsFalse(_repositorio.GetByContendoNoNome("Benetti").Contains(_joao));
            Assert.IsFalse(_repositorio.GetByContendoNoNome("Benetti").Contains(_abraao));
            Assert.IsTrue(_repositorio.GetByContendoNoNome("Benetti").Contains(_luca));

            //Joao, João, joao, jOaO
            Assert.IsTrue(_repositorio.GetByContendoNoNome("Joao").Contains(_joao) 
                && _repositorio.GetByContendoNoNome("João").Contains(_joao)
                && _repositorio.GetByContendoNoNome("joao").Contains(_joao)
                && _repositorio.GetByContendoNoNome("jOaO").Contains(_joao));
            Assert.IsFalse(_repositorio.GetByContendoNoNome("Joao").Contains(_abraao)
                && _repositorio.GetByContendoNoNome("João").Contains(_abraao)
                && _repositorio.GetByContendoNoNome("joao").Contains(_abraao)
                && _repositorio.GetByContendoNoNome("jOaO").Contains(_abraao));
            Assert.IsFalse(_repositorio.GetByContendoNoNome("Joao").Contains(_luca)
                && _repositorio.GetByContendoNoNome("João").Contains(_luca)
                && _repositorio.GetByContendoNoNome("joao").Contains(_luca)
                && _repositorio.GetByContendoNoNome("jOaO").Contains(_luca));
        }

    }
}
