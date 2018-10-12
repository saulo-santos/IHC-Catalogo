using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Catalogo
{
    public partial class Principal : Form
    {
        public Principal()
        {
            InitializeComponent();
        }

        private void Principal_Load(object sender, EventArgs e)
        {
            LstCategoriaPreencher();
            GridArtigosPreencher();
            GridArtigosFormatar();
            GridArtigosRedimensionar();
        }

        private void LstCategoriaPreencher()
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
                    SELECT 0 CATE_CODIGO, '(TODOS)' CATE_TITULO
                    UNION ALL
                    SELECT 
	                    C.CATE_CODIGO, C.CATE_TITULO
                    FROM TB_CATEGORIA C
                    ) CatOrdenado
                    ORDER BY CatOrdenado.CATE_TITULO";

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

            cnn.Close();
        }

        private void grdArtigos_Resize(object sender, EventArgs e)
        {
            GridArtigosRedimensionar();
        }

        private void GridArtigosPreencher(int idCategoria = 0)
        {
            SqlConnection cnn = new SqlConnection();
            string pstrMsg = "";
            bool pbooRetorno = false;

            cnn = ConexaoBD.CriarConexao(out pstrMsg, out pbooRetorno);

            if (pbooRetorno)
            {
                string strSQL = @"
                    SELECT 
                    A.ARTI_CODIGO, A.ARTI_NOME, A.ARTI_CATE_CODIGO, C.CATE_TITULO
                    FROM TB_ARTIGO A 
                    INNER JOIN TB_CATEGORIA C ON C.CATE_CODIGO = A.ARTI_CATE_CODIGO ";

                if (idCategoria != 0)
                {
                    strSQL += "WHERE C.CATE_CODIGO = " + idCategoria + " ";
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
        }

        private void GridArtigosFormatar()
        {
            grdArtigos.Columns[0].HeaderText = "Código";
            grdArtigos.Columns[0].Visible = false;

            grdArtigos.Columns[1].HeaderText = "Título";

            grdArtigos.Columns[2].HeaderText = "Código Categoria";
            grdArtigos.Columns[2].Visible = false;

            grdArtigos.Columns[3].HeaderText = "Categoria";

            DataGridViewButtonColumn btcEditar = new DataGridViewButtonColumn();
            btcEditar.Name = "btnEditar";
            btcEditar.HeaderText = "Editar";
            btcEditar.UseColumnTextForButtonValue = true;
            btcEditar.Text = "Editar";

            DataGridViewButtonColumn btcExcluir = new DataGridViewButtonColumn();
            btcExcluir.Name = "btcExcluir";
            btcExcluir.HeaderText = "Excluir";
            btcExcluir.UseColumnTextForButtonValue = true;
            btcExcluir.Text = "Excluir";

            grdArtigos.Columns.Add(btcEditar);
            grdArtigos.Columns.Add(btcExcluir);
        }

        private void GridArtigosRedimensionar()
        {
            int intButtonWidth = 50;
            int intGridViewWidthWoutButton = grdArtigos.Width - (intButtonWidth * 2);

            grdArtigos.Columns[1].Width = (int)(intGridViewWidthWoutButton * 0.74);
            grdArtigos.Columns[3].Width = (int)(intGridViewWidthWoutButton * 0.25);
            grdArtigos.Columns[4].Width = intButtonWidth;
            grdArtigos.Columns[5].Width = intButtonWidth;
        }

        private void lstCategorias_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridArtigosPreencher(lstCategorias.SelectedIndex);
        }
    }
}
