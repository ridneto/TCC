using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using ModelLayer;
using DataLayer;

namespace BusinessLayer
{
    public class BLClientes
    {

        #region "Excluir"

        public void Excluir(int pintIdCliente) 
        {
            var objDlClientes = new DLClientes();

            try
            {
                objDlClientes.Excluir(pintIdCliente);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally 
            {
                objDlClientes = null;
            }
        }           
        #endregion

        #region "Gravar"

        public int Gravar(MLClientes objMLClientes)
        {
            var objDlClientes = new DLClientes();

            try
            {
                return objDlClientes.Gravar(objMLClientes);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objDlClientes = null;
            }
        }
        #endregion

        #region "Atualizar"

        public int Atualizar(MLClientes objMLClientes)
        {
            var objDlClientes = new DLClientes();

            try
            {
                return objDlClientes.Atualizar(objMLClientes);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objDlClientes = null;
            }
        }
        #endregion

        #region "Consultar"

        public List<MLClientes> Consultar()
        {
            var objDlClientes = new DLClientes();

            try
            {
                return objDlClientes.Consultar();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objDlClientes = null;
            }
        }

        public List<MLClientes> Consultar(MLClientes objMLClientes)
        {
            var objDlClientes = new DLClientes();

            try
            {
                return objDlClientes.ConsultarNome(objMLClientes);
            }
            catch (Exception ex)
            {
                throw ex;

            }
            finally
            {
                objDlClientes = null;
            }
        }
        #endregion
    }
}
