using DataGridViewButton;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Catalogo
{
    public partial class ArtigoListagem : Form
    {
        int msDelay = 3000;
        CancellationTokenSource tokenSource = new CancellationTokenSource();

        public ArtigoListagem()
        {
            InitializeComponent();
        }

        #region [ Controles ]

        private void ArtigoListagem_Load(object sender, EventArgs e)
        {
            LstCategoriaPreencher();
            GridArtigosPreencher();
        }

        private void ArtigoListagem_Paint(object sender, PaintEventArgs e)
        {
            GridArtigosRedimensionar();
        }

        private void ArtigoListagem_Resize(object sender, EventArgs e)
        {
            GridArtigosRedimensionar();
        }

        private void ArtigoListagem_SizeChanged(object sender, EventArgs e)
        {
            //GridArtigosRedimensionar();
        }

        private void txtCategoria_TextChanged(object sender, EventArgs e)
        {
            LstCategoriaPreencher();
        }

        private void txtArtigo_TextChanged(object sender, EventArgs e)
        {
            GridArtigosPreencher();
        }

        private void lstCategorias_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridArtigosPreencher();
        }

        private async void grdArtigos_CellContentClickAsync(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex < 0 || e.RowIndex < 0) return;

            int colSel = e.ColumnIndex;
            int rowSel = e.RowIndex;

            int artigoCodigo = int.Parse(grdArtigos.Rows[rowSel].Cells["ARTI_CODIGO"].Value.ToString());

            var cellExcluirEnabled = ((DataGridViewDisableButtonCell)grdArtigos.Rows[rowSel].Cells["btnExcluir"]).Enabled;

            if (e.ColumnIndex == ((DataGridViewDisableButtonCell)grdArtigos.Rows[rowSel].Cells["btnVisualizar"]).ColumnIndex)
            {
                ((Principal)this.Parent.Parent).artigoVisualizador(artigoCodigo);
            }

            if (e.ColumnIndex == ((DataGridViewDisableButtonCell)grdArtigos.Rows[rowSel].Cells["btnExcluir"]).ColumnIndex && cellExcluirEnabled)
            {
                grdArtigos.Rows.RemoveAt(rowSel);
                await ArtigoExcluirAsync(artigoCodigo);
            }
        }

        private void grdArtigos_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            /*
            if (grdArtigos.Columns[e.ColumnIndex].Name == "btnVisualizar" && e.RowIndex >= 0)
            //if (((DataGridViewDisableButtonCell)grdArtigos.Rows[e.RowIndex].Cells["btnVisualizar"]).ColumnIndex == e.ColumnIndex && e.RowIndex >= 0)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);
                e.Graphics.DrawImage(Resources.resume, System.Convert.ToInt32((e.CellBounds.Width / (double)2) - (Resources.resume.Width / (double)2)) + e.CellBounds.X, System.Convert.ToInt32((e.CellBounds.Height / (double)2) - (Resources.resume.Height / (double)2)) + e.CellBounds.Y);
                e.Handled = true;
            }

            if (grdArtigos.Columns[e.ColumnIndex].Name == "btnEditar" && e.RowIndex >= 0)
            //if (((DataGridViewDisableButtonCell)grdArtigos.Rows[e.RowIndex].Cells["btnVisualizar"]).ColumnIndex == e.ColumnIndex && e.RowIndex >= 0)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);
                e.Graphics.DrawImage(Resources.add_1, System.Convert.ToInt32((e.CellBounds.Width / (double)2) - (Resources.add_1.Width / (double)2)) + e.CellBounds.X, System.Convert.ToInt32((e.CellBounds.Height / (double)2) - (Resources.add_1.Height / (double)2)) + e.CellBounds.Y);
                e.Handled = true;
            }

            if (grdArtigos.Columns[e.ColumnIndex].Name == "btnExcluir" && e.RowIndex >= 0)
            //if (((DataGridViewDisableButtonCell)grdArtigos.Rows[e.RowIndex].Cells["btnVisualizar"]).ColumnIndex == e.ColumnIndex && e.RowIndex >= 0)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);
                e.Graphics.DrawImage(Resources.minus, System.Convert.ToInt32((e.CellBounds.Width / (double)2) - (Resources.minus.Width / (double)2)) + e.CellBounds.X, System.Convert.ToInt32((e.CellBounds.Height / (double)2) - (Resources.minus.Height / (double)2)) + e.CellBounds.Y);
                e.Handled = true;
            }
            */
        }

        private void grdArtigos_Resize(object sender, EventArgs e)
        {
            //GridArtigosRedimensionar();
        }

        private void lklDesfazerExclusao_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            tokenSource.Cancel();
        }

        #endregion

        #region [ Métodos ]

        private void LstCategoriaPreencher()
        {
            SqlConnection cnn = new SqlConnection();
            string pstrMsg = "";
            bool pbooRetorno = false;
            string titCategoria = txtCategoria.Text;

            cnn = ConexaoBD.CriarConexao(out pstrMsg, out pbooRetorno);

            if (pbooRetorno)
            {
                string strSQL = @"
                SELECT * FROM 
                (
                SELECT 0 CATE_CODIGO, '(TODOS)' CATE_TITULO
                UNION ALL
                SELECT 
	                C.CATE_CODIGO, C.CATE_TITULO
                FROM TB_CATEGORIA C
                ) CatOrdenado 
                WHERE 1 = 1 ";


                if (!string.IsNullOrEmpty(titCategoria))
                {
                    strSQL += "AND CatOrdenado.CATE_TITULO LIKE '%" + titCategoria + "%' ";
                }

                strSQL += "ORDER BY CatOrdenado.CATE_TITULO ";

                SqlCommand sqlCmd = new SqlCommand(strSQL, cnn);

                SqlDataAdapter da = new SqlDataAdapter(sqlCmd);
                DataTable dt = new DataTable("TB_CATEGORIA");

                da.Fill(dt);

                lstCategorias.ValueMember = "CATE_CODIGO";
                lstCategorias.DisplayMember = "CATE_TITULO";
                lstCategorias.DataSource = dt;
            }
            else
            {
                MessageBox.Show(pstrMsg);

                if (!pbooRetorno)
                    Close();
            }

            //GridArtigosPreencher();

            cnn.Close();
        }

        private void GridArtigosPreencher()
        {
            grdArtigos.Columns.Clear();
            grdArtigos.DataSource = null;

            SqlConnection cnn = new SqlConnection();
            string pstrMsg = "";
            bool pbooRetorno = false;

            int idCategoria = lstCategorias.SelectedIndex;
            string titArtigo = txtArtigo.Text;

            cnn = ConexaoBD.CriarConexao(out pstrMsg, out pbooRetorno);

            if (pbooRetorno)
            {
                string strSQL = @"
                    SELECT 
                    A.ARTI_CODIGO, A.ARTI_NOME, A.ARTI_CATE_CODIGO, C.CATE_TITULO
                    FROM TB_ARTIGO A 
                    INNER JOIN TB_CATEGORIA C ON C.CATE_CODIGO = A.ARTI_CATE_CODIGO 
                    WHERE 1 = 1 ";

                if (idCategoria != 0)
                {
                    strSQL += "AND C.CATE_CODIGO = " + idCategoria + " ";
                }

                if (!string.IsNullOrEmpty(titArtigo))
                {
                    strSQL += "AND A.ARTI_NOME LIKE '%" + titArtigo + "%' ";
                }

                strSQL += "ORDER BY A.ARTI_NOME ";

                SqlCommand sqlCmd = new SqlCommand(strSQL, cnn);
                SqlDataAdapter sqlDataAdap = new SqlDataAdapter(sqlCmd);

                DataTable dtRecord = new DataTable();
                sqlDataAdap.Fill(dtRecord);

                grdArtigos.DataSource = dtRecord;
            }
            else
            {
                MessageBox.Show(pstrMsg);

                if (!pbooRetorno)
                    Close();
            }

            cnn.Close();

            GridArtigosFormatar();            
        }

        private void GridArtigosFormatar()
        {
            grdArtigos.Columns[0].HeaderText = "Código";
            grdArtigos.Columns[0].Visible = false;

            grdArtigos.Columns[1].HeaderText = "Título";

            grdArtigos.Columns[2].HeaderText = "Código Categoria";
            grdArtigos.Columns[2].Visible = false;

            grdArtigos.Columns[3].HeaderText = "Categoria";

            DataGridViewDisableButtonColumn btcVisualizar = new DataGridViewDisableButtonColumn();
            btcVisualizar.Name = "btnVisualizar";
            btcVisualizar.HeaderText = "Visualizar";
            btcVisualizar.UseColumnTextForButtonValue = true;
            btcVisualizar.Text = "Visualizar";

            DataGridViewDisableButtonColumn btcEditar = new DataGridViewDisableButtonColumn();
            btcEditar.Name = "btnEditar";
            btcEditar.HeaderText = "Editar";
            btcEditar.UseColumnTextForButtonValue = true;
            btcEditar.Text = "Editar";

            DataGridViewDisableButtonColumn btcExcluir = new DataGridViewDisableButtonColumn();
            btcExcluir.Name = "btnExcluir";
            btcExcluir.HeaderText = "Excluir";
            btcExcluir.UseColumnTextForButtonValue = true;
            btcExcluir.Text = "Excluir";

            grdArtigos.Columns.Add(btcVisualizar);
            grdArtigos.Columns.Add(btcEditar);
            grdArtigos.Columns.Add(btcExcluir);

            GridArtigosRedimensionar();
        }

        public void GridArtigosRedimensionar()
        {
            lblTitulo.Left = (this.Width - lblTitulo.Width) / 2;

            txtCategoria.Width = lstCategorias.Width - lblCategoria.Width - 2;
            txtArtigo.Width = grdArtigos.Width - lblArtigo.Width - 2;

            int intButtonWidth = 75;
            int intGridViewWidthWoutButton = grdArtigos.Width - (intButtonWidth * 3);
            
            if (grdArtigos.Columns.Count >= 7)
            {
                grdArtigos.Columns["ARTI_NOME"].Width = (int)(intGridViewWidthWoutButton * 0.74);
                grdArtigos.Columns["CATE_TITULO"].Width = (int)(intGridViewWidthWoutButton * 0.25);
                grdArtigos.Columns["btnVisualizar"].Width = intButtonWidth;
                grdArtigos.Columns["btnEditar"].Width = intButtonWidth;
                grdArtigos.Columns["btnExcluir"].Width = intButtonWidth;
            }

            sptArtigoListagem.Height = this.Height - 100;
            sptArtigoListagem.Width = this.Width - 45;

            pnlInfo.Left = grdArtigos.Width - pnlInfo.Width;
            pnlInfo.Top = grdArtigos.Height - 5;// - pnlInfo.Height;
            
        }

        async Task AcaoDelay()
        {
            try
            {
                await Task.Delay(msDelay, tokenSource.Token);
            }
            catch (TaskCanceledException tcex)
            {
                throw tcex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                tokenSource.Dispose();
                tokenSource = new CancellationTokenSource();
            }
        }

        private async Task ArtigoExcluirAsync(int codArtigo)
        {
            pnlInfo.Visible = true;
            ExcluirButtonEnable();

            try
            {
                await AcaoDelay();

                SqlConnection cnn = new SqlConnection();
                string pstrMsg = "";
                bool pbooRetorno = false;

                cnn = ConexaoBD.CriarConexao(out pstrMsg, out pbooRetorno);

                if (pbooRetorno)
                {
                    string strSQL = @"
                    DELETE FROM TB_ARTIGO
                    WHERE ARTI_CODIGO = " + codArtigo;

                    SqlCommand sqlCmd = new SqlCommand(strSQL, cnn);
                    sqlCmd.ExecuteNonQuery();

                    GridArtigosPreencher();
                }
            }
            catch (TaskCanceledException ex)
            {
                if (ex.CancellationToken.IsCancellationRequested)
                {
                    GridArtigosPreencher();
                }                
            } 
            finally
            {
                pnlInfo.Visible = false;
                ExcluirButtonEnable(true);
            }
        }

        private void ExcluirButtonEnable(bool blnEnable = false)
        {
            foreach (DataGridViewRow row in grdArtigos.Rows)
            {
                DataGridViewDisableButtonCell btn = (DataGridViewDisableButtonCell)row.Cells["btnExcluir"];
                btn.Enabled = blnEnable;
            }
        }

        #endregion
    }
}
