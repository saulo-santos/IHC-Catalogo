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

        private void btnImagemProcurar_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dlgImagem = new OpenFileDialog())
            {
                dlgImagem.Title = "Procurar Imagens";
                dlgImagem.Filter = "Arquivos de Imagem (*.jpg, *.jpeg, *.bmp) | *.jpg; *.jpeg; *.bmp";

                if (dlgImagem.ShowDialog() == DialogResult.OK)
                {
                    picImagemVisualizador.Image = new Bitmap(dlgImagem.FileName);
                }
            }
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

            tabArtigo.Width = this.ClientSize.Width - 20;

            #region TabDados
            cmbCategoria.Width = tabArtigo.Width - 22;

            btnFechar.Left = (tabArtigo.Left + tabArtigo.Width) - btnFechar.Width;
            btnSalvar.Left = btnFechar.Left - 8 - btnSalvar.Width;

            btnFechar.Top = this.ClientSize.Height - btnFechar.Height - 10;
            btnSalvar.Top = this.ClientSize.Height - btnSalvar.Height - 10;

            tabArtigo.Height = btnFechar.Top - 45;
            txtTexto.Height = tpgDados.Height - txtTexto.Top - 12;
            #endregion 

            #region TabImagens

            lsvImagens.Left = tpgImagens.Width - lsvImagens.Width - 10;
            lsvImagens.Height = tpgImagens.Height - 20;

            btnImagemProcurar.Left = lsvImagens.Left - 10 - btnImagemProcurar.Width;
            txtImagemDescricao.Width = btnImagemProcurar.Left + btnImagemProcurar.Width - 6;
            btnSalvarImagem.Left = lsvImagens.Left - 10 - btnImagemProcurar.Width;
            picImagemVisualizador.Width = btnImagemProcurar.Left + btnImagemProcurar.Width - 6;
            picImagemVisualizador.Height = tpgImagens.Height - picImagemVisualizador.Top - 10;

            #endregion

            /* if (this.Height >= 550)
             {
                 txtTexto.Height = this.ClientSize.Height - txtTexto.Top - (btnFechar.Height + 20);
             }
             txtTexto.Width = this.tpgDados.Width - (txtTexto.Left * 2);

             cmbCategoria.Width = this.tpgDados.Width - (txtTexto.Left * 2);

             if (this.ClientSize.Width >= btnSalvar.Width + btnFechar.Width + 32)
             {
                 btnFechar.Left = (tpgDados.Left + tpgDados.Width) - btnFechar.Width;
                 btnSalvar.Left = btnFechar.Left - 8 - btnSalvar.Width;
             }

             if (this.Height >= 550)
             {
                 btnFechar.Top = this.tpgDados.Height - btnFechar.Height - 10;
                 btnSalvar.Top = this.tpgDados.Height - btnSalvar.Height - 10;
             }*/

            //--------------------------
            /*lblTitulo.Left = (this.ClientSize.Width - lblTitulo.Width) / 2;

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
            }*/
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

        private bool ArtigoValidaCampos()
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

        private void ArtigoSalvar()
        {
            try
            {
                // Valida se o(s) campo(s) obrigatórios foram preenchidos
                if (!ArtigoValidaCampos())
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

                    ArtigoLimpaCampos();
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

        private void ArtigoLimpaCampos()
        {
            txtTitulo.Text = string.Empty;
            cmbCategoria.SelectedIndex = 0;
            txtTexto.Text = string.Empty;

            txtTitulo.Focus();
        }

        private bool ImagemValidaCampos()
        {
            if (string.IsNullOrEmpty(txtImagemDescricao.Text.Trim()))
            {
                MessageBox.Show("O campo de 'Descrição' da imagem é obrigatório. Por favor preencha-o!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            if (picImagemVisualizador == null && picImagemVisualizador.Image == null)
            {
                MessageBox.Show("Procure por uma imagem para depois adiciona-la!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            return true;
        }

        private void ImagemLimpaCampos()
        {
            txtImagemDescricao.Text = string.Empty;
            picImagemVisualizador = null;

            btnImagemProcurar.Focus();
        }

        private void btnSalvarImagem_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ImagemValidaCampos())
                {
                    return;
                }

                SqlConnection cnn = new SqlConnection();
                string pstrMsg = "";
                bool pbooRetorno = false;

                cnn = ConexaoBD.CriarConexao(out pstrMsg, out pbooRetorno);

                if (pbooRetorno)
                {
                    imlImagens.Images.Add(txtImagemDescricao.Text, picImagemVisualizador.Image);
                    lsvImagens.Items.Clear();

                    for (int i = 0; i < imlImagens.Images.Count; i++)
                    {
                        lsvImagens.Items.Add(new ListViewItem { ImageIndex = i, Text = txtImagemDescricao.Text });
                    }

                    ArtigoLimpaCampos();
                }
                else
                {
                    MessageBox.Show(pstrMsg, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);

                    if (!pbooRetorno)
                        Close();
                }

                cnn.Close();
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
