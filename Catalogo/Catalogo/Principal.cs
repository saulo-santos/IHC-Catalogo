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
    public partial class Principal : Form
    {
        public Principal()
        {
            InitializeComponent();
        }

        private void Principal_Load(object sender, EventArgs e)
        {
            PreencherGridArtigos();
        }

        private void PreencherGridArtigos()
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
                    INNER JOIN TB_CATEGORIA C ON C.CATE_CODIGO = A.ARTI_CATE_CODIGO";

                SqlCommand sqlCmd = new SqlCommand(strSQL, cnn);
                SqlDataAdapter sqlDataAdap = new SqlDataAdapter(sqlCmd);

                DataTable dtRecord = new DataTable();
                sqlDataAdap.Fill(dtRecord);
                grdArtigos.DataSource = dtRecord;

                FormatarGridArtigos();
            }
            else
            {
                MessageBox.Show(pstrMsg);

                if (!pbooRetorno)
                    Close();
            }
        }

        private void FormatarGridArtigos()
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

            int columnIndex = 4;
            grdArtigos.Columns.Add(btcEditar);
            grdArtigos.Columns.Add(btcExcluir);

            //if (grdArtigos.Columns["btnEditar"] == null)
            //{
            //    grdArtigos.Columns.Insert(columnIndex, btcEditar);
            //}
        }
        private void grdArtigos_Resize(object sender, EventArgs e)
        {
            grdArtigos.Columns[1].Width = (int)(grdArtigos.Width * 0.70);
            grdArtigos.Columns[3].Width = (int)(grdArtigos.Width * 0.20);
        }
    }
}
