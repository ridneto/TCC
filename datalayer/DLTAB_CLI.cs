using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using ModelLayer;

namespace DataLayer
{
    public class DLTAB_CLI
    {
        #region Conexão

        public string strConnection = ConfigurationManager.ConnectionStrings["TCC_CAVALCENT.Properties.Settings.DB_TCCConnectionString"].ConnectionString;

        #endregion

        #region Comando

        public const string strDelete = "DELETE FROM TAB_CLI WHERE ID_CLI = @ID_CLI";
        public const string strInsert = "INSERT INTO TAB_CLI Values (@Cli_Nome, @Cli_DataNasc, @Cli_Sexo, @Cli_Telefone, @Cli_Email) SELECT SCOPE_IDENTITY()";
        public const string strUpdate = "UPDATE TAB_CLI SET Cli_Nome = @Cli_Nome, Cli_DataNasc = @Cli_DataNasc, Cli_Sexo = @Cli_Sexo, Cli_Telefone = @Cli_Telefone, Cli_Email = @Cli_Email WHERE ID_CLI = @ID_CLI ";
        public const string strSelect = "SELECT ID_CLI, Cli_Nome, Cli_DataNasc, Cli_Sexo, Cli_Telefone, Cli_Email FROM TAB_CLI ORDER BY Cli_Nome";
        public const string strSelectNome = "SELECT ID_CLI, Cli_Nome, Cli_DataNasc, Cli_Sexo, Cli_Telefone, Cli_Email FROM TAB_CLI WHERE (@Cli_Nome IS NULL OR Cli_Nome Like '%' + @Cli_Nome + '%') ORDER BY Cli_Nome";
        public const string strNome = "SELECT Cli_Nome FROM TAB_CLI WHERE ID_CLI = @ID_CLI";

        #endregion

        #region Métodos

        public int Excluir(int ID_CLI)
        {
            int retorno = 0;

            using (SqlConnection objConexao = new SqlConnection(strConnection))
            {
                using (SqlCommand objComando = new SqlCommand(strDelete, objConexao))
                {
                    objComando.Parameters.AddWithValue("@ID_CLI", ID_CLI);

                    objConexao.Open();

                    retorno = objComando.ExecuteNonQuery();

                    objConexao.Close();
                }
            }

            return retorno;
        }

        public int Gravar(MLTAB_CLI objMLTAB_Cli)
        {
            int retorno = 0;

            using (SqlConnection objConexao = new SqlConnection(strConnection))
            {
                using (SqlCommand objComando = new SqlCommand(strInsert, objConexao))
                {
                    objComando.Parameters.AddWithValue("@Cli_Nome", objMLTAB_Cli.Cli_Nome);
                    objComando.Parameters.AddWithValue("@Cli_DataNasc", objMLTAB_Cli.Cli_DataNasc);
                    objComando.Parameters.AddWithValue("@Cli_Sexo", objMLTAB_Cli.Cli_Sexo);
                    objComando.Parameters.AddWithValue("@Cli_Telefone", objMLTAB_Cli.Cli_Telefone);
                    objComando.Parameters.AddWithValue("@Cli_Email", objMLTAB_Cli.Cli_Email);     

                    objConexao.Open();
                    //Utilizo o ExecuteScalar para obter o ID Gravado.
                    retorno = Convert.ToInt32(objComando.ExecuteScalar());

                    objConexao.Close();
                }
            }

            return retorno;
        }

        public int Atualizar(MLTAB_CLI objMLTAB_CLI)
        {
            int retorno = 0;

            using (SqlConnection objConexao = new SqlConnection(strConnection))
            {
                using (SqlCommand objComando = new SqlCommand(strUpdate, objConexao))
                {
                    objComando.Parameters.AddWithValue("@ID_CLI", objMLTAB_CLI.ID_CLI);
                    objComando.Parameters.AddWithValue("@Cli_Nome", objMLTAB_CLI.Cli_Nome);
                    objComando.Parameters.AddWithValue("@Cli_DataNasc", objMLTAB_CLI.Cli_DataNasc);
                    objComando.Parameters.AddWithValue("@Cli_Sexo", objMLTAB_CLI.Cli_Sexo);
                    objComando.Parameters.AddWithValue("@Cli_Telefone", objMLTAB_CLI.Cli_Telefone);
                    objComando.Parameters.AddWithValue("@Cli_Email", objMLTAB_CLI.Cli_Email);

                    objConexao.Open();

                    retorno = objComando.ExecuteNonQuery();

                    objConexao.Close();
                }
            }

            return retorno;
        }

