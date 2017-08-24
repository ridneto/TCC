using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ModelLayer;
using DataLayer;

namespace BusinessLayer
{
    public class BLTAB_FUNC
    {  
        #region "Consultar"

        public List<MLTAB_FUNC> Consultar(string nome, string senha)
        {
            var objDLTAB_FUNC = new DLTAB_FUNC();

            try
            {
                return objDLTAB_FUNC.Consultar(nome, senha);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objDLTAB_FUNC = null;
            }
        }

        public List<MLTAB_FUNC> Consultar(MLTAB_FUNC objMLTAB_FUNC)
        {
            var objDlTAB_FUNC = new DLTAB_FUNC();

            try
            {
                return objDlTAB_FUNC.ConsultarNome(objMLTAB_FUNC);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objDlTAB_FUNC = null;
            }

        }            

        public List<MLTAB_FUNC> ConsultarTatuadores()
        {
            var objDlTAB_FUNC = new DLTAB_FUNC();

            try
            {
                return objDlTAB_FUNC.ConsultarTatuadores();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objDlTAB_FUNC = null;
            }
        }

        #endregion

        #region "Gravar"

        public int Gravar(MLTAB_FUNC objMLTAB_FUNC)
        {
            var objDLTAB_FUN = new DLTAB_FUNC();

            try
            {
                return objDLTAB_FUN.Gravar(objMLTAB_FUNC);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objDLTAB_FUN = null;
            }
        }

        #endregion

        #region "Pesquisar"

        public List<MLTAB_FUNC> Pesquisar()
        {
            var objDlTAB_FUNC = new DLTAB_FUNC();

            try
            {
                return objDlTAB_FUNC.Consultar();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objDlTAB_FUNC = null;
            }
        }

        #endregion

        #region "Excluir"

        public void Excluir(int pintID_FUN)
        {
            var objDlTAB_FUNC = new DLTAB_FUNC();

            try
            {
                objDlTAB_FUNC.Excluir(pintID_FUN);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objDlTAB_FUNC = null;
            }
        }
        #endregion

        #region "Atualizar"

        public int Atualizar(MLTAB_FUNC objMLTAB_FUNC)
        {
            var objDlTAB_FUNC = new DLTAB_FUNC();

            try
            {
                return objDlTAB_FUNC.Atualizar(objMLTAB_FUNC);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objDlTAB_FUNC = null;
            }
        }
        #endregion
    }
}
