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
        private AcessoFB() {}

        public static AcessoFB getInstancia()
        {
            return instanciaFireBird;
        }

        public FbConnection getConexao()
        {
            string configuration = ConfigurationManager.ConnectionStrings["FireBirdConnectionString"].ToString();

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
                    string mSQL = $"INSERT into ALUNOS Values ({aluno.Matricula}, {aluno.Nome}, {(int)aluno.Sexo}, {aluno.Nascimento.ToString("d", CultureInfo.CreateSpecificCulture("pt-BR"))}, {aluno.CPF})";
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

        public static Aluno fb_ProcuraDados(int matricula)
        {
            using (FbConnection conexaoFireBird = AcessoFB.getInstancia().getConexao())
            {
                try
                {
                    conexaoFireBird.Open();
                    string mSQL = $"Select * from ALUNOS Where MATRICULA = {matricula}";
                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    FbDataReader dr = cmd.ExecuteReader();
                    Aluno aluno = new Aluno();
                    while (dr.Read())
                    {
                        aluno.Matricula = Convert.ToInt32(dr[0]);
                        aluno.Nome = dr[1].ToString();
                        aluno.Sexo = (EnumeradorSexo)dr[2];
                        aluno.Nascimento = DateTime.ParseExact(dr[3].ToString(), "dd/MM/yyyy", CultureInfo.CreateSpecificCulture("pt-BR"));
                        aluno.CPF = dr[4].ToString();
                    }
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
               
                catch(FbException fbex)
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
