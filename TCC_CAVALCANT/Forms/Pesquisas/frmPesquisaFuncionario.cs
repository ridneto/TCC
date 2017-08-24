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
    public partial class frmPesquisaFuncionario : Form
    {
        public frmPesquisaFuncionario()
        {
            InitializeComponent();
        }

        public bool SenhaCerta = false;

        #region eventos


        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmPesquisaFuncionario_Load(object sender, EventArgs e)
        {
            CarregarDadosFuncionario();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (lstPesquisa.SelectedItems.Count > 0)
            {
                if (MessageBox.Show("Realmente deseja excluir esse funcionário?", "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    frmConfirmaSenha objConfirmarSenha = new frmConfirmaSenha();
                    objConfirmarSenha.objFuncionario = this;
                    objConfirmarSenha.Form = 3;
                    objConfirmarSenha.ShowDialog();
                    if (SenhaCerta)
                    {
                        Excluir();
                    }
                }
                CarregarDadosFuncionario();
            }            
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            Pesquisar();
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            Alterar();
            CarregarDadosFuncionario();
        }

        #endregion

        #region metodos

        private void CarregarDadosFuncionario()
        {
            var objBLTAB_FUNC = new BLTAB_FUNC();
            List<MLTAB_FUNC> objListaFuncionario = new List<MLTAB_FUNC>();
            objListaFuncionario = objBLTAB_FUNC.Pesquisar();

            lstPesquisa.Items.Clear();

            foreach (var itemLista in objListaFuncionario)
            {
                if (itemLista.ID_FUN > 1)
                {
                    ListViewItem objListViewItem = new ListViewItem();

                    objListViewItem.Text = itemLista.ID_FUN.ToString();
                    if (itemLista.Fun_Tipo == 1)
                    {
                        string Tipo = "Administrador";
                        objListViewItem.SubItems.Add(Tipo);
                    }
                    else
                    {
                        string Tipo = "Funcionário";
                        objListViewItem.SubItems.Add(Tipo);
                    }
                    //objListViewItem.SubItems.Add(itemLista.Fun_Tipo.ToString());
                    objListViewItem.SubItems.Add(itemLista.Fun_Login.ToString());
                    objListViewItem.SubItems.Add(itemLista.Fun_Senha.ToString());
                    objListViewItem.SubItems.Add(itemLista.Fun_NomeTatuador);
              
                    lstPesquisa.Items.Add(objListViewItem);
                }
            }
        }

        private void Excluir()
        {
            try
            {
                var objBLTAB_FUNC = new BLTAB_FUNC();
                int ID_FUNC = 0;

                if (lstPesquisa.SelectedItems.Count > 0)
                {
                    ID_FUNC = Convert.ToInt32(lstPesquisa.SelectedItems[0].Text);
                }

                if (ID_FUNC == 2)
                {
                    MessageBox.Show("Não é possivel excluir o ADM");
                }
                else
                {
                    objBLTAB_FUNC.Excluir(ID_FUNC);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Não é possivel excluir o funcionário, pois este já fez uma sessão.");
            }
        }

        private void Pesquisar()
        {
            var objBLTAB_FUNC = new BLTAB_FUNC();
            var objMLTAB_FUNC = new MLTAB_FUNC();
            List<MLTAB_FUNC> objListaFuncionario = new List<MLTAB_FUNC>();


            objMLTAB_FUNC.Fun_NomeTatuador = (String.IsNullOrEmpty(txtNome.Text)) ? null : txtNome.Text;

            objListaFuncionario = objBLTAB_FUNC.Consultar(objMLTAB_FUNC);

            lstPesquisa.Items.Clear();

            foreach (var itemLista in objListaFuncionario)
            {
                ListViewItem objListViewItem = new ListViewItem();

                objListViewItem.Text = itemLista.ID_FUN.ToString();
                objListViewItem.SubItems.Add(itemLista.Fun_Tipo.ToString());
                objListViewItem.SubItems.Add(itemLista.Fun_Login.ToString());
                objListViewItem.SubItems.Add(itemLista.Fun_Senha.ToString());
                objListViewItem.SubItems.Add(itemLista.Fun_NomeTatuador);


                lstPesquisa.Items.Add(objListViewItem);
            }
        }

        private void Alterar()
        {
            var objMLTAB_FUNC = new MLTAB_FUNC();
            try
            {
                if (lstPesquisa.SelectedItems.Count > 0)
                {
                    objMLTAB_FUNC.ID_FUN = Convert.ToInt32(lstPesquisa.SelectedItems[0].Text);
                    objMLTAB_FUNC.Fun_Tipo = Convert.ToInt16(lstPesquisa.SelectedItems[0].SubItems[1].Text);
                    objMLTAB_FUNC.Fun_Login = lstPesquisa.SelectedItems[0].SubItems[2].Text;
                    objMLTAB_FUNC.Fun_Senha = lstPesquisa.SelectedItems[0].SubItems[3].Text;
                    objMLTAB_FUNC.Fun_NomeTatuador = lstPesquisa.SelectedItems[0].SubItems[4].Text;

                    frmNovoFuncionario objfrmCadastroFuncionario = new frmNovoFuncionario();

                    objfrmCadastroFuncionario.ID_FUN = objMLTAB_FUNC.ID_FUN;
                    objfrmCadastroFuncionario.Fun_Tipo = objMLTAB_FUNC.Fun_Tipo;
                    objfrmCadastroFuncionario.Fun_Login = objMLTAB_FUNC.Fun_Login;
                    objfrmCadastroFuncionario.Fun_Senha = objMLTAB_FUNC.Fun_Senha;
                    objfrmCadastroFuncionario.Fun_NomeTatuador = objMLTAB_FUNC.Fun_NomeTatuador;                    

                    objfrmCadastroFuncionario.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro ao Atualizar o Funcionário: " + ex.Message);
            }
        }

        #endregion


    

        

        

        

        


        
    }
}
