using EM.Domain;
using System.Collections.Generic;
using System.Linq;
using EM.MetodosExtensao;
using FirebirdSql.Data.FirebirdClient;
using System;
using System.Globalization;
using System.Linq.Expressions;

namespace EM.Repository
{
    public class RepositorioAluno : RepositorioAbstrato<Aluno>
    {
        #region Firebird Config

        private static readonly string configuracaoBD = @"User=SYSDBA;Password=masterkey;Database=E:\dados\CADASTRO.fdb;DataSource=localhost;Port=3050;Dialect=3;Charset=NONE;Role=;Connection lifetime=15;Pooling=true;MinPoolSize=0;MaxPoolSize=50;Packet Size=8192;
ServerType=0";

        private FbConnection ConectarBD()
        {
            return new FbConnection(configuracaoBD);
        }

        #endregion

        public override void Add(Aluno objeto)
        {
            using (var conexaoFireBird = ConectarBD())
            {
                try
                {
                    conexaoFireBird.Open();
                    var mSQL = $"INSERT into ALUNOS Values ({objeto.Matricula}, '{objeto.Nome}', {(int)objeto.Sexo}, '{objeto.Nascimento.ToString("d", CultureInfo.CreateSpecificCulture("pt-BR"))}', '{objeto.CPF}')";
                    var cmd = new FbCommand(mSQL, conexaoFireBird);
                    cmd.ExecuteNonQuery();
                    conexaoFireBird.Close();
                }

                catch (FbException fbex)
                {
                    throw fbex;
                }

                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }

        public override void Remove(Aluno objeto)
        {
            using (FbConnection conexaoFireBird = ConectarBD())
            {
                try
                {
                    conexaoFireBird.Open();
                    var mSQL = $"DELETE from ALUNOS where MATRICULA={objeto.Matricula}";
                    var cmd = new FbCommand(mSQL, conexaoFireBird);
                    cmd.ExecuteNonQuery();
                    conexaoFireBird.Close();
                }

                catch (FbException fbex)
                {
                    throw fbex;
                }

                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }

        public override void Update(Aluno objeto)
        {
            using (FbConnection conexaoFireBird = ConectarBD())
            {
                try
                {
                    conexaoFireBird.Open();
                    string mSQL = $"UPDATE ALUNOS set NOME ='{objeto.Nome}', SEXO={(int)objeto.Sexo}, NASCIMENTO='{objeto.Nascimento.ToString("d", CultureInfo.CreateSpecificCulture("pt-BR"))}', CPF='{objeto.CPF}' WHERE MATRICULA={objeto.Matricula}";
                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    cmd.ExecuteNonQuery();
                    conexaoFireBird.Close();
                }

                catch (FbException fbex)
                {
                    throw fbex;
                }

                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }

        public override IEnumerable<Aluno> GetAll()
        {
            using (var conexaoFireBird = ConectarBD())
            {
                try
                {
                    conexaoFireBird.Open();
                    var mSQL = $"SELECT * FROM ALUNOS";
                    var ColecaoDeAlunos = new List<Aluno>();
                    using (var cmd = new FbCommand(mSQL, conexaoFireBird))
                    {
                        using (var dr = cmd.ExecuteReader())
                        {

                            while (dr.Read())
                            {
                                var aluno = new Aluno
                                {
                                    Matricula = Convert.ToInt32(dr[0]),
                                    Nome = dr[1].ToString(),
                                    Sexo = (EnumeradorSexo)dr[2],
                                    Nascimento = DateTime.ParseExact(dr[3].ToString(), "dd/MM/yyyy", CultureInfo.CreateSpecificCulture("pt-BR")),
                                    CPF = dr[4].ToString()
                                };

                                ColecaoDeAlunos.Add(aluno);
                            }
                        }
                    }
                    conexaoFireBird.Close();
                    return ColecaoDeAlunos;
                }

                catch (FbException fbex)
                {
                    throw fbex;
                }

                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }

        public override IEnumerable<Aluno> Get(Expression<Func<Aluno, bool>> predicate)
        {
            return GetAll().Where(predicate.Compile()).ToList();
        }

        public Aluno GetByMatricula(int matricula)
        {
            using (var conexaoFireBird = ConectarBD())
            {
                try
                {
                    conexaoFireBird.Open();
                    var mSQL = $"SELECT * FROM ALUNOS WHERE MATRICULA={matricula}";
                    var ColecaoDeAlunos = new List<Aluno>();
                    var aluno = new Aluno();
                    using (var cmd = new FbCommand(mSQL, conexaoFireBird))
                    {
                        using (var dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                aluno.Matricula = Convert.ToInt32(dr[0]);
                                aluno.Nome = dr[1].ToString();
                                aluno.Sexo = (EnumeradorSexo)dr[2];
                                aluno.Nascimento = DateTime.ParseExact(dr[3].ToString(), "dd/MM/yyyy", CultureInfo.CreateSpecificCulture("pt-BR"));
                                aluno.CPF = dr[4].ToString();
                            }
                        }
                    }
                    conexaoFireBird.Close();
                    return aluno;
                }

                catch (FbException fbex)
                {
                    throw fbex;
                }

                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }

        public IEnumerable<Aluno> GetByContendoNoNome(string parteDoNome)
        {
            return new List<Aluno>();
        }

    }
}
