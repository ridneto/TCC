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
    public partial class frmPesquisaClienteAG : Form
    {
        public frmPesquisaClienteAG()
        {
            InitializeComponent();
        }

        #region variaveis

        public frmNovoAgendamento objFrmNovoAgendamento { get; set; }

        public string NomeCli { get; set; }
        public string Tat_Descricao { get; set; }
        public string Tpt_Tipo { get; set; }
        public double Tat_Total { get; set; }
        public int ID_TAT { get; set; }
        public double Tat_FaltaPagar { get; set; }

        public int NAG;

        #endregion

        #region eventos

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
           Confirmar();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmPesquisaClienteAG_Load(object sender, EventArgs e)
        {
            CarregarDadosCliente();
        }

        private void lstPesquisa_DoubleClick(object sender, EventArgs e)
        {
            Confirmar();
        }

        #endregion 

        #region metodos
        
        private void CarregarDadosCliente()
        {
            var objBLTAB_CLI = new BLTAB_CLI();
            var objMLTAB_CLI = new MLTAB_CLI();
            List<MLTAB_CLI> objListaClientes = new List<MLTAB_CLI>();

            objMLTAB_CLI.Cli_Nome = NomeCli = (String.IsNullOrEmpty(NomeCli)) ? null : NomeCli;

            objListaClientes = objBLTAB_CLI.Consultar(objMLTAB_CLI);

            lstPesquisa.Items.Clear();

            foreach (var itemLista in objListaClientes)
            {
                ListViewItem objListViewItem = new ListViewItem();

                objListViewItem.Text = itemLista.ID_CLI.ToString();
                objListViewItem.SubItems.Add(itemLista.Cli_Nome);

                lstPesquisa.Items.Add(objListViewItem);
            }
        }
                   
        private void Confirmar()
        {
            int idCli = Convert.ToInt32(lstPesquisa.SelectedItems[0].Text);
            var objBLTAB_TAT = new BLTAB_TAT();

            if (objBLTAB_TAT.ChecarTat(idCli))
            {
                if (rdbContinuar.Checked)
                {
                    var objMLTAB_TAT = new MLTAB_TAT();
                    if (lstPesquisa.SelectedItems.Count > 0)
                    {
                        objMLTAB_TAT.ID_CLI = Convert.ToInt32(lstPesquisa.SelectedItems[0].Text);

                        frmPesquisaTatuagemAG objFrmPesquisaTatuagem = new frmPesquisaTatuagemAG();
                        objFrmPesquisaTatuagem.objfrmPesquisaClienteAG = this;
                        objFrmPesquisaTatuagem.ID_CLI = objMLTAB_TAT.ID_CLI;
                        objFrmPesquisaTatuagem.ShowDialog();
                        if (NAG == 1)
                        {
                            objFrmNovoAgendamento.NAG = 2;
                            objFrmNovoAgendamento.ID_TAT = ID_TAT;
                            objFrmNovoAgendamento.NomeCli = NomeCli;
                            objFrmNovoAgendamento.Orc_Total = Tat_Total;
                            objFrmNovoAgendamento.Tpt_Tipo = Tpt_Tipo;
                            objFrmNovoAgendamento.Tat_Descricao = Tat_Descricao;
                            objFrmNovoAgendamento.Tat_FaltaPagar = Tat_FaltaPagar;

                            this.Close();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Escolha o cliente");
                    }
                }
                else
                {
                    var objMLTAB_Cli = new MLTAB_CLI();
                    if (lstPesquisa.SelectedItems.Count > 0)
                    {
                        objMLTAB_Cli.ID_CLI = Convert.ToInt16(lstPesquisa.SelectedItems[0].Text);
                        objMLTAB_Cli.Cli_Nome = lstPesquisa.SelectedItems[0].SubItems[1].Text;

                        frmNovoTatuagem objfrmNovoTat = new frmNovoTatuagem();
                        objfrmNovoTat.objFrmPesquisaClienteAG = this;
                        objfrmNovoTat.Cli_Nome = objMLTAB_Cli.Cli_Nome;
                        objfrmNovoTat.ID_CLI = objMLTAB_Cli.ID_CLI;
                        objfrmNovoTat.NovaTatAGENDA = 1;
                        objfrmNovoTat.ShowDialog();
                        if (NAG == 1)
                        {
                            objFrmNovoAgendamento.NomeCli = NomeCli;
                            objFrmNovoAgendamento.Orc_Total = Tat_Total;
                            objFrmNovoAgendamento.Tat_Descricao = Tat_Descricao;
                            objFrmNovoAgendamento.Tpt_Tipo = Tpt_Tipo;
                            objFrmNovoAgendamento.ID_TAT = ID_TAT;
                            objFrmNovoAgendamento.NAG = 1;

                            this.Close();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Escolha o cliente");
                    }
                }
            }
            else
            {
                 var objMLTAB_Cli = new MLTAB_CLI();
                    if (lstPesquisa.SelectedItems.Count > 0)
                    {
                        objMLTAB_Cli.ID_CLI = Convert.ToInt16(lstPesquisa.SelectedItems[0].Text);
                        objMLTAB_Cli.Cli_Nome = lstPesquisa.SelectedItems[0].SubItems[1].Text;

                        frmNovoTatuagem objfrmNovoTat = new frmNovoTatuagem();
                        objfrmNovoTat.objFrmPesquisaClienteAG = this;
                        objfrmNovoTat.Cli_Nome = objMLTAB_Cli.Cli_Nome;
                        objfrmNovoTat.ID_CLI = objMLTAB_Cli.ID_CLI;
                        objfrmNovoTat.NovaTatAGENDA = 1;
                        objfrmNovoTat.ShowDialog();
                        if (NAG == 1)
                        {
                            objFrmNovoAgendamento.NomeCli = NomeCli;
                            objFrmNovoAgendamento.Orc_Total = Tat_Total;
                            objFrmNovoAgendamento.Tat_Descricao = Tat_Descricao;
                            objFrmNovoAgendamento.Tpt_Tipo = Tpt_Tipo;
                            objFrmNovoAgendamento.ID_TAT = ID_TAT;
                            objFrmNovoAgendamento.NAG = 1;

                            this.Close();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Escolha o cliente");
                    }
                }
            }     
        
        }
        #endregion
    }


