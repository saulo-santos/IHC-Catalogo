namespace Catalogo
{
    partial class ArtigoListagem
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
            this.lblCategoria = new System.Windows.Forms.Label();
            this.lblArtigo = new System.Windows.Forms.Label();
            this.txtArtigo = new System.Windows.Forms.TextBox();
            this.sptArtigoListagem = new System.Windows.Forms.SplitContainer();
            this.lstCategorias = new System.Windows.Forms.ListBox();
            this.txtCategoria = new System.Windows.Forms.TextBox();
            this.pnlInfo = new System.Windows.Forms.Panel();
            this.lblInfo = new System.Windows.Forms.Label();
            this.lklDesfazerExclusao = new System.Windows.Forms.LinkLabel();
            this.grdArtigos = new System.Windows.Forms.DataGridView();
            this.lblTitulo = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.sptArtigoListagem)).BeginInit();
            this.sptArtigoListagem.Panel1.SuspendLayout();
            this.sptArtigoListagem.Panel2.SuspendLayout();
            this.sptArtigoListagem.SuspendLayout();
            this.pnlInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdArtigos)).BeginInit();
            this.SuspendLayout();
            // 
            // lblCategoria
            // 
            this.lblCategoria.AutoSize = true;
            this.lblCategoria.Location = new System.Drawing.Point(3, 3);
            this.lblCategoria.Name = "lblCategoria";
            this.lblCategoria.Size = new System.Drawing.Size(52, 13);
            this.lblCategoria.TabIndex = 2;
            this.lblCategoria.Text = "Categoria";
            // 
            // lblArtigo
            // 
            this.lblArtigo.AutoSize = true;
            this.lblArtigo.Location = new System.Drawing.Point(3, 3);
            this.lblArtigo.Name = "lblArtigo";
            this.lblArtigo.Size = new System.Drawing.Size(34, 13);
            this.lblArtigo.TabIndex = 2;
            this.lblArtigo.Text = "Artigo";
            // 
            // txtArtigo
            // 
            this.txtArtigo.Location = new System.Drawing.Point(40, 0);
            this.txtArtigo.Name = "txtArtigo";
            this.txtArtigo.Size = new System.Drawing.Size(527, 20);
            this.txtArtigo.TabIndex = 4;
            this.txtArtigo.TextChanged += new System.EventHandler(this.txtArtigo_TextChanged);
            // 
            // sptArtigoListagem
            // 
            this.sptArtigoListagem.Location = new System.Drawing.Point(12, 47);
            this.sptArtigoListagem.Name = "sptArtigoListagem";
            // 
            // sptArtigoListagem.Panel1
            // 
            this.sptArtigoListagem.Panel1.Controls.Add(this.lstCategorias);
            this.sptArtigoListagem.Panel1.Controls.Add(this.txtCategoria);
            this.sptArtigoListagem.Panel1.Controls.Add(this.lblCategoria);
            // 
            // sptArtigoListagem.Panel2
            // 
            this.sptArtigoListagem.Panel2.Controls.Add(this.pnlInfo);
            this.sptArtigoListagem.Panel2.Controls.Add(this.grdArtigos);
            this.sptArtigoListagem.Panel2.Controls.Add(this.txtArtigo);
            this.sptArtigoListagem.Panel2.Controls.Add(this.lblArtigo);
            this.sptArtigoListagem.Size = new System.Drawing.Size(803, 523);
            this.sptArtigoListagem.SplitterDistance = 215;
            this.sptArtigoListagem.TabIndex = 5;
            // 
            // lstCategorias
            // 
            this.lstCategorias.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstCategorias.FormattingEnabled = true;
            this.lstCategorias.Location = new System.Drawing.Point(3, 26);
            this.lstCategorias.Name = "lstCategorias";
            this.lstCategorias.Size = new System.Drawing.Size(209, 485);
            this.lstCategorias.TabIndex = 0;
            this.lstCategorias.SelectedIndexChanged += new System.EventHandler(this.lstCategorias_SelectedIndexChanged);
            // 
            // txtCategoria
            // 
            this.txtCategoria.Location = new System.Drawing.Point(58, 0);
            this.txtCategoria.Name = "txtCategoria";
            this.txtCategoria.Size = new System.Drawing.Size(150, 20);
            this.txtCategoria.TabIndex = 3;
            this.txtCategoria.TextChanged += new System.EventHandler(this.txtCategoria_TextChanged);
            // 
            // pnlInfo
            // 
            this.pnlInfo.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.pnlInfo.Controls.Add(this.lblInfo);
            this.pnlInfo.Controls.Add(this.lklDesfazerExclusao);
            this.pnlInfo.Location = new System.Drawing.Point(177, 449);
            this.pnlInfo.Name = "pnlInfo";
            this.pnlInfo.Size = new System.Drawing.Size(400, 27);
            this.pnlInfo.TabIndex = 6;
            this.pnlInfo.Visible = false;
            // 
            // lblInfo
            // 
            this.lblInfo.AutoSize = true;
            this.lblInfo.BackColor = System.Drawing.Color.Transparent;
            this.lblInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInfo.ForeColor = System.Drawing.Color.Black;
            this.lblInfo.Location = new System.Drawing.Point(15, 5);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(218, 17);
            this.lblInfo.TabIndex = 8;
            this.lblInfo.Text = "Artigo excluído com sucesso.";
            this.lblInfo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lklDesfazerExclusao
            // 
            this.lklDesfazerExclusao.Dock = System.Windows.Forms.DockStyle.Right;
            this.lklDesfazerExclusao.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lklDesfazerExclusao.LinkColor = System.Drawing.Color.Red;
            this.lklDesfazerExclusao.Location = new System.Drawing.Point(258, 0);
            this.lklDesfazerExclusao.Name = "lklDesfazerExclusao";
            this.lklDesfazerExclusao.Size = new System.Drawing.Size(142, 27);
            this.lklDesfazerExclusao.TabIndex = 7;
            this.lklDesfazerExclusao.TabStop = true;
            this.lklDesfazerExclusao.Text = "Desfazer Exclusão";
            this.lklDesfazerExclusao.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lklDesfazerExclusao.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lklDesfazerExclusao_LinkClicked);
            // 
            // grdArtigos
            // 
            this.grdArtigos.AllowUserToAddRows = false;
            this.grdArtigos.AllowUserToDeleteRows = false;
            this.grdArtigos.AllowUserToOrderColumns = true;
            this.grdArtigos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdArtigos.BackgroundColor = System.Drawing.SystemColors.Window;
            this.grdArtigos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdArtigos.Location = new System.Drawing.Point(3, 26);
            this.grdArtigos.Name = "grdArtigos";
            this.grdArtigos.ReadOnly = true;
            this.grdArtigos.RowHeadersVisible = false;
            this.grdArtigos.Size = new System.Drawing.Size(578, 494);
            this.grdArtigos.TabIndex = 0;
            this.grdArtigos.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdArtigos_CellContentClickAsync);
            this.grdArtigos.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.grdArtigos_CellPainting);
            this.grdArtigos.Resize += new System.EventHandler(this.grdArtigos_Resize);
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.Location = new System.Drawing.Point(329, 9);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(146, 25);
            this.lblTitulo.TabIndex = 1;
            this.lblTitulo.Text = "Lista de Artigos";
            this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ArtigoListagem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(827, 582);
            this.Controls.Add(this.sptArtigoListagem);
            this.Controls.Add(this.lblTitulo);
            this.Name = "ArtigoListagem";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Lista de Artigos";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.ArtigoListagem_Load);
            this.SizeChanged += new System.EventHandler(this.ArtigoListagem_SizeChanged);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.ArtigoListagem_Paint);
            this.Resize += new System.EventHandler(this.ArtigoListagem_Resize);
            this.sptArtigoListagem.Panel1.ResumeLayout(false);
            this.sptArtigoListagem.Panel1.PerformLayout();
            this.sptArtigoListagem.Panel2.ResumeLayout(false);
            this.sptArtigoListagem.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sptArtigoListagem)).EndInit();
            this.sptArtigoListagem.ResumeLayout(false);
            this.pnlInfo.ResumeLayout(false);
            this.pnlInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdArtigos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblCategoria;
        private System.Windows.Forms.Label lblArtigo;
        private System.Windows.Forms.TextBox txtArtigo;
        private System.Windows.Forms.SplitContainer sptArtigoListagem;
        private System.Windows.Forms.ListBox lstCategorias;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.TextBox txtCategoria;
        private System.Windows.Forms.Panel pnlInfo;
        private System.Windows.Forms.LinkLabel lklDesfazerExclusao;
        private System.Windows.Forms.DataGridView grdArtigos;
        private System.Windows.Forms.Label lblInfo;
    }
}

