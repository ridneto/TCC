namespace TCC_CAVALCENT
{
    partial class frmTelaPrincipal
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTelaPrincipal));
            this.mtcPrincipal = new System.Windows.Forms.MonthCalendar();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.novoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clienteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.funcionarioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tipoTatuagemToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.orçamentoTattooToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.agendamentoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pesquisarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clienteToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.funcionárioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tipoTatuagemToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.tatuagemToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.agendamentosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.relatórioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gerarRelatórioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sessõesNãoRealizadasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ferramentaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.backupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.calculadoraToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.blocoDeNotasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sairToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sairToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.btnConfirmar = new System.Windows.Forms.Button();
            this.lstData = new System.Windows.Forms.ListView();
            this.Age_Hora = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Cli_Nome = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Age_ValorSessao = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnExcluir = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.ttpCancelar = new System.Windows.Forms.ToolTip(this.components);
            this.ttpAdicionar = new System.Windows.Forms.ToolTip(this.components);
            this.ttpConfirmar = new System.Windows.Forms.ToolTip(this.components);
            this.menuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // mtcPrincipal
            // 
            this.mtcPrincipal.Location = new System.Drawing.Point(37, 25);
            this.mtcPrincipal.Name = "mtcPrincipal";
            this.mtcPrincipal.TabIndex = 1;
            this.mtcPrincipal.TitleBackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.mtcPrincipal.TitleForeColor = System.Drawing.Color.Transparent;
            this.mtcPrincipal.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.mtcPrincipal_DateChanged);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.novoToolStripMenuItem,
            this.pesquisarToolStripMenuItem,
            this.relatórioToolStripMenuItem,
            this.ferramentaToolStripMenuItem,
            this.sairToolStripMenuItem,
            this.sairToolStripMenuItem1});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(793, 24);
            this.menuStrip1.TabIndex = 5;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // novoToolStripMenuItem
            // 
            this.novoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clienteToolStripMenuItem,
            this.funcionarioToolStripMenuItem,
            this.tipoTatuagemToolStripMenuItem,
            this.orçamentoTattooToolStripMenuItem,
            this.agendamentoToolStripMenuItem});
            this.novoToolStripMenuItem.Image = global::TCC_CAVALCENT.Properties.Resources.menu_novo;
            this.novoToolStripMenuItem.Name = "novoToolStripMenuItem";
            this.novoToolStripMenuItem.Size = new System.Drawing.Size(64, 20);
            this.novoToolStripMenuItem.Text = "Novo";
            // 
            // clienteToolStripMenuItem
            // 
            this.clienteToolStripMenuItem.Image = global::TCC_CAVALCENT.Properties.Resources.novo_cliente;
            this.clienteToolStripMenuItem.Name = "clienteToolStripMenuItem";
            this.clienteToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.clienteToolStripMenuItem.Text = "Cliente";
            this.clienteToolStripMenuItem.Click += new System.EventHandler(this.clienteToolStripMenuItem_Click);
            // 
            // funcionarioToolStripMenuItem
            // 
            this.funcionarioToolStripMenuItem.Image = global::TCC_CAVALCENT.Properties.Resources.Novo_Funcionario;
            this.funcionarioToolStripMenuItem.Name = "funcionarioToolStripMenuItem";
            this.funcionarioToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.funcionarioToolStripMenuItem.Text = "Funcionário";
            this.funcionarioToolStripMenuItem.Click += new System.EventHandler(this.funcionarioToolStripMenuItem_Click);
            // 
            // tipoTatuagemToolStripMenuItem
            // 
            this.tipoTatuagemToolStripMenuItem.Image = global::TCC_CAVALCENT.Properties.Resources.Novo_Tipo_Tatuagem;
            this.tipoTatuagemToolStripMenuItem.Name = "tipoTatuagemToolStripMenuItem";
            this.tipoTatuagemToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.tipoTatuagemToolStripMenuItem.Text = "Tipo Tatuagem";
            this.tipoTatuagemToolStripMenuItem.Click += new System.EventHandler(this.tipoTatuagemToolStripMenuItem_Click);
            // 
            // orçamentoTattooToolStripMenuItem
            // 
            this.orçamentoTattooToolStripMenuItem.Image = global::TCC_CAVALCENT.Properties.Resources.novo_tatuagem;
            this.orçamentoTattooToolStripMenuItem.Name = "orçamentoTattooToolStripMenuItem";
            this.orçamentoTattooToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.orçamentoTattooToolStripMenuItem.Text = "Tatuagem";
            this.orçamentoTattooToolStripMenuItem.Click += new System.EventHandler(this.orçamentoTattooToolStripMenuItem_Click);
            // 
            // agendamentoToolStripMenuItem
            // 
            this.agendamentoToolStripMenuItem.Image = global::TCC_CAVALCENT.Properties.Resources.novo_agendamento;
            this.agendamentoToolStripMenuItem.Name = "agendamentoToolStripMenuItem";
            this.agendamentoToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.agendamentoToolStripMenuItem.Text = "Agendamento";
            this.agendamentoToolStripMenuItem.Click += new System.EventHandler(this.agendamentoToolStripMenuItem_Click);
            // 
            // pesquisarToolStripMenuItem
            // 
            this.pesquisarToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clienteToolStripMenuItem1,
            this.funcionárioToolStripMenuItem,
            this.tipoTatuagemToolStripMenuItem1,
            this.tatuagemToolStripMenuItem,
            this.agendamentosToolStripMenuItem});
            this.pesquisarToolStripMenuItem.Image = global::TCC_CAVALCENT.Properties.Resources.menu_pesquisar;
            this.pesquisarToolStripMenuItem.Name = "pesquisarToolStripMenuItem";
            this.pesquisarToolStripMenuItem.Size = new System.Drawing.Size(85, 20);
            this.pesquisarToolStripMenuItem.Text = "Pesquisar";
            // 
            // clienteToolStripMenuItem1
            // 
            this.clienteToolStripMenuItem1.Image = global::TCC_CAVALCENT.Properties.Resources.pesquisar_cliente;
            this.clienteToolStripMenuItem1.Name = "clienteToolStripMenuItem1";
            this.clienteToolStripMenuItem1.Size = new System.Drawing.Size(155, 22);
            this.clienteToolStripMenuItem1.Text = "Cliente";
            this.clienteToolStripMenuItem1.Click += new System.EventHandler(this.clienteToolStripMenuItem1_Click);
            // 
            // funcionárioToolStripMenuItem
            // 
            this.funcionárioToolStripMenuItem.Enabled = false;
            this.funcionárioToolStripMenuItem.Image = global::TCC_CAVALCENT.Properties.Resources.Pesquisar_funcionario;
            this.funcionárioToolStripMenuItem.Name = "funcionárioToolStripMenuItem";
            this.funcionárioToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.funcionárioToolStripMenuItem.Text = "Funcionário";
            this.funcionárioToolStripMenuItem.Click += new System.EventHandler(this.funcionárioToolStripMenuItem_Click);
            // 
            // tipoTatuagemToolStripMenuItem1
            // 
            this.tipoTatuagemToolStripMenuItem1.Image = global::TCC_CAVALCENT.Properties.Resources.Pesquisar_Tipo_Tatuagem;
            this.tipoTatuagemToolStripMenuItem1.Name = "tipoTatuagemToolStripMenuItem1";
            this.tipoTatuagemToolStripMenuItem1.Size = new System.Drawing.Size(155, 22);
            this.tipoTatuagemToolStripMenuItem1.Text = "Tipo Tatuagem";
            this.tipoTatuagemToolStripMenuItem1.Click += new System.EventHandler(this.tipoTatuagemToolStripMenuItem1_Click);
            // 
            // tatuagemToolStripMenuItem
            // 
            this.tatuagemToolStripMenuItem.Image = global::TCC_CAVALCENT.Properties.Resources.Pesquisar_tatuagem;
            this.tatuagemToolStripMenuItem.Name = "tatuagemToolStripMenuItem";
            this.tatuagemToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.tatuagemToolStripMenuItem.Text = "Tatuagem";
            this.tatuagemToolStripMenuItem.Click += new System.EventHandler(this.tatuagemToolStripMenuItem_Click);
            // 
            // agendamentosToolStripMenuItem
            // 
            this.agendamentosToolStripMenuItem.Image = global::TCC_CAVALCENT.Properties.Resources.Pesquisar_Agendamento;
            this.agendamentosToolStripMenuItem.Name = "agendamentosToolStripMenuItem";
            this.agendamentosToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.agendamentosToolStripMenuItem.Text = "Agendamento";
            this.agendamentosToolStripMenuItem.Click += new System.EventHandler(this.agendamentosToolStripMenuItem_Click);
            // 
            // relatórioToolStripMenuItem
            // 
            this.relatórioToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gerarRelatórioToolStripMenuItem,
            this.sessõesNãoRealizadasToolStripMenuItem});
            this.relatórioToolStripMenuItem.Image = global::TCC_CAVALCENT.Properties.Resources.Menu_Relatorio;
            this.relatórioToolStripMenuItem.Name = "relatórioToolStripMenuItem";
            this.relatórioToolStripMenuItem.Size = new System.Drawing.Size(87, 20);
            this.relatórioToolStripMenuItem.Text = "Relatórios";
            // 
            // gerarRelatórioToolStripMenuItem
            // 
            this.gerarRelatórioToolStripMenuItem.Image = global::TCC_CAVALCENT.Properties.Resources.Menu_Relatorio_Gerar_Relatorio;
            this.gerarRelatórioToolStripMenuItem.Name = "gerarRelatórioToolStripMenuItem";
            this.gerarRelatórioToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
            this.gerarRelatórioToolStripMenuItem.Text = "Sessões Realizadas";
            this.gerarRelatórioToolStripMenuItem.Click += new System.EventHandler(this.gerarRelatórioToolStripMenuItem_Click);
            // 
            // sessõesNãoRealizadasToolStripMenuItem
            // 
            this.sessõesNãoRealizadasToolStripMenuItem.Image = global::TCC_CAVALCENT.Properties.Resources.Menu_Relatorio_Gerar_Relatorio;
            this.sessõesNãoRealizadasToolStripMenuItem.Name = "sessõesNãoRealizadasToolStripMenuItem";
            this.sessõesNãoRealizadasToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
            this.sessõesNãoRealizadasToolStripMenuItem.Text = "Sessões Não Realizadas";
            this.sessõesNãoRealizadasToolStripMenuItem.Click += new System.EventHandler(this.sessõesNãoRealizadasToolStripMenuItem_Click);
            // 
            // ferramentaToolStripMenuItem
            // 
            this.ferramentaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.backupToolStripMenuItem,
            this.calculadoraToolStripMenuItem,
            this.blocoDeNotasToolStripMenuItem});
            this.ferramentaToolStripMenuItem.Image = global::TCC_CAVALCENT.Properties.Resources.Ferramentos;
            this.ferramentaToolStripMenuItem.Name = "ferramentaToolStripMenuItem";
            this.ferramentaToolStripMenuItem.Size = new System.Drawing.Size(100, 20);
            this.ferramentaToolStripMenuItem.Text = "Ferramentas";
            // 
            // backupToolStripMenuItem
            // 
            this.backupToolStripMenuItem.Enabled = false;
            this.backupToolStripMenuItem.Image = global::TCC_CAVALCENT.Properties.Resources.backup;
            this.backupToolStripMenuItem.Name = "backupToolStripMenuItem";
            this.backupToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.backupToolStripMenuItem.Text = "Backup";
            this.backupToolStripMenuItem.Click += new System.EventHandler(this.backupToolStripMenuItem_Click);
            // 
            // calculadoraToolStripMenuItem
            // 
            this.calculadoraToolStripMenuItem.Image = global::TCC_CAVALCENT.Properties.Resources.Calculadora;
            this.calculadoraToolStripMenuItem.Name = "calculadoraToolStripMenuItem";
            this.calculadoraToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.calculadoraToolStripMenuItem.Text = "Calculadora";
            this.calculadoraToolStripMenuItem.Click += new System.EventHandler(this.calculadoraToolStripMenuItem_Click);
            // 
            // blocoDeNotasToolStripMenuItem
            // 
            this.blocoDeNotasToolStripMenuItem.Image = global::TCC_CAVALCENT.Properties.Resources.bloco_de__notes;
            this.blocoDeNotasToolStripMenuItem.Name = "blocoDeNotasToolStripMenuItem";
            this.blocoDeNotasToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.blocoDeNotasToolStripMenuItem.Text = "Bloco de Notas";
            this.blocoDeNotasToolStripMenuItem.Click += new System.EventHandler(this.blocoDeNotasToolStripMenuItem_Click);
            // 
            // sairToolStripMenuItem
            // 
            this.sairToolStripMenuItem.Image = global::TCC_CAVALCENT.Properties.Resources.Menu_Mudar_Usuario;
            this.sairToolStripMenuItem.Name = "sairToolStripMenuItem";
            this.sairToolStripMenuItem.Size = new System.Drawing.Size(112, 20);
            this.sairToolStripMenuItem.Text = "Trocar Usuário";
            this.sairToolStripMenuItem.Click += new System.EventHandler(this.sairToolStripMenuItem_Click);
            // 
            // sairToolStripMenuItem1
            // 
            this.sairToolStripMenuItem1.Image = global::TCC_CAVALCENT.Properties.Resources.Menu_Sair;
            this.sairToolStripMenuItem1.Name = "sairToolStripMenuItem1";
            this.sairToolStripMenuItem1.Size = new System.Drawing.Size(54, 20);
            this.sairToolStripMenuItem1.Text = "&Sair";
            this.sairToolStripMenuItem1.Click += new System.EventHandler(this.sairToolStripMenuItem1_Click);
            // 
            // btnConfirmar
            // 
            this.btnConfirmar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnConfirmar.Image = global::TCC_CAVALCENT.Properties.Resources.Tela_Principal_Confirmar;
            this.btnConfirmar.Location = new System.Drawing.Point(230, 367);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(52, 52);
            this.btnConfirmar.TabIndex = 7;
            this.btnConfirmar.UseVisualStyleBackColor = true;
            this.btnConfirmar.Click += new System.EventHandler(this.btnConfirmar_Click);
            // 
            // lstData
            // 
            this.lstData.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Age_Hora,
            this.Cli_Nome,
            this.Age_ValorSessao});
            this.lstData.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstData.FullRowSelect = true;
            this.lstData.GridLines = true;
            this.lstData.Location = new System.Drawing.Point(20, 199);
            this.lstData.Name = "lstData";
            this.lstData.Size = new System.Drawing.Size(262, 162);
            this.lstData.TabIndex = 37;
            this.lstData.UseCompatibleStateImageBehavior = false;
            this.lstData.View = System.Windows.Forms.View.Details;
            // 
            // Age_Hora
            // 
            this.Age_Hora.Text = "Hora";
            this.Age_Hora.Width = 50;
            // 
            // Cli_Nome
            // 
            this.Cli_Nome.Text = "Nome Cliente";
            this.Cli_Nome.Width = 127;
            // 
            // Age_ValorSessao
            // 
            this.Age_ValorSessao.Text = "Valor";
            this.Age_ValorSessao.Width = 81;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.btnAdd);
            this.groupBox1.Controls.Add(this.btnExcluir);
            this.groupBox1.Controls.Add(this.lstData);
            this.groupBox1.Controls.Add(this.mtcPrincipal);
            this.groupBox1.Controls.Add(this.btnConfirmar);
            this.groupBox1.Location = new System.Drawing.Point(401, 85);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(305, 426);
            this.groupBox1.TabIndex = 38;
            this.groupBox1.TabStop = false;
            // 
            // btnAdd
            // 
            this.btnAdd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAdd.Image = global::TCC_CAVALCENT.Properties.Resources.Menu_Button_Add;
            this.btnAdd.Location = new System.Drawing.Point(126, 367);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(52, 52);
            this.btnAdd.TabIndex = 39;
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnExcluir
            // 
            this.btnExcluir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnExcluir.Image = global::TCC_CAVALCENT.Properties.Resources.Tela_Principal_Excluir;
            this.btnExcluir.Location = new System.Drawing.Point(20, 368);
            this.btnExcluir.Name = "btnExcluir";
            this.btnExcluir.Size = new System.Drawing.Size(52, 52);
            this.btnExcluir.TabIndex = 38;
            this.btnExcluir.UseVisualStyleBackColor = true;
            this.btnExcluir.Click += new System.EventHandler(this.btnExcluir_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            // 
            // ttpCancelar
            // 
            this.ttpCancelar.IsBalloon = true;
            this.ttpCancelar.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Warning;
            this.ttpCancelar.ToolTipTitle = "Excluir Agendamento";
            // 
            // ttpAdicionar
            // 
            this.ttpAdicionar.IsBalloon = true;
            this.ttpAdicionar.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.ttpAdicionar.ToolTipTitle = "Novo Agendamento";
            // 
            // ttpConfirmar
            // 
            this.ttpConfirmar.IsBalloon = true;
            this.ttpConfirmar.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.ttpConfirmar.ToolTipTitle = "Confirmar Sessão";
            // 
            // frmTelaPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::TCC_CAVALCENT.Properties.Resources.BG_Tela_Principal;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(793, 573);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStrip1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmTelaPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Client Tattoo";
            this.Load += new System.EventHandler(this.frmTelaPrincipal_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MonthCalendar mtcPrincipal;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem novoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clienteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem funcionarioToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem agendamentoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pesquisarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clienteToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem funcionárioToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem relatórioToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gerarRelatórioToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ferramentaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem backupToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sairToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sairToolStripMenuItem1;
        private System.Windows.Forms.Button btnConfirmar;
        private System.Windows.Forms.ListView lstData;
        private System.Windows.Forms.ColumnHeader Age_Hora;
        private System.Windows.Forms.ColumnHeader Cli_Nome;
        private System.Windows.Forms.ToolStripMenuItem agendamentosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tatuagemToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem orçamentoTattooToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem calculadoraToolStripMenuItem;
        private System.Windows.Forms.ColumnHeader Age_ValorSessao;
        private System.Windows.Forms.ToolStripMenuItem tipoTatuagemToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ToolStripMenuItem blocoDeNotasToolStripMenuItem;
        private System.Windows.Forms.Button btnExcluir;
        private System.Windows.Forms.ToolStripMenuItem tipoTatuagemToolStripMenuItem1;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.ToolStripMenuItem sessõesNãoRealizadasToolStripMenuItem;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ToolTip ttpCancelar;
        private System.Windows.Forms.ToolTip ttpAdicionar;
        private System.Windows.Forms.ToolTip ttpConfirmar;
    }
}