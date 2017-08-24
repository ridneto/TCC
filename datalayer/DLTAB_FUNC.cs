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
    public class DLTAB_FUNC
    {

        #region Conexão

        public string strConnection = ConfigurationManager.ConnectionStrings["TCC_CAVALCENT.Properties.Settings.DB_TCCConnectionString"].ConnectionString;

        #endregion

        #region Comando

        public const string strSelect = "SELECT ID_FUN, Fun_Login, Fun_Senha, Fun_Tipo FROM TAB_FUNC WHERE (Fun_Login = @Fun_Login) AND (Fun_Senha = @Fun_Senha)";
        public const string strInsert = "INSERT INTO TAB_FUNC Values (@Fun_Tipo, @Fun_Login, @Fun_Senha, @Fun_NomeTatuador) SELECT SCOPE_IDENTITY()";
        public const string strSelectt = "SELECT ID_FUN, Fun_Tipo, Fun_Login, Fun_Senha, Fun_NomeTatuador FROM TAB_FUNC";
        public const string strDelete = "DELETE FROM TAB_FUNC WHERE ID_FUN = @ID_FUN";
        public const string strSelectNome = "SELECT ID_FUN, Fun_Tipo, Fun_Login, Fun_Senha, Fun_NomeTatuador FROM TAB_FUNC WHERE (@Fun_NomeTatuador IS NULL OR Fun_NomeTatuador Like '%' + @Fun_NomeTatuador + '%')";
        public const string strUpdate = "UPDATE TAB_FUNC SET Fun_Tipo = @Fun_Tipo, Fun_Login = @Fun_Login, Fun_Senha = @Fun_Senha, Fun_NomeTatuador = @Fun_NomeTatuador WHERE ID_FUN = @ID_FUN ";
        public const string strSelectFunc = "SELECT ID_FUN, Fun_NomeTatuador From TAB_FUNC except select ID_FUN, Fun_NomeTatuador from TAB_FUNC where ID_FUN = 1";
        
        #endregion

        #region Métodos

        public List<MLTAB_FUNC> Consultar(string nome, string senha)
        {
            List<MLTAB_FUNC> lstMLUsuarios = new List<MLTAB_FUNC>();

            using (SqlConnection objConexao = new SqlConnection(strConnection))
            {
                using (SqlCommand objComando = new SqlCommand(strSelect, objConexao))
                {
                    objComando.Parameters.AddWithValue("@Fun_Login", nome);
                    objComando.Parameters.AddWithValue("@Fun_Senha", senha);
                    objConexao.Open();

                    SqlDataReader objDataReader = objComando.ExecuteReader();

                    if (objDataReader.HasRows) 
                    {

                        while (objDataReader.Read())
                        {
                            MLTAB_FUNC objMLTAB_FUNC = new MLTAB_FUNC();

                            objMLTAB_FUNC.ID_FUN = Convert.ToInt32(objDataReader["ID_FUN"].ToString());
                            objMLTAB_FUNC.Fun_Login = objDataReader["Fun_Login"].ToString();
                            objMLTAB_FUNC.Fun_Senha = objDataReader["Fun_Senha"].ToString();
                            objMLTAB_FUNC.Fun_Tipo = Convert.ToInt16(objDataReader["Fun_Tipo"].ToString());


                            lstMLUsuarios.Add(objMLTAB_FUNC);
                        }
                        
                        objDataReader.Close();
                    }

                    objConexao.Close();
                }
            }

            return lstMLUsuarios;
        }

        public int Gravar(MLTAB_FUNC objMLTAB_FUN)
        {
            int retorno = 0;

            using (SqlConnection objConexao = new SqlConnection(strConnection))
            {
                using (SqlCommand objComando = new SqlCommand(strInsert, objConexao))
                {
                    objComando.Parameters.AddWithValue("@Fun_Tipo", objMLTAB_FUN.Fun_Tipo);
                    objComando.Parameters.AddWithValue("@Fun_Login", objMLTAB_FUN.Fun_Login);
                    objComando.Parameters.AddWithValue("@Fun_Senha", objMLTAB_FUN.Fun_Senha);
                    objComando.Parameters.AddWithValue("@Fun_NomeTatuador", objMLTAB_FUN.Fun_NomeTatuador);
          

                    objConexao.Open();
                    //Utilizo o ExecuteScalar para obter o ID Gravado.
                    retorno = Convert.ToInt32(objComando.ExecuteScalar());

                    objConexao.Close();
                }
            }

            return retorno;
        }

        public List<MLTAB_FUNC> Consultar()
        {
            List<MLTAB_FUNC> lstMLTAB_FUNC = new List<MLTAB_FUNC>();

            using (SqlConnection objConexao = new SqlConnection(strConnection))
            {
                using (SqlCommand objComando = new SqlCommand(strSelectt, objConexao))
                {
                    objConexao.Open();

                    SqlDataReader objDataReader = objComando.ExecuteReader();

                    if (objDataReader.HasRows)
                    {

                        while (objDataReader.Read())
                        {
                            MLTAB_FUNC objMLTAB_FUNC = new MLTAB_FUNC();

                            objMLTAB_FUNC.ID_FUN = Convert.ToInt32(objDataReader["ID_FUN"].ToString());
                            objMLTAB_FUNC.Fun_Tipo = Convert.ToInt16(objDataReader["Fun_Tipo"]);
                            objMLTAB_FUNC.Fun_Login = objDataReader["Fun_Login"].ToString();
                            objMLTAB_FUNC.Fun_Senha = objDataReader["Fun_Senha"].ToString();
                            objMLTAB_FUNC.Fun_NomeTatuador = objDataReader["Fun_NomeTatuador"].ToString();                       

                            lstMLTAB_FUNC.Add(objMLTAB_FUNC);
                        }

                        objDataReader.Close();
                    }

                    objConexao.Close();
                }
            }
            return lstMLTAB_FUNC;
        }

        public int Excluir(int ID_FUN)
        {
            int retorno = 0;

            using (SqlConnection objConexao = new SqlConnection(strConnection))
            {
                using (SqlCommand objComando = new SqlCommand(strDelete, objConexao))
                {
                    objComando.Parameters.AddWithValue("@ID_FUN", ID_FUN);

                    objConexao.Open();

                    retorno = objComando.ExecuteNonQuery();

                    objConexao.Close();
                }
            }

            return retorno;
        }

        public List<MLTAB_FUNC> ConsultarNome(MLTAB_FUNC objMLTAB_FUNC)
        {
            List<MLTAB_FUNC> lstMLTAB_FUNC = new List<MLTAB_FUNC>();

            using (SqlConnection objConexao = new SqlConnection(strConnection))
            {
                using (SqlCommand objComando = new SqlCommand(strSelectNome, objConexao))
                {

                    if (String.IsNullOrEmpty(objMLTAB_FUNC.Fun_NomeTatuador))
                    {
                        objComando.Parameters.AddWithValue("@Fun_NomeTatuador", DBNull.Value);
                    }
                    else
                    {
                        objComando.Parameters.AddWithValue("@Fun_NomeTatuador", objMLTAB_FUNC.Fun_NomeTatuador);

                    }

                    objConexao.Open();

                    SqlDataReader objDataReader = objComando.ExecuteReader();

                    if (objDataReader.HasRows)
                    {

                        while (objDataReader.Read())
                        {
                            MLTAB_FUNC objMLTAB_CLI = new MLTAB_FUNC();

                            objMLTAB_CLI.ID_FUN = Convert.ToInt32(objDataReader["ID_FUN"].ToString());
                            objMLTAB_CLI.Fun_Tipo = Convert.ToInt16(objDataReader["Fun_Tipo"]);
                            objMLTAB_CLI.Fun_Login = objDataReader["Fun_Login"].ToString();
                            objMLTAB_CLI.Fun_Senha = objDataReader["Fun_Senha"].ToString();
                            objMLTAB_CLI.Fun_NomeTatuador = objDataReader["Fun_NomeTatuador"].ToString();

                            lstMLTAB_FUNC.Add(objMLTAB_CLI);
                        }

                        objDataReader.Close();
                    }

                    objConexao.Close();
                }
            }
            return lstMLTAB_FUNC;
        }

        public int Atualizar(MLTAB_FUNC objMLTAB_FUNC)
        {
            int retorno = 0;

            using (SqlConnection objConexao = new SqlConnection(strConnection))
            {
                using (SqlCommand objComando = new SqlCommand(strUpdate, objConexao))
                {
                    objComando.Parameters.AddWithValue("@ID_FUN", objMLTAB_FUNC.ID_FUN);
                    objComando.Parameters.AddWithValue("@Fun_Tipo", objMLTAB_FUNC.Fun_Tipo);
                    objComando.Parameters.AddWithValue("@Fun_Login", objMLTAB_FUNC.Fun_Login);
                    objComando.Parameters.AddWithValue("@Fun_Senha", objMLTAB_FUNC.Fun_Senha);
                    objComando.Parameters.AddWithValue("@Fun_NomeTatuador", objMLTAB_FUNC.Fun_NomeTatuador);

                    objConexao.Open();

                    retorno = objComando.ExecuteNonQuery();

                    objConexao.Close();
                }
            }
            return retorno;
        }

        public List<MLTAB_FUNC> ConsultarTatuadores()
        {
            List<MLTAB_FUNC> lstMLTAB_FUNC = new List<MLTAB_FUNC>();

            using (SqlConnection objConexao = new SqlConnection(strConnection))
            {
                using (SqlCommand objComando = new SqlCommand(strSelectFunc, objConexao))
                {
                    objConexao.Open();

                    SqlDataReader objDataReader = objComando.ExecuteReader();

                    if (objDataReader.HasRows)
                    {

                        while (objDataReader.Read())
                        {
                            MLTAB_FUNC objMLTAB_FUNC = new MLTAB_FUNC();

                            objMLTAB_FUNC.ID_FUN = Convert.ToInt32(objDataReader["ID_FUN"].ToString());
                            objMLTAB_FUNC.Fun_NomeTatuador = objDataReader["Fun_NomeTatuador"].ToString();

                            lstMLTAB_FUNC.Add(objMLTAB_FUNC);
                        }

                        objDataReader.Close();
                    }

                    objConexao.Close();
                }
            }
            return lstMLTAB_FUNC;
        }

        #endregion

    }
}
