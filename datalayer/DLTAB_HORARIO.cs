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
    public class DLTAB_HORARIO
    {
        #region Conexão

        public string strConnection = ConfigurationManager.ConnectionStrings["TCC_CAVALCENT.Properties.Settings.DB_TCCConnectionString"].ConnectionString;

        #endregion

        #region Comando

        public const string strSelectHorario = "select * from tab_horario except select a.ID_HOR, h.Hora from tab_agenda a, TAB_HORARIO h where a.ID_HOR = a.ID_HOR and age_data = @Dia and Age_Realizada = 'A'";

        #endregion

        #region metodos

        public List<MLTAB_HORARIO> ConsultarHorarios(DateTime Dia)
        {
            List<MLTAB_HORARIO> lst = new List<MLTAB_HORARIO>();

            using (SqlConnection objConexao = new SqlConnection(strConnection))
            {
                using (SqlCommand objComando = new SqlCommand(strSelectHorario, objConexao))
                {
                    objComando.Parameters.AddWithValue("@Dia", Dia);

                    objConexao.Open();

                    SqlDataReader objDataReader = objComando.ExecuteReader();

                    if (objDataReader.HasRows)
                    {
                        while (objDataReader.Read())
                        {
                            MLTAB_HORARIO objMLTAB_HORARIO = new MLTAB_HORARIO();

                            objMLTAB_HORARIO.ID_HOR = Convert.ToInt32(objDataReader["ID_HOR"].ToString());
                            objMLTAB_HORARIO.Hora = objDataReader["Hora"].ToString();

                            lst.Add(objMLTAB_HORARIO);
                        }

                        objDataReader.Close();
                    }
                    objConexao.Close();
                }
            }
            return lst;
        }

        #endregion
    }
}
