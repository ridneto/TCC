using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ModelLayer;
using DataLayer;

namespace BusinessLayer
{
   public class BLTAB_CLI
    {

        #region "Excluir"

       public bool Excluir(int ID_CLI)
       {
           var objDlTAB_CLI = new DLTAB_CLI();
           var objBLTAB_TAT = new BLTAB_TAT();
           var objDLTAB_TAT = new DLTAB_TAT();

           List<MLTAB_TAT> objMLTAT = new List<MLTAB_TAT>();
           objMLTAT = objDLTAB_TAT.ConsultarIDTATPOIDCLI(ID_CLI);

           try
           {
               foreach (var item in objMLTAT)
               {
                   objBLTAB_TAT.ExcluirTAT(item.ID_TAT);
               }
               objDlTAB_CLI.Excluir(ID_CLI);
               return true;
           }
           catch (Exception ex)
           {
               return false;
               throw ex;
           }
           finally
           {
               objDlTAB_CLI = null;
               objDlTAB_CLI = null;
           }
       }
        #endregion

        #region "Gravar"

        public int Gravar(MLTAB_CLI objMLTAB_CLI)
        {
            var objDLTAB_CLI = new DLTAB_CLI();

            try
            {
                return objDLTAB_CLI.Gravar(objMLTAB_CLI);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objDLTAB_CLI = null;
            }
        }
        #endregion

        #region "Atualizar"

        public int Atualizar(MLTAB_CLI objMLTAB_CLI)
        {
            var objDlTAB_CLI = new DLTAB_CLI();

            try
            {
                return objDlTAB_CLI.Atualizar(objMLTAB_CLI);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objDlTAB_CLI = null;
            }
        }
        #endregion

        #region "Consultar"


        public string Consultar(int ID_CLI)
        {
            var objDLTAB_CLI = new DLTAB_CLI();

            try
            {
                return objDLTAB_CLI.ConsultarNome(ID_CLI);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {

                objDLTAB_CLI = null;
            
            }
        }

        public List<MLTAB_CLI> Consultar()
        {
            var objDlTAB_CLI = new DLTAB_CLI();

            try
            {
                return objDlTAB_CLI.Consultar();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objDlTAB_CLI = null;
            }
        }

        public List<MLTAB_CLI> Consultar(MLTAB_CLI objMLTAB_CLI)
        {
            var objDlTAB_CLI = new DLTAB_CLI();

            try
            {
                return objDlTAB_CLI.ConsultarNome(objMLTAB_CLI);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objDlTAB_CLI = null;
            }

        }      


        #endregion

    }
}
