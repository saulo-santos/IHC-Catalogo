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
            PreencherArtigos();
        }

        private void PreencherArtigos()
        {
            SqlConnection cnn = new SqlConnection();
            string pstrMsg = "";
            bool pbooRetorno = false;

            cnn = ConexaoBD.CriarConexao(out pstrMsg, out pbooRetorno);

            if (pbooRetorno)
            {
                string strSQL = "SELECT * FROM TB_ARTIGO";

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

    }
}
