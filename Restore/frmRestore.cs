using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Restore
{
    public partial class frmRestore : Form
    {
        public frmRestore()
        {
            InitializeComponent();
        }

        string strcon = "Data Source=.;Initial Catalog=master;Persist Security Info=True;User ID=sa;Password=123456 ";
        SqlConnection conexão;
        SqlCommand cmd;

        private void btnRestaurarBackup_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.InitialDirectory = "C:";
            ofd.Filter = "Arquivos Bak (*.bak)|*.bak";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                conexão = new SqlConnection(strcon);
                conexão.Open();
                cmd = new SqlCommand("RESTORE DATABASE DB_TCC FROM DISK=  '" + @ofd.FileName + "' WITH REPLACE", conexão);
                cmd.ExecuteNonQuery();

                conexão.Close();
                MessageBox.Show("Sistema restaurado com sucesso.");

                System.Diagnostics.Process.Start(Application.StartupPath + "\\TCC_CAVALCENT.exe");            
                Application.Exit();             
            }
        }
    }
}
