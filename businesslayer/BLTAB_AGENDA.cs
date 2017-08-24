using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ModelLayer;
using DataLayer;

namespace BusinessLayer
{
    public class BLTAB_AGENDA
    {

        #region "Consultar"

        public List<MLTAB_AGENDA> ConsultarDataEspecifica(DateTime dEspecifico)
        {
            var objDlTAB_AGENDA = new DLTAB_AGENDA();

            try
            {
                return objDlTAB_AGENDA.DiaEspecifico(dEspecifico);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objDlTAB_AGENDA = null;
            }

        }

        public List<MLTAB_AGENDA> ConsultarDataAtual(DateTime dAtual)
        {
            var objDlTAB_AGENDA = new DLTAB_AGENDA();

            try
            {
                return objDlTAB_AGENDA.DiaEspecifico(dAtual);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objDlTAB_AGENDA = null;
            }

        }

        public List<MLTAB_AGENDA> ConsultarDataEspecificaP(DateTime dEspecifico)
        {
            var objDlTAB_AGENDA = new DLTAB_AGENDA();

            try
            {
                return objDlTAB_AGENDA.DiaEspecificoP(dEspecifico);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objDlTAB_AGENDA = null;
            }
        }       

        public List<MLTAB_AGENDA> ConsultarDataPorNome(string Cli_Nome)
        {
            var objDlTAB_AGENDA = new DLTAB_AGENDA();

            try
            {
                return objDlTAB_AGENDA.DiaAtualCliente(Cli_Nome);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objDlTAB_AGENDA = null;
            }

        }

        public bool ConsultarSessaoLivre(DateTime Age_Data, string Hora)
        {
            var objDlTAB_AGENDA = new DLTAB_AGENDA();
            try
            {
                int ID = objDlTAB_AGENDA.ConsultarSessaoLivre(Age_Data, Hora);
                if (ID > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objDlTAB_AGENDA = null;
            }
        }

        public List<MLTAB_AGENDA> ValorSessoes(int ID_TA)
        {
            var objDlTAB_AGENDA = new DLTAB_AGENDA();

            try
            {
                return objDlTAB_AGENDA.ValorSessoes(ID_TA);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objDlTAB_AGENDA = null;
            }
        }

        public double ConsultarValorTotal(int ID_AGE)
        {
            var objDlTAB_AGENDA = new DLTAB_AGENDA();
            var objDLTAB_TAT = new DLTAB_TAT();
            double Tat_Total;
            try
            {
                int id_tat = objDlTAB_AGENDA.ConsultarIDTAT(ID_AGE);
                return Tat_Total = objDLTAB_TAT.ConsultarValorTotal(id_tat);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objDlTAB_AGENDA = null;
                objDLTAB_TAT = null;
            }

        }

        public double ConsultarValorFalta(int ID_AGE)
        {
            var objDlTAB_AGENDA = new DLTAB_AGENDA();
            var objDLTAB_TAT = new DLTAB_TAT();
            double Tat_FaltaPagar;
            try
            {
                int id_tat = objDlTAB_AGENDA.ConsultarIDTAT(ID_AGE);
                return Tat_FaltaPagar = objDLTAB_TAT.ConsultarValorFalta(id_tat);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objDlTAB_AGENDA = null;
                objDLTAB_TAT = null;
            }

        }

        public int ConsultaIDAGE(MLTAB_AGENDA objml)
        {
            var objAGE = new DLTAB_AGENDA();
            int ID_AGE;
            try
            {
                return ID_AGE = objAGE.ConsultarIDAGE(objml);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                objAGE = null;
            }
        }

        #endregion

        #region "Gravar"

        public int Gravar(MLTAB_AGENDA objMLTAB_AGENDA)
        {
            var objDLTAB_AGENDA = new DLTAB_AGENDA();
            try
            {
                return objDLTAB_AGENDA.Gravar(objMLTAB_AGENDA);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objDLTAB_AGENDA = null;
            }
        }

        #endregion

        #region "Atualizar"

        public bool Atualizar(string FormPag, int Parcelas, int ID_AGE, int ID_FUN, DateTime Age_Data, double Age_ValorSessao, int Age_Hora)        
        {
            var objDlTAB_FORMPAG = new DLTAB_FORMPAG();
            var objBLTAB_AGENDA = new DLTAB_AGENDA();
  
            try
            {
                objDlTAB_FORMPAG.Atualizar(ID_AGE, FormPag, Parcelas);
                objBLTAB_AGENDA.Atualizar(ID_AGE, Age_Data, Age_Hora, Age_ValorSessao, ID_FUN);
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
            finally
            {
                objDlTAB_FORMPAG = null;
                objBLTAB_AGENDA = null;            
            }            
        }

        public int AtualizarSessao(MLTAB_AGENDA objml)
        {
            var objDLTAB_AGENDA = new DLTAB_AGENDA();

            try
            {
                return objDLTAB_AGENDA.Atualizar(objDLTAB_AGENDA.ConsultarIDAGE(objml));                
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                objDLTAB_AGENDA = null;            
            }        
        }

        #endregion

        #region "Excluir"

        public bool Excluir(MLTAB_AGENDA objML)
        {
            var objDLFORMA = new DLTAB_FORMPAG();
            var objAGE = new DLTAB_AGENDA();

            try
            {
                int ID_AGE = objAGE.ConsultarIDAGE(objML);
                objDLFORMA.Excluir(ID_AGE);
                objAGE.ExcluirPorIDAGE(ID_AGE);
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
            finally
            {
                objDLFORMA = null;
                objAGE = null;
            }
        }

        public bool Excluir(int ID_AGE)
        {
            var objDLFORMA = new DLTAB_FORMPAG();
            var objAGE = new DLTAB_AGENDA();

            try
            {
                objDLFORMA.Excluir(ID_AGE);
                objAGE.ExcluirPorIDAGE(ID_AGE);
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
            finally
            {
                objDLFORMA = null;
                objAGE = null;
            }
        }

        #endregion

    }
}
