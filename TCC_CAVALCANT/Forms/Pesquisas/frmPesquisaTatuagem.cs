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
    public partial class frmPesquisaTatuagem : Form
    {
        public frmPesquisaTatuagem()
        {
            InitializeComponent();
        }


        public bool SenhaCerta = false;
        int qual; // 1 = TODOSNOME, 2 = FINALIZADASNOME, 3 = NAOFINALIZADASNOME, 4 = TODOS, 5 = FINALIZADAS, 6 = NAOFINALIZADAS
        int ComNome; // 1 = Sim, 2 = Não;
        int Escolha; // 1 = Todos, 2 = Finalizados, 3 = Não Finalizados

        #region eventos

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            Alterar();
            if (qual == 1)
            {
                CarregarTatuagensTODASNOME(txtNome.Text);
            }else
                if (qual == 2)
                {
                    ConsultaTatuagemFINALIZADASNOME(txtNome.Text);
                }else
                    if (qual == 3)
                    {
                        ConsultaTatuagemNAOFINALIZADASNOME(txtNome.Text);
                    }else
                        if (qual == 4)
                        {
                            CarregarTatuagensTODAS();
                        }else
                            if (qual == 5)
                            {
                                CarregarTatuagensFINALIZADAS();
                            }
                            else
                            {
                                CarregarTatuagensNAOFINALIZADAS();
                            }
                                
        }

        private void frmPesquisaTatuagem_Load(object sender, EventArgs e)
        {
            if (TAB_FUNC.Fun_Tipo > 2)
            {
                CarregarTatuagensTODAS();
                qual = 4;
                ComNome = 2;
                Escolha = 1;
                btnExcluir.Enabled = false;
            }
            else
            {
                CarregarTatuagensTODAS();
                qual = 4;
                ComNome = 2;
                Escolha = 1;
            }
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            if (rdbSim.Checked)
            {
                if (string.IsNullOrEmpty(txtNome.Text))
                {
                    MessageBox.Show("Por favor, digite o nome do cliente");
                }
                else
                {
                    if (rdbTodos.Checked)
                    {
                        CarregarTatuagensTODASNOME(txtNome.Text);
                        qual = 1;
                    }
                    else
                        if (rdbFinalizadas.Checked)
                        {
                             ConsultaTatuagemFINALIZADASNOME(txtNome.Text);
                             qual = 2;
                        }
                        else
                        {
                            ConsultaTatuagemNAOFINALIZADASNOME(txtNome.Text);
                            qual = 3;
                        }
                }
            }
            else
            {
                if (rdbTodos.Checked)
                {
                    CarregarTatuagensTODAS();
                    qual = 4;
                }
                else
                    if (rdbFinalizadas.Checked)
                    {
                        CarregarTatuagensFINALIZADAS();
                        qual = 5;
                    }
                    else
                    {
                         CarregarTatuagensNAOFINALIZADAS();
                         qual = 6;
                    }
            }
        }         

        private void rdbSim_CheckedChanged(object sender, EventArgs e)
        {
            ComNome = 1;
            txtNome.Enabled = true;
            txtNome.Text = "";
           // lstPesquisa.Items.Clear();
            if (Escolha == 1)
            {
                qual = 1;
            }
            else
                if (Escolha == 2)
                {
                    qual = 2;
                }
                else
                {
                    qual = 3;
                }

        }

        private void rdbNao_CheckedChanged(object sender, EventArgs e)
        {
            ComNome = 2;
            txtNome.Enabled = false;
            txtNome.Text = "";
           // lstPesquisa.Items.Clear();
            if (Escolha == 1)
            {
                qual = 4;
            }else
                if (Escolha == 2)
                {
                    qual = 5;
                }
                else
                {
                    qual = 6;
                }
        }

        private void rdbAmbos_CheckedChanged(object sender, EventArgs e)
        {
            Escolha = 1;
          //  lstPesquisa.Items.Clear();
          //  txtNome.Text = "";
            if (ComNome == 1)
            {
                qual = 1;
            }
            else
            {
                qual = 2;
            }
        }

        private void rdbFinalizadas_CheckedChanged(object sender, EventArgs e)
        {
            Escolha = 2;
           // lstPesquisa.Items.Clear();
            //txtNome.Text = "";
            if (ComNome == 1)
            {
                qual = 1;
            }
            else
            {
                qual = 2;
            }
        }

        private void rdbNaoFinalizadas_CheckedChanged(object sender, EventArgs e)
        {
            Escolha = 3;
        //    lstPesquisa.Items.Clear();
           // txtNome.Text = "";
            if (ComNome == 1)
            {
                qual = 1;
            }
            else
            {
                qual = 2;
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (lstPesquisa.SelectedItems.Count > 0)
            {
                if (MessageBox.Show("Você possui certeza absoluta que deseja excluir a tatuagem? Isso eliminará todos os agendamentos feitos/abertos com a tatuagem.", "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    frmConfirmaSenha objConfirmarSenha = new frmConfirmaSenha();
                    objConfirmarSenha.objTatuagem = this;
                    objConfirmarSenha.Form = 4;
                    objConfirmarSenha.ShowDialog();
                    if (SenhaCerta)
                    {
                        int ID_TAT = Convert.ToInt16(lstPesquisa.SelectedItems[0].SubItems[1].Text);
                        ExcluIr(ID_TAT);
                        if (qual == 1)
                        {
                            CarregarTatuagensTODASNOME(txtNome.Text);
                        }
                        else
                            if (qual == 2)
                            {
                                ConsultaTatuagemFINALIZADASNOME(txtNome.Text);
                            }
                            else
                                if (qual == 3)
                                {
                                    ConsultaTatuagemNAOFINALIZADASNOME(txtNome.Text);
                                }
                                else
                                    if (qual == 4)
                                    {
                                        CarregarTatuagensTODAS();
                                    }
                                    else
                                        if (qual == 5)
                                        {
                                            CarregarTatuagensFINALIZADAS();
                                        }
                                        else
                                        {
                                            CarregarTatuagensNAOFINALIZADAS();
                                        }
                    }                        
                }
            }
        }

        #endregion

        #region metodos

        private void ExcluIr(int ID_TAT)
        {
            var objDBTAB_TAT = new BLTAB_TAT();

            bool excluido = objDBTAB_TAT.ExcluirTAT(ID_TAT);
            if (excluido)
            {
                MessageBox.Show("Tatuagem excluida com sucesso.");
            }
        }

        private void CarregarTatuagensTODASNOME(string Cli_Nome)
        {
            var objBLTAB_TAT = new BLTAB_TAT();
            var objMLTAB_TAT = new MLTAB_TAT();

            List<MLTAB_TAT> objListaTAT = new List<MLTAB_TAT>();

            objMLTAB_TAT.Cli_Nome = Cli_Nome;

            objListaTAT = objBLTAB_TAT.ConsultaTatuagemTODOSNOME(objMLTAB_TAT);

            lstPesquisa.Items.Clear();

            foreach (var itemLista in objListaTAT)
            {
                ListViewItem objListViewItem = new ListViewItem();

                objListViewItem.Text = itemLista.Cli_Nome.ToString();
                objListViewItem.SubItems.Add(itemLista.ID_TAT.ToString());
                objListViewItem.SubItems.Add(itemLista.Tpt_Tipo.ToString());
                objListViewItem.SubItems.Add(itemLista.Tat_Descricao.ToString());
                if (itemLista.Tat_Total > 0)
                {
                    objListViewItem.SubItems.Add(itemLista.Tat_Total.ToString(".00"));
                }
                else
                {
                    objListViewItem.SubItems.Add(itemLista.Tat_Total.ToString("0.00"));
                }

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

        private void ConsultaTatuagemFINALIZADASNOME(string Cli_Nome)
        {
            var objBLTAB_TAT = new BLTAB_TAT();
            var objMLTAB_TAT = new MLTAB_TAT();

            List<MLTAB_TAT> objListaTAT = new List<MLTAB_TAT>();

            objMLTAB_TAT.Cli_Nome = Cli_Nome;

            objListaTAT = objBLTAB_TAT.ConsultaTatuagemFINALIZADASNOME(objMLTAB_TAT);

            lstPesquisa.Items.Clear();

            foreach (var itemLista in objListaTAT)
            {
                ListViewItem objListViewItem = new ListViewItem();

                objListViewItem.Text = itemLista.Cli_Nome.ToString();
                objListViewItem.SubItems.Add(itemLista.ID_TAT.ToString());
                objListViewItem.SubItems.Add(itemLista.Tpt_Tipo.ToString());
                objListViewItem.SubItems.Add(itemLista.Tat_Descricao.ToString()); 
                if (itemLista.Tat_Total > 0)
                {
                    objListViewItem.SubItems.Add(itemLista.Tat_Total.ToString(".00"));
                }
                else
                {
                    objListViewItem.SubItems.Add(itemLista.Tat_Total.ToString("0.00"));
                }

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

        private void ConsultaTatuagemNAOFINALIZADASNOME(string Cli_Nome)
        {
            var objBLTAB_TAT = new BLTAB_TAT();
            var objMLTAB_TAT = new MLTAB_TAT();

            List<MLTAB_TAT> objListaTAT = new List<MLTAB_TAT>();

            objMLTAB_TAT.Cli_Nome = Cli_Nome;

            objListaTAT = objBLTAB_TAT.ConsultaTatuagemNAOFINALIZADASNOME(objMLTAB_TAT);

            lstPesquisa.Items.Clear();

            foreach (var itemLista in objListaTAT)
            {
                ListViewItem objListViewItem = new ListViewItem();

                objListViewItem.Text = itemLista.Cli_Nome.ToString();
                objListViewItem.SubItems.Add(itemLista.ID_TAT.ToString());
                objListViewItem.SubItems.Add(itemLista.Tpt_Tipo.ToString());
                objListViewItem.SubItems.Add(itemLista.Tat_Descricao.ToString());
                if (itemLista.Tat_Total > 0)
                {
                    objListViewItem.SubItems.Add(itemLista.Tat_Total.ToString(".00"));
                }
                else
                {
                    objListViewItem.SubItems.Add(itemLista.Tat_Total.ToString("0.00"));
                }

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

        private void CarregarTatuagensTODAS()
        {
            var objBLTAB_TAT = new BLTAB_TAT();
            List<MLTAB_TAT> objListaTAT = new List<MLTAB_TAT>();
            objListaTAT = objBLTAB_TAT.ConsultaTatuagemTODOS();

            lstPesquisa.Items.Clear();

            foreach (var itemLista in objListaTAT)
            {
                ListViewItem objListViewItem = new ListViewItem();

                objListViewItem.Text = itemLista.Cli_Nome.ToString();
                objListViewItem.SubItems.Add(itemLista.ID_TAT.ToString());
                objListViewItem.SubItems.Add(itemLista.Tpt_Tipo.ToString());
                objListViewItem.SubItems.Add(itemLista.Tat_Descricao.ToString());
                if (itemLista.Tat_Total > 0)
                {
                    objListViewItem.SubItems.Add(itemLista.Tat_Total.ToString(".00"));
                }
                else
                {
                    objListViewItem.SubItems.Add(itemLista.Tat_Total.ToString("0.00"));
                }

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

        private void CarregarTatuagensFINALIZADAS()
        {
            var objBLTAB_TAT = new BLTAB_TAT();
            List<MLTAB_TAT> objListaTAT = new List<MLTAB_TAT>();
            objListaTAT = objBLTAB_TAT.ConsultaTatuagemFINALIZADAS();

            lstPesquisa.Items.Clear();

            foreach (var itemLista in objListaTAT)
            {
                ListViewItem objListViewItem = new ListViewItem();

                objListViewItem.Text = itemLista.Cli_Nome.ToString();
                objListViewItem.SubItems.Add(itemLista.ID_TAT.ToString());
                objListViewItem.SubItems.Add(itemLista.Tpt_Tipo.ToString());
                objListViewItem.SubItems.Add(itemLista.Tat_Descricao.ToString());
                if (itemLista.Tat_Total > 0)
                {
                    objListViewItem.SubItems.Add(itemLista.Tat_Total.ToString(".00"));
                }
                else
                {
                    objListViewItem.SubItems.Add(itemLista.Tat_Total.ToString("0.00"));
                }

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

        private void CarregarTatuagensNAOFINALIZADAS()
        {
            var objBLTAB_TAT = new BLTAB_TAT();
            List<MLTAB_TAT> objListaTAT = new List<MLTAB_TAT>();
            objListaTAT = objBLTAB_TAT.ConsultaTatuagemNAOFINALIZADAS();

            lstPesquisa.Items.Clear();

            foreach (var itemLista in objListaTAT)
            {
                ListViewItem objListViewItem = new ListViewItem();

                objListViewItem.Text = itemLista.Cli_Nome.ToString();
                objListViewItem.SubItems.Add(itemLista.ID_TAT.ToString());
                objListViewItem.SubItems.Add(itemLista.Tpt_Tipo.ToString());
                objListViewItem.SubItems.Add(itemLista.Tat_Descricao.ToString());
                if (itemLista.Tat_Total > 0)
                {
                    objListViewItem.SubItems.Add(itemLista.Tat_Total.ToString(".00"));
                }
                else
                {
                    objListViewItem.SubItems.Add(itemLista.Tat_Total.ToString("0.00"));
                }

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

        private void Alterar()
        {
            var objMLTAB_TAT = new MLTAB_TAT();
            try
            {
                if (lstPesquisa.SelectedItems.Count > 0)
                {
                    objMLTAB_TAT.Cli_Nome = lstPesquisa.SelectedItems[0].Text;
                    objMLTAB_TAT.ID_TAT = Convert.ToInt32(lstPesquisa.SelectedItems[0].SubItems[1].Text);
                    objMLTAB_TAT.Tpt_Tipo = lstPesquisa.SelectedItems[0].SubItems[2].Text;
                    objMLTAB_TAT.Tat_Descricao = lstPesquisa.SelectedItems[0].SubItems[3].Text;
                    objMLTAB_TAT.Tat_Total = Convert.ToDouble(lstPesquisa.SelectedItems[0].SubItems[4].Text);
                    objMLTAB_TAT.Tat_FaltaPagar = Convert.ToDouble(lstPesquisa.SelectedItems[0].SubItems[5].Text);

                    frmNovoTatuagem objNovoTatuagem = new frmNovoTatuagem();

                    objNovoTatuagem.Cli_Nome = objMLTAB_TAT.Cli_Nome;
                    objNovoTatuagem.ID_TAT = objMLTAB_TAT.ID_TAT;
                    objNovoTatuagem.Tpt_Tipo = objMLTAB_TAT.Tpt_Tipo;
                    objNovoTatuagem.Tat_Descricao = objMLTAB_TAT.Tat_Descricao;
                    objNovoTatuagem.Tat_Total = objMLTAB_TAT.Tat_Total;
                    objNovoTatuagem.Tat_FaltaPagar = objMLTAB_TAT.Tat_FaltaPagar;
                    objNovoTatuagem.EditaTat = 1;
                    
                    objNovoTatuagem.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro ao atualizar a tatuagem: " + ex.Message);
            }
        }

        #endregion

        

        

    }
}
