using DataGridViewButton;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Catalogo
{
    public partial class Principal : Form
    {
        int msDelay = 3000;
        CancellationTokenSource tokenSource = new CancellationTokenSource();

        public Principal()
        {
            InitializeComponent();
        }

        private void Principal_Load(object sender, EventArgs e)
        {
            LstCategoriaPreencher();
            GridArtigosPreencher();
        }

        private void Principal_Resize(object sender, EventArgs e)
        {
            lblTitulo.Left = (this.Width - lblTitulo.Width) / 2;

            txtCategoria.Width = lstCategorias.Width - lblCategoria.Width - 2;
            txtArtigo.Width = grdArtigos.Width - lblArtigo.Width - 2;

            GridArtigosRedimensionar();
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

            int artigoCodigo = int.Parse(grdArtigos.Rows[rowSel].Cells[0].Value.ToString());

            var cellEnabled = ((DataGridViewDisableButtonCell)grdArtigos.Rows[rowSel].Cells[5]).Enabled;

            if (e.ColumnIndex == 4)
            {
                ArtigoVisualizador artigoVisualizador = new ArtigoVisualizador(artigoCodigo);
                artigoVisualizador.Show();
            }

            if (e.ColumnIndex == 5 && cellEnabled)
            {
                grdArtigos.Rows.RemoveAt(rowSel);
                await ArtigoExcluirAsync(artigoCodigo);
            }
        }

        private void grdArtigos_Resize(object sender, EventArgs e)
        {
            //GridArtigosRedimensionar();
        }

        private void lklDesfazerExclusao_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            tokenSource.Cancel();
        }

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

            grdArtigos.Columns.Add(btcEditar);
            grdArtigos.Columns.Add(btcExcluir);

            GridArtigosRedimensionar();
        }

        private void GridArtigosRedimensionar()
        {
            int intButtonWidth = 50;
            int intGridViewWidthWoutButton = grdArtigos.Width - (intButtonWidth * 2);

            grdArtigos.Columns[1].Width = (int)(intGridViewWidthWoutButton * 0.74);
            grdArtigos.Columns[3].Width = (int)(intGridViewWidthWoutButton * 0.25);
            grdArtigos.Columns[4].Width = intButtonWidth;
            grdArtigos.Columns[5].Width = intButtonWidth;

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
                DataGridViewDisableButtonCell btn = (DataGridViewDisableButtonCell)row.Cells[5];
                btn.Enabled = blnEnable;
            }
        }
    }
}
