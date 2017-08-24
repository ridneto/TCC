using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TCC_CAVALCENT
{
    public partial class frmConfirmaSenha : Form
    {
        public frmConfirmaSenha()
        {
            InitializeComponent();
        }

        public int Form { get; set; }

        public frmTelaPrincipal objPrincipal { get; set; } // 1
        public frmPesquisaCliente objCliente { get; set; } // 2
        public frmPesquisaFuncionario objFuncionario { get; set; } // 3
        public frmPesquisaTatuagem objTatuagem { get; set; } // 4
        public frmPesquisaAgendamento objAgendamento { get; set; } // 5
        public frmGerarBackup objBackup { get; set; } // 6

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            if (ConferirSenha())
            {
                if (Form == 1)
                {
                    objPrincipal.SenhaCerta = true;   
                }else
                    if (Form == 2)
                    {
                        objCliente.SenhaCerta = true;
                    }else
                        if (Form == 3)
                        {
                            objFuncionario.SenhaCerta = true;
                        }else
                            if (Form == 4)
                            {
                                objTatuagem.SenhaCerta = true;
                            }else
                                if (Form == 5)
                                {
                                    objAgendamento.SenhaCerta = true;
                                }
                                else
                                {
                                    objBackup.SenhaCerta = true;
                                }
                Close();      
            }
            else
            {
                MessageBox.Show("Senha Inválida.", "Erro",
                                 MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSenha.Text = "";
            }
        }

        private bool ConferirSenha()
        {
            if (TAB_FUNC.Fun_Senha != txtSenha.Text)
            {
                return false;
            }
            else
            {
                return true;
            }        
        }

        private void frmConfirmaSenha_Load(object sender, EventArgs e)
        {

        }
    }
}