        public List<MLTAB_CLI> Consultar()
        {
            List<MLTAB_CLI> lstMLTAB_Cli = new List<MLTAB_CLI>();

            using (SqlConnection objConexao = new SqlConnection(strConnection))
            {
                using (SqlCommand objComando = new SqlCommand(strSelect, objConexao))
                {
                    objConexao.Open();

                    SqlDataReader objDataReader = objComando.ExecuteReader();

                    if (objDataReader.HasRows)
                    {

                        while (objDataReader.Read())
                        {
                            MLTAB_CLI objMLTAB_CLI = new MLTAB_CLI();
                           
                            objMLTAB_CLI.ID_CLI = Convert.ToInt32(objDataReader["ID_CLI"].ToString());
                            objMLTAB_CLI.Cli_Nome = objDataReader["Cli_Nome"].ToString();
                            objMLTAB_CLI.Cli_DataNasc = Convert.ToDateTime(objDataReader["Cli_DataNasc"]);
                            objMLTAB_CLI.Cli_Sexo = objDataReader["Cli_Sexo"].ToString();
                            objMLTAB_CLI.Cli_Telefone = objDataReader["Cli_Telefone"].ToString();
                            objMLTAB_CLI.Cli_Email = objDataReader["Cli_Email"].ToString();
                           
                            lstMLTAB_Cli.Add(objMLTAB_CLI);
                        }
                        objDataReader.Close();
                    }
                    objConexao.Close();
                }
            }
            return lstMLTAB_Cli;
        }

        public List<MLTAB_CLI> ConsultarNome(MLTAB_CLI objMLTAB_CLI)
        {
            List<MLTAB_CLI> lstMLTAB_CLI = new List<MLTAB_CLI>();

            using (SqlConnection objConexao = new SqlConnection(strConnection))
            {
                using (SqlCommand objComando = new SqlCommand(strSelectNome, objConexao))
                {

                    if (String.IsNullOrEmpty(objMLTAB_CLI.Cli_Nome))
                    {
                        objComando.Parameters.AddWithValue("@Cli_Nome", DBNull.Value);
                    }
                    else
                    {
                        objComando.Parameters.AddWithValue("@Cli_Nome", objMLTAB_CLI.Cli_Nome);

                    }

                    objConexao.Open();

                    SqlDataReader objDataReader = objComando.ExecuteReader();

                    if (objDataReader.HasRows)
                    {

                        while (objDataReader.Read())
                        {
                            MLTAB_CLI objMLCliente = new MLTAB_CLI();

                            objMLCliente.ID_CLI = Convert.ToInt32(objDataReader["ID_CLI"].ToString());
                            objMLCliente.Cli_Nome = objDataReader["Cli_Nome"].ToString();
                            objMLCliente.Cli_DataNasc = Convert.ToDateTime(objDataReader["Cli_DataNasc"]);
                            objMLCliente.Cli_Sexo = objDataReader["Cli_Sexo"].ToString();
                            objMLCliente.Cli_Telefone = objDataReader["Cli_Telefone"].ToString();
                            objMLCliente.Cli_Email = objDataReader["Cli_Email"].ToString();

                            lstMLTAB_CLI.Add(objMLCliente);
                        }

                        objDataReader.Close();
                    }

                    objConexao.Close();
                }
            }
            return lstMLTAB_CLI;
        }

        public string ConsultarNome(int ID_CLI)
        {
            string Cli_Nome = null;
            using (SqlConnection objConexao = new SqlConnection(strConnection))
            {
                using (SqlCommand objComando = new SqlCommand(strNome, objConexao))
                {
                    objComando.Parameters.AddWithValue("@ID_CLI", ID_CLI);

                    objConexao.Open();

                    SqlDataReader objDataReader = objComando.ExecuteReader();

                    if (objDataReader.HasRows)
                    {
                        while (objDataReader.Read())
                        {
                            Cli_Nome = (objDataReader["Cli_Nome"].ToString());                            
                        }
                        objDataReader.Close();
                    }
                    objConexao.Close();
                }
            }
            return Cli_Nome;
        }


        #endregion
    }
}
