using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;

namespace TCC_CAVALCENT
{
    public partial class frmRelatorio : Form
    {

        public string pInicio;
        public string pFinal;

        public frmRelatorio()
        {
            InitializeComponent();
        }

        public bool realizada { get; set; }

        private void frmRelatorio_Load(object sender, EventArgs e)
        {
            if (realizada)
            {
                ReportParameter objParameter1 = new ReportParameter("pInicio", pInicio);
                ReportParameter objParameter2 = new ReportParameter("pFinal", pFinal);

                this.dataTable1TableAdapter.FillByRel(this.dB_TCCDataSet.DataTable1, pInicio, pFinal);

                this.reportViewer1.LocalReport.SetParameters(objParameter1);
                this.reportViewer1.LocalReport.SetParameters(objParameter2);

                this.reportViewer1.RefreshReport();
                this.reportViewer1.Show();
            }
            else
            {
                ReportParameter objParameter1 = new ReportParameter("pInicio", pInicio);
                ReportParameter objParameter2 = new ReportParameter("pFinal", pFinal);

                this.dataTable1TableAdapter.FillByNao(this.dB_TCCDataSet.DataTable1, pInicio, pFinal);

                this.reportViewer1.LocalReport.SetParameters(objParameter1);
                this.reportViewer1.LocalReport.SetParameters(objParameter2);

                this.reportViewer1.RefreshReport();
                this.reportViewer1.Show();
            }
            
        }
    }
}
