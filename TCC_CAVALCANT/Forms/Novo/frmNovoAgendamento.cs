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
    public partial class frmNovoAgendamento : Form
    {
        public frmNovoAgendamento()
        {
            InitializeComponent();
        }

        #region variaveis

        public string NomeCli { get; set; }
        public string Tat_Descricao { get; set; }
        public string Tpt_Tipo { get; set; }
        public double Orc_Total { get; set; }
        public int ID_TAT { get; set; }
        public double Tat_FaltaPagar { get; set; }
        public int editaAgendamento;
        public DateTime Age_Data { get; set; }
        public double Age_ValorSessao { get; set; }
        public string Fpg_Forma { get; set; }
        public int Fpg_Vezes { get; set; }
        public int ID_AGEe { get; set; }
        public int ID_CLI;
        public string HoraAg { get; set; }

        public int NAG = 0; // se for uma nova tatuagem criada agr (1), continuar uma que já tem (2);
        public int ContinuaTat = 0;
        public int TelaPrincipal = 0;

        int Parcelas;
        int ID_AGE;
        string FormPag;


        #endregion

        #region eventos

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            Zerar();
        }

        private void frmNovoAgendamento_Load(object sender, EventArgs e)
        {
            cmbParcelas.Text = "1";
            txtValorRestante.Text = "0,00";
            txtValorSessao.Text = "0,00";
            txtValorTotal.Text = "0,00";

            DateTime Dta = Convert.ToDateTime(txtData.Text);
            CarregarHorarios(Dta);
       
            if (TelaPrincipal == 1)
            {
                txtData.Text = Age_Data.ToString();
                DateTime Data = Convert.ToDateTime(txtData.Text);
                CarregarHorarios(Data);
            }
            else
            {
                if (editaAgendamento == 1)
                {
                    LiberarEditAgendamento();
                }
                else
                    if (ContinuaTat == 1)
                    {
                        CarregarNomeID(ID_CLI);
                        CarregarTat(ID_TAT);
                        txtCliente.Enabled = false;
                        btnCliente.Enabled = false;
                        txtData.Enabled = true;
                        cmbHora.Enabled = true;
                    }
            }
        }

        private void rdbCartao_CheckedChanged(object sender, EventArgs e)
        {
            cmbParcelas.Enabled = true;
        }

        private void rdbDinheiro_CheckedChanged(object sender, EventArgs e)
        {
            cmbParcelas.Enabled = false;
            cmbParcelas.Text = "1";
        }

        private void btnCliente_Click(object sender, EventArgs e)
        {
            frmPesquisaClienteAG objFrmPesquisaCA = new frmPesquisaClienteAG();
            objFrmPesquisaCA.objFrmNovoAgendamento = this;
            objFrmPesquisaCA.NomeCli = txtCliente.Text;
            objFrmPesquisaCA.ShowDialog();
            if (NAG != 0)
            {
                txtCliente.Text = NomeCli;
                if (NAG == 1)
                {
                    tattoCriada();
                }
                else
                {
                    tattoJaExistente();
                }
                CarregarTatuadores();
                LiberarCampos();
            }
        }                

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtCliente.Text))
            {
                Close();
            }
            else
            {
                if (MessageBox.Show("Há dados à serem salvos, deseja mesmo fechar?", "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    Close();
                }
            }
        }

        private void btnHorario_Click(object sender, EventArgs e)
        {
            DateTime Dia = Convert.ToDateTime(txtData.Text);

            string Escolha = cmbHora.Text;

            if (Age_Data != Dia || HoraAg != Escolha || editaAgendamento != 1)
            {
                ChecarHorario(Dia, Escolha);
            }
            else
            {
                cmbHora.Enabled = false;
                txtData.Enabled = false;
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (editaAgendamento == 0)
            {
                if (string.IsNullOrEmpty(cmbParcelas.Text) || string.IsNullOrEmpty(txtValorSessao.Text))
                {
                    MessageBox.Show("Preencha todos os campos antes de fazer o agendamento.", "Erro",
                                 MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    double ValorRestante = Convert.ToDouble(txtValorRestante.Text);
                    double ValorSessao = Convert.ToDouble(txtValorSessao.Text);

                    if (ValorSessao > ValorRestante)
                    {
                        MessageBox.Show("Não é possivel fazer uma sessão que custe mais que o valor da tatuagem.", "Erro",
                             MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    else
                    {
                        try
                        {
                            if (ValorRestante == ValorSessao)
                            {
                                Salvar(ID_TAT, Convert.ToInt32(cmbFunc.SelectedValue.ToString()), Convert.ToDateTime(txtData.Text), Convert.ToInt16(cmbHora.SelectedValue.ToString()), Convert.ToDouble(txtValorSessao.Text));
                                formaPag();
                                SalvarFormaPagamento(ID_AGE, FormPag, Parcelas);
                                DateTime data = Convert.ToDateTime(txtData.Text);
                                CarregarHorarios(data);
                                if (TelaPrincipal == 1)
                                {
                                    Close();
                                }
                                if (ContinuaTat == 1)
                                {
                                    Close();
                                    TAB_FUNC.Gambi = 1;
                                }
                            }
                            else
                            {
                                if (ValorSessao == 0)
                                {
                                    MessageBox.Show("Não é possivel fazer uma sessão que custe esse valor.", "Erro",
                                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                }
                                else
                                {
                                    Salvar(ID_TAT, Convert.ToInt32(cmbFunc.SelectedValue.ToString()), Convert.ToDateTime(txtData.Text), Convert.ToInt16(cmbHora.SelectedValue.ToString()), Convert.ToDouble(txtValorSessao.Text));
                                    formaPag();
                                    SalvarFormaPagamento(ID_AGE, FormPag, Parcelas);
                                    DateTime data = Convert.ToDateTime(txtData.Text);
                                    CarregarHorarios(data);
                                    if (TelaPrincipal == 1)
                                    {
                                        Close();
                                    }
                                    if (ContinuaTat == 1)
                                    {
                                        Close();
                                        TAB_FUNC.Gambi = 1;
                                    }
                                }
                            }
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("Erro na hora de salvar agendamento.");
                            throw;
                        }
                    }
                }
            }
            else
            {
                if (string.IsNullOrEmpty(cmbParcelas.Text) || string.IsNullOrEmpty(txtValorSessao.Text))
                {
                    MessageBox.Show("Preencha todos os campos antes de alterar.", "Erro",
                             MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    double ValorRestante = Convert.ToDouble(txtValorRestante.Text);
                    double ValorSessao = Convert.ToDouble(txtValorSessao.Text);

                    if (ValorSessao <= 0)
                    {
                        MessageBox.Show("Não é possivel alterar a sessão com esse valor.", "Erro",
                             MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    else
                    {
                        if (ValorSessao > ValorRestante)
                        {
                            MessageBox.Show("Não é possivel fazer uma sessão que custe mais que o valor da tatuagem.", "Erro",
                             MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                        else
                        {
                            try
                            {
                                formaPag();
                                DateTime Data = Convert.ToDateTime(txtData.Text);
                                AlterarAgendamento(FormPag, Parcelas, ID_AGEe, Convert.ToInt16(cmbFunc.SelectedValue.ToString()), Data, Convert.ToDouble(txtValorSessao.Text), Convert.ToInt16(cmbHora.SelectedValue.ToString()));
                                Close();
                            }
                            catch (Exception)
                            {
                                MessageBox.Show("Ocorreu um erro ao atualizar o agendamento");
                            }
                        }
                    }
                }
            }
        }

        #endregion

        #region metodos

        private void txtValorSessao_TextChanged(object sender, EventArgs e)
        {
            Utils.TextBoxMoeda(txtValorSessao);
        }

        private void txtValorSessao_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
        }

        private void LiberarEditAgendamento()
        {
            cmbHora.Text = HoraAg;
            btnSalvar.Text = "Alterar";
            txtCliente.Text = NomeCli;
            txtCliente.Enabled = false;
            btnCliente.Enabled = false;
            txtData.Text = Age_Data.ToString();
            CarregarHorarios(Age_Data);
            txtData.Enabled = true;
            cmbHora.Enabled = true;
            cmbParcelas.Enabled = true;
            txtValorSessao.Enabled = true;
            txtValorSessao.Text = Age_ValorSessao.ToString(".00");
            cmbFunc.Enabled = true;
            txtTipo.Text = Tpt_Tipo;
            txtDescricao.Text = Tat_Descricao;
            gpbForma.Enabled = true;
            CarregarTatuadores();
            btnSalvar.Enabled = true;
            cmbParcelas.Text = Fpg_Vezes.ToString();
            if (Fpg_Forma == "Dinheiro")
            {
                rdbDinheiro.Checked = true;
            }
            else
            {
                rdbCartao.Checked = true;
            }

            var objBLTAB_AGENDA = new BLTAB_AGENDA();
            txtValorTotal.Text = objBLTAB_AGENDA.ConsultarValorTotal(ID_AGEe).ToString(".00");
            txtValorRestante.Text = objBLTAB_AGENDA.ConsultarValorFalta(ID_AGEe).ToString(".00");
        }

        private void SalvarFormaPagamento(int ID_AGE, string FormaPag, int Parcelas)
        {
            var objMLTAB_FORMAPAG = new MLTAB_FORMAPAG();
            var objBLTAB_FORMPAG = new BLTAB_FORMAPAG();

            objMLTAB_FORMAPAG.ID_AGE = ID_AGE;
            objMLTAB_FORMAPAG.Fpg_Forma = FormaPag;
            objMLTAB_FORMAPAG.Fpg_Vezes = Parcelas;

            int salvado = objBLTAB_FORMPAG.Gravar(objMLTAB_FORMAPAG);

            if (salvado > 0)
            {
                MessageBox.Show("Agendamento gravado com sucesso.");
                Zerar();
            }

        }

        private void ChecarHorario(DateTime Dia, string Hora)
        {
            var objBLTAB_AGENDA = new BLTAB_AGENDA();

            if (objBLTAB_AGENDA.ConsultarSessaoLivre(Dia, Hora))
            {
                MessageBox.Show("Horário/Data Indisponivel. Escolha outra combinação.", "Erro",
                                 MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (editaAgendamento == 0)
                {
                    if (ContinuaTat == 1)
                    {
                        CarregarTat(ID_TAT);
                        cmbParcelas.Enabled = true;
                        txtValorSessao.Enabled = true;
                        cmbFunc.Enabled = true;
                        rdbCartao.Enabled = true;
                        rdbDinheiro.Enabled = true;
                        btnSalvar.Enabled = true;
                    }
                    else
                    {
                        if (NAG == 1)
                        {
                            tattoCriada();
                        }
                        else
                        {
                            tattoJaExistente();
                        }
                    }
                }
                else
                {
                    cmbHora.Enabled = false;
                    txtData.Enabled = false;
                }
                CarregarTatuadores();
            }
        }

        private void tattoCriada()
        {
            txtValorTotal.Text = Orc_Total.ToString(".00");
            txtValorRestante.Text = Orc_Total.ToString(".00");
            txtDescricao.Text = Tat_Descricao;
            txtTipo.Text = Tpt_Tipo;          
        }

        private void tattoJaExistente()
        {
            txtValorTotal.Text = Orc_Total.ToString(".00");
            txtDescricao.Text = Tat_Descricao;
            txtTipo.Text = Tpt_Tipo;
            txtValorRestante.Text = Tat_FaltaPagar.ToString(".00");            
           
        }

        private void CarregarTatuadores()
        {
            var objBLTAB_FUNC = new BLTAB_FUNC();
           // List<MLTAB_FUNC> objListaFunc = new List<MLTAB_FUNC>();

         //   objListaFunc = objBLTAB_FUNC.ConsultarTatuadores();
            cmbFunc.DataSource = objBLTAB_FUNC.ConsultarTatuadores();
            cmbFunc.DisplayMember = "Fun_NomeTatuador";
            cmbFunc.ValueMember = "ID_FUN";
        }

        private void CarregarHorarios(DateTime Dia)
        {
            var objBl = new BLTAB_HORARIO();

            cmbHora.DataSource = objBl.ConsultarHorario(Dia);
            cmbHora.DisplayMember = "Hora";
            cmbHora.ValueMember = "ID_HOR";
        }

        private void Zerar()
        {
            cmbParcelas.Text = "1";
            txtValorRestante.Text = "0,00";
            txtValorSessao.Text = "0,00";
            txtValorTotal.Text = "0,00";
            rdbCartao.Checked = true;
            NAG = 0;
            txtCliente.Text = "";
            txtCliente.Enabled = true;
            btnCliente.Enabled = true;
            txtTipo.Text = "";
            txtTipo.Enabled = true;
            txtDescricao.Text = "";
            txtDescricao.Enabled = false;
            txtValorTotal.Enabled = false;
            cmbParcelas.Enabled = false;
            cmbFunc.Enabled = false;
            txtTipo.Enabled = false;
            txtValorSessao.Enabled = false;
            txtValorRestante.Enabled = false;
            cmbHora.Enabled = false;
            txtData.Enabled = false;
            btnSalvar.Enabled = false;
            btnLimpar.Enabled = false;
            rdbCartao.Enabled = false;
            rdbDinheiro.Enabled = false;
            
            DateTime agora = DateTime.Now;
            txtData.Text = agora.ToString();
        }

        private void Salvar(int ID_TAT, int ID_FUN, DateTime Age_Data, int ID_HOR, Double Age_ValorSessao)
        {
            var objMLTAB_AGENDA = new MLTAB_AGENDA();
            var objBLTAB_AGENDA = new BLTAB_AGENDA();

            objMLTAB_AGENDA.ID_TAT = ID_TAT;
            objMLTAB_AGENDA.ID_FUN = ID_FUN;
            objMLTAB_AGENDA.Age_Data = Age_Data;
            objMLTAB_AGENDA.ID_HOR = ID_HOR;
            objMLTAB_AGENDA.Age_Realizada = "A";
            objMLTAB_AGENDA.Age_ValorSessao = Age_ValorSessao;

            ID_AGE = objBLTAB_AGENDA.Gravar(objMLTAB_AGENDA);
        }
        
        private void LiberarCampos()
        {
            
            cmbParcelas.Enabled = true;
            cmbFunc.Enabled = true;            
            cmbHora.Enabled = true;

            txtCliente.Enabled = false;
            txtData.Enabled = true;
            txtValorSessao.Enabled = true;

            btnCliente.Enabled = false;
            btnLimpar.Enabled = true;
            btnSalvar.Enabled = true;
            btnCancelar.Enabled = true;

            rdbCartao.Enabled = true;
            rdbDinheiro.Enabled = true;

            gpbForma.Enabled = true;
            
        }

        private void formaPag()
        {
            if (cmbParcelas.SelectedIndex == 0)
            {
                Parcelas = 1;
            }
            else
                if (cmbParcelas.SelectedIndex == 1)
                {
                    Parcelas = 2;
                }
                else
                    if (cmbParcelas.SelectedIndex == 2)
                    {
                        Parcelas = 3;
                    }
                    else
                        if (cmbParcelas.SelectedIndex == 3)
                        {
                            Parcelas = 4;
                        }
                        else
                            if (cmbParcelas.SelectedIndex == 4)
                            {
                                Parcelas = 5;
                            }
                            else
                                if (cmbParcelas.SelectedIndex == 5)
                                {
                                    Parcelas = 6;
                                }
            if (rdbDinheiro.Checked)
            {
                FormPag = "Dinheiro";
            }
            else
            {
                FormPag = "Cartão";
            }
        }

        private void AlterarAgendamento(string FormPag, int Parcelas, int ID_AGE, int ID_FUN, DateTime Age_Data, double Age_ValorSessao, int ID_HOR)
        {
            var objBLTAB_AGENDA = new BLTAB_AGENDA();

            if (objBLTAB_AGENDA.Atualizar(FormPag, Parcelas, ID_AGE, ID_FUN, Age_Data, Age_ValorSessao, ID_HOR))
            {
                MessageBox.Show("Alterado com sucesso o agendamento.");
            }
        }

        private void CarregarTat(int ID_TAT)
        {
            var objBLTAB_TAT = new BLTAB_TAT();
            MLTAB_TAT mlTAB_TAT = new MLTAB_TAT();
            mlTAB_TAT = objBLTAB_TAT.ConsultaTAT(ID_TAT);
            txtDescricao.Text = mlTAB_TAT.Tat_Descricao;
            txtTipo.Text = mlTAB_TAT.Tpt_Tipo;
            txtValorRestante.Text = mlTAB_TAT.Tat_FaltaPagar.ToString(".00");
            txtValorTotal.Text = mlTAB_TAT.Tat_Total.ToString(".00");

            CarregarTatuadores();

            txtValorSessao.Enabled = true;
            cmbParcelas.Enabled = true;
            gpbForma.Enabled = true;
            cmbFunc.Enabled = true;
            btnSalvar.Enabled = true;
            btnCancelar.Enabled = true;
            btnLimpar.Enabled = true;
        }

        private void CarregarNomeID(int ID_CLI)
        {
            var objBLTAB_CLI = new BLTAB_CLI();

            txtCliente.Text = objBLTAB_CLI.Consultar(ID_CLI);
        }

        private void txtData_ValueChanged(object sender, EventArgs e)
        {
            DateTime Data = Convert.ToDateTime(txtData.Text);
            CarregarHorarios(Data);
        }

        #endregion

    }
}
