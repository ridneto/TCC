using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ModelLayer;
using BusinessLayer;

namespace TCC_CAVALCENT
{
    public partial class frmPesquisarTipos : Form
    {
        public frmPesquisarTipos()
        {
            InitializeComponent();
        }

        public frmNovoOrcamentoTattoo objfrmNovoOrcamentoTattoo { get; set; }


        #region metodos

        private void CarregarTipos()
        {
            var objBLTAB_TPT = new BLTAB_TPT();
            var objMLTAB_TPT = new MLTAB_TPT();
            List<MLTAB_TPT> objListaTipos = new List<MLTAB_TPT>();

            objListaTipos = objBLTAB_TPT.Consultar();

            lstPesquisa.Items.Clear();

            foreach (var itemLista in objListaTipos)
            {
                ListViewItem objListViewItem = new ListViewItem();

                objListViewItem.Text = itemLista.ID_TPT.ToString();
                objListViewItem.SubItems.Add(itemLista.Tpt_Tipo);

                lstPesquisa.Items.Add(objListViewItem);
            }
        
        }

        private void ConfirmarTipo()
        {
            var objMLTAB_TPT = new MLTAB_TPT();

            if (lstPesquisa.SelectedItems.Count > 0)
            {
                objMLTAB_TPT.ID_TPT = Convert.ToInt32(lstPesquisa.SelectedItems[0].Text);
                objMLTAB_TPT.Tpt_Tipo = lstPesquisa.SelectedItems[0].SubItems[1].Text;

                objfrmNovoOrcamentoTattoo.ID_TPT = Convert.ToInt16(objMLTAB_TPT.ID_TPT);
                objfrmNovoOrcamentoTattoo.Tpt_Tipo = objMLTAB_TPT.Tpt_Tipo;
                this.Close();
            }        
        }

        #endregion

        #region eventos

        private void frmPesquisarTipos_Load(object sender, EventArgs e)
        {
            CarregarTipos();
        }

        private void lstPesquisa_DoubleClick(object sender, EventArgs e)
        {
            ConfirmarTipo();
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            ConfirmarTipo();
        }

        #endregion

        private void btnNovo_Click(object sender, EventArgs e)
        {
            frmNovoTipo objFrmNovoTipo = new frmNovoTipo();
            objFrmNovoTipo.ShowDialog();
            this.Close();
        }

        

        
        

    }
}
