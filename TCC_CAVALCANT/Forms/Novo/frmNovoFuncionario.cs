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
    public partial class frmNovoFuncionario : Form
    {
        public frmNovoFuncionario()
        {
            InitializeComponent();
        }

        #region Variaveis Publicas

        public int ID_FUN;
        public int Fun_Tipo;
        public string Fun_Login;
        public string Fun_Senha;
        public string Fun_NomeTatuador;

        #endregion

        #region metodos

        private void CadastrarFuncionario(string Fun_Login, string Fun_Senha, string Fun_NomeTatuador, int Fun_Tipo)
        {
            try
            {
                int registrosAfetados = 0;
                var objMLTAB_Fun = new MLTAB_FUNC();
                var objBLTAB_Fun = new BLTAB_FUNC();

                objMLTAB_Fun.Fun_Login = Fun_Login;
                objMLTAB_Fun.Fun_Senha = Fun_Senha;
                objMLTAB_Fun.Fun_NomeTatuador = Fun_NomeTatuador;
                objMLTAB_Fun.Fun_Tipo = Fun_Tipo;

                registrosAfetados = objBLTAB_Fun.Gravar(objMLTAB_Fun);

                if (registrosAfetados > 0)
                {
                    MessageBox.Show("Funcionário cadastro com sucesso.");
                    txtLogin.Text = "";
                    txtConfirmarSenha.Text = "";
                    txtNomeTatuador.Text = "";
                    txtSenha.Text = "";
                }
            }
            catch (Exception )
            {
                MessageBox.Show("Não foi possível cadastrar esse funcionário.");
            }
        }

        private void Atualizar(int ID_FUN, string Fun_Login, string Fun_Senha, string Fun_NomeTatuador)
        {
            try
            {
                int registrosAfetados = 0;
                var objMLTAB_FUNC = new MLTAB_FUNC();
                var objBLTAB_FUNC = new BLTAB_FUNC();

                objMLTAB_FUNC.ID_FUN = ID_FUN;
                objMLTAB_FUNC.Fun_Tipo = Fun_Tipo;
                objMLTAB_FUNC.Fun_Login = Fun_Login;
                objMLTAB_FUNC.Fun_Senha = Fun_Senha;
                objMLTAB_FUNC.Fun_NomeTatuador = Fun_NomeTatuador;

                if (TAB_FUNC.ID_FUN == ID_FUN)
                {
                    TAB_FUNC.Fun_Tipo = Fun_Tipo;
                    TAB_FUNC.Fun_Senha = Fun_Senha;
                    TAB_FUNC.Fun_Login = Fun_Login;
                }

                registrosAfetados = objBLTAB_FUNC.Atualizar(objMLTAB_FUNC);

                if (registrosAfetados > 0)
                {
                    MessageBox.Show("Funcionário atualizado com sucesso.");
                    Close();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Não foi possível atualizar esse funcionário.");
            }
        }

        #endregion

        #region eventos

        private void frmCadastroFuncionario_Load(object sender, EventArgs e)
        {
            if (ID_FUN > 0)
            {
                btnSalvar.Text = "Alterar";

                if (Fun_Tipo == 1)
                {
                    rdbAdm.Checked = true;
                }
                else
                {
                    rdbFunc.Checked = true;
                }

                if (ID_FUN == 1)
                {
                    rdbAdm.Enabled = false;
                    rdbFunc.Enabled = false;
                }

                txtLogin.Text = Fun_Login;
                txtSenha.Text = Fun_Senha;
                txtNomeTatuador.Text = Fun_NomeTatuador;                
            }
            else
            {
                btnSalvar.Text = "Salvar";
            }
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            txtLogin.Text = "";
            txtConfirmarSenha.Text = "";
            txtNomeTatuador.Text = "";
            txtSenha.Text = "";
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtLogin.Text) || string.IsNullOrEmpty(txtSenha.Text) || string.IsNullOrEmpty(txtConfirmarSenha.Text) || (string.IsNullOrEmpty(txtNomeTatuador.Text)))
            {
                MessageBox.Show("Por favor, preencha todos os campos requisitados", "Erro",
                                 MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
                if (txtSenha.Text != txtConfirmarSenha.Text)
                {
                    MessageBox.Show("Senhas não correspondem.", "Erro",
                                 MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtSenha.Focus();
                }
                else
                {
                    if (rdbAdm.Checked)
                    {
                        Fun_Tipo = 1;
                    }
                    else
                    {
                        Fun_Tipo = 2;
                    }

                    if (ID_FUN > 0)
                    {                        
                        Atualizar(ID_FUN, txtLogin.Text, txtSenha.Text, txtNomeTatuador.Text);                        
                    }
                    else
                    {
                        CadastrarFuncionario(txtLogin.Text, txtSenha.Text, txtNomeTatuador.Text, Fun_Tipo);  
                    }
              
                }
        }   

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        #endregion 

      

        

    }
}
