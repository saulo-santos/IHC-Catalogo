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
    public partial class ArtigoVisualizador : Form
    {
        public int ArtigoCodigo = 0;

        public ArtigoVisualizador(int pArtigoCodigo = 0)
        {
            this.ArtigoCodigo = pArtigoCodigo;
            InitializeComponent();
        }

        private void ArtigoVisualizador_Load(object sender, EventArgs e)
        {
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
                        lblTítulo.Text = sqlDataRead.GetValue(0).ToString();
                        lblCategoria.Text = sqlDataRead.GetValue(1).ToString();
                        lblDescricao.Text = sqlDataRead.GetValue(2).ToString();
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

            Redimencionador();
        }

        private void ArtigoVisualizador_Resize(object sender, EventArgs e)
        {
            Redimencionador();
        }

        private void Redimencionador()
        {
            lblTítulo.Left = 12;
            lblTítulo.Width = this.Width - 42;

            lblCategoria.Left = this.Width - lblCategoria.Width - 30;

            lblDescricao.Left = 12;
            lblDescricao.Width = this.Width - 42;
        }
    }
}
