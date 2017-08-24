using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace TCC_CAVALCENT
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            frmSplash objSplahs = new frmSplash();
            frmLogin objFrmLogin = new frmLogin();
            objSplahs.ShowDialog();
            objFrmLogin.ShowDialog();

            if (objFrmLogin.DialogResult == DialogResult.OK)
            {
                Application.Run(new frmTelaPrincipal());
            }
        }
    }
}
