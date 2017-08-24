namespace TCC_CAVALCENT
{
    partial class frmPesquisaTatuagemAG
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPesquisaTatuagemAG));
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnContinuar = new System.Windows.Forms.Button();
            this.lstPesquisa = new System.Windows.Forms.ListView();
            this.Cli_Nome = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ID_TAT = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Tpt_Tipo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Tat_Descricao = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Tat_Total = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Tat_Sessoes = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Tat_FaltaPagar = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // btnCancelar
            // 
            this.btnCancelar.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.Image = global::TCC_CAVALCENT.Properties.Resources.CANCELAR;
            this.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancelar.Location = new System.Drawing.Point(3, 301);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(90, 30);
            this.btnCancelar.TabIndex = 3;
            this.btnCancelar.Text = " Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnContinuar
            // 
            this.btnContinuar.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnContinuar.Image = global::TCC_CAVALCENT.Properties.Resources.CONFIRMAR;
            this.btnContinuar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnContinuar.Location = new System.Drawing.Point(912, 301);
            this.btnContinuar.Name = "btnContinuar";
            this.btnContinuar.Size = new System.Drawing.Size(90, 30);
            this.btnContinuar.TabIndex = 2;
            this.btnContinuar.Text = "Continuar";
            this.btnContinuar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnContinuar.UseVisualStyleBackColor = true;
            this.btnContinuar.Click += new System.EventHandler(this.btnContinuar_Click);
            // 
            // lstPesquisa
            // 
            this.lstPesquisa.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Cli_Nome,
            this.ID_TAT,
            this.Tpt_Tipo,
            this.Tat_Descricao,
            this.Tat_Total,
            this.Tat_Sessoes,
            this.Tat_FaltaPagar});
            this.lstPesquisa.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstPesquisa.FullRowSelect = true;
            this.lstPesquisa.GridLines = true;
            this.lstPesquisa.Location = new System.Drawing.Point(3, 12);
            this.lstPesquisa.Name = "lstPesquisa";
            this.lstPesquisa.Size = new System.Drawing.Size(998, 283);
            this.lstPesquisa.TabIndex = 0;
            this.lstPesquisa.UseCompatibleStateImageBehavior = false;
            this.lstPesquisa.View = System.Windows.Forms.View.Details;
            this.lstPesquisa.DoubleClick += new System.EventHandler(this.lstPesquisa_DoubleClick);
            // 
            // Cli_Nome
            // 
            this.Cli_Nome.Text = "Cliente";
            this.Cli_Nome.Width = 122;
            // 
            // ID_TAT
            // 
            this.ID_TAT.Text = "Nr° Registro Tattoo";
            this.ID_TAT.Width = 129;
            // 
            // Tpt_Tipo
            // 
            this.Tpt_Tipo.Text = "Tipo";
            this.Tpt_Tipo.Width = 156;
            // 
            // Tat_Descricao
            // 
            this.Tat_Descricao.Text = "Descrição";
            this.Tat_Descricao.Width = 236;
            // 
            // Tat_Total
            // 
            this.Tat_Total.Text = "ValorTotal";
            this.Tat_Total.Width = 86;
            // 
            // Tat_Sessoes
            // 
            this.Tat_Sessoes.Text = "Sessoes para finalizar";
            this.Tat_Sessoes.Width = 146;
            // 
            // Tat_FaltaPagar
            // 
            this.Tat_FaltaPagar.Text = "Preço P/ Finalizar";
            this.Tat_FaltaPagar.Width = 118;
            // 
            // frmPesquisaTatuagemAG
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::TCC_CAVALCENT.Properties.Resources.BG_Tela_Geral;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1013, 341);
            this.Controls.Add(this.lstPesquisa);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnContinuar);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmPesquisaTatuagemAG";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pesquisa Tatuagem";
            this.Load += new System.EventHandler(this.frmPesquisaTatuagemAG_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnContinuar;
        private System.Windows.Forms.ListView lstPesquisa;
        private System.Windows.Forms.ColumnHeader Cli_Nome;
        private System.Windows.Forms.ColumnHeader ID_TAT;
        private System.Windows.Forms.ColumnHeader Tpt_Tipo;
        private System.Windows.Forms.ColumnHeader Tat_Descricao;
        private System.Windows.Forms.ColumnHeader Tat_Total;
        private System.Windows.Forms.ColumnHeader Tat_Sessoes;
        private System.Windows.Forms.ColumnHeader Tat_FaltaPagar;
    }
}