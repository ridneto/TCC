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
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        int tentativas = 0;

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            var objBLTAB_FUNC = new BLTAB_FUNC();
            List<MLTAB_FUNC> objListaUsuario = new List<MLTAB_FUNC>();

            objListaUsuario = objBLTAB_FUNC.Consultar(txtUser.Text, txtSenha.Text);

            if (objListaUsuario.Count > 0)
            {
                TAB_FUNC.ID_FUN = objListaUsuario[0].ID_FUN;
                TAB_FUNC.Fun_Login = objListaUsuario[0].Fun_Login;
                TAB_FUNC.Fun_Senha = objListaUsuario[0].Fun_Senha;
                TAB_FUNC.Fun_Tipo = objListaUsuario[0].Fun_Tipo;

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                tentativas++;

                if (tentativas == 3)
                {
                    MessageBox.Show("Você atinguiu o limite de tentativas", "Erro de acesso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Application.ExitThread();
                }

                MessageBox.Show("Nome de usuário e/ou senha incorreta. Na 3° tentativa o programa se fechará.", "Erro",
                                 MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtSenha.Text = "";
                txtUser.Text = "";

                txtUser.Focus();                
            }
        }
    }
}
