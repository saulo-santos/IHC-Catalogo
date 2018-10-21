namespace Catalogo
{
    partial class UsrCtrlInfo
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblInfo = new System.Windows.Forms.Label();
            this.lklAcao = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // lblInfo
            // 
            this.lblInfo.AutoSize = true;
            this.lblInfo.BackColor = System.Drawing.Color.Transparent;
            this.lblInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInfo.ForeColor = System.Drawing.Color.Black;
            this.lblInfo.Location = new System.Drawing.Point(4, 9);
            this.lblInfo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(241, 20);
            this.lblInfo.TabIndex = 8;
            this.lblInfo.Text = "Artigo excluído com sucesso.";
            this.lblInfo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lklAcao
            // 
            this.lklAcao.Dock = System.Windows.Forms.DockStyle.Right;
            this.lklAcao.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lklAcao.LinkColor = System.Drawing.Color.Red;
            this.lklAcao.Location = new System.Drawing.Point(251, 0);
            this.lklAcao.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lklAcao.Name = "lklAcao";
            this.lklAcao.Size = new System.Drawing.Size(164, 38);
            this.lklAcao.TabIndex = 9;
            this.lklAcao.TabStop = true;
            this.lklAcao.Text = "Desfazer Exclusão";
            this.lklAcao.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // UsrCtrlInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lklAcao);
            this.Controls.Add(this.lblInfo);
            this.Name = "UsrCtrlInfo";
            this.Size = new System.Drawing.Size(415, 38);
            this.Load += new System.EventHandler(this.UsrCtrlInfo_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.LinkLabel lklAcao;
    }
}
