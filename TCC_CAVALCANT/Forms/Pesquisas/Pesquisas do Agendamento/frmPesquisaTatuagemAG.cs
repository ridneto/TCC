using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BusinessLayer;
using ModelLayer;

namespace TCC_CAVALCENT
{
    public partial class frmPesquisaTatuagemAG : Form
    {
        public frmPesquisaTatuagemAG()
        {
            InitializeComponent();
        }
        public int ID_CLI { get; set; }

        public frmPesquisaClienteAG objfrmPesquisaClienteAG { get; set; }

        #region eventos

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
        
        private void frmPesquisaTatuagemAG_Load(object sender, EventArgs e)
        {
            CarregarDados();
        }

        private void lstPesquisa_DoubleClick(object sender, EventArgs e)
        {
            ConfirmarTatuagem();
        }

        private void btnContinuar_Click(object sender, EventArgs e)
        {
            ConfirmarTatuagem();
        }

        #endregion

        #region metodos

        private void CarregarDados()
            {
            var objBLTAB_Tat = new BLTAB_TAT();
            var objMLTAB_Tat = new MLTAB_TAT();
            List<MLTAB_TAT> objLisTat = new List<MLTAB_TAT>();

            objMLTAB_Tat.ID_CLI = ID_CLI;

            objLisTat = objBLTAB_Tat.ConsultarClienteAG(objMLTAB_Tat);

            lstPesquisa.Items.Clear();

            foreach (var itemLista in objLisTat)
            {
                ListViewItem objListViewItem = new ListViewItem();

                objListViewItem.Text = itemLista.Cli_Nome;
                objListViewItem.SubItems.Add(itemLista.ID_TAT.ToString());
                objListViewItem.SubItems.Add(itemLista.Tpt_Tipo);
                objListViewItem.SubItems.Add(itemLista.Tat_Descricao);
                if (itemLista.Tat_Total > 0)
                {
                    objListViewItem.SubItems.Add(itemLista.Tat_Total.ToString(".00"));
                }
                else
                {
                    objListViewItem.SubItems.Add(itemLista.Tat_Total.ToString("0.00"));
                }
                objListViewItem.SubItems.Add(itemLista.Tat_Sessoes.ToString());
                if (itemLista.Tat_FaltaPagar > 0)
                {
                    objListViewItem.SubItems.Add(itemLista.Tat_FaltaPagar.ToString(".00"));
                }
                else
                {
                    objListViewItem.SubItems.Add(itemLista.Tat_FaltaPagar.ToString("0.00"));
                }

                lstPesquisa.Items.Add(objListViewItem);
            }
        }

        private void ConfirmarTatuagem()
        {
            var objMLTAB_TAT = new MLTAB_TAT();

            if (lstPesquisa.SelectedItems.Count > 0)
            {
                objMLTAB_TAT.Cli_Nome = lstPesquisa.SelectedItems[0].Text.ToString();
                objMLTAB_TAT.ID_TAT = Convert.ToInt16(lstPesquisa.SelectedItems[0].SubItems[1].Text);
                objMLTAB_TAT.Tpt_Tipo = lstPesquisa.SelectedItems[0].SubItems[2].Text.ToString();
                objMLTAB_TAT.Tat_Descricao = lstPesquisa.SelectedItems[0].SubItems[3].Text.ToString();
                objMLTAB_TAT.Tat_Total = Convert.ToDouble(lstPesquisa.SelectedItems[0].SubItems[4].Text);
                objMLTAB_TAT.Tat_Sessoes = Convert.ToInt16(lstPesquisa.SelectedItems[0].SubItems[5].Text);
                objMLTAB_TAT.Tat_FaltaPagar = Convert.ToDouble(lstPesquisa.SelectedItems[0].SubItems[6].Text);

                objfrmPesquisaClienteAG.NAG = 1;
                objfrmPesquisaClienteAG.ID_TAT = objMLTAB_TAT.ID_TAT;
                objfrmPesquisaClienteAG.Tpt_Tipo = objMLTAB_TAT.Tpt_Tipo;
                objfrmPesquisaClienteAG.Tat_Descricao = objMLTAB_TAT.Tat_Descricao;
                objfrmPesquisaClienteAG.Tat_Total = objMLTAB_TAT.Tat_Total;
                objfrmPesquisaClienteAG.NomeCli = objMLTAB_TAT.Cli_Nome;
                objfrmPesquisaClienteAG.Tat_FaltaPagar = objMLTAB_TAT.Tat_FaltaPagar;

                this.Close();
            }      
        }

        #endregion

        

        


    }
}
