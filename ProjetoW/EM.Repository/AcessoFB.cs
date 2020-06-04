using EM.Domain;
using FirebirdSql.Data.FirebirdClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EM.Repository
{
    public class AcessoFB
    {
        private static readonly AcessoFB instanciaFireBird = new AcessoFB();
        private AcessoFB() { }

        public static AcessoFB getInstancia()
        {
            return instanciaFireBird;
        }

        public FbConnection getConexao()
        {
            string configuration = @"User=SYSDBA;Password=masterkey;Database=E:\dados\CADASTRO.fdb;DataSource=localhost;Port=3050;Dialect=3;Charset=NONE;Role=;Connection lifetime=15;Pooling=true;MinPoolSize=0;MaxPoolSize=50;Packet Size=8192;
ServerType=0";

            return new FbConnection(configuration);
        }

        public static DataTable fb_GetDados()
        {
            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                try
                {
                    conexaoFireBird.Open();
                    string mSQL = "Select * from ALUNOS";
                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    FbDataAdapter da = new FbDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);


                    return dt;
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

        public static void fb_InserirDados(Aluno aluno)
        {
            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                try
                {
                    conexaoFireBird.Open();
                    string mSQL = $"INSERT into ALUNOS Values ({aluno.Matricula}, '{aluno.Nome}', {(int)aluno.Sexo}, '{aluno.Nascimento.ToString("d", CultureInfo.CreateSpecificCulture("pt-BR"))}', '{aluno.CPF}')";
                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    cmd.ExecuteNonQuery();
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

        public static void fb_ExcluirDados(int matricula)
        {
            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                try
                {
                    conexaoFireBird.Open();
                    string mSQL = $"DELETE from ALUNOS where MATRICULA={matricula}";
                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    cmd.ExecuteNonQuery();
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

        public static IEnumerable<Aluno> fb_ProcuraDados()
        {
            using (var conexaoFireBird = AcessoFB.getInstancia().getConexao())
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
                                var aluno = new Aluno();

                                aluno.Matricula = Convert.ToInt32(dr[0]);
                                aluno.Nome = dr[1].ToString();
                                aluno.Sexo = (EnumeradorSexo)dr[2];
                                aluno.Nascimento = DateTime.ParseExact(dr[3].ToString(), "dd/MM/yyyy", CultureInfo.CreateSpecificCulture("pt-BR"));
                                aluno.CPF = dr[4].ToString();

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
                }
            }
        }

        public static void fb_AlterarDados(Aluno aluno)
        {
            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                try
                {
                    conexaoFireBird.Open();
                    string mSQL = $"UPDATE ALUNOS set MATRICULA={aluno.Matricula}, NOME ={aluno.Nome}, SEXO={(int)aluno.Sexo}, NASCIMENTO={aluno.Nascimento.ToString("d", CultureInfo.CreateSpecificCulture("pt-BR"))}, CPF={aluno.CPF}";
                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    cmd.ExecuteNonQuery();
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

    }
}
