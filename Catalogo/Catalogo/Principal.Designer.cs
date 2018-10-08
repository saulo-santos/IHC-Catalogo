namespace Catalogo
{
    partial class Principal
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
            this.grdArtigos = new System.Windows.Forms.DataGridView();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblArtigo = new System.Windows.Forms.Label();
            this.txtCategoria = new System.Windows.Forms.TextBox();
            this.txtArtigo = new System.Windows.Forms.TextBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.lstCategorias = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.grdArtigos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // grdArtigos
            // 
            this.grdArtigos.AllowUserToAddRows = false;
            this.grdArtigos.AllowUserToDeleteRows = false;
            this.grdArtigos.AllowUserToOrderColumns = true;
            this.grdArtigos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdArtigos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdArtigos.Location = new System.Drawing.Point(3, 3);
            this.grdArtigos.Name = "grdArtigos";
            this.grdArtigos.ReadOnly = true;
            this.grdArtigos.Size = new System.Drawing.Size(564, 497);
            this.grdArtigos.TabIndex = 0;
            this.grdArtigos.Resize += new System.EventHandler(this.grdArtigos_Resize);
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Location = new System.Drawing.Point(364, 9);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(79, 13);
            this.lblTitulo.TabIndex = 1;
            this.lblTitulo.Text = "Lista de Artigos";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(201, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Categoria";
            // 
            // lblArtigo
            // 
            this.lblArtigo.AutoSize = true;
            this.lblArtigo.Location = new System.Drawing.Point(409, 57);
            this.lblArtigo.Name = "lblArtigo";
            this.lblArtigo.Size = new System.Drawing.Size(34, 13);
            this.lblArtigo.TabIndex = 2;
            this.lblArtigo.Text = "Artigo";
            // 
            // txtCategoria
            // 
            this.txtCategoria.Location = new System.Drawing.Point(259, 54);
            this.txtCategoria.Name = "txtCategoria";
            this.txtCategoria.Size = new System.Drawing.Size(100, 20);
            this.txtCategoria.TabIndex = 3;
            // 
            // txtArtigo
            // 
            this.txtArtigo.Location = new System.Drawing.Point(451, 54);
            this.txtArtigo.Name = "txtArtigo";
            this.txtArtigo.Size = new System.Drawing.Size(100, 20);
            this.txtArtigo.TabIndex = 4;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(12, 95);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.lstCategorias);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.grdArtigos);
            this.splitContainer1.Size = new System.Drawing.Size(785, 503);
            this.splitContainer1.SplitterDistance = 211;
            this.splitContainer1.TabIndex = 5;
            // 
            // lstCategorias
            // 
            this.lstCategorias.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstCategorias.FormattingEnabled = true;
            this.lstCategorias.Location = new System.Drawing.Point(3, 3);
            this.lstCategorias.Name = "lstCategorias";
            this.lstCategorias.Size = new System.Drawing.Size(205, 485);
            this.lstCategorias.TabIndex = 0;
            // 
            // Principal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(809, 610);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.txtArtigo);
            this.Controls.Add(this.txtCategoria);
            this.Controls.Add(this.lblArtigo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblTitulo);
            this.Name = "Principal";
            this.Text = "Principal";
            this.Load += new System.EventHandler(this.Principal_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdArtigos)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView grdArtigos;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblArtigo;
        private System.Windows.Forms.TextBox txtCategoria;
        private System.Windows.Forms.TextBox txtArtigo;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ListBox lstCategorias;
    }
}

