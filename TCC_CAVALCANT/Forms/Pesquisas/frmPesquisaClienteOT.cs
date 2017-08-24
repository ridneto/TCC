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
    public partial class frmPesquisaClienteOT : Form
    {
        public frmPesquisaClienteOT()
        {
            InitializeComponent();
        }

        public string nomeCliente { get; set; }

        public frmNovoTatuagem objfrmNovoOrcamentoTattoo { get; set; }

        #region metodos

        private void CarregarDadosCliente()
        {
            var objBLTAB_CLI = new BLTAB_CLI();
            var objMLTAB_CLI = new MLTAB_CLI();
            List<MLTAB_CLI> objListaClientes = new List<MLTAB_CLI>();


            objMLTAB_CLI.Cli_Nome = nomeCliente = (String.IsNullOrEmpty(nomeCliente)) ? null : nomeCliente;


            objListaClientes = objBLTAB_CLI.Consultar(objMLTAB_CLI);

            lstPesquisa.Items.Clear();

            foreach (var itemLista in objListaClientes)
            {
                ListViewItem objListViewItem = new ListViewItem();

                objListViewItem.Text = itemLista.ID_CLI.ToString();
                objListViewItem.SubItems.Add(itemLista.Cli_Nome);
                objListViewItem.SubItems.Add(itemLista.Cli_DataNasc.ToString());
                objListViewItem.SubItems.Add(itemLista.Cli_Sexo.ToString());
                objListViewItem.SubItems.Add(itemLista.Cli_Telefone);
                objListViewItem.SubItems.Add(itemLista.Cli_Email);


                lstPesquisa.Items.Add(objListViewItem);
            }
        }

        private void ConfirmarCliente()
        {
            var objMLTAB_CLI = new MLTAB_CLI();

            if (lstPesquisa.SelectedItems.Count > 0)
            {
                objMLTAB_CLI.ID_CLI = Convert.ToInt32(lstPesquisa.SelectedItems[0].Text);
                objMLTAB_CLI.Cli_Nome = lstPesquisa.SelectedItems[0].SubItems[1].Text;


                objfrmNovoOrcamentoTattoo.ID_CLI = Convert.ToInt16(objMLTAB_CLI.ID_CLI);
                objfrmNovoOrcamentoTattoo.Cli_Nome = objMLTAB_CLI.Cli_Nome;
                this.Close();               
            }
        }

        #endregion

        #region eventos

        private void lstPesquisa_DoubleClick(object sender, EventArgs e)
        {
            ConfirmarCliente();
        }

        private void frmPesquisaClienteOT_Load(object sender, EventArgs e)
        {
            CarregarDadosCliente();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            ConfirmarCliente();
        }

        #endregion

        

        

        

        
    }
}
