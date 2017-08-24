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
    public partial class frmTelaPrincipal : Form
    {
        public frmTelaPrincipal()
        {
            InitializeComponent();
        }

        DateTime Data;
        public bool SenhaCerta = false;

        #region metodos

        public void abrirForm(Type tipoForm)
        {
            bool isOpen = false;

            foreach (Form objForm in Application.OpenForms)
            {
                if (objForm.GetType().Equals(tipoForm))
                {
                    objForm.Show();
                    isOpen = true;
                    break;
                }
            }

            if (!isOpen)
            {
                Form objForm = (Form)Activator.CreateInstance(tipoForm);
                objForm.Show();
            }
        }

        private void CarregarSessoes(DateTime Data)
        {
            var objBLTAB_AGENDA = new BLTAB_AGENDA();
            List<MLTAB_AGENDA> objDiaEspecifico = new List<MLTAB_AGENDA>();

            objDiaEspecifico = objBLTAB_AGENDA.ConsultarDataEspecifica(Data);

            lstData.Items.Clear();

            if (objDiaEspecifico.Count > 0)
            {
                foreach (var itemLista in objDiaEspecifico)
                {
                    ListViewItem objListViewItem = new ListViewItem();

                    objListViewItem.Text = itemLista.Hora.ToString();
                    objListViewItem.SubItems.Add(itemLista.Cli_Nome);
                    if (itemLista.Age_ValorSessao > 0)
                    {
                        objListViewItem.SubItems.Add(itemLista.Age_ValorSessao.ToString(".00"));
                    }
                    else
                    {
                        objListViewItem.SubItems.Add(itemLista.Age_ValorSessao.ToString("0.00"));
                    }                    
               //     objListViewItem.SubItems.Add(String.Format("{0:###,###0.00}",itemLista.Age_ValorSessao));
                    lstData.Items.Add(objListViewItem);
                }
            }
        }

        private void SessaoRealizada(DateTime Data)
        {
            MLTAB_AGENDA objML = new MLTAB_AGENDA();
            var objBL = new BLTAB_AGENDA();
            objML.Age_Data = Data;
            objML.Hora = lstData.SelectedItems[0].Text;
            objML.Cli_Nome = lstData.SelectedItems[0].SubItems[1].Text;

            int registro = objBL.AtualizarSessao(objML);

            if (registro > 0)
            {
                MessageBox.Show("Sessão Atualizada");
            }
            
        }

        private void Excluir()
        {

            var objML = new MLTAB_AGENDA();
            var objBL = new BLTAB_AGENDA();

            objML.Hora = lstData.SelectedItems[0].Text;
            objML.Cli_Nome = lstData.SelectedItems[0].SubItems[1].Text;
            objML.Age_ValorSessao = Convert.ToDouble(lstData.SelectedItems[0].SubItems[2].Text);
            objML.Age_Data = Convert.ToDateTime(Data);
                        
            if (objBL.Excluir(objML))
            {
                MessageBox.Show("Agendamento excluido com sucesso");
            }
        }

        private void Alterar()
        {
            var objBl = new BLTAB_AGENDA();
            var objML = new MLTAB_AGENDA();
            int ID_AGE;
            objML.Hora = lstData.SelectedItems[0].Text;
            objML.Cli_Nome = lstData.SelectedItems[0].SubItems[1].Text;
            objML.Age_ValorSessao = Convert.ToDouble(lstData.SelectedItems[0].SubItems[2].Text);
            objML.Age_Data = Data;

            ID_AGE = objBl.ConsultaIDAGE(objML);

            frmNovoAgendamento objNovo = new frmNovoAgendamento();
            objNovo.ID_AGEe = ID_AGE;
            objNovo.ShowDialog();
        }
        
        #endregion

        #region eventos      

        private void timer1_Tick(object sender, EventArgs e)
        {
            CarregarSessoes(Data);
        }

        private void frmTelaPrincipal_Load(object sender, EventArgs e)
        {
            ttpAdicionar.SetToolTip(btnAdd, "Cria um novo agendamento.");
            ttpCancelar.SetToolTip(btnExcluir, "Exclui permanentemente um agendamento.");
            ttpConfirmar.SetToolTip(btnConfirmar, "Confirma um agendamento já realizado.");

            if (TAB_FUNC.ID_FUN == 1 || TAB_FUNC.ID_FUN == 2)
            {
                funcionárioToolStripMenuItem.Enabled = true;
                backupToolStripMenuItem.Enabled = true;
            }

            if (TAB_FUNC.Fun_Tipo == 3)
            {
                relatórioToolStripMenuItem.Enabled = false;
                funcionarioToolStripMenuItem.Enabled = false;
                btnExcluir.Enabled = false;
            }
             Data = DateTime.Today;

             CarregarSessoes(Data);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmNovoAgendamento objFrmNovoAgendamento = new frmNovoAgendamento();
            objFrmNovoAgendamento.Age_Data = Data;
            objFrmNovoAgendamento.TelaPrincipal = 1;
            objFrmNovoAgendamento.ShowDialog();
            CarregarSessoes(Data);
        }

        private void sairToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja realmente fechar o programa?", "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                Close();
            }
        }

        private void mtcPrincipal_DateChanged(object sender, DateRangeEventArgs e)
        {
            Data = mtcPrincipal.SelectionStart;

            CarregarSessoes(Data);
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            if (lstData.SelectedItems.Count > 0)
            {
                if (MessageBox.Show("A sessão foi realmente realizada?", "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    Data = mtcPrincipal.SelectionStart;
                    SessaoRealizada(Data);
                    CarregarSessoes(Data);
                }
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (lstData.SelectedItems.Count > 0)
            {
                frmConfirmaSenha objConfirmarSenha = new frmConfirmaSenha();
                objConfirmarSenha.objPrincipal = this;
                objConfirmarSenha.Form = 1;
                objConfirmarSenha.ShowDialog();
                if (SenhaCerta)
                {                    
                    Excluir();
                    CarregarSessoes(Data);
                }
            }
        }

        #region abrirForm

        private void sessõesNãoRealizadasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmEscolhaRelatorio obj = new frmEscolhaRelatorio();
            obj.Realizada = false;
            obj.ShowDialog();
        }


        private void tipoTatuagemToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            abrirForm(typeof(frmPesquisaTipoTatuagem));
        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja realmente trocar o usuário?", "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                Application.Restart();
            }
        }

        private void gerarRelatórioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmEscolhaRelatorio obj = new frmEscolhaRelatorio();
            obj.Realizada = true;
            obj.ShowDialog();
        }

        private void orçamentoTattooToolStripMenuItem_Click(object sender, EventArgs e)
        {
            abrirForm(typeof(frmNovoTatuagem));
        }

        private void clienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            abrirForm(typeof(frmNovoCliente));
        }

        private void tatuagemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            abrirForm(typeof(frmPesquisaTatuagem));
        }

        private void funcionarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            abrirForm(typeof(frmNovoFuncionario));
        }
        
        private void agendamentoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            abrirForm(typeof(frmNovoAgendamento));
        }

        private void clienteToolStripMenuItem1_Click(object sender, EventArgs e)
        {         
            abrirForm(typeof(frmPesquisaCliente));
        }

        private void funcionárioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            abrirForm(typeof(frmPesquisaFuncionario));
        }

        private void backupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            abrirForm(typeof(frmGerarBackup));
        }
        
        private void agendamentosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            abrirForm(typeof(frmPesquisaAgendamento));
        }

        private void tipoTatuagemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            abrirForm(typeof(frmNovoTipo));
        }

        #endregion

        private void calculadoraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("Calc");
        }

        private void blocoDeNotasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("NotePad");
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            if (lstData.SelectedItems.Count > 0)
            {
                Alterar();
            }
        }

        #endregion       

    }
}
