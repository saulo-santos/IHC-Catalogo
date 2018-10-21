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
    public partial class ArtigoCadastro : Form
    {
        public int ArtigoCodigo = 0;

        public ArtigoCadastro(int pArtigoCodigo)
        {
            this.ArtigoCodigo = pArtigoCodigo;
            InitializeComponent();
        }

        private void ArtigoCadastro_Load(object sender, EventArgs e)
        {
            LstCategoriaPreencher();

            if (!ArtigoCodigo.Equals(0))
            {
                SqlConnection cnn = new SqlConnection();
                string pstrMsg = "";
                bool pbooRetorno = false;

                cnn = ConexaoBD.CriarConexao(out pstrMsg, out pbooRetorno);

                if (pbooRetorno)
                {
                    string strSQL = @"
                    SELECT A.ARTI_NOME, C.CATE_NOME, A.ARTI_TEXTO
                    FROM TB_ARTIGO A
                    INNER JOIN TB_CATEGORIA C ON C.CATE_CODIGO = A.ARTI_CATE_CODIGO
                    WHERE A.ARTI_CODIGO = " + ArtigoCodigo;

                    SqlCommand sqlCmd = new SqlCommand(strSQL, cnn);
                    SqlDataReader sqlDataRead = sqlCmd.ExecuteReader();

                    while (sqlDataRead.Read())
                    {
                        txtTitulo.Text = sqlDataRead.GetValue(0).ToString();

                        int index = cmbCategoria.FindString(sqlDataRead.GetValue(1).ToString());

                        cmbCategoria.SelectedIndex = index;
                        txtTexto.Text = sqlDataRead.GetValue(2).ToString();
                    }
                }
                else
                {
                    MessageBox.Show(pstrMsg);

                    if (!pbooRetorno)
                        Close();
                }

                cnn.Close();
            }

            RedimencionaObjetos();
        }

        private void ArtigoCadastro_Resize(object sender, EventArgs e)
        {
            RedimencionaObjetos();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            ArtigoSalvar();
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
                txtTexto.Height = this.ClientSize.Height - txtTexto.Top - (btnFechar.Height + 20);
            }
            txtTexto.Width = this.ClientSize.Width - (txtTexto.Left * 2);

            cmbCategoria.Width = this.ClientSize.Width - (txtTexto.Left * 2);

            if (this.ClientSize.Width >= btnSalvar.Width + btnFechar.Width + 32)
            {
                btnFechar.Left = (txtTexto.Left + txtTexto.Width) - btnFechar.Width;
                btnSalvar.Left = btnFechar.Left - 8 - btnSalvar.Width;
            }

            if (this.Height >= 550)
            {
                btnFechar.Top = this.ClientSize.Height - btnFechar.Height - 10;
                btnSalvar.Top = this.ClientSize.Height - btnSalvar.Height - 10;
            }
        }

        private void LstCategoriaPreencher()
        {
            try
            {
                SqlConnection cnn = new SqlConnection();
                string pstrMsg = "";
                bool pbooRetorno = false;

                cnn = ConexaoBD.CriarConexao(out pstrMsg, out pbooRetorno);

                if (pbooRetorno)
                {
                    string strSQL = @"
                    SELECT * FROM 
                    (
                    SELECT 0 CATE_CODIGO, '' CATE_NOME
                    UNION ALL
                    SELECT CATE_CODIGO, CATE_NOME 
                    FROM TB_CATEGORIA
                    ) CarOrdenado
                    ORDEr BY CarOrdenado.CATE_NOME ";

                    SqlCommand sqlCmd = new SqlCommand(strSQL, cnn);

                    SqlDataAdapter da = new SqlDataAdapter(sqlCmd);
                    DataTable dt = new DataTable("TB_CATEGORIA");

                    da.Fill(dt);

                    cmbCategoria.ValueMember = "CATE_CODIGO";
                    cmbCategoria.DisplayMember = "CATE_NOME";
                    cmbCategoria.DataSource = dt;
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
                MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ArtigoSalvar()
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
                    if (ArtigoCodigo.Equals(0))
                    {
                        string strSQL = @"
                        INSERT INTO TB_ARTIGO 
                        VALUES ('" + txtTitulo.Text + "','" + txtTexto.Text + "'," + cmbCategoria.SelectedValue + ")";

                        SqlCommand sqlCmd = new SqlCommand(strSQL, cnn);

                        sqlCmd.ExecuteNonQuery();

                        MessageBox.Show("O artigo de título '" + txtTitulo.Text + "' foi incluído com sucesso!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        string strSQL = @"
                        UPDATE TB_ARTIGO 
                        SET ARTI_NOME = '" + txtTitulo.Text + "', ARTI_TEXTO = '" + txtTexto.Text.Replace("'","") + "', ARTI_CATE_CODIGO = " + cmbCategoria.SelectedValue + " WHERE ARTI_CODIGO = " + ArtigoCodigo;

                        SqlCommand sqlCmd = new SqlCommand(strSQL, cnn);

                        sqlCmd.ExecuteNonQuery();

                        MessageBox.Show("O artigo de título '" + txtTitulo.Text + "' foi alterado com sucesso!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        
                        Close();
                    }

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
                MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LimpaCampos()
        {
            txtTitulo.Text = string.Empty;
            cmbCategoria.SelectedIndex = 0;
            txtTexto.Text = string.Empty;

            txtTitulo.Focus();
        }

        private bool ValidaCampos()
        {
            if (string.IsNullOrEmpty(txtTitulo.Text.Trim()))
            {
                MessageBox.Show("O campo 'Título' é obrigatório. Por favor preencha-o!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            if (cmbCategoria.SelectedIndex == 0)
            {
                MessageBox.Show("O campo 'Categoria' é obrigatório. Por favor escolha um dos itens da Lista!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            if (string.IsNullOrEmpty(txtTexto.Text.Trim()))
            {
                MessageBox.Show("O campo 'Texto' é obrigatório. Por favor preencha-o!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            return true;
        }

    }
}
