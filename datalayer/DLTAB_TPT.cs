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
    public class DLTAB_TPT
    {

        #region Conexão

        public string strConnection = ConfigurationManager.ConnectionStrings["TCC_CAVALCENT.Properties.Settings.DB_TCCConnectionString"].ConnectionString;

        #endregion

        #region Comando

        public const string STRinsert = "INSERT INTO TAB_TPT VALUES (@Tpt_Tipo) SELECT SCOPE_IDENTITY()";
        public const string strSelect = "SELECT ID_TPT, Tpt_Tipo FROM TAB_TPT ORDER BY Tpt_Tipo";
        public const string strSelectTipo = "SELECT Tpt_Tipo FROM TAB_TPT WHERE (Tpt_Tipo = '@Tpt_Tipo') ORDER BY Tpt_Tipo";
        public const string strDelete = "DELETE FROM TAB_TPT WHERE ID_TPT = @ID_TPT";
        public const string strUpdate = "UPDATE TAB_TPT SET Tpt_Tipo = @Tpt_Tipo WHERE ID_TPT = @ID_TPT ";
            
        #endregion

        #region Métodos

        public int Gravar(MLTAB_TPT objMLTAB_TPT)
        {
            int retorno = 0;

            using (SqlConnection objConexao = new SqlConnection(strConnection))
            {
                using (SqlCommand objComando = new SqlCommand(STRinsert, objConexao))
                {
                    objComando.Parameters.AddWithValue("@Tpt_Tipo", objMLTAB_TPT.Tpt_Tipo);

                    objConexao.Open();
                    //Utilizo o ExecuteScalar para obter o ID Gravado.
                    retorno = Convert.ToInt32(objComando.ExecuteScalar());

                    objConexao.Close();
                }
            }

            return retorno;
        }

        public List<MLTAB_TPT> Consultar()
        {
            List<MLTAB_TPT> lstMLTAB_TPT = new List<MLTAB_TPT>();

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
                            MLTAB_TPT objMLTAB_TPT = new MLTAB_TPT();

                            objMLTAB_TPT.ID_TPT = Convert.ToInt32(objDataReader["ID_TPT"].ToString());
                            objMLTAB_TPT.Tpt_Tipo = objDataReader["Tpt_Tipo"].ToString();                       

                            lstMLTAB_TPT.Add(objMLTAB_TPT);
                        }
                        objDataReader.Close();
                    }
                    objConexao.Close();
                }
            }
            return lstMLTAB_TPT;
        }

        public List<MLTAB_TPT> ConsultarTipo(MLTAB_TPT objMLTAB_TPT)
        {
            List<MLTAB_TPT> lstMLTAB_TPT = new List<MLTAB_TPT>();

            using (SqlConnection objConexao = new SqlConnection(strConnection))
            {
                using (SqlCommand objComando = new SqlCommand(strSelectTipo, objConexao))
                {

                    objComando.Parameters.AddWithValue("@Tpt_Tipo", objMLTAB_TPT.Tpt_Tipo);

                    objConexao.Open();

                    SqlDataReader objDataReader = objComando.ExecuteReader();

                    if (objDataReader.HasRows)
                    {

                        while (objDataReader.Read())
                        {
                            MLTAB_TPT objMLTPT = new MLTAB_TPT();

                            objMLTPT.Tpt_Tipo = objDataReader["Tpt_Tipo"].ToString();
                    

                            lstMLTAB_TPT.Add(objMLTPT);
                        }

                        objDataReader.Close();
                    }

                    objConexao.Close();
                }
            }
            return lstMLTAB_TPT;
        }

        public int Excluir(int ID_TPT)
        {
            int retorno = 0;

            using (SqlConnection objConexao = new SqlConnection(strConnection))
            {
                using (SqlCommand objComando = new SqlCommand(strDelete, objConexao))
                {
                    objComando.Parameters.AddWithValue("@ID_TPT", ID_TPT);

                    objConexao.Open();

                    retorno = objComando.ExecuteNonQuery();

                    objConexao.Close();
                }
            }

            return retorno;
        }

        public int Atualizar(MLTAB_TPT objMLTAB_TPT)
        {
            int retorno = 0;

            using (SqlConnection objConexao = new SqlConnection(strConnection))
            {
                using (SqlCommand objComando = new SqlCommand(strUpdate, objConexao))
                {
                    objComando.Parameters.AddWithValue("@ID_TPT", objMLTAB_TPT.ID_TPT);
                    objComando.Parameters.AddWithValue("@Tpt_Tipo", objMLTAB_TPT.Tpt_Tipo);

                    objConexao.Open();

                    retorno = objComando.ExecuteNonQuery();

                    objConexao.Close();
                }
            }

            return retorno;
        }

        #endregion

    }
}
