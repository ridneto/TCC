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
    public partial class frmPesquisaCliente : Form
    {
        public frmPesquisaCliente()
        {
            InitializeComponent();
        }

        public bool SenhaCerta = false;

        #region eventos

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnExcluir_Click_1(object sender, EventArgs e)
        {
            if (lstPesquisa.SelectedItems.Count > 0)
            {
                if (MessageBox.Show("Realmente deseja excluir este Cliente? Isso excluirá todo o histórico dele. (Não haverá volta)", "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    frmConfirmaSenha objConfirmarSenha = new frmConfirmaSenha();
                    objConfirmarSenha.objCliente = this;
                    objConfirmarSenha.Form = 2;
                    objConfirmarSenha.ShowDialog();
                    if (SenhaCerta)
                    {
                        Excluir();
                        MessageBox.Show("Cliente excluido com sucesso");
                        CarregarDadosClientes(); ;
                    }
                }
            }
        }

        private void frmPesquisaCliente_Load(object sender, EventArgs e)
        {
            if (TAB_FUNC.Fun_Tipo > 2)
            {
                btnExcluir.Enabled = false;
                CarregarDadosClientes();
            }
            else
            {
                CarregarDadosClientes();
            }                        
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            Alterar();
            CarregarDadosClientes();
        }     

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            Pesquisar();
        }

        #endregion

        #region Metodos

        private void CarregarDadosClientes()
        {
            var objBLTAB_CLI = new BLTAB_CLI();
            List<MLTAB_CLI> objListaClientes = new List<MLTAB_CLI>();
            objListaClientes = objBLTAB_CLI.Consultar();

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

        private void Excluir()
        {
            try
            {
                var objBLClientes = new BLTAB_CLI();
                int ID_CLI = 0;

                if (lstPesquisa.SelectedItems.Count > 0)
                {
                    ID_CLI = Convert.ToInt32(lstPesquisa.SelectedItems[0].Text);
                }

                objBLClientes.Excluir(ID_CLI);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao tentar excluir Cliente. Erro : " + ex);
            }
        }

        private void Pesquisar()
        {
            var objBLTAB_CLI = new BLTAB_CLI();
            var objMLTAB_CLI = new MLTAB_CLI();
            List<MLTAB_CLI> objListaClientes = new List<MLTAB_CLI>();


            objMLTAB_CLI.Cli_Nome = (String.IsNullOrEmpty(txtNome.Text)) ? null : txtNome.Text;

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

        private void Alterar()
        {
            var objMLTAB_CLI = new MLTAB_CLI();
            try
            {
                if (lstPesquisa.SelectedItems.Count > 0)
                {
                    objMLTAB_CLI.ID_CLI = Convert.ToInt32(lstPesquisa.SelectedItems[0].Text);
                    objMLTAB_CLI.Cli_Nome = lstPesquisa.SelectedItems[0].SubItems[1].Text;
                    objMLTAB_CLI.Cli_DataNasc = Convert.ToDateTime(lstPesquisa.SelectedItems[0].SubItems[2].Text);
                    objMLTAB_CLI.Cli_Sexo = lstPesquisa.SelectedItems[0].SubItems[3].Text;
                    objMLTAB_CLI.Cli_Telefone = lstPesquisa.SelectedItems[0].SubItems[4].Text;
                    objMLTAB_CLI.Cli_Email = lstPesquisa.SelectedItems[0].SubItems[5].Text;
                    
                    frmNovoCliente objfrmCadastroCliente = new frmNovoCliente();

                    objfrmCadastroCliente.ID_CLI = objMLTAB_CLI.ID_CLI;
                    objfrmCadastroCliente.Cli_Nome = objMLTAB_CLI.Cli_Nome;
                    objfrmCadastroCliente.Cli_DataNasc = objMLTAB_CLI.Cli_DataNasc;
                    objfrmCadastroCliente.Cli_Sexo = objMLTAB_CLI.Cli_Sexo;
                    objfrmCadastroCliente.Cli_Telefone = objMLTAB_CLI.Cli_Telefone;
                    objfrmCadastroCliente.Cli_Email = objMLTAB_CLI.Cli_Email;

                    objfrmCadastroCliente.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro ao atualizar o cliente: " + ex.Message);
            }
        }

        #endregion

        
    }
}
