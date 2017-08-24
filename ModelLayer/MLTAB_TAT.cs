using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ModelLayer
{
    public class MLTAB_TAT
    {
        public int    ID_TAT { get; set; } 
        public int    ID_TPT { get; set; }
        public int    Tat_Sessoes { get; set; }
        public string Tat_Aberto { get; set; }
        public double Tat_Total { get; set; }
        public double Tat_FaltaPagar { get; set; }
        public int    ID_CLI { get; set; }
        public string Tat_Descricao { get; set; }

        public double teste { get; set; }

        public string Cli_Nome { get; set; }
        public string Tpt_Tipo { get; set; }
    }
}
