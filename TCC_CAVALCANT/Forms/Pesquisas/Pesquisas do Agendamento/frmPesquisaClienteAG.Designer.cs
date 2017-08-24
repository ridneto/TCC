namespace TCC_CAVALCENT
{
    partial class frmPesquisaClienteAG
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPesquisaClienteAG));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rdbContinuar = new System.Windows.Forms.RadioButton();
            this.rdbNovo = new System.Windows.Forms.RadioButton();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnConfirmar = new System.Windows.Forms.Button();
            this.lstPesquisa = new System.Windows.Forms.ListView();
            this.ID_CLI = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Cli_Nome = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.rdbContinuar);
            this.groupBox1.Controls.Add(this.rdbNovo);
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // rdbContinuar
            // 
            resources.ApplyResources(this.rdbContinuar, "rdbContinuar");
            this.rdbContinuar.Checked = true;
            this.rdbContinuar.Name = "rdbContinuar";
            this.rdbContinuar.TabStop = true;
            this.rdbContinuar.UseVisualStyleBackColor = true;
            // 
            // rdbNovo
            // 
            resources.ApplyResources(this.rdbNovo, "rdbNovo");
            this.rdbNovo.Name = "rdbNovo";
            this.rdbNovo.UseVisualStyleBackColor = true;
            // 
            // btnCancelar
            // 
            resources.ApplyResources(this.btnCancelar, "btnCancelar");
            this.btnCancelar.Image = global::TCC_CAVALCENT.Properties.Resources.CANCELAR;
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnConfirmar
            // 
            resources.ApplyResources(this.btnConfirmar, "btnConfirmar");
            this.btnConfirmar.Image = global::TCC_CAVALCENT.Properties.Resources.CONFIRMAR;
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.UseVisualStyleBackColor = true;
            this.btnConfirmar.Click += new System.EventHandler(this.btnConfirmar_Click);
            // 
            // lstPesquisa
            // 
            this.lstPesquisa.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ID_CLI,
            this.Cli_Nome});
            resources.ApplyResources(this.lstPesquisa, "lstPesquisa");
            this.lstPesquisa.FullRowSelect = true;
            this.lstPesquisa.GridLines = true;
            this.lstPesquisa.Name = "lstPesquisa";
            this.lstPesquisa.UseCompatibleStateImageBehavior = false;
            this.lstPesquisa.View = System.Windows.Forms.View.Details;
            this.lstPesquisa.DoubleClick += new System.EventHandler(this.lstPesquisa_DoubleClick);
            // 
            // ID_CLI
            // 
            resources.ApplyResources(this.ID_CLI, "ID_CLI");
            // 
            // Cli_Nome
            // 
            resources.ApplyResources(this.Cli_Nome, "Cli_Nome");
            // 
            // frmPesquisaClienteAG
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::TCC_CAVALCENT.Properties.Resources.BG_Tela_Geral;
            this.Controls.Add(this.lstPesquisa);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnConfirmar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmPesquisaClienteAG";
            this.Load += new System.EventHandler(this.frmPesquisaClienteAG_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rdbContinuar;
        private System.Windows.Forms.RadioButton rdbNovo;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnConfirmar;
        private System.Windows.Forms.ListView lstPesquisa;
        private System.Windows.Forms.ColumnHeader ID_CLI;
        private System.Windows.Forms.ColumnHeader Cli_Nome;
    }
}