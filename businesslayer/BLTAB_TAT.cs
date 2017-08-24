using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ModelLayer;
using DataLayer;

namespace BusinessLayer
{
    public class BLTAB_TAT
    {
        #region PesquisaTatuagem

        public List<MLTAB_TAT> ConsultaTatuagemTODOS()
        {
            var objDlTAB_TAT = new DLTAB_TAT();

            try
            {
                return objDlTAB_TAT.ConsultarTatuagemTODOS();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objDlTAB_TAT = null;
            }
        }

        public List<MLTAB_TAT> ConsultaTatuagemFINALIZADAS()
        {
            var objDlTAB_TAT = new DLTAB_TAT();

            try
            {
                return objDlTAB_TAT.ConsultarTatuagemFINALIZADAS();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objDlTAB_TAT = null;
            }
        }

        public List<MLTAB_TAT> ConsultaTatuagemNAOFINALIZADAS()
        {
            var objDlTAB_TAT = new DLTAB_TAT();

            try
            {
                return objDlTAB_TAT.ConsultarTatuagemNAOFINALIZADAS();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objDlTAB_TAT = null;
            }
        }

        public List<MLTAB_TAT> ConsultaTatuagemTODOSNOME(MLTAB_TAT objMLTAB_TAT)
        {

            var objDLTAB_TAT = new DLTAB_TAT();

            try
            {
                return objDLTAB_TAT.ConsultarTatuagemTODOSNOME(objMLTAB_TAT);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                objDLTAB_TAT = null;
            }
        }

        public List<MLTAB_TAT> ConsultaTatuagemFINALIZADASNOME(MLTAB_TAT objMLTAB_TAT)
        {
            var objDLTAB_TAT = new DLTAB_TAT();

            try
            {
                return objDLTAB_TAT.ConsultarTatuagemFINALIZADASNOME(objMLTAB_TAT);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                objDLTAB_TAT = null;
            }
        }

        public List<MLTAB_TAT> ConsultaTatuagemNAOFINALIZADASNOME(MLTAB_TAT objMLTAB_TAT)
        {
            var objDLTAB_TAT = new DLTAB_TAT();

            try
            {
                return objDLTAB_TAT.ConsultarTatuagemNAOFINALIZADASNOME(objMLTAB_TAT);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                objDLTAB_TAT = null;
            }
        }

        #endregion

        public int Gravar(MLTAB_TAT objMLTAB_TAT)
        {
            var objDLTAB_TAT = new DLTAB_TAT();

            try
            {
                return objDLTAB_TAT.Gravar(objMLTAB_TAT);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objDLTAB_TAT = null;
            }
        }

        public MLTAB_TAT ConsultaTAT(int ID_TAT)
        {
            var objDL = new DLTAB_TAT();
            MLTAB_TAT ml = new MLTAB_TAT();
            try
            {
                return ml = objDL.consularTAT(ID_TAT);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                objDL = null;
                ml = null;
            }        
        }

        public List<MLTAB_TAT> ConsultarClienteAG(MLTAB_TAT objMLTAB_tatuagensAberto)
        {
            var objDlTAB_tatuagensAberto = new DLTAB_TAT();

            try
            {
                return objDlTAB_tatuagensAberto.ConsultarClienteAG(objMLTAB_tatuagensAberto);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objDlTAB_tatuagensAberto = null;
            }
        }

        public int ConsultarSessoes(int ID_TAT)
        {
            var objDLTAB_TAT = new DLTAB_TAT();

            try
            {
                return objDLTAB_TAT.ConsultarSessoes(ID_TAT);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objDLTAB_TAT = null;
            }
        }

        public int Atualizar(MLTAB_TAT objMLTAB_TAT)
        {
            var objDlTAB_TAT = new DLTAB_TAT();

            try
            {
                return objDlTAB_TAT.Atualizar(objMLTAB_TAT);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objDlTAB_TAT = null;
            }
        }

        public bool ExcluirTAT(int ID_TAT)
        {
            bool retorno = false;

            var objDLTAB_TAT = new DLTAB_TAT();
            var objDLTAB_AGENDA = new DLTAB_AGENDA();
            var objDLTAB_FORMPAGAR = new DLTAB_FORMPAG();

            List<MLTAB_AGENDA> objMLAgenda = new List<MLTAB_AGENDA>();

            objMLAgenda = objDLTAB_AGENDA.ConsultaID(ID_TAT);

            try
            {
                foreach (var item in objMLAgenda)
                {
                    objDLTAB_FORMPAGAR.Excluir(item.ID_AGE);                    
                }

                objDLTAB_AGENDA.ExcluirPorIDTAT(ID_TAT);

                objDLTAB_TAT.Excluir(ID_TAT);

                retorno = true;                               

            }
            catch (Exception)
            {
                retorno = false;
                throw;
            }
            finally
            {
                objDLTAB_TAT = null;
                objDLTAB_FORMPAGAR = null;
                objDLTAB_AGENDA = null;
            }

            return retorno;
        }

        public bool ChecarTat(int ID_CLI)
        {
            var objDLTAB_TAT = new DLTAB_TAT();
            
            try
            {
                return objDLTAB_TAT.ChecarTatuagem(ID_CLI);                
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                objDLTAB_TAT = null;
            }    
        }


    }
}
