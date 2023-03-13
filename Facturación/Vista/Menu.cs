using System;
using System.Windows.Forms;

namespace Vista
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        //Usuarios
        private void UsuariosToolStripButton1_Click(object sender, EventArgs e)
        {
            //Mostrar el formulario Usuario
            //Instanciar
            UsuariosForm userForm = new UsuariosForm();
            //Para que muestre ahi mismo en el menú los formularios y no en otras ventanas
            userForm.MdiParent = this;
            userForm.Show();
        }

        //Productos
        private void ProductosToolStripButton_Click(object sender, EventArgs e)
        {
            ProductosForm productosForm = new ProductosForm();
            productosForm.MdiParent = this;
            productosForm.Show();
        }

        private void ClientesToolStripButton1_Click(object sender, EventArgs e)
        {
            ClientesForm clientesForm = new ClientesForm();
            clientesForm.MdiParent = this;
            clientesForm.Show();
        }
    }
}
