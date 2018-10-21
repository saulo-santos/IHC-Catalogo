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

        private void Principal_Load(object sender, EventArgs e)
        {
            artigoListagem();
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

        private void mnuCadastrarCategoria_Click(object sender, EventArgs e)
        {
            categoriaCadastro();
        }

        private void mnuCadastrarArtigo_Click(object sender, EventArgs e)
        {
            artigoCadastro();
        }

        private void mnuListaArtigo_Click(object sender, EventArgs e)
        {
            artigoListagem();
        }

        private void categoriaCadastro()
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form.GetType() == typeof(CategoriaCadastro))
                {
                    form.WindowState = FormWindowState.Maximized;
                    return;
                }
            }

            CategoriaCadastro categoriaCadastro = new CategoriaCadastro();
            categoriaCadastro.MdiParent = this;
            categoriaCadastro.WindowState = FormWindowState.Maximized;
            categoriaCadastro.Show();
        }

        public void artigoCadastro(int ArtigoCodigo = 0)
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form.GetType() == typeof(ArtigoCadastro))
                {
                    form.WindowState = FormWindowState.Maximized;
                    return;
                }
            }

            ArtigoCadastro artigoCadastro = new ArtigoCadastro(ArtigoCodigo);
            artigoCadastro.MdiParent = this;
            artigoCadastro.WindowState = FormWindowState.Maximized;
            artigoCadastro.Show();
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

        public void artigoVisualizador(int ArtigoCodigo = 0)
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

            ArtigoVisualizador artigoVisualizador = new ArtigoVisualizador(ArtigoCodigo);
            artigoVisualizador.MdiParent = this;
            artigoVisualizador.WindowState = FormWindowState.Maximized;
            artigoVisualizador.Height = this.Height - 20;
            artigoVisualizador.Width = this.Width;
            artigoVisualizador.Show();
        }
    }
}
