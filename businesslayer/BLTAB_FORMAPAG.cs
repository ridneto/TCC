using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ModelLayer;
using DataLayer;

namespace BusinessLayer
{
    public class BLTAB_FORMAPAG    
    {

        #region "Gravar"

        public int Gravar(MLTAB_FORMAPAG objMLTAB_FORMAPAG)
        {
            var objDLTAB_FORMAPAG = new DLTAB_FORMPAG();

            try
            {
                return objDLTAB_FORMAPAG.Gravar(objMLTAB_FORMAPAG);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objDLTAB_FORMAPAG = null;
            }
        }
        #endregion

        #region "Atualizar"

        public int Atualizar(int ID_AGE, string FormPag, int Parcelas)
        {
            var objDlTAB_FORMAPAG = new DLTAB_FORMPAG();

            try
            {
                return objDlTAB_FORMAPAG.Atualizar(ID_AGE, FormPag, Parcelas);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objDlTAB_FORMAPAG = null;
            }
        }
        #endregion
    }
}
