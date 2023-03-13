using System;
using System.Windows.Forms;

namespace Vista
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void CancelarButton_Click(object sender, EventArgs e)
        {
            //Cerrar programa al presionar cancelar
            Close();
        }

        private void AceptarButton_Click(object sender, EventArgs e)
        {
            //Validar que el usuario ingresó los respectivos datos
            if (UsuarioTextBox.Text == string.Empty)
            {
                errorProvider1.SetError(UsuarioTextBox, "Ingrese un usuario");
                //Devuelve a la casilla que está el error
                UsuarioTextBox.Focus();
                return;
            }

            //limpiar
            errorProvider1.Clear();

            //Otra forma de validar si está vacio y si es nulo
            if (string.IsNullOrEmpty(ContraseñaTextBox.Text))
            {
                errorProvider1.SetError(ContraseñaTextBox, "Ingrese una contraseña");
                ContraseñaTextBox.Focus();
                return;

            }

            //limpiar
            errorProvider1.Clear();

            //Validar en la base de datos

            //Mostrar el Menú
            //Instnacia del objeto
            Menu menuFormulario = new Menu();
            //Para que ya no se mire el login despues de mostrar el menú
            this.Hide();
            //Mostrar
            menuFormulario.Show();
        }

        //Botón mostrar contraseña
        private void MostrarContraseñaButton_Click(object sender, EventArgs e)
        {
            if (ContraseñaTextBox.PasswordChar == '*')
            {
                ContraseñaTextBox.PasswordChar = '\0';
            }
            else
            {
                ContraseñaTextBox.PasswordChar = '*';
            }

        }
    }
}
