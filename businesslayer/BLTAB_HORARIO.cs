using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ModelLayer;
using DataLayer;

namespace BusinessLayer
{
    public class BLTAB_HORARIO
    {
        public List<MLTAB_HORARIO> ConsultarHorario(DateTime Dia)
        {
            var objDlTAB_HORARIO = new DLTAB_HORARIO();

            try
            {
                return objDlTAB_HORARIO.ConsultarHorarios(Dia);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objDlTAB_HORARIO = null;
            }
        }
    }
}
