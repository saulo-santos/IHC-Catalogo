using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Catalogo
{
    public partial class UsrCtrlInfo : UserControl
    {
        public UsrCtrlInfo(string pInfoText, string pAcaoText)
        {
            lblInfo.Text = pInfoText;
            lklAcao.Text = pAcaoText;

            InitializeComponent();
        }

        private void UsrCtrlInfo_Load(object sender, EventArgs e)
        {

        }
    }
}
