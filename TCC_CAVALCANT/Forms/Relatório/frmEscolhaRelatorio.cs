using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Globalization;

namespace TCC_CAVALCENT
{
    public partial class frmEscolhaRelatorio : Form
    {
        public frmEscolhaRelatorio()
        {
            InitializeComponent();
        }

        public bool Realizada { get; set; }

        private void btnRelatorio_Click(object sender, EventArgs e)
        {
            frmRelatorio objFrmRelatorio = new frmRelatorio();
            CultureInfo ci = new CultureInfo("en-US");
            
            objFrmRelatorio.pInicio = txtInicio.Value.ToShortDateString();
            objFrmRelatorio.pFinal = txtFinal.Value.ToShortDateString();
            if (Realizada)
            {
                objFrmRelatorio.realizada = true;
            }
            else
            {
                objFrmRelatorio.realizada = false;
            }

            objFrmRelatorio.Show();
        } 
    }
}
