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
    public partial class frmNovoCliente : Form
    {
        public frmNovoCliente()
        {
            InitializeComponent();
        }

        #region Variaveis Publicas

        public int ID_CLI;
        public string Cli_Nome;
        public DateTime Cli_DataNasc;
        public string Cli_Sexo;
        public string Cli_Telefone;
        public string Cli_Email;       

        #endregion

        #region metodos

        private void txtIdade_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
        }

        private void Gravar(string Cli_Nome, DateTime Cli_DataNasc, string Cli_Email, string Cli_Telefone, string Cli_Sexo)
        {
            try
            {
                int registrosAfetados = 0;
                var objMLTAB_CLI = new MLTAB_CLI();
                var objBLTAB_CLI = new BLTAB_CLI();

                objMLTAB_CLI.Cli_Nome = Cli_Nome;
                objMLTAB_CLI.Cli_DataNasc = Cli_DataNasc;
                objMLTAB_CLI.Cli_Email = Cli_Email;
                objMLTAB_CLI.Cli_Telefone = Cli_Telefone;
                objMLTAB_CLI.Cli_Sexo = Cli_Sexo;

                registrosAfetados = objBLTAB_CLI.Gravar(objMLTAB_CLI);

                if (registrosAfetados > 0)
                {
                    if (MessageBox.Show("Cliente gravado com sucesso. Deseja fazer uma tatuagem com esse cliente?", "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                    {
                        frmNovoTatuagem objFrmNovoTatuagem = new frmNovoTatuagem();
                        objFrmNovoTatuagem.ID_CLI = registrosAfetados;
                        objFrmNovoTatuagem.Cli_Nome = txtNome.Text;
                        objFrmNovoTatuagem.ContinuaTat = 1;
                        objFrmNovoTatuagem.ShowDialog();
                    }
                    txtNome.Text = "";
                    mskNascimento.Text = "";
                    txtEmail.Text = "";
                    mskTelefone.Text = "";
                }

            }
            catch (Exception)
            {
                MessageBox.Show("Ocorreu um erro ao tentar gravar.");
            }
        }

        private void Atualizar(int ID_CLI, string Cli_Nome, DateTime Cli_DataNasc, string Cli_Email, string Cli_Telefone, string Cli_Sexo)
        {
            try
            {
                int registrosAfetados = 0;
                var objMLTAB_CLI = new MLTAB_CLI();
                var objBLTAB_CLI = new BLTAB_CLI();

                objMLTAB_CLI.ID_CLI = ID_CLI;
                objMLTAB_CLI.Cli_Nome = Cli_Nome;
                objMLTAB_CLI.Cli_DataNasc = Cli_DataNasc;
                objMLTAB_CLI.Cli_Email = Cli_Email;
                objMLTAB_CLI.Cli_Telefone = Cli_Telefone;
                objMLTAB_CLI.Cli_Sexo = Cli_Sexo;

                registrosAfetados = objBLTAB_CLI.Atualizar(objMLTAB_CLI);

                if (registrosAfetados > 0)
                {
                    MessageBox.Show("Cliente atualizado com sucesso.");
                    Close();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Ocorreu um erro ao tentar atualizar o cliente.");
            }
        }   

        #endregion 

        #region eventos

        private void frmCadastroCliente_Load(object sender, EventArgs e)
        {
            if (ID_CLI > 0)
            {
                btnSalvar.Text = "Alterar";                

                txtNome.Text = Cli_Nome;
                mskNascimento.Text = Cli_DataNasc.ToString();
                mskTelefone.Text = Cli_Telefone;
                txtEmail.Text = Cli_Email;

                if (Cli_Sexo == "M")
                {
                    rdbMasculino.Checked = true;
                }
                else
                {
                    rdbFemenino.Checked = true;
                }                 
            }
            else
            {
                btnSalvar.Text = "Salvar";
            }
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            txtNome.Text = "";
            mskNascimento.Text = "";
            txtEmail.Text = "";
            mskTelefone.Text = "";
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtNome.Text) || string.IsNullOrEmpty(mskNascimento.Text)/* || string.IsNullOrEmpty(mskTelefone.Text */)
            {
                MessageBox.Show("Por favor, preencha todos os campos.", "Erro",
                                 MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {      
                if (rdbMasculino.Checked)
                {
                    Cli_Sexo = "M";
                }
                else
                {
                    Cli_Sexo = "F";
                }

                try
                {
                    if (ID_CLI > 0)
                    {
                        Atualizar(ID_CLI, txtNome.Text, Convert.ToDateTime(mskNascimento.Text), txtEmail.Text, mskTelefone.Text, Cli_Sexo);
                    }
                    else
                    {
                        Gravar(txtNome.Text, Convert.ToDateTime(mskNascimento.Text), txtEmail.Text, mskTelefone.Text, Cli_Sexo);
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Dados Inválidos", "Erro",
                               MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }               
            }
        }             

        #endregion  

    }
}
