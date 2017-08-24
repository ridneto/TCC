using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using Restore;


namespace TCC_CAVALCENT
{
    public partial class frmGerarBackup : Form
    {
        public frmGerarBackup()
        {
            InitializeComponent();
        }


        public bool SenhaCerta = false;

        string strcon = "Data Source=.;Initial Catalog=master;Persist Security Info=True;User ID=sa;Password=123456";
        SqlConnection conexao;
        SqlCommand cmd;      

        private void btnBackup_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "Arquivos BAK (*.bak) | *.bak";
                sfd.InitialDirectory = "C:";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    string nomedoarquivo = System.IO.Path.GetFileName(sfd.FileName);
                    string diretorio = System.IO.Path.GetDirectoryName(sfd.FileName);
                    string tratarnome = System.IO.Path.GetFileNameWithoutExtension(nomedoarquivo);
                    string nomefinal = tratarnome +
                                        DateTime.Now.Ticks.ToString() +
                                        DateTime.Now.Day.ToString() +
                                        DateTime.Now.Month.ToString() +
                                        DateTime.Now.Year.ToString() +
                                        ".bak";
                    conexao = new SqlConnection(strcon);
                    conexao.Open();
                    cmd = new SqlCommand("Backup database DB_TCC to disk='" + @diretorio + "\\" + nomefinal + "'", conexao);
                    cmd.ExecuteNonQuery();

                    conexao.Close();

                    lblCaminho.Text = sfd.FileName;
                 }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex);
            }
        }

        private void btnRestaurarBackup_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Possui certerza que deseja restaurar o sistema?", "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                if (MessageBox.Show("Isso excluirá o atual banco e irá restaurar o backup, certeza disso?", "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    frmConfirmaSenha objfrmConfirmaSenha = new frmConfirmaSenha();
                    objfrmConfirmaSenha.objBackup = this;
                    objfrmConfirmaSenha.Form = 6;
                    objfrmConfirmaSenha.ShowDialog();
                    if (SenhaCerta)
                    {                        
                         MessageBox.Show("Para restauração do sistema, você será redirecionado a outra tela.");
                     
                         System.Diagnostics.Process.Start(Application.StartupPath + "\\Restore.exe");
                        Application.ExitThread();
                        }
                    }                    
                }
            }
            
        }   

    }

