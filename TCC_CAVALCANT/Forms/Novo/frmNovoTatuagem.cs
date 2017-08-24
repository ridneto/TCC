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
    public partial class frmNovoTatuagem : Form
    {
        public frmNovoTatuagem()
        {
            InitializeComponent();
        }              

        #region variaveis

        public frmPesquisaClienteAG objFrmPesquisaClienteAG { get; set; }  
        public string NomeCliente { get; set; }

        public string Tat_Descricao;
        public string Tat_Tipo;
        public int    ID_CLI;
        public double Tat_Total;
        public double Tat_FaltaPagar;
        public string Cli_Nome;
        public int    ID_TPT;
        public string Tpt_Tipo;
        public int    ID_TAT;

        public int EditaTat = 0;
        public int ContinuaTat = 0;
        int AG = 0;
        public int NovaTatAGENDA = 0;

        #endregion

        #region eventos

        private void frmNovoOrcamentoTattoo_Load(object sender, EventArgs e)
        {
            if (EditaTat == 1)
            {
                txtNomeCliente.Text = Cli_Nome;
                txtNomeCliente.Enabled = false;
                CarregarTipos();
                LiberarComponentes();
                txtDescricao.Text = Tat_Descricao;
                txtPreco.Text = Tat_Total.ToString(".00");
                btnSalvar.Text = "Alterar";
                txtSessoes.Text = ConsultarSessoes(ID_TAT).ToString();
                lblFalta.Visible = true;
                txtFaltaPagar.Visible = true;
                txtFaltaPagar.Text = Tat_FaltaPagar.ToString(".00");
            }
            if (ID_CLI > 0)
            {
                txtNomeCliente.Text = Cli_Nome;
                txtNomeCliente.Enabled = false;
                btnPesquisar.Enabled = false;
                LiberarComponentes();
                CarregarTipos();
                if (ContinuaTat == 0)
                {
                    AG = 1;
                }
            }
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            frmPesquisaClienteOT objfrmPesquisaClienteOT = new frmPesquisaClienteOT();
            objfrmPesquisaClienteOT.nomeCliente = txtNomeCliente.Text;
            objfrmPesquisaClienteOT.objfrmNovoOrcamentoTattoo = this;
            objfrmPesquisaClienteOT.ShowDialog();
            txtNomeCliente.Text = Cli_Nome;
            if (ID_CLI > 0)
            {
                LiberarComponentes();
                CarregarTipos();
            }
        }

        private void Cancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            if (EditaTat == 1)
            {
                txtPreco.Text = "";
                txtSessoes.Text = "";
                txtDescricao.Text = "";
                cmbTipos.Text = "";
                txtFaltaPagar.Text = "";
            }else
            {
                if (AG == 0)
                {
                Limpar();
                }
                else
                {
                    txtSessoes.Text = "";
                    txtDescricao.Text = "";
                    cmbTipos.Text = "";
                    cmbTipos.Enabled = true;
                    btnNovoTipo.Enabled = true;
                }
            }
            
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {   
            if (EditaTat == 1)
            {
                double FaltaPagar = Convert.ToDouble(txtFaltaPagar.Text);

                if (string.IsNullOrEmpty(txtPreco.Text) || string.IsNullOrEmpty(cmbTipos.Text) || string.IsNullOrEmpty(txtDescricao.Text) || string.IsNullOrEmpty(txtSessoes.Text) || string.IsNullOrEmpty(txtFaltaPagar.Text))
                {
                    MessageBox.Show("Por favor, preencha todos os campos.", "Erro",
                                 MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    int Sessoes = Convert.ToInt16(txtSessoes.Text);
                    double Preco = Convert.ToDouble(txtPreco.Text);

                    if (Sessoes <= 0 || Preco <= 0 || FaltaPagar <= 0)
                    {
                        MessageBox.Show("Não é possivel ter o número igual a zero de Sessões/Preço/Falta Pagar.", "Erro",
                                 MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    else
                    {
                        if (Preco < FaltaPagar)
                        {
                            MessageBox.Show("Não é possivel o valor total da tatuagem ser menor que o valor que falta pagar.", "Erro",
                                 MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                        else
                        {
                            try
                            {
                                int ID_TPT = Convert.ToInt16(cmbTipos.SelectedValue.ToString());
                                double PrecoDouble = Convert.ToDouble(Preco);
                                double FaltaDouble = Convert.ToDouble(FaltaPagar);
                                AtualizarTatuagem(ID_TAT, ID_TPT, Sessoes, PrecoDouble, txtDescricao.Text, FaltaDouble);
                                Close();   
                            }
                            catch (Exception)
                            {
                                MessageBox.Show("Não é possivel atualizar a tatuagem.");
                            }
                        }
                    }
                }
            }
            else
            {
                if (string.IsNullOrEmpty(txtPreco.Text) || string.IsNullOrEmpty(cmbTipos.Text) || string.IsNullOrEmpty(txtDescricao.Text) || string.IsNullOrEmpty(txtSessoes.Text))
                {
                    MessageBox.Show("Por favor, preencha todos os campos.");
                }
                else
                {
                    int Sessoes = Convert.ToInt16(txtSessoes.Text);
                    double Preco = Convert.ToDouble(txtPreco.Text);

                    if (Sessoes <= 0 || Preco <= 0)
                    {
                        MessageBox.Show("Não é possivel ter o número igual a 0 de Sessões/Preço.");
                    }
                    else
                    {
                        try
                        {
                            SalvarTatuagem(Convert.ToInt32(cmbTipos.SelectedValue.ToString()), ID_CLI, Convert.ToInt16(txtSessoes.Text), Convert.ToDouble(txtPreco.Text), txtDescricao.Text);
                            
                            if (AG == 1)
                            {
                                objFrmPesquisaClienteAG.NomeCli = txtNomeCliente.Text;
                                objFrmPesquisaClienteAG.Tat_Descricao = txtDescricao.Text;
                                objFrmPesquisaClienteAG.Tpt_Tipo = cmbTipos.Text.ToString();
                                objFrmPesquisaClienteAG.Tat_Total = Convert.ToDouble(txtPreco.Text);
                                objFrmPesquisaClienteAG.ID_TAT = ID_TAT;

                                objFrmPesquisaClienteAG.NAG = 1;
                                this.Close();
                            }
                            else
                            {
                                if (ContinuaTat == 0)
                                {
                                   Limpar();
                                }
                                else
                                {
                                    txtDescricao.Text = "";
                                    txtSessoes.Text = "";
                                    txtPreco.Text = "";
                                }
                            }
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("Dados inválidos.");
                        }
                    }
                }
            }                               
        }        
        
        private void btnNovoTipo_Click(object sender, EventArgs e)
        {
            frmNovoTipo objFrmNovoTipo = new frmNovoTipo();
            objFrmNovoTipo.objfrmNovoOrcamentoTattoo = this;
            objFrmNovoTipo.NovaTatto = 1;
            objFrmNovoTipo.ShowDialog();
            cmbTipos.Text = Tpt_Tipo;
            if (string.IsNullOrEmpty(cmbTipos.Text))
            {
            }
            else
            {
                cmbTipos.Enabled = false;
                btnNovoTipo.Enabled = false;
            }    
        }

        #endregion

        #region metodos

        private void txtPreco_TextChanged(object sender, EventArgs e)
        {
            Utils.TextBoxMoeda(txtPreco);
        }

        private void txtFaltaPagar_TextChanged(object sender, EventArgs e)
        {
            Utils.TextBoxMoeda(txtFaltaPagar);
        }

        private int ConsultarSessoes(int ID_TAT)
        {
            var objBLTAB_TPT = new BLTAB_TAT();
            return objBLTAB_TPT.ConsultarSessoes(ID_TAT);        
        }
        
        private void SalvarTatuagem(int ID_TPT, int ID_CLI, int Tat_Sessoes, double Tat_Total, string Tat_Descricao)
        {
            int registrosAfetados = 0;
            var objMLTAB_TAT = new MLTAB_TAT();
            var objBLTAB_TAT = new BLTAB_TAT();

            objMLTAB_TAT.ID_TPT = ID_TPT;
            objMLTAB_TAT.ID_CLI = ID_CLI;
            objMLTAB_TAT.Tat_Sessoes = Tat_Sessoes;
            objMLTAB_TAT.Tat_Aberto = "A";
            objMLTAB_TAT.Tat_Total = Tat_Total;
            objMLTAB_TAT.Tat_FaltaPagar = Convert.ToDouble(Tat_Total);
            objMLTAB_TAT.Tat_Descricao = Tat_Descricao;

            registrosAfetados = objBLTAB_TAT.Gravar(objMLTAB_TAT);

            ID_TAT = registrosAfetados;

            if (registrosAfetados > 0)
            {
                if (NovaTatAGENDA == 0)
                {
                    if (MessageBox.Show("Tatuagem gravada com sucesso. Deseja fazer um agendamento?", "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                    {
                        for (int i = 0; i < 1; i++)
                        {
                            frmNovoAgendamento objfrmNovoAgendamento = new frmNovoAgendamento();
                            objfrmNovoAgendamento.ID_TAT = registrosAfetados;
                            objfrmNovoAgendamento.ContinuaTat = 1;
                            objfrmNovoAgendamento.ID_CLI = ID_CLI;
                            objfrmNovoAgendamento.ShowDialog();
                            if (TAB_FUNC.Gambi == 1)
                            {
                                if (MessageBox.Show("Deseja fazer outro agendamento?", "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                                {
                                    i--;
                                    TAB_FUNC.Gambi = 0;
                                }
                            }
                        }
                    }
                }
            }
        }       

        private void CarregarTipos()
        {
            var objBLTAB_TPT = new BLTAB_TPT();            
            List<MLTAB_TPT> objListaTipos = new List<MLTAB_TPT>();

            objListaTipos = objBLTAB_TPT.Consultar();

            cmbTipos.DataSource = objBLTAB_TPT.Consultar();
            cmbTipos.DisplayMember = "Tpt_Tipo";
            cmbTipos.ValueMember = "ID_TPT";

            //cmbTipos.DataBindings.Add("SelectedValue", objListaTipos, "TAB_TPT.ID_TPT");
        }        

        private void LiberarComponentes()
        {
            cmbTipos.Enabled = true;
            txtDescricao.Enabled = true;
            txtSessoes.Enabled = true;
            txtPreco.Enabled = true;
            btnLimpar.Enabled = true;
            btnNovoTipo.Enabled = true;
            btnSalvar.Enabled = true;
            txtNomeCliente.Enabled = false;
            btnPesquisar.Enabled = false;
        }

        private void Limpar()
        {
            cmbTipos.Enabled = false;
            txtDescricao.Enabled = false;
            txtSessoes.Enabled = false;
            txtPreco.Enabled = false;
            btnLimpar.Enabled = false;
            btnNovoTipo.Enabled = false;
            btnSalvar.Enabled = false;
            txtNomeCliente.Enabled = true;
            btnPesquisar.Enabled = true;

            txtSessoes.Text = "";
            txtPreco.Text = "";
            txtNomeCliente.Text = "";
            txtDescricao.Text = "";
            cmbTipos.Text = "";
        }

        private void txtSessoes_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
        }

        private void txtPreco_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
        }

        private void AtualizarTatuagem(int ID_TAT, int ID_TPT, int Sessoes, double PrecoDouble, string Tat_Descricao, double FaltaPagar)
        {
            int registrosAfetados = 0;
            var objMLTAB_TAT = new MLTAB_TAT();
            var objBLTAB_TAT = new BLTAB_TAT();

            objMLTAB_TAT.ID_TAT = ID_TAT;
            objMLTAB_TAT.ID_TPT = ID_TPT;
            objMLTAB_TAT.Tat_Sessoes = Sessoes;
            objMLTAB_TAT.Tat_Total = PrecoDouble;
            objMLTAB_TAT.Tat_Descricao = Tat_Descricao;
            objMLTAB_TAT.Tat_FaltaPagar = FaltaPagar;

            registrosAfetados = objBLTAB_TAT.Atualizar(objMLTAB_TAT);

            if (registrosAfetados > 0)
            {
                MessageBox.Show("Tatuagem atualizada com sucesso.");
                Close();
            }
        }       

        #endregion   

       

    }
}
