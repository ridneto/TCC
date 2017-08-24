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
    public class DLTAB_TAT
    {
        #region Conexão

        public string strConnection = ConfigurationManager.ConnectionStrings["TCC_CAVALCENT.Properties.Settings.DB_TCCConnectionString"].ConnectionString;

        #endregion

        #region Comando

        public const string strSelectTodos = "SELECT Cli_Nome, ID_TAT, Tpt_Tipo, Tat_Descricao, Tat_Total, Tat_FaltaPagar FROM TAB_CLI TC, TAB_TAT TAT, TAB_TPT TPT WHERE TC.ID_CLI = TAT.ID_CLI AND TAT.ID_TPT = TPT.ID_TPT ORDER BY Cli_Nome";
        public const string strSelectFINALIZADAS = "SELECT Cli_Nome, ID_TAT, Tpt_Tipo, Tat_Descricao, Tat_Total, Tat_FaltaPagar FROM TAB_CLI TC, TAB_TAT TAT, TAB_TPT TPT WHERE TC.ID_CLI = TAT.ID_CLI AND TAT.ID_TPT = TPT.ID_TPT AND TAT.Tat_Aberto = 'F' ORDER BY Cli_Nome";
        public const string strSelectNAOFINALIZADAS = "SELECT Cli_Nome, ID_TAT, Tpt_Tipo, Tat_Descricao, Tat_Total, Tat_FaltaPagar FROM TAB_CLI TC, TAB_TAT TAT, TAB_TPT TPT WHERE TC.ID_CLI = TAT.ID_CLI AND TAT.ID_TPT = TPT.ID_TPT AND TAT.Tat_Aberto = 'A' ORDER BY Cli_Nome";
        public const string strSelectTodosNOME = "SELECT Cli_Nome, ID_TAT, Tpt_Tipo, Tat_Descricao, Tat_Total, Tat_FaltaPagar FROM TAB_CLI TC, TAB_TAT TAT, TAB_TPT TPT WHERE TC.ID_CLI = TAT.ID_CLI AND TAT.ID_TPT = TPT.ID_TPT AND Cli_Nome like '%' + @Cli_Nome + '%' ORDER BY Cli_Nome";
        public const string strSelectFINALIZADASNOME = "SELECT Cli_Nome, ID_TAT, Tpt_Tipo, Tat_Descricao, Tat_Total, Tat_FaltaPagar FROM TAB_CLI TC, TAB_TAT TAT, TAB_TPT TPT WHERE TC.ID_CLI = TAT.ID_CLI AND TAT.ID_TPT = TPT.ID_TPT AND TAT.Tat_Aberto = 'F' AND Cli_Nome like '%' + @Cli_Nome + '%' ORDER BY Cli_Nome";
        public const string strSelectNAOFINALIZADASNOME = "SELECT Cli_Nome, ID_TAT, Tpt_Tipo, Tat_Descricao, Tat_Total, Tat_FaltaPagar FROM TAB_CLI TC, TAB_TAT TAT, TAB_TPT TPT WHERE TC.ID_CLI = TAT.ID_CLI AND TAT.ID_TPT = TPT.ID_TPT AND TAT.Tat_Aberto = 'A' AND Cli_Nome like '%' + @Cli_Nome + '%' ORDER BY Cli_Nome";
        public const string strSelectClienteAG = "SELECT Cli_Nome, ID_TAT, Tpt_Tipo, Tat_Descricao, Tat_Total, Tat_Sessoes, Tat_FaltaPagar FROM TAB_TAT TT, TAB_CLI TC, TAB_TPT TPT WHERE TT.ID_CLI = TC.ID_CLI AND TT.ID_TPT = TPT.ID_TPT AND TT.ID_CLI = @ID_CLI AND Tat_Aberto = 'A'";
        public const string strInsert = "INSERT INTO TAB_TAT Values (@ID_TPT, @ID_CLI, @Tat_Aberto, @Tat_Sessoes, @Tat_Total, @Tat_FaltaPagar, @Tat_Descricao) SELECT SCOPE_IDENTITY()";
        public const string strSelectSessoes = "SELECT Tat_Sessoes FROM TAB_TAT WHERE ID_TAT = @ID_TAT";
        public const string strUpdate = "UPDATE TAB_TAT SET ID_TPT = @ID_TPT, Tat_Sessoes = @Tat_Sessoes, Tat_Total = @Tat_Total, Tat_Descricao = @Tat_Descricao, Tat_FaltaPagar = @Tat_FaltaPagar WHERE ID_TAT = @ID_TAT";
        public const string strDelete = "DELETE FROM TAB_TAT WHERE ID_TAT = @ID_TAT";
        public const string strSelectID = "SELECT ID_TAT FROM TAB_TAT WHERE ID_CLI = @ID_CLI";
        public const string strSelectValorTotal = "SELECT Tat_Total FROM TAB_TAT WHERE ID_TAT = @ID_TAT";
        public const string strSelectValorFalta = "SELECT Tat_FaltaPagar FROM TAB_TAT WHERE ID_TAT = @ID_TAT";
        public const string strSelectIDTATPORIDCLI = "SELECT ID_TAT FROM TAB_TAT WHERE ID_CLI = @ID_CLI";
        public const string strSelectTAT = "SELECT Tat_Total, Tat_FaltaPagar, Tat_Descricao, Tpt_Tipo FROM TAB_TAT TA, TAB_TPT TP WHERE TA.ID_TPT = TP.ID_TPT AND ID_TAT = @ID_TAT"; 
        public const string strChecarTatuagem = "SELECT ID_TAT FROM TAB_TAT where ID_CLI = @ID_CLI and Tat_Aberto = 'A'"; 

        #endregion

        #region Metodos

        public bool ChecarTatuagem(int ID_CLI)
        {
            int id = 0;
            using (SqlConnection objConexao = new SqlConnection(strConnection))
            {
                using (SqlCommand objComando = new SqlCommand(strChecarTatuagem, objConexao))
                {
                    objComando.Parameters.AddWithValue("@ID_CLI", ID_CLI);

                    objConexao.Open();

                    SqlDataReader objDataReader = objComando.ExecuteReader();

                    if (objDataReader.HasRows)
                    {

                        while (objDataReader.Read())
                        {
                            id = Convert.ToInt32(objDataReader["ID_TAT"]);
                        }

                        objDataReader.Close();
                    }

                    objConexao.Close();
                }
            }
            if (id > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }





        public int Gravar(MLTAB_TAT objMLTAB_TAT)
        {
            int retorno = 0;

            using (SqlConnection objConexao = new SqlConnection(strConnection))
            {
                using (SqlCommand objComando = new SqlCommand(strInsert, objConexao))
                {
                    objComando.Parameters.AddWithValue("@ID_TPT", Convert.ToInt32(objMLTAB_TAT.ID_TPT));
                    objComando.Parameters.AddWithValue("@ID_CLI", Convert.ToInt32(objMLTAB_TAT.ID_CLI));
                    objComando.Parameters.AddWithValue("@Tat_Aberto", objMLTAB_TAT.Tat_Aberto);
                    objComando.Parameters.AddWithValue("@Tat_Sessoes", Convert.ToInt32(objMLTAB_TAT.Tat_Sessoes));
                    objComando.Parameters.AddWithValue("@Tat_Total", Convert.ToDouble(objMLTAB_TAT.Tat_Total));
                    objComando.Parameters.AddWithValue("@Tat_FaltaPagar", Convert.ToDouble(objMLTAB_TAT.Tat_FaltaPagar));
                    objComando.Parameters.AddWithValue("@Tat_Descricao", objMLTAB_TAT.Tat_Descricao);

                    objConexao.Open();
                    //Utilizo o ExecuteScalar para obter o ID Gravado.
                    retorno = Convert.ToInt32(objComando.ExecuteScalar());

                    objConexao.Close();
                }
            }
            return retorno;
        }

        public List<MLTAB_TAT> ConsultarClienteAG(MLTAB_TAT objMLTAB_TAT)
        {
            List<MLTAB_TAT> lstMLTAB_TAT = new List<MLTAB_TAT>();

            using (SqlConnection objConexao = new SqlConnection(strConnection))
            {
                using (SqlCommand objComando = new SqlCommand(strSelectClienteAG, objConexao))
                {
                    objComando.Parameters.AddWithValue("@ID_CLI", objMLTAB_TAT.ID_CLI);
                    
                    objConexao.Open();

                    SqlDataReader objDataReader = objComando.ExecuteReader();

                    if (objDataReader.HasRows)
                    {

                        while (objDataReader.Read())
                        {
                            MLTAB_TAT objMLTAT = new MLTAB_TAT();

                            //Cli_Nome, ID_TAT, Tpt_Tipo, Tat_Descricao, Tat_Total, Tat_Sessoes

                            objMLTAT.Cli_Nome = objDataReader["Cli_Nome"].ToString();
                            objMLTAT.ID_TAT = Convert.ToInt32(objDataReader["ID_TAT"]);
                            objMLTAT.Tpt_Tipo = objDataReader["Tpt_Tipo"].ToString();
                            objMLTAT.Tat_Descricao = objDataReader["Tat_Descricao"].ToString();
                            objMLTAT.Tat_Total = Convert.ToDouble(objDataReader["Tat_Total"]);
                            objMLTAT.Tat_Sessoes = Convert.ToInt32(objDataReader["Tat_Sessoes"]);
                            //objMLTAB_TAT.Tat_FaltaPagar = Convert.ToDouble(objDataReader["Tat_FaltaPagar"]);
                            objMLTAT.Tat_FaltaPagar = Convert.ToDouble(objDataReader["Tat_FaltaPagar"]);

                            objMLTAB_TAT.teste = objMLTAB_TAT.Tat_FaltaPagar;

                            lstMLTAB_TAT.Add(objMLTAT);
                        }

                        objDataReader.Close();
                    }

                    objConexao.Close();
                }
            }
            return lstMLTAB_TAT;
        }

        public int ConsultarSessoes(int ID_TAT)
        {
            int Sessoes = 0;

            using (SqlConnection objConexao = new SqlConnection(strConnection))
            {
                using (SqlCommand objComando = new SqlCommand(strSelectSessoes, objConexao))
                {
                    objComando.Parameters.AddWithValue("@ID_TAT", ID_TAT);

                    objConexao.Open();

                    SqlDataReader objDataReader = objComando.ExecuteReader();

                    if (objDataReader.HasRows)
                    {
                        while (objDataReader.Read())
                        {
                            Sessoes = Convert.ToInt32(objDataReader["Tat_Sessoes"].ToString());
                        }                        
                    }                    

                    objDataReader.Close();
                }
                objConexao.Close();
            }
            return Sessoes;
        }

        public int Atualizar(MLTAB_TAT objMLTAB_TAT)
        {
            int retorno = 0;

            using (SqlConnection objConexao = new SqlConnection(strConnection))
            {
                using (SqlCommand objComando = new SqlCommand(strUpdate, objConexao))
                {
                    objComando.Parameters.AddWithValue("@ID_TPT", objMLTAB_TAT.ID_TPT);
                    objComando.Parameters.AddWithValue("@Tat_Sessoes", objMLTAB_TAT.Tat_Sessoes);
                    objComando.Parameters.AddWithValue("@Tat_Total", objMLTAB_TAT.Tat_Total);
                    objComando.Parameters.AddWithValue("@Tat_Descricao", objMLTAB_TAT.Tat_Descricao);
                    objComando.Parameters.AddWithValue("@ID_TAT", objMLTAB_TAT.ID_TAT);
                    objComando.Parameters.AddWithValue("@Tat_FaltaPagar", objMLTAB_TAT.Tat_FaltaPagar);

                    objConexao.Open();

                    retorno = objComando.ExecuteNonQuery();

                    objConexao.Close();
                }
            }
            return retorno;
        }

        public double ConsultarValorTotal(int ID_TAT)
        {
            double Tat_Total = 0;

            using (SqlConnection objConexao = new SqlConnection(strConnection))
            {
                using (SqlCommand objComando = new SqlCommand(strSelectValorTotal, objConexao))
                {
                    objComando.Parameters.AddWithValue("@ID_TAT", ID_TAT);

                    objConexao.Open();

                    SqlDataReader objDataReader = objComando.ExecuteReader();

                    if (objDataReader.HasRows)
                    {
                        while (objDataReader.Read())
                        {
                            Tat_Total = Convert.ToDouble(objDataReader["Tat_Total"].ToString());
                        }
                    }
                    objDataReader.Close();
                }
                objConexao.Close();
            }
            return Tat_Total;
        }

        public double ConsultarValorFalta(int ID_TAT)
        {
            double Tat_FaltaPagar = 0;

            using (SqlConnection objConexao = new SqlConnection(strConnection))
            {
                using (SqlCommand objComando = new SqlCommand(strSelectValorFalta, objConexao))
                {
                    objComando.Parameters.AddWithValue("@ID_TAT", ID_TAT);

                    objConexao.Open();

                    SqlDataReader objDataReader = objComando.ExecuteReader();

                    if (objDataReader.HasRows)
                    {
                        while (objDataReader.Read())
                        {
                            Tat_FaltaPagar = Convert.ToDouble(objDataReader["Tat_FaltaPagar"].ToString());
                        }
                    }
                    objDataReader.Close();
                }
                objConexao.Close();
            }
            return Tat_FaltaPagar;
        }

        #region PesquisaTatuagem

        //Cli_Nome, ID_TAT, Tpt_Tipo, Tat_Descricao, Tat_Total, Tat_FaltaPagar

        public List<MLTAB_TAT> ConsultarTatuagemTODOS()
        {
            List<MLTAB_TAT> lstMLTAB_TAT = new List<MLTAB_TAT>();

            using (SqlConnection objConexao = new SqlConnection(strConnection))
            {
                using (SqlCommand objComando = new SqlCommand(strSelectTodos, objConexao))
                { 
                    objConexao.Open();

                    SqlDataReader objDataReader = objComando.ExecuteReader();

                    if (objDataReader.HasRows)
                    {

                        while (objDataReader.Read())
                        {
                            MLTAB_TAT objMLTAT = new MLTAB_TAT();

                            objMLTAT.Cli_Nome = objDataReader["Cli_Nome"].ToString();
                            objMLTAT.ID_TAT = Convert.ToInt32(objDataReader["ID_TAT"]);
                            objMLTAT.Tpt_Tipo = objDataReader["Tpt_Tipo"].ToString();
                            objMLTAT.Tat_Descricao = objDataReader["Tat_Descricao"].ToString();
                            objMLTAT.Tat_Total = Convert.ToDouble(objDataReader["Tat_Total"]);
                            objMLTAT.Tat_FaltaPagar = Convert.ToDouble(objDataReader["Tat_FaltaPagar"]);

                            lstMLTAB_TAT.Add(objMLTAT);
                        }

                        objDataReader.Close();
                    }

                    objConexao.Close();
                }
            }
            return lstMLTAB_TAT;
        }

        public List<MLTAB_TAT> ConsultarTatuagemFINALIZADAS()
        {
            List<MLTAB_TAT> lstMLTAB_TAT = new List<MLTAB_TAT>();

            using (SqlConnection objConexao = new SqlConnection(strConnection))
            {
                using (SqlCommand objComando = new SqlCommand(strSelectFINALIZADAS, objConexao))
                {
                    objConexao.Open();

                    SqlDataReader objDataReader = objComando.ExecuteReader();

                    if (objDataReader.HasRows)
                    {

                        while (objDataReader.Read())
                        {
                            MLTAB_TAT objMLTAT = new MLTAB_TAT();

                            objMLTAT.Cli_Nome = objDataReader["Cli_Nome"].ToString();
                            objMLTAT.ID_TAT = Convert.ToInt32(objDataReader["ID_TAT"]);
                            //objMLTAT.ID_TPT = Convert.ToInt32(objDataReader["ID_TPT"]);
                            objMLTAT.Tpt_Tipo = objDataReader["Tpt_Tipo"].ToString();
                            objMLTAT.Tat_Descricao = objDataReader["Tat_Descricao"].ToString();
                            objMLTAT.Tat_Total = Convert.ToDouble(objDataReader["Tat_Total"]);
                            objMLTAT.Tat_FaltaPagar = Convert.ToDouble(objDataReader["Tat_FaltaPagar"]);

                            lstMLTAB_TAT.Add(objMLTAT);
                        }

                        objDataReader.Close();
                    }

                    objConexao.Close();
                }
            }
            return lstMLTAB_TAT;
        }

        public List<MLTAB_TAT> ConsultarTatuagemNAOFINALIZADAS()
        {
            List<MLTAB_TAT> lstMLTAB_TAT = new List<MLTAB_TAT>();

            using (SqlConnection objConexao = new SqlConnection(strConnection))
            {
                using (SqlCommand objComando = new SqlCommand(strSelectNAOFINALIZADAS, objConexao))
                {
                    objConexao.Open();

                    SqlDataReader objDataReader = objComando.ExecuteReader();

                    if (objDataReader.HasRows)
                    {

                        while (objDataReader.Read())
                        {
                            MLTAB_TAT objMLTAT = new MLTAB_TAT();

                            objMLTAT.Cli_Nome = objDataReader["Cli_Nome"].ToString();
                            objMLTAT.ID_TAT = Convert.ToInt32(objDataReader["ID_TAT"]);
                           // objMLTAT.ID_TPT = Convert.ToInt32(objDataReader["ID_TPT"]);
                            objMLTAT.Tpt_Tipo = objDataReader["Tpt_Tipo"].ToString();
                            objMLTAT.Tat_Descricao = objDataReader["Tat_Descricao"].ToString();
                            objMLTAT.Tat_Total = Convert.ToDouble(objDataReader["Tat_Total"]);
                            objMLTAT.Tat_FaltaPagar = Convert.ToDouble(objDataReader["Tat_FaltaPagar"]);

                            lstMLTAB_TAT.Add(objMLTAT);
                        }

                        objDataReader.Close();
                    }

                    objConexao.Close();
                }
            }
            return lstMLTAB_TAT;
        }

        public List<MLTAB_TAT> ConsultarTatuagemTODOSNOME(MLTAB_TAT objMLTAB_TAT)
        {
            List<MLTAB_TAT> lstMLTAB_tatuagensAberto = new List<MLTAB_TAT>();

            using (SqlConnection objConexao = new SqlConnection(strConnection))
            {
                using (SqlCommand objComando = new SqlCommand(strSelectTodosNOME, objConexao))
                {

                    objComando.Parameters.AddWithValue("@Cli_Nome", objMLTAB_TAT.Cli_Nome);


                    objConexao.Open();

                    SqlDataReader objDataReader = objComando.ExecuteReader();

                    if (objDataReader.HasRows)
                    {

                        while (objDataReader.Read())
                        {
                            MLTAB_TAT objMLTAT = new MLTAB_TAT();

                            objMLTAT.Cli_Nome = objDataReader["Cli_Nome"].ToString();
                            objMLTAT.ID_TAT = Convert.ToInt32(objDataReader["ID_TAT"]);
                          // objMLTAT.ID_TPT = Convert.ToInt32(objDataReader["ID_TPT"]);
                            objMLTAT.Tpt_Tipo = objDataReader["Tpt_Tipo"].ToString();
                            objMLTAT.Tat_Descricao = objDataReader["Tat_Descricao"].ToString();
                            objMLTAT.Tat_Total = Convert.ToDouble(objDataReader["Tat_Total"]);
                            objMLTAT.Tat_FaltaPagar = Convert.ToDouble(objDataReader["Tat_FaltaPagar"]);


                            lstMLTAB_tatuagensAberto.Add(objMLTAT);
                        }

                        objDataReader.Close();
                    }

                    objConexao.Close();
                }
            }
            return lstMLTAB_tatuagensAberto;
        }

        public List<MLTAB_TAT> ConsultarTatuagemFINALIZADASNOME(MLTAB_TAT objMLTAB_TAT)
        {
            List<MLTAB_TAT> lstMLTAB_tatuagensAberto = new List<MLTAB_TAT>();

            using (SqlConnection objConexao = new SqlConnection(strConnection))
            {
                using (SqlCommand objComando = new SqlCommand(strSelectFINALIZADASNOME, objConexao))
                {

                    objComando.Parameters.AddWithValue("@Cli_Nome", objMLTAB_TAT.Cli_Nome);


                    objConexao.Open();

                    SqlDataReader objDataReader = objComando.ExecuteReader();

                    if (objDataReader.HasRows)
                    {

                        while (objDataReader.Read())
                        {
                            MLTAB_TAT objMLTAT = new MLTAB_TAT();

                            objMLTAT.Cli_Nome = objDataReader["Cli_Nome"].ToString();
                            objMLTAT.ID_TAT = Convert.ToInt32(objDataReader["ID_TAT"]);
                            // objMLTAT.ID_TPT = Convert.ToInt32(objDataReader["ID_TPT"]);
                            objMLTAT.Tpt_Tipo = objDataReader["Tpt_Tipo"].ToString();
                            objMLTAT.Tat_Descricao = objDataReader["Tat_Descricao"].ToString();
                            objMLTAT.Tat_Total = Convert.ToDouble(objDataReader["Tat_Total"]);
                            objMLTAT.Tat_FaltaPagar = Convert.ToDouble(objDataReader["Tat_FaltaPagar"]);


                            lstMLTAB_tatuagensAberto.Add(objMLTAT);
                        }

                        objDataReader.Close();
                    }

                    objConexao.Close();
                }
            }
            return lstMLTAB_tatuagensAberto;
        }

        public List<MLTAB_TAT> ConsultarTatuagemNAOFINALIZADASNOME(MLTAB_TAT objMLTAB_TAT)
        {
            List<MLTAB_TAT> lstMLTAB_tatuagensAberto = new List<MLTAB_TAT>();

            using (SqlConnection objConexao = new SqlConnection(strConnection))
            {
                using (SqlCommand objComando = new SqlCommand(strSelectNAOFINALIZADASNOME, objConexao))
                {

                    objComando.Parameters.AddWithValue("@Cli_Nome", objMLTAB_TAT.Cli_Nome);


                    objConexao.Open();

                    SqlDataReader objDataReader = objComando.ExecuteReader();

                    if (objDataReader.HasRows)
                    {

                        while (objDataReader.Read())
                        {
                            MLTAB_TAT objMLTAT = new MLTAB_TAT();

                            objMLTAT.Cli_Nome = objDataReader["Cli_Nome"].ToString();
                            objMLTAT.ID_TAT = Convert.ToInt32(objDataReader["ID_TAT"]);
                            // objMLTAT.ID_TPT = Convert.ToInt32(objDataReader["ID_TPT"]);
                            objMLTAT.Tpt_Tipo = objDataReader["Tpt_Tipo"].ToString();
                            objMLTAT.Tat_Descricao = objDataReader["Tat_Descricao"].ToString();
                            objMLTAT.Tat_Total = Convert.ToDouble(objDataReader["Tat_Total"]);
                            objMLTAT.Tat_FaltaPagar = Convert.ToDouble(objDataReader["Tat_FaltaPagar"]);
                            
                            lstMLTAB_tatuagensAberto.Add(objMLTAT);
                        }

                        objDataReader.Close();
                    }

                    objConexao.Close();
                }
            }
            return lstMLTAB_tatuagensAberto;
        }

        #endregion

        public int Excluir(int ID_TAT)
        {
            int retorno = 0;

            using (SqlConnection objConexao = new SqlConnection(strConnection))
            {
                using (SqlCommand objComando = new SqlCommand(strDelete, objConexao))
                {
                    objComando.Parameters.AddWithValue("@ID_TAT", ID_TAT);

                    objConexao.Open();

                    retorno = objComando.ExecuteNonQuery();

                    objConexao.Close();
                }
            }

            return retorno;
        }

        public int ConsultarID(int ID_CLI)
        {
            int ID_TAT = 0;

            using (SqlConnection objConexao = new SqlConnection(strConnection))
            {
                using (SqlCommand objComando = new SqlCommand(strSelectID, objConexao))
                {
                    objComando.Parameters.AddWithValue("@ID_CLI", ID_CLI);

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

        public List<MLTAB_TAT> ConsultarIDTATPOIDCLI(int ID_CLI)
        {
            List<MLTAB_TAT> lstMLTAB_TAT = new List<MLTAB_TAT>();

            using (SqlConnection objConexao = new SqlConnection(strConnection))
            {
                using (SqlCommand objComando = new SqlCommand(strSelectIDTATPORIDCLI, objConexao))
                {
                    objComando.Parameters.AddWithValue("@ID_CLI", ID_CLI);

                    objConexao.Open();

                    SqlDataReader objDataReader = objComando.ExecuteReader();

                    if (objDataReader.HasRows)
                    {

                        while (objDataReader.Read())
                        {
                            MLTAB_TAT objMLTAT = new MLTAB_TAT();

                            objMLTAT.ID_TAT = Convert.ToInt32(objDataReader["ID_TAT"]);

                            lstMLTAB_TAT.Add(objMLTAT);
                        }

                        objDataReader.Close();
                    }

                    objConexao.Close();
                }
            }
            return lstMLTAB_TAT;
        }

        public MLTAB_TAT consularTAT(int ID_TAT)
        {
            MLTAB_TAT ml = new MLTAB_TAT();
            using (SqlConnection objConexao = new SqlConnection(strConnection))
            {
                using (SqlCommand objComando = new SqlCommand(strSelectTAT, objConexao))
                {
                    objComando.Parameters.AddWithValue("@ID_TAT", ID_TAT);

                    objConexao.Open();

                    SqlDataReader objDataReader = objComando.ExecuteReader();

                    if (objDataReader.HasRows)
                    {
                        while (objDataReader.Read())
                        {
                            ml.Tat_Total = Convert.ToDouble(objDataReader["Tat_Total"].ToString());
                            ml.Tat_FaltaPagar = Convert.ToDouble(objDataReader["Tat_FaltaPagar"].ToString());
                            ml.Tat_Descricao = (objDataReader["Tat_Descricao"].ToString());
                            ml.Tpt_Tipo = (objDataReader["Tpt_Tipo"].ToString());
                        }
                    }
                    objDataReader.Close();
                }
                objConexao.Close();
            }
            return ml;
        }

        #endregion

        
    }
}
