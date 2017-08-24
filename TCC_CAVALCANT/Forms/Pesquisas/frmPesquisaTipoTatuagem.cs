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
    public partial class frmPesquisaTipoTatuagem : Form
    {
        public frmPesquisaTipoTatuagem()
        {
            InitializeComponent();
        }


        #region metodos

        private void Excluir()
        {
            try
            {
                var objTAB_TPT = new BLTAB_TPT();
                int ID_CLI = 0;

                if (lstPesquisa.SelectedItems.Count > 0)
                {
                    ID_CLI = Convert.ToInt32(lstPesquisa.SelectedItems[0].Text);
                }
                objTAB_TPT.Excluir(ID_CLI);
                MessageBox.Show("Tipo de Tatuagem excluida com sucesso");
            }
            catch (Exception)
            {
                MessageBox.Show("Não é possível excluir esse tipo de tatuagem pois este tipo está sendo utilizado em uma tatuagem.");
            }
        }

        private void CarregarTipo()
        {
            var objBLTAB_TPT = new BLTAB_TPT();
            List<MLTAB_TPT> objListaTPT = new List<MLTAB_TPT>();
            objListaTPT = objBLTAB_TPT.Consultar();

            lstPesquisa.Items.Clear();

            foreach (var itemLista in objListaTPT)
            {
                ListViewItem objListViewItem = new ListViewItem();

                objListViewItem.Text = itemLista.ID_TPT.ToString();
                objListViewItem.SubItems.Add(itemLista.Tpt_Tipo);

                lstPesquisa.Items.Add(objListViewItem);
            }
        
        }

        private void Alterar()
        {
            var objMLTAB_TPT = new MLTAB_TPT();

            if (lstPesquisa.SelectedItems.Count > 0)
            {
                objMLTAB_TPT.ID_TPT = Convert.ToInt32(lstPesquisa.SelectedItems[0].Text);
                objMLTAB_TPT.Tpt_Tipo = lstPesquisa.SelectedItems[0].SubItems[1].Text;

                frmNovoTipo objNovoTipo = new frmNovoTipo();

                objNovoTipo.ID_TPTT = objMLTAB_TPT.ID_TPT;
                objNovoTipo.Tpt_Tipo = objMLTAB_TPT.Tpt_Tipo;

                objNovoTipo.ShowDialog();                
            }
        }

        #endregion       

        #region eventos

        private void frmPesquisaTipoTatuagem_Load(object sender, EventArgs e)
        {
            if (TAB_FUNC.Fun_Tipo > 2)
            {
                CarregarTipo();
                btnExcluir.Enabled = false;
            }
            else
            {
                CarregarTipo();
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {            
            Excluir();
            CarregarTipo();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            Alterar();
            CarregarTipo();
        }

        #endregion

        

       

    }
}
