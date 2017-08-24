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
    public class DLTAB_AGENDA
    {

        #region Conexão

        public string strConnection = ConfigurationManager.ConnectionStrings["TCC_CAVALCENT.Properties.Settings.DB_TCCConnectionString"].ConnectionString;

        #endregion

        #region Comando

        public const string strSelectDia = "SELECT Hora, Cli_Nome, Age_ValorSessao FROM TAB_AGENDA TAG, TAB_TAT TAT, TAB_CLI TC, TAB_HORARIO TH WHERE TH.ID_HOR = TAG.ID_HOR AND TAT.ID_TAT = TAG.ID_TAT AND TC.ID_CLI = TAT.ID_CLI AND Age_Data = @Age_Data and Age_Realizada like 'A' ORDER BY Hora";
        public const string strUpdate = "UPDATE TAB_AGENDA SET Age_Realizada = 'R' WHERE ID_AGE = @ID_AGE";
        public const string strSelectDiaP = "SELECT Cli_Nome, TAG.ID_AGE, Age_ValorSessao, Hora, Age_Data, Tpt_Tipo, Tat_Descricao, Fpg_Forma, Fpg_Vezes FROM TAB_HORARIO TH, TAB_FORMAPAG TFG, TAB_CLI TC, TAB_AGENDA TAG, TAB_TAT TAT, TAB_TPT TPT WHERE TFG.ID_AGE = TAG.ID_AGE AND TC.ID_CLI = TAT.ID_CLI AND TAT.ID_TAT = TAG.ID_TAT  AND TAG.ID_HOR = TH.ID_HOR and TPT.ID_TPT = TAT.ID_TPT AND Age_Data = @Age_Data and Age_Realizada like 'A' ORDER BY Cli_Nome";
        public const string strSelectDiaNomeP = "SELECT Cli_Nome,  TAG.ID_AGE, Age_ValorSessao, Hora, Age_Data, Tpt_Tipo, Tat_Descricao, Fpg_Forma, Fpg_Vezes FROM TAB_HORARIO TH, TAB_FORMAPAG TFG, TAB_CLI TC, TAB_AGENDA TAG, TAB_TAT TAT, TAB_TPT TPT WHERE TFG.ID_AGE = TAG.ID_AGE AND TC.ID_CLI = TAT.ID_CLI AND TAT.ID_TAT = TAG.ID_TAT AND TAG.ID_HOR = TH.ID_HOR and TPT.ID_TPT = TAT.ID_TPT AND (@Cli_Nome IS NULL OR Cli_Nome Like '%' + @Cli_Nome + '%') and Age_Realizada like 'A'  ORDER BY Cli_Nome";
        public const string strSelectHorario = "SELECT ID_AGE FROM TAB_AGENDA TG, TAB_HORARIO TH WHERE Age_Data = @Age_Data and Hora = @Hora and TG.ID_HOR = TH.ID_HOR and Age_Realizada like 'A'";
        public const string strValor = "SELECT Age_ValorSessao FROM TAB_AGENDA WHERE ID_TA = @ID_TA";
        public const string strInsert = "INSERT INTO TAB_AGENDA VALUES (@ID_TAT, @ID_FUN, @ID_HOR, @Age_Data, @Age_Realizada, @Age_ValorSessao) SELECT SCOPE_IDENTITY()";
        public const string strSelectID = "SELECT ID_AGE FROM TAB_AGENDA WHERE ID_TAT = @ID_TAT";
        public const string strDeleteIDTAT = "DELETE FROM TAB_AGENDA WHERE ID_TAT = @ID_TAT";
        public const string strSelectIDTAT = "SELECT ID_TAT FROM TAB_AGENDA WHERE ID_AGE = @ID_AGE";
        public const string strSelectIDAGE = "SELECT ID_AGE FROM TAB_AGENDA TG, TAB_TAT TT, TAB_CLI TC, TAB_HORARIO TH WHERE Cli_Nome = @Cli_Nome AND Hora = @Hora AND Age_Data = @Age_Data AND TG.ID_TAT = TT.ID_TAT AND TT.ID_CLI = TC.ID_CLI AND TG.ID_HOR = TH.ID_HOR AND Age_Realizada like 'A'";
        public const string strDeleteIDAGE = "DELETE FROM TAB_AGENDA WHERE ID_AGE = @ID_AGE";
        public const string atualizar = "UPDATE TAB_AGENDA SET ID_FUN = @ID_FUN, Age_Data = @Age_Data, ID_HOR = @ID_HOR, Age_ValorSessao = @Age_ValorSessao WHERE ID_AGE = @ID_AGE";

        #endregion

        #region Metodos

        public List<MLTAB_AGENDA> DiaEspecifico(DateTime Age_Data)
        {
            List<MLTAB_AGENDA> lstMLTAB_AGENDA = new List<MLTAB_AGENDA>();

            using (SqlConnection objConexao = new SqlConnection(strConnection))
            {
                using (SqlCommand objComando = new SqlCommand(strSelectDia, objConexao))
                {
                    objComando.Parameters.AddWithValue("@Age_Data", Age_Data);

                    objConexao.Open();

                    SqlDataReader objDataReader = objComando.ExecuteReader();

                    if (objDataReader.HasRows)
                    {

                        while (objDataReader.Read())
                        {
                            MLTAB_AGENDA objMLAGENDA = new MLTAB_AGENDA();

                            objMLAGENDA.Hora = objDataReader["Hora"].ToString();
                            objMLAGENDA.Cli_Nome = objDataReader["Cli_Nome"].ToString();
                            objMLAGENDA.Age_ValorSessao = Convert.ToInt16(objDataReader["Age_ValorSessao"]);

                            lstMLTAB_AGENDA.Add(objMLAGENDA);
                        }

                        objDataReader.Close();
                    }

                    objConexao.Close();
                }
            }
            return lstMLTAB_AGENDA;
        }

        public List<MLTAB_AGENDA> DiaAtual(DateTime Age_Data)
        {
            List<MLTAB_AGENDA> lstMLTAB_AGENDA = new List<MLTAB_AGENDA>();

            using (SqlConnection objConexao = new SqlConnection(strConnection))
            {
                using (SqlCommand objComando = new SqlCommand(strSelectDia, objConexao))
                {
                    objComando.Parameters.AddWithValue("@Age_Data", Age_Data);

                    objConexao.Open();

                    SqlDataReader objDataReader = objComando.ExecuteReader();

                    if (objDataReader.HasRows)
                    {

                        while (objDataReader.Read())
                        {
                            MLTAB_AGENDA objMLAGENDA = new MLTAB_AGENDA();

                            objMLAGENDA.Hora = objDataReader["Hora"].ToString();
                            objMLAGENDA.Cli_Nome = objDataReader["Cli_Nome"].ToString();
                            objMLAGENDA.Age_ValorSessao = Convert.ToInt16(objDataReader["Age_ValorSessao"]);

                            lstMLTAB_AGENDA.Add(objMLAGENDA);
                        }

                        objDataReader.Close();
                    }

                    objConexao.Close();
                }
            }
            return lstMLTAB_AGENDA;
        }

        public List<MLTAB_AGENDA> DiaEspecificoP(DateTime Age_Data)
        {
            List<MLTAB_AGENDA> lstMLTAB_AGENDA = new List<MLTAB_AGENDA>();

            using (SqlConnection objConexao = new SqlConnection(strConnection))
            {
                using (SqlCommand objComando = new SqlCommand(strSelectDiaP, objConexao))
                {
                    objComando.Parameters.AddWithValue("@Age_Data", Age_Data);

                    objConexao.Open();

                    SqlDataReader objDataReader = objComando.ExecuteReader();

                    if (objDataReader.HasRows)
                    {

                        while (objDataReader.Read())
                        {
                            MLTAB_AGENDA objMLAGENDA = new MLTAB_AGENDA();
                            objMLAGENDA.ID_AGE = Convert.ToInt16(objDataReader["ID_AGE"].ToString());
                            objMLAGENDA.Cli_Nome = objDataReader["Cli_Nome"].ToString();
                            objMLAGENDA.Hora = (objDataReader["Hora"].ToString());
                            objMLAGENDA.Age_Data = Convert.ToDateTime(objDataReader["Age_Data"]);
                            objMLAGENDA.Age_ValorSessao = Convert.ToInt16(objDataReader["Age_ValorSessao"]);
                            objMLAGENDA.Tpt_Tipo = objDataReader["Tpt_Tipo"].ToString();
                            objMLAGENDA.Tat_Descricao = objDataReader["Tat_Descricao"].ToString();
                            objMLAGENDA.Fpg_Forma = objDataReader["Fpg_Forma"].ToString();
                            objMLAGENDA.Fpg_Vezes = Convert.ToInt16(objDataReader["Fpg_Vezes"].ToString());

                            lstMLTAB_AGENDA.Add(objMLAGENDA);
                        }

                        objDataReader.Close();
                    }

                    objConexao.Close();
                }
            }
            return lstMLTAB_AGENDA;
        }

        public List<MLTAB_AGENDA> DiaAtualCliente(string Cli_Nome)
        {
            List<MLTAB_AGENDA> lstMLTAB_AGENDA = new List<MLTAB_AGENDA>();

            using (SqlConnection objConexao = new SqlConnection(strConnection))
            {
                using (SqlCommand objComando = new SqlCommand(strSelectDiaNomeP, objConexao))
                {
                    if (String.IsNullOrEmpty(Cli_Nome))
                    {
                        objComando.Parameters.AddWithValue("@Cli_Nome", DBNull.Value);
                    }
                    else
                    {
                        objComando.Parameters.AddWithValue("@Cli_Nome", Cli_Nome);
                    }

                    objConexao.Open();

                    SqlDataReader objDataReader = objComando.ExecuteReader();

                    if (objDataReader.HasRows)
                    {

                        while (objDataReader.Read())
                        {
                            MLTAB_AGENDA objMLAGENDA = new MLTAB_AGENDA();

                            objMLAGENDA.Cli_Nome = objDataReader["Cli_Nome"].ToString();
                            objMLAGENDA.ID_AGE = Convert.ToInt16(objDataReader["ID_AGE"].ToString());
                            objMLAGENDA.Hora = (objDataReader["Hora"].ToString());
                            objMLAGENDA.Age_Data = Convert.ToDateTime(objDataReader["Age_Data"]);
                            objMLAGENDA.Age_ValorSessao = Convert.ToInt16(objDataReader["Age_ValorSessao"]);
                            objMLAGENDA.Tpt_Tipo = objDataReader["Tpt_Tipo"].ToString();
                            objMLAGENDA.Tat_Descricao = objDataReader["Tat_Descricao"].ToString();
                            objMLAGENDA.Fpg_Forma = objDataReader["Fpg_Forma"].ToString();
                            objMLAGENDA.Fpg_Vezes = Convert.ToInt16(objDataReader["Fpg_Vezes"].ToString());

                            lstMLTAB_AGENDA.Add(objMLAGENDA);
                        }

                        objDataReader.Close();
                    }

                    objConexao.Close();
                }
            }
            return lstMLTAB_AGENDA;
        }

        public int ConsultarSessaoLivre(DateTime Age_Data, string Hora)
        {
            int ID = 0;
            using (SqlConnection objConexao = new SqlConnection(strConnection))
            {
                using (SqlCommand objComando = new SqlCommand(strSelectHorario, objConexao))
                {

                    objComando.Parameters.AddWithValue("@Age_Data", Age_Data);
                    objComando.Parameters.AddWithValue("@Hora", Hora);

                    objConexao.Open();

                    SqlDataReader objDataReader = objComando.ExecuteReader();

                    if (objDataReader.HasRows)
                    {
                        while (objDataReader.Read())
                        {
                            ID = Convert.ToInt16(objDataReader["ID_AGE"]);
                        }
                        objDataReader.Close();
                    }
                    objConexao.Close();
                }
            }
            return ID;
        }

        public List<MLTAB_AGENDA> ValorSessoes(int ID_TAT)
        {
            List<MLTAB_AGENDA> lstMLTAB_AGENDA = new List<MLTAB_AGENDA>();

            using (SqlConnection objConexao = new SqlConnection(strConnection))
            {
                using (SqlCommand objComando = new SqlCommand(strValor, objConexao))
                {
                    objComando.Parameters.AddWithValue("@ID_TAT", ID_TAT);

                    objConexao.Open();

                    SqlDataReader objDataReader = objComando.ExecuteReader();

                    if (objDataReader.HasRows)
                    {

                        while (objDataReader.Read())
                        {
                            MLTAB_AGENDA objMLAGENDA = new MLTAB_AGENDA();

                            objMLAGENDA.Age_ValorSessao = Convert.ToInt32(objDataReader["Age_ValorSessao"].ToString());

                            lstMLTAB_AGENDA.Add(objMLAGENDA);
                        }

                        objDataReader.Close();
                    }

                    objConexao.Close();
                }
            }
            return lstMLTAB_AGENDA;
        }

        public int Gravar(MLTAB_AGENDA objMLTAB_AGENDA)
        {
            int retorno = 0;

            using (SqlConnection objConexao = new SqlConnection(strConnection))
            {
                using (SqlCommand objComando = new SqlCommand(strInsert, objConexao))
                {
                    objComando.Parameters.AddWithValue("@ID_TAT", objMLTAB_AGENDA.ID_TAT);
                    objComando.Parameters.AddWithValue("@ID_FUN", objMLTAB_AGENDA.ID_FUN);
                    objComando.Parameters.AddWithValue("@ID_HOR", objMLTAB_AGENDA.ID_HOR);
                    objComando.Parameters.AddWithValue("@Age_Data", objMLTAB_AGENDA.Age_Data);
                    objComando.Parameters.AddWithValue("@Age_Realizada", objMLTAB_AGENDA.Age_Realizada);
                    objComando.Parameters.AddWithValue("@Age_ValorSessao", objMLTAB_AGENDA.Age_ValorSessao);

                    objConexao.Open();
                    //Utilizo o ExecuteScalar para obter o ID Gravado.
                    retorno = Convert.ToInt32(objComando.ExecuteScalar());

                    objConexao.Close();
                }
            }

            return retorno;
        }

        public List<MLTAB_AGENDA> ConsultaID(int ID_TAT)
        {
            List<MLTAB_AGENDA> listMLTAB_AGENDA = new List<MLTAB_AGENDA>();

            using (SqlConnection objConexao = new SqlConnection(strConnection))
            {
                using (SqlCommand objComando = new SqlCommand(strSelectID, objConexao))
                {
                    objComando.Parameters.AddWithValue("@ID_TAT", ID_TAT);

                    objConexao.Open();

                    SqlDataReader objDataReader = objComando.ExecuteReader();

                    if (objDataReader.HasRows)
                    {
                        while (objDataReader.Read())
                        {
                            MLTAB_AGENDA objMLTAB_AGENDA = new MLTAB_AGENDA();

                            objMLTAB_AGENDA.ID_AGE = Convert.ToInt32(objDataReader["ID_AGE"].ToString());

                            listMLTAB_AGENDA.Add(objMLTAB_AGENDA);
                        }
                    }

                    objDataReader.Close();
                }
                objConexao.Close();
            }
            return listMLTAB_AGENDA;
        }

        public int ExcluirPorIDTAT(int ID_TAT)
        {
            int retorno = 0;

            using (SqlConnection objConexao = new SqlConnection(strConnection))
            {
                using (SqlCommand objComando = new SqlCommand(strDeleteIDTAT, objConexao))
                {
                    objComando.Parameters.AddWithValue("@ID_TAT", ID_TAT);

                    objConexao.Open();

                    retorno = objComando.ExecuteNonQuery();

                    objConexao.Close();
                }
            }
            return retorno;
        }

        public int ExcluirPorIDAGE(int ID_AGE)
        {
            int retorno = 0;

            using (SqlConnection objConexao = new SqlConnection(strConnection))
            {
                using (SqlCommand objComando = new SqlCommand(strDeleteIDAGE, objConexao))
                {
                    objComando.Parameters.AddWithValue("@ID_AGE", ID_AGE);

                    objConexao.Open();

                    retorno = objComando.ExecuteNonQuery();

                    objConexao.Close();
                }
            }
            return retorno;
        }

        public int Atualizar(int ID_AGE)
        {
            int retorno = 0;

            using (SqlConnection objConexao = new SqlConnection(strConnection))
            {
                using (SqlCommand objComando = new SqlCommand(strUpdate, objConexao))
                {
                    objComando.Parameters.AddWithValue("@ID_AGE", ID_AGE);

                    objConexao.Open();

                    retorno = objComando.ExecuteNonQuery();

                    objConexao.Close();
                }
            }

            return retorno;
        }

        public int Atualizar(int ID_AGE, DateTime Age_Data, int ID_HOR, double Age_ValorSessao, int ID_FUN)
        {
            int retorno;
            using (SqlConnection objConexao = new SqlConnection(strConnection))
            {
                using (SqlCommand objComando = new SqlCommand(atualizar, objConexao))
                {
                    objComando.Parameters.AddWithValue("@ID_AGE", ID_AGE);
                    objComando.Parameters.AddWithValue("@Age_Data", Age_Data);
                    objComando.Parameters.AddWithValue("@ID_HOR", ID_HOR);
                    objComando.Parameters.AddWithValue("@Age_ValorSessao", Age_ValorSessao);
                    objComando.Parameters.AddWithValue("ID_FUN", ID_FUN);

                    objConexao.Open();

                    retorno = objComando.ExecuteNonQuery();

                    objConexao.Close();
                }
            }
            return retorno;
        }

        public int ConsultarIDAGE(MLTAB_AGENDA objml)
        {
            int ID_AGE = 0;

            using (SqlConnection objConexao = new SqlConnection(strConnection))
            {
                using (SqlCommand objComando = new SqlCommand(strSelectIDAGE, objConexao))
                {
                    objComando.Parameters.AddWithValue("@Age_Data", objml.Age_Data);
                    objComando.Parameters.AddWithValue("@Hora", objml.Hora);
                    objComando.Parameters.AddWithValue("@Cli_Nome", objml.Cli_Nome);

                    objConexao.Open();

                    SqlDataReader objDataReader = objComando.ExecuteReader();

                    if (objDataReader.HasRows)
                    {
                        while (objDataReader.Read())
                        {
                            ID_AGE = Convert.ToInt16(objDataReader["ID_AGE"].ToString());
                        }
                    }
                    objDataReader.Close();
                }
                objConexao.Close();
            }
            return ID_AGE;
        }

        public int ConsultarIDTAT(int ID_AGE)
        {
            int ID_TAT = 0;

            using (SqlConnection objConexao = new SqlConnection(strConnection))
            {
                using (SqlCommand objComando = new SqlCommand(strSelectIDTAT, objConexao))
                {
                    objComando.Parameters.AddWithValue("@ID_AGE", ID_AGE);

                    objConexao.Open();

                    SqlDataReader objDataReader = objComando.ExecuteReader();

                    if (objDataReader.HasRows)
                    {
                        while (objDataReader.Read())
                        {
                            ID_TAT = Convert.ToInt32(objDataReader["ID_TAT"].ToString());
                        }
                    }
                    objDataReader.Close();
                }
                objConexao.Close();
            }
            return ID_TAT;
        }

        #endregion

    }
}
