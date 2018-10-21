namespace Catalogo
{
    partial class ArtigoCadastro
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
            this.btnFechar = new System.Windows.Forms.Button();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.tabArtigo = new System.Windows.Forms.TabControl();
            this.tpgDados = new System.Windows.Forms.TabPage();
            this.txtTexto = new System.Windows.Forms.TextBox();
            this.lblDescricao = new System.Windows.Forms.Label();
            this.cmbCategoria = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTitulo = new System.Windows.Forms.TextBox();
            this.lblNome = new System.Windows.Forms.Label();
            this.imlImagens = new System.Windows.Forms.ImageList(this.components);
            this.tabLinks = new System.Windows.Forms.TabPage();
            this.btnImagemProcurar = new System.Windows.Forms.Button();
            this.btnSalvarImagem = new System.Windows.Forms.Button();
            this.picImagemVisualizador = new System.Windows.Forms.PictureBox();
            this.lblImagemDescricao = new System.Windows.Forms.Label();
            this.txtImagemDescricao = new System.Windows.Forms.TextBox();
            this.tpgImagens = new System.Windows.Forms.TabPage();
            this.lsvImagens = new System.Windows.Forms.ListView();
            this.tabArtigo.SuspendLayout();
            this.tpgDados.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picImagemVisualizador)).BeginInit();
            this.tpgImagens.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnFechar
            // 
            this.btnFechar.Location = new System.Drawing.Point(909, 552);
            this.btnFechar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnFechar.Name = "btnFechar";
            this.btnFechar.Size = new System.Drawing.Size(112, 35);
            this.btnFechar.TabIndex = 4;
            this.btnFechar.Text = "&Fechar";
            this.btnFechar.UseVisualStyleBackColor = true;
            this.btnFechar.Click += new System.EventHandler(this.btnFechar_Click);
            // 
            // btnSalvar
            // 
            this.btnSalvar.Location = new System.Drawing.Point(789, 552);
            this.btnSalvar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(112, 35);
            this.btnSalvar.TabIndex = 3;
            this.btnSalvar.Text = "&Salvar Artigo";
            this.btnSalvar.UseVisualStyleBackColor = true;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // lblTitulo
            // 
            this.lblTitulo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.Location = new System.Drawing.Point(413, 9);
            this.lblTitulo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(175, 25);
            this.lblTitulo.TabIndex = 12;
            this.lblTitulo.Text = "Cadastro de Artigo";
            this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tabArtigo
            // 
            this.tabArtigo.Controls.Add(this.tpgDados);
            this.tabArtigo.Controls.Add(this.tpgImagens);
            this.tabArtigo.Controls.Add(this.tabLinks);
            this.tabArtigo.Location = new System.Drawing.Point(12, 37);
            this.tabArtigo.Name = "tabArtigo";
            this.tabArtigo.SelectedIndex = 0;
            this.tabArtigo.Size = new System.Drawing.Size(1010, 511);
            this.tabArtigo.TabIndex = 14;
            // 
            // tpgDados
            // 
            this.tpgDados.Controls.Add(this.txtTexto);
            this.tpgDados.Controls.Add(this.lblDescricao);
            this.tpgDados.Controls.Add(this.cmbCategoria);
            this.tpgDados.Controls.Add(this.label1);
            this.tpgDados.Controls.Add(this.txtTitulo);
            this.tpgDados.Controls.Add(this.lblNome);
            this.tpgDados.Location = new System.Drawing.Point(4, 29);
            this.tpgDados.Name = "tpgDados";
            this.tpgDados.Padding = new System.Windows.Forms.Padding(3);
            this.tpgDados.Size = new System.Drawing.Size(1002, 478);
            this.tpgDados.TabIndex = 0;
            this.tpgDados.Text = "Dados";
            this.tpgDados.UseVisualStyleBackColor = true;
            // 
            // txtTexto
            // 
            this.txtTexto.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTexto.Location = new System.Drawing.Point(8, 146);
            this.txtTexto.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtTexto.MaxLength = 400;
            this.txtTexto.Multiline = true;
            this.txtTexto.Name = "txtTexto";
            this.txtTexto.Size = new System.Drawing.Size(987, 324);
            this.txtTexto.TabIndex = 16;
            // 
            // lblDescricao
            // 
            this.lblDescricao.AutoSize = true;
            this.lblDescricao.Location = new System.Drawing.Point(4, 121);
            this.lblDescricao.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDescricao.Name = "lblDescricao";
            this.lblDescricao.Size = new System.Drawing.Size(48, 20);
            this.lblDescricao.TabIndex = 17;
            this.lblDescricao.Text = "Texto";
            // 
            // cmbCategoria
            // 
            this.cmbCategoria.BackColor = System.Drawing.SystemColors.Window;
            this.cmbCategoria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCategoria.FormattingEnabled = true;
            this.cmbCategoria.Location = new System.Drawing.Point(7, 90);
            this.cmbCategoria.Name = "cmbCategoria";
            this.cmbCategoria.Size = new System.Drawing.Size(988, 28);
            this.cmbCategoria.TabIndex = 14;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 66);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 20);
            this.label1.TabIndex = 15;
            this.label1.Text = "Categoria";
            // 
            // txtTitulo
            // 
            this.txtTitulo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTitulo.Location = new System.Drawing.Point(7, 35);
            this.txtTitulo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtTitulo.MaxLength = 40;
            this.txtTitulo.Name = "txtTitulo";
            this.txtTitulo.Size = new System.Drawing.Size(988, 26);
            this.txtTitulo.TabIndex = 8;
            // 
            // lblNome
            // 
            this.lblNome.AutoSize = true;
            this.lblNome.Location = new System.Drawing.Point(3, 10);
            this.lblNome.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNome.Name = "lblNome";
            this.lblNome.Size = new System.Drawing.Size(47, 20);
            this.lblNome.TabIndex = 9;
            this.lblNome.Text = "Título";
            // 
            // imlImagens
            // 
            this.imlImagens.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imlImagens.ImageSize = new System.Drawing.Size(16, 16);
            this.imlImagens.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // tabLinks
            // 
            this.tabLinks.Location = new System.Drawing.Point(4, 29);
            this.tabLinks.Name = "tabLinks";
            this.tabLinks.Size = new System.Drawing.Size(1002, 478);
            this.tabLinks.TabIndex = 2;
            this.tabLinks.Text = "Links";
            this.tabLinks.UseVisualStyleBackColor = true;
            // 
            // btnImagemProcurar
            // 
            this.btnImagemProcurar.Location = new System.Drawing.Point(517, 8);
            this.btnImagemProcurar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnImagemProcurar.Name = "btnImagemProcurar";
            this.btnImagemProcurar.Size = new System.Drawing.Size(159, 30);
            this.btnImagemProcurar.TabIndex = 7;
            this.btnImagemProcurar.Text = "&Procurar Imagem";
            this.btnImagemProcurar.UseVisualStyleBackColor = true;
            this.btnImagemProcurar.Click += new System.EventHandler(this.btnImagemProcurar_Click);
            // 
            // btnSalvarImagem
            // 
            this.btnSalvarImagem.Location = new System.Drawing.Point(517, 78);
            this.btnSalvarImagem.Name = "btnSalvarImagem";
            this.btnSalvarImagem.Size = new System.Drawing.Size(159, 29);
            this.btnSalvarImagem.TabIndex = 10;
            this.btnSalvarImagem.Text = "&Salvar Imagem";
            this.btnSalvarImagem.UseVisualStyleBackColor = true;
            this.btnSalvarImagem.Click += new System.EventHandler(this.btnSalvarImagem_Click);
            // 
            // picImagemVisualizador
            // 
            this.picImagemVisualizador.BackColor = System.Drawing.Color.Transparent;
            this.picImagemVisualizador.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picImagemVisualizador.Location = new System.Drawing.Point(7, 113);
            this.picImagemVisualizador.Name = "picImagemVisualizador";
            this.picImagemVisualizador.Size = new System.Drawing.Size(669, 357);
            this.picImagemVisualizador.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picImagemVisualizador.TabIndex = 11;
            this.picImagemVisualizador.TabStop = false;
            // 
            // lblImagemDescricao
            // 
            this.lblImagemDescricao.AutoSize = true;
            this.lblImagemDescricao.Location = new System.Drawing.Point(2, 13);
            this.lblImagemDescricao.Name = "lblImagemDescricao";
            this.lblImagemDescricao.Size = new System.Drawing.Size(80, 20);
            this.lblImagemDescricao.TabIndex = 12;
            this.lblImagemDescricao.Text = "Descrição";
            // 
            // txtImagemDescricao
            // 
            this.txtImagemDescricao.Location = new System.Drawing.Point(6, 46);
            this.txtImagemDescricao.Name = "txtImagemDescricao";
            this.txtImagemDescricao.Size = new System.Drawing.Size(669, 26);
            this.txtImagemDescricao.TabIndex = 13;
            // 
            // tpgImagens
            // 
            this.tpgImagens.Controls.Add(this.lsvImagens);
            this.tpgImagens.Controls.Add(this.txtImagemDescricao);
            this.tpgImagens.Controls.Add(this.lblImagemDescricao);
            this.tpgImagens.Controls.Add(this.picImagemVisualizador);
            this.tpgImagens.Controls.Add(this.btnSalvarImagem);
            this.tpgImagens.Controls.Add(this.btnImagemProcurar);
            this.tpgImagens.Location = new System.Drawing.Point(4, 29);
            this.tpgImagens.Name = "tpgImagens";
            this.tpgImagens.Padding = new System.Windows.Forms.Padding(3);
            this.tpgImagens.Size = new System.Drawing.Size(1002, 478);
            this.tpgImagens.TabIndex = 1;
            this.tpgImagens.Text = "Imagens";
            this.tpgImagens.UseVisualStyleBackColor = true;
            // 
            // lsvImagens
            // 
            this.lsvImagens.LargeImageList = this.imlImagens;
            this.lsvImagens.Location = new System.Drawing.Point(682, 8);
            this.lsvImagens.Name = "lsvImagens";
            this.lsvImagens.Size = new System.Drawing.Size(315, 462);
            this.lsvImagens.SmallImageList = this.imlImagens;
            this.lsvImagens.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.lsvImagens.TabIndex = 15;
            this.lsvImagens.UseCompatibleStateImageBehavior = false;
            this.lsvImagens.View = System.Windows.Forms.View.Tile;
            // 
            // ArtigoCadastro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1034, 593);
            this.Controls.Add(this.tabArtigo);
            this.Controls.Add(this.btnFechar);
            this.Controls.Add(this.btnSalvar);
            this.Controls.Add(this.lblTitulo);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "ArtigoCadastro";
            this.Text = "Cadastro de Artigo";
            this.Load += new System.EventHandler(this.ArtigoCadastro_Load);
            this.Resize += new System.EventHandler(this.ArtigoCadastro_Resize);
            this.tabArtigo.ResumeLayout(false);
            this.tpgDados.ResumeLayout(false);
            this.tpgDados.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picImagemVisualizador)).EndInit();
            this.tpgImagens.ResumeLayout(false);
            this.tpgImagens.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnFechar;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.TabControl tabArtigo;
        private System.Windows.Forms.TabPage tpgDados;
        private System.Windows.Forms.TextBox txtTexto;
        private System.Windows.Forms.Label lblDescricao;
        private System.Windows.Forms.ComboBox cmbCategoria;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTitulo;
        private System.Windows.Forms.Label lblNome;
        private System.Windows.Forms.TabPage tabLinks;
        private System.Windows.Forms.ImageList imlImagens;
        private System.Windows.Forms.TabPage tpgImagens;
        private System.Windows.Forms.ListView lsvImagens;
        private System.Windows.Forms.TextBox txtImagemDescricao;
        private System.Windows.Forms.Label lblImagemDescricao;
        private System.Windows.Forms.PictureBox picImagemVisualizador;
        private System.Windows.Forms.Button btnSalvarImagem;
        private System.Windows.Forms.Button btnImagemProcurar;
    }
}