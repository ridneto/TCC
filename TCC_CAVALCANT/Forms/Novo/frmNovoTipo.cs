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
    public partial class frmNovoTipo : Form
    {
        public frmNovoTipo()
        {
            InitializeComponent();
        }

        #region variaveis

        public int ID_TPTT;
        public string Tpt_Tipo;
        int ID_TPT;
        public frmNovoTatuagem objfrmNovoOrcamentoTattoo { get; set; }
        public int NovaTatto = 0;

        #endregion

        #region metodos

        private void SalvarTipo(string Tpt_Tipo)
        {
            try
            {
                int registrosAfetados = 0;
                var objMLTAB_TPT = new MLTAB_TPT();
                var objBLTAB_TPT = new BLTAB_TPT();

                objMLTAB_TPT.Tpt_Tipo = Tpt_Tipo;
                
                registrosAfetados = objBLTAB_TPT.Gravar(objMLTAB_TPT);
                ID_TPT = registrosAfetados;
                if (registrosAfetados > 0)
                {
                    if (ID_TPTT > 0)
                    {
                        MessageBox.Show("Tipo de tatuagem alterado com sucesso.");
                    }
                    else
                    {
                        MessageBox.Show("Tipo Tatuagem gravado com sucesso"); 
                    }                  
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Tipo de tatuagem já existente");
            }
        }

        private void AlterarTipo(int ID_TPTT, string Tpt_Tipo)
        {
            var objMLTAB_TPT = new MLTAB_TPT();
            var objBLTAB_TPT = new BLTAB_TPT();

            objMLTAB_TPT.ID_TPT = ID_TPTT;
            objMLTAB_TPT.Tpt_Tipo = Tpt_Tipo;

            int registrosAfetados = objBLTAB_TPT.Atualizar(objMLTAB_TPT);

            if (registrosAfetados > 0)
            {
                MessageBox.Show("Tipo atualizado com sucesso.");
                Close();
            }
        }

        #endregion

        #region eventos

        private void frmNovoTipo_Load(object sender, EventArgs e)
        {
            if (ID_TPTT > 0)
            {
                btnSalvar.Text = "Alterar";
                txtTipo.Text = Tpt_Tipo;
            }
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTipo.Text))
            {
                MessageBox.Show("Por favor, digite o tipo da tatuagem.");
            }
            else
            {
                if (ID_TPTT > 0)
                {
                    try
                    {
                        AlterarTipo(ID_TPTT, txtTipo.Text);
                        this.Close();
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Tipo de tatuagem já existente.");
                    }
                }
                else
                {
                    SalvarTipo(txtTipo.Text);
                }
                if (NovaTatto == 1)
                {
                    objfrmNovoOrcamentoTattoo.ID_TPT = ID_TPT;
                    objfrmNovoOrcamentoTattoo.Tpt_Tipo = txtTipo.Text;
                    this.Close();
                }
                txtTipo.Text = "";
            }            
        }

        

        #endregion

    }
}
