using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ModelLayer
{
    public class MLTAB_AGENDA
    {
         public int ID_AGE { get; set; }
         public int ID_TAT { get; set; }
         public int ID_FUN { get; set; }
         public DateTime Age_Data { get; set; }
         public int ID_HOR { get; set; }
         public string Age_Realizada { get; set; }
         public double Age_ValorSessao { get; set; }
         public int Fpg_Vezes { get; set; }
         public string Fpg_Forma { get; set; }
        
         public string Hora { get; set; }
         public string Cli_Nome { get; set; }
         public string Tpt_Tipo { get; set; }
         public string Tat_Descricao { get; set; }
    }
}
