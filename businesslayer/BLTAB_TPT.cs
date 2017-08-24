using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ModelLayer;
using DataLayer;

namespace BusinessLayer
{
    public class BLTAB_TPT
    {

        #region "Gravar"

        public int Gravar(MLTAB_TPT objMLTAB_TPT)
        {
            var objDLTAB_TPT = new DLTAB_TPT();

            try
            {
                return objDLTAB_TPT.Gravar(objMLTAB_TPT);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objDLTAB_TPT = null;
            }
        }

        #endregion

        #region Consultar

        public List<MLTAB_TPT> Consultar()
        {
            var objDlTAB_TPT = new DLTAB_TPT();

            try
            {
                return objDlTAB_TPT.Consultar();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objDlTAB_TPT = null;
            }
        }

        public List<MLTAB_TPT> ConsultarTipo(MLTAB_TPT objMLTAB_TPT)
        {
            var objDlTAB_TPT = new DLTAB_TPT();

            try
            {
                return objDlTAB_TPT.ConsultarTipo(objMLTAB_TPT);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objDlTAB_TPT = null;
            }

        }      

        #endregion

        #region "Excluir"

        public void Excluir(int pintID_TPT)
        {
            var objDlTAB_TPT = new DLTAB_TPT();

            try
            {
                objDlTAB_TPT.Excluir(pintID_TPT);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objDlTAB_TPT = null;
            }
        }
        #endregion

        #region "Atualizar"

        public int Atualizar(MLTAB_TPT objMLTAB_TPT)
        {
            var objDlTAB_TPT = new DLTAB_TPT();

            try
            {
                return objDlTAB_TPT.Atualizar(objMLTAB_TPT);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objDlTAB_TPT = null;
            }
        }
        #endregion
    }
}
