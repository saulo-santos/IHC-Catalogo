using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Catalogo
{
    public partial class CategoriaCadastro : Form
    {
        public CategoriaCadastro()
        {
            InitializeComponent();
        }

        private void CategoriaCadastro_Load(object sender, EventArgs e)
        {
            RedimencionaObjetos();
        }

        private void CategoriaCadastro_Resize(object sender, EventArgs e)
        {
            RedimencionaObjetos();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            CategoriaSalvar();
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void RedimencionaObjetos()
        {
            lblTitulo.Left = (this.ClientSize.Width - lblTitulo.Width) / 2;

            if (this.Height >= 550)
            {
                txtDescricao.Height = this.ClientSize.Height - txtDescricao.Top - (btnFechar.Height + 20);
            }
            txtDescricao.Width = this.ClientSize.Width - (txtDescricao.Left * 2);

            if (this.ClientSize.Width >= btnSalvar.Width + btnFechar.Width + 32)
            {
                btnFechar.Left = (txtDescricao.Left + txtDescricao.Width) - btnFechar.Width;
                btnSalvar.Left = btnFechar.Left - 8 - btnSalvar.Width;
            }

            if (this.Height >= 550)
            {
                btnFechar.Top = this.ClientSize.Height - btnFechar.Height - 10;
                btnSalvar.Top = this.ClientSize.Height - btnSalvar.Height - 10;
            }         
        }

        private void CategoriaSalvar()
        {
            try
            {
                // Valida se o(s) campo(s) obrigatórios foram preenchidos
                if (!ValidaCampos())
                {
                    return;
                }

                SqlConnection cnn = new SqlConnection();
                string pstrMsg = "";
                bool pbooRetorno = false;

                cnn = ConexaoBD.CriarConexao(out pstrMsg, out pbooRetorno);

                if (pbooRetorno)
                {
                    string strSQL = @"
                    INSERT INTO TB_CATEGORIA 
                    VALUES ('" + txtNome.Text + "','" + txtDescricao.Text + "')";

                    SqlCommand sqlCmd = new SqlCommand(strSQL, cnn);

                    sqlCmd.ExecuteNonQuery();

                    MessageBox.Show("A categoria '" + txtNome.Text + "' foi incluída com sucesso!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimpaCampos();
                }
                else
                {
                    MessageBox.Show(pstrMsg, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);

                    if (!pbooRetorno)
                        Close();
                }

                cnn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void LimpaCampos()
        {
            txtNome.Text = string.Empty;
            txtDescricao.Text = string.Empty;

            txtNome.Focus();
        }

        private bool ValidaCampos()
        {
            if (string.IsNullOrEmpty(txtNome.Text.Trim()))
            {
                MessageBox.Show("O campo 'Nome' é obrigatório. Por favor preencha-o!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            return true;
        }
    }
}
