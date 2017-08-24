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
    public partial class frmPesquisaAgendamento : Form
    {
        public frmPesquisaAgendamento()
        {
            InitializeComponent();
        }

        public bool SenhaCerta = false;
        DateTime Data;
        string Nome;
        
        #region eventos

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (lstData.SelectedItems.Count > 0)
            {
                if (MessageBox.Show("Realmente deseja excluir este agendamento? (Não haverá volta)", "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    frmConfirmaSenha objConfirmarSenha = new frmConfirmaSenha();
                    objConfirmarSenha.objAgendamento = this;
                    objConfirmarSenha.Form = 5;
                    objConfirmarSenha.ShowDialog();
                    if (SenhaCerta)
                    {
                        Excluir();
                    }
                }
            }
        }

        private void frmPesquisaAgendamento_Load(object sender, EventArgs e)
        {
            Data = DateTime.Today;
            txtNome.Enabled = false;
            CarregarSessoes(Data);

            if (TAB_FUNC.Fun_Tipo > 2)
            {
                btnExcluir.Enabled = false;
            }
        }        

        private void rdbNome_CheckedChanged(object sender, EventArgs e)
        {
            txtNome.Enabled = true;
            dEspecifico.Enabled = false;
            txtNome.Text = "";
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            if (rdbNome.Checked)
            {
                Nome = txtNome.Text;
                CarregarSessoesPorNome(Nome);
            }
            else
            {
                CarregarSessoes(Data);
            }
        }

        private void dEspecifico_RegionChanged(object sender, EventArgs e)
        {
            lstData.Items.Clear();
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            Alterar();
        }

        private void dEspecifico_ValueChanged(object sender, EventArgs e)
        {
            
            Data = Convert.ToDateTime(dEspecifico.Text);
        }

        private void rdbData_CheckedChanged(object sender, EventArgs e)
        {
            txtNome.Enabled = false;
            dEspecifico.Enabled = true;
            txtNome.Text = "";
        }

        #endregion

        #region metodos

        private void lstData_SelectedIndexChanged(object sender, EventArgs e)
        {
            Data = Convert.ToDateTime(dEspecifico.Text);
        }

        private void CarregarSessoes(DateTime Data)
        {
            var objBLTAB_AGENDA = new BLTAB_AGENDA();
            List<MLTAB_AGENDA> objDiaAtual = new List<MLTAB_AGENDA>();

            objDiaAtual = objBLTAB_AGENDA.ConsultarDataEspecificaP(Data);

            if (objDiaAtual.Count > 0)
            {
                lstData.Items.Clear();

                foreach (var itemLista in objDiaAtual)
                {
                    ListViewItem objListViewItem = new ListViewItem();

                    objListViewItem.Text = itemLista.Cli_Nome;
                    objListViewItem.SubItems.Add(itemLista.ID_AGE.ToString());
                    objListViewItem.SubItems.Add(itemLista.Hora.ToString());
                    objListViewItem.SubItems.Add(itemLista.Age_Data.ToString());
                    if (itemLista.Age_ValorSessao > 0)
                    {
                        objListViewItem.SubItems.Add(itemLista.Age_ValorSessao.ToString(".00"));
                    }
                    else
                    {
                        objListViewItem.SubItems.Add(itemLista.Age_ValorSessao.ToString("0.00"));
                    }
                    
                    objListViewItem.SubItems.Add(itemLista.Tpt_Tipo.ToString());
                    objListViewItem.SubItems.Add(itemLista.Tat_Descricao.ToString());
                    objListViewItem.SubItems.Add(itemLista.Fpg_Vezes.ToString());
                    objListViewItem.SubItems.Add(itemLista.Fpg_Forma.ToString());

                    lstData.Items.Add(objListViewItem);
                }
            }
        }

        private void CarregarSessoesPorNome(string Cli_Nome)
        {
            var objBLTAB_AGENDA = new BLTAB_AGENDA();
            List<MLTAB_AGENDA> objDiaAtual = new List<MLTAB_AGENDA>();

            string CliNome = (String.IsNullOrEmpty(Cli_Nome)) ? null : Cli_Nome;

            objDiaAtual = objBLTAB_AGENDA.ConsultarDataPorNome(CliNome);

            if (objDiaAtual.Count > 0)
            {
                foreach (var itemLista in objDiaAtual)
                {
                    ListViewItem objListViewItem = new ListViewItem();

                    objListViewItem.Text = itemLista.Cli_Nome;
                    objListViewItem.SubItems.Add(itemLista.ID_AGE.ToString());
                    objListViewItem.SubItems.Add(itemLista.Hora.ToString());
                    objListViewItem.SubItems.Add(itemLista.Age_Data.ToString());
                    if (itemLista.Age_ValorSessao > 0)
                    {
                        objListViewItem.SubItems.Add(itemLista.Age_ValorSessao.ToString(".00"));
                    }
                    else
                    {
                        objListViewItem.SubItems.Add(itemLista.Age_ValorSessao.ToString("0.00"));
                    }
                    objListViewItem.SubItems.Add(itemLista.Tpt_Tipo.ToString());
                    objListViewItem.SubItems.Add(itemLista.Tat_Descricao.ToString());
                    objListViewItem.SubItems.Add(itemLista.Fpg_Vezes.ToString());
                    objListViewItem.SubItems.Add(itemLista.Fpg_Forma.ToString());

                    lstData.Items.Add(objListViewItem);
                }
            }
        }

        private void Alterar()
        {
            var objMLTAB_AGENDA = new MLTAB_AGENDA();
            try
            {
                if (lstData.SelectedItems.Count > 0)
                {
                    objMLTAB_AGENDA.Cli_Nome = lstData.SelectedItems[0].Text;
                    objMLTAB_AGENDA.ID_AGE = Convert.ToInt16(lstData.SelectedItems[0].SubItems[1].Text);
                    objMLTAB_AGENDA.Hora = lstData.SelectedItems[0].SubItems[2].Text;
                    objMLTAB_AGENDA.Age_Data = Convert.ToDateTime(lstData.SelectedItems[0].SubItems[3].Text);
                    objMLTAB_AGENDA.Age_ValorSessao = Convert.ToDouble(lstData.SelectedItems[0].SubItems[4].Text);
                    objMLTAB_AGENDA.Tpt_Tipo = lstData.SelectedItems[0].SubItems[5].Text;
                    objMLTAB_AGENDA.Tat_Descricao = lstData.SelectedItems[0].SubItems[6].Text;
                    objMLTAB_AGENDA.Fpg_Vezes = Convert.ToInt16(lstData.SelectedItems[0].SubItems[7].Text);
                    objMLTAB_AGENDA.Fpg_Forma = lstData.SelectedItems[0].SubItems[8].Text;

                    frmNovoAgendamento objfrmNovoAgendamento = new frmNovoAgendamento();

                    objfrmNovoAgendamento.NomeCli = objMLTAB_AGENDA.Cli_Nome;
                    objfrmNovoAgendamento.HoraAg = objMLTAB_AGENDA.Hora;
                    objfrmNovoAgendamento.Age_Data = objMLTAB_AGENDA.Age_Data;
                    objfrmNovoAgendamento.Age_ValorSessao = objMLTAB_AGENDA.Age_ValorSessao;
                    objfrmNovoAgendamento.Tpt_Tipo = objMLTAB_AGENDA.Tpt_Tipo;
                    objfrmNovoAgendamento.Tat_Descricao = objMLTAB_AGENDA.Tat_Descricao;
                    objfrmNovoAgendamento.Fpg_Vezes = objMLTAB_AGENDA.Fpg_Vezes;
                    objfrmNovoAgendamento.editaAgendamento = 1;
                    objfrmNovoAgendamento.Fpg_Forma = objMLTAB_AGENDA.Fpg_Forma;
                    objfrmNovoAgendamento.ID_AGEe = objMLTAB_AGENDA.ID_AGE;

                    objfrmNovoAgendamento.ShowDialog();
                    
                        if (rdbNome.Checked)
                        {
                            CarregarSessoesPorNome(Nome);
                        }
                        else
                        {
                            CarregarSessoes(Data);
                        }                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro ao atualizar o agendamento: " + ex.Message);
            }
        }

        private void Excluir()
        {
            var objBL = new BLTAB_AGENDA();
            int ID_AGE = Convert.ToInt16(lstData.SelectedItems[0].SubItems[1].Text);

            if (objBL.Excluir(ID_AGE))
            {
                MessageBox.Show("Agendamento Excluido com sucesso");
                if (rdbNome.Checked)
                {
                    CarregarSessoesPorNome(Nome);
                }
                else
                {
                    CarregarSessoes(Data);
                }
            }        
        }

        #endregion

    }
}
