using EM.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EM.Repository
{
    public class Processo<T> where T : Aluno
    {

        private RepositorioAluno repositorio = new RepositorioAluno();

        public void Add(T objeto)
        {
            ValidaAluno(objeto);

            if(AlunoCadastrado(objeto)) throw new InconsistenciaException("Matrícula ou CPF já cadastrado!");

            repositorio.Add(objeto);
        }

        public void Remove(T objeto)
        {
            if(!(AlunoCadastrado(objeto))) throw new InconsistenciaException("Matrícula não cadastrada!");

            repositorio.Remove(objeto);
        }

        public void Update(T objeto)
        {
            ValidaAluno(objeto);

            if (!(AlunoCadastrado(objeto))) throw new InconsistenciaException("Matrícula não cadastrada!");

            repositorio.Update(objeto);
        }

        public IEnumerable<Aluno> GetByPesquisa(string entrada)
        {
            if (EhInt(entrada))
            {
                var retorno = repositorio.GetByMatricula(Convert.ToInt32(entrada));

                if (retorno == null)
                {
                    throw new InconsistenciaException("Não foram encontrados alunos para a matrícula especificada, tente novamente");
                }

                List <Aluno> colecaoDeAlunos = new List<Aluno>();
                colecaoDeAlunos.Add(retorno);

                return colecaoDeAlunos;
            }

            else
            {
                var retorno = repositorio.GetByContendoNoNome(entrada);

                if (retorno.Count() == 0)
                {
                    throw new InconsistenciaException("Não foram encontrados alunos para o nome especificado, tente novamente");
                }

                return retorno;
            }
        }

        public IEnumerable<T> GetAll() {
            return (IEnumerable<T>) repositorio.GetAll();
        }

        public bool AlunoCadastrado(T objeto)
        {
            if (repositorio.GetAll().Contains(objeto)) return true;
            return false;
        }

        public void ValidaAluno(T objeto)
        {
            if (!(objeto.Matricula >= 1 && objeto.Matricula <= 999999999)) throw new InconsistenciaException("Matrícula deve ter pelo menos 1 no máximo 9 dígitos!");
            if ((string.IsNullOrWhiteSpace(objeto.Nome) || objeto.Nome.Length > 100)) throw new InconsistenciaException("Nome deve conter pelo menos 1 e no máximo 100 caracteres!");
            if (!(objeto.Sexo == EnumeradorSexo.Feminino || objeto.Sexo == EnumeradorSexo.Masculino)) throw new InconsistenciaException("Sexo escolhido deve ser Masculino ou Feminino!");
            if (objeto.Nascimento.Date > DateTime.Today) throw new InconsistenciaException("Data de nascimento futura inválida!");
            if (!ValidaCPF(objeto.CPF)) throw new InconsistenciaException("CPF inválido!");
        }

        private bool EhInt(string entrada)
        {
            return Int32.TryParse(entrada, out _);
        }

        private bool ValidaCPF(string cpf)
        {
            if (string.IsNullOrEmpty(cpf) || string.IsNullOrWhiteSpace(cpf))
            {
                return true;
            }

            if (cpf.Distinct().Count() <= 3)
            {
                return false;
            }

            int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            string tempCpf;
            string digito;
            int soma;
            int resto;
            cpf = cpf.Trim();
            cpf = cpf.Replace(".", "").Replace("-", "");
            if (cpf.Length != 11)
                return false;
            tempCpf = cpf.Substring(0, 9);
            soma = 0;

            for (int i = 0; i < 9; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = resto.ToString();
            tempCpf = tempCpf + digito;
            soma = 0;
            for (int i = 0; i < 10; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = digito + resto.ToString();
            return cpf.EndsWith(digito);
        }
    }
}
