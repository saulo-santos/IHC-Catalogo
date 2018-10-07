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
            ((System.ComponentModel.ISupportInitialize)(this.grdArtigos)).BeginInit();
            this.SuspendLayout();
            // 
            // grdArtigos
            // 
            this.grdArtigos.AllowUserToAddRows = false;
            this.grdArtigos.AllowUserToDeleteRows = false;
            this.grdArtigos.AllowUserToOrderColumns = true;
            this.grdArtigos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdArtigos.Location = new System.Drawing.Point(30, 153);
            this.grdArtigos.Name = "grdArtigos";
            this.grdArtigos.ReadOnly = true;
            this.grdArtigos.Size = new System.Drawing.Size(527, 288);
            this.grdArtigos.TabIndex = 0;
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Location = new System.Drawing.Point(235, 9);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(79, 13);
            this.lblTitulo.TabIndex = 1;
            this.lblTitulo.Text = "Lista de Artigos";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Categoria";
            // 
            // lblArtigo
            // 
            this.lblArtigo.AutoSize = true;
            this.lblArtigo.Location = new System.Drawing.Point(235, 54);
            this.lblArtigo.Name = "lblArtigo";
            this.lblArtigo.Size = new System.Drawing.Size(34, 13);
            this.lblArtigo.TabIndex = 2;
            this.lblArtigo.Text = "Artigo";
            // 
            // txtCategoria
            // 
            this.txtCategoria.Location = new System.Drawing.Point(85, 51);
            this.txtCategoria.Name = "txtCategoria";
            this.txtCategoria.Size = new System.Drawing.Size(100, 20);
            this.txtCategoria.TabIndex = 3;
            // 
            // txtArtigo
            // 
            this.txtArtigo.Location = new System.Drawing.Point(277, 51);
            this.txtArtigo.Name = "txtArtigo";
            this.txtArtigo.Size = new System.Drawing.Size(100, 20);
            this.txtArtigo.TabIndex = 4;
            // 
            // Principal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(609, 469);
            this.Controls.Add(this.txtArtigo);
            this.Controls.Add(this.txtCategoria);
            this.Controls.Add(this.lblArtigo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.grdArtigos);
            this.Name = "Principal";
            this.Text = "Principal";
            this.Load += new System.EventHandler(this.Principal_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdArtigos)).EndInit();
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
    }
}

