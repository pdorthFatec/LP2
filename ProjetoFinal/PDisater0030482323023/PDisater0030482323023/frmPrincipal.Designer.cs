namespace PDisater0030482323023
{
    partial class frmPrincipal
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.outrosCadastrosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cadastroDeEventosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sobreToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sairToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cadastroDeCidadesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cadastroDeTiposDeEventosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.outrosCadastrosToolStripMenuItem,
            this.cadastroDeEventosToolStripMenuItem,
            this.sobreToolStripMenuItem,
            this.sairToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // outrosCadastrosToolStripMenuItem
            // 
            this.outrosCadastrosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cadastroDeCidadesToolStripMenuItem,
            this.cadastroDeTiposDeEventosToolStripMenuItem});
            this.outrosCadastrosToolStripMenuItem.Name = "outrosCadastrosToolStripMenuItem";
            this.outrosCadastrosToolStripMenuItem.Size = new System.Drawing.Size(110, 20);
            this.outrosCadastrosToolStripMenuItem.Text = "Outros Cadastros";
            // 
            // cadastroDeEventosToolStripMenuItem
            // 
            this.cadastroDeEventosToolStripMenuItem.Name = "cadastroDeEventosToolStripMenuItem";
            this.cadastroDeEventosToolStripMenuItem.Size = new System.Drawing.Size(126, 20);
            this.cadastroDeEventosToolStripMenuItem.Text = "Cadastro de Eventos";
            // 
            // sobreToolStripMenuItem
            // 
            this.sobreToolStripMenuItem.Name = "sobreToolStripMenuItem";
            this.sobreToolStripMenuItem.Size = new System.Drawing.Size(49, 20);
            this.sobreToolStripMenuItem.Text = "Sobre";
            // 
            // sairToolStripMenuItem
            // 
            this.sairToolStripMenuItem.Name = "sairToolStripMenuItem";
            this.sairToolStripMenuItem.Size = new System.Drawing.Size(38, 20);
            this.sairToolStripMenuItem.Text = "Sair";
            this.sairToolStripMenuItem.Click += new System.EventHandler(this.sairToolStripMenuItem_Click);
            // 
            // cadastroDeCidadesToolStripMenuItem
            // 
            this.cadastroDeCidadesToolStripMenuItem.Name = "cadastroDeCidadesToolStripMenuItem";
            this.cadastroDeCidadesToolStripMenuItem.Size = new System.Drawing.Size(223, 22);
            this.cadastroDeCidadesToolStripMenuItem.Text = "Cadastro de Cidades";
            // 
            // cadastroDeTiposDeEventosToolStripMenuItem
            // 
            this.cadastroDeTiposDeEventosToolStripMenuItem.Name = "cadastroDeTiposDeEventosToolStripMenuItem";
            this.cadastroDeTiposDeEventosToolStripMenuItem.Size = new System.Drawing.Size(223, 22);
            this.cadastroDeTiposDeEventosToolStripMenuItem.Text = "Cadastro de Tipo de Eventos";
            this.cadastroDeTiposDeEventosToolStripMenuItem.Click += new System.EventHandler(this.cadastroDeTiposDeEventosToolStripMenuItem_Click);
            // 
            // frmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmPrincipal";
            this.Text = "Cadastro de Desastres";
            this.Load += new System.EventHandler(this.frmPrincipal_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem outrosCadastrosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cadastroDeCidadesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cadastroDeTiposDeEventosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cadastroDeEventosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sobreToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sairToolStripMenuItem;
    }
}

