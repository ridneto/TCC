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
    public class DLTAB_FORMPAG
    {
        #region Conexão

        public string strConnection = ConfigurationManager.ConnectionStrings["TCC_CAVALCENT.Properties.Settings.DB_TCCConnectionString"].ConnectionString;

        #endregion

        #region Comando

        public const string strInsert = "INSERT INTO TAB_FORMAPAG Values (@ID_AGE, @Fpg_Forma, @Fpg_Vezes) SELECT SCOPE_IDENTITY()";
        public const string strDelete = "DELETE FROM TAB_FORMAPAG WHERE ID_AGE = @ID_AGE";
        public const string strUpdate = "UPDATE TAB_FORMAPAG SET Fpg_Forma = @Fpg_Forma, Fpg_Vezes = @Fpg_Vezes WHERE ID_AGE = @ID_AGE ";

    
        #endregion

        #region metodos

        public int Gravar(MLTAB_FORMAPAG objMLTAB_FORMPAG)
        {
            int retorno = 0;

            using (SqlConnection objConexao = new SqlConnection(strConnection))
            {
                using (SqlCommand objComando = new SqlCommand(strInsert, objConexao))
                {
                    objComando.Parameters.AddWithValue("@ID_AGE", objMLTAB_FORMPAG.ID_AGE);
                    objComando.Parameters.AddWithValue("@Fpg_Forma", objMLTAB_FORMPAG.Fpg_Forma);
                    objComando.Parameters.AddWithValue("@Fpg_Vezes", objMLTAB_FORMPAG.Fpg_Vezes);

                    objConexao.Open();
                    //Utilizo o ExecuteScalar para obter o ID Gravado.
                    retorno = Convert.ToInt32(objComando.ExecuteScalar());

                    objConexao.Close();
                }
            }

            return retorno;
        }

        public int Excluir(int ID_AGE)
        {
            int retorno = 0;

            using (SqlConnection objConexao = new SqlConnection(strConnection))
            {
                using (SqlCommand objComando = new SqlCommand(strDelete, objConexao))
                {
                    objComando.Parameters.AddWithValue("@ID_AGE", ID_AGE);

                    objConexao.Open();

                    retorno = objComando.ExecuteNonQuery();

                    objConexao.Close();
                }
            }

            return retorno;
        }

        public int Atualizar(int ID_AGE, string Fpg_Forma, int Fpg_Vezes)
        {
            int retorno = 0;

            using (SqlConnection objConexao = new SqlConnection(strConnection))
            {
                using (SqlCommand objComando = new SqlCommand(strUpdate, objConexao))
                {
                    objComando.Parameters.AddWithValue("@ID_AGE", ID_AGE);
                    objComando.Parameters.AddWithValue("@Fpg_Forma", Fpg_Forma);
                    objComando.Parameters.AddWithValue("@Fpg_Vezes", Fpg_Vezes);
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
