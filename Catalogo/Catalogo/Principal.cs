using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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

        private void Principal_Resize(object sender, EventArgs e)
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form.GetType() == typeof(ArtigoListagem))
                {
                    ((ArtigoListagem)form).GridArtigosRedimensionar();
                    return;
                }
            }
        }

        private void artigosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            artigoListagem();
        }

        private void artigoListagem()
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form.GetType() == typeof(ArtigoListagem))
                {
                    //form.Activate();
                    //form.BringToFront();
                    form.WindowState = FormWindowState.Maximized;
                    return;
                }
            }

            ArtigoListagem artigoListagem = new ArtigoListagem();
            artigoListagem.MdiParent = this;
            artigoListagem.WindowState = FormWindowState.Maximized;
            artigoListagem.Height = this.Height - 20;
            artigoListagem.Width = this.Width;
            artigoListagem.Show();
        }

        public void artigoVisualizador(int ArtigoCodigo)
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form.GetType() == typeof(ArtigoVisualizador))
                {
                    //form.Activate();
                    //form.BringToFront();
                    form.WindowState = FormWindowState.Maximized;
                    return;
                }
            }

            ArtigoVisualizador artigoListagem = new ArtigoVisualizador(ArtigoCodigo);
            artigoListagem.MdiParent = this;
            artigoListagem.WindowState = FormWindowState.Maximized;
            artigoListagem.Show();
        }
    }
}
