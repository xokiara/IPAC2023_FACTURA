using Datos;
using Entidades;
using System;
using System.Windows.Forms;

namespace Vista
{
    public partial class LoginForm : Form
    {
        public LoginForm()
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
            Login login = new Login(UsuarioTextBox.Text, ContraseñaTextBox.Text);
            Usuario usuario = new Usuario();
            UsuarioDB usuarioDB = new UsuarioDB();

            usuario = usuarioDB.Autenticar(login);

            if (usuario != null)
            {
                if (usuario.EstaActivo)
                {
                    //Mostrar el Menú
                    //Instnacia del objeto
                    Menu menuFormulario = new Menu();
                    //Para que ya no se mire el login despues de mostrar el menú
                    this.Hide();
                    //Mostrar
                    menuFormulario.Show();
                }
                else
                {
                    MessageBox.Show("El usuario no esta activo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }


            }
            else
            {
                MessageBox.Show("Datos de usuario incorrectos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }




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
