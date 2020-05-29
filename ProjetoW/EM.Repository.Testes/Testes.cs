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

            Aluno _aluno = new Aluno(1, "A", new DateTime(25/01/2000), "412.637.180-00", EnumeradorSexo.Masculino);

            _repositorio.Add(_aluno);

            Assert.AreEqual(_aluno, _repositorio.GetAll().First());
        }

        public void Remove_Aluno_Da_ColecaoDeAlunos()
        {
      
        }

        public void Atualiza_Aluno_Na_ColecaoDeAlunos()
        {

        }

        public void Retorna_ColecaoDeAlunos_De_Alunos()
        {

        }

        public void Retorna_Expressao_Determinada()
        {

        }

        public void Retorna_Aluno_Pela_Matricula()
        {

        }

        public void Retorna_ColecaoDeAlunos_Pelo_Nome()
        {

        }

    }
}
