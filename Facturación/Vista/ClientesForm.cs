using Datos;
using Entidades;
using System;
using System.Data;
using System.Windows.Forms;

namespace Vista
{
    public partial class ClientesForm : Syncfusion.Windows.Forms.Office2010Form
    {
        public ClientesForm()
        {
            InitializeComponent();
        }

        //Variable Global
        string tipoOperacion;

        DataTable dt = new DataTable();
        ClienteDB ClienteDB = new ClienteDB();
        Cliente cliente = new Cliente();

        private void HabilitarControles()
        {
            IdentidadTextBox.Enabled = true;
            NombreTextBox.Enabled = true;
            TelefonoTextBox.Enabled = true;
            CorreoTextBox.Enabled = true;
            DireccionTextBox.Enabled = true;
            FechaNacimientoDateTimePicker.Enabled = true;
            EstaActivoCheckBox.Enabled = true;
            GuardarButton.Enabled = true;
            CancelarButton.Enabled = true;
            ModificarButton.Enabled = false;
        }

        private void DesabilitarControles()
        {
            IdentidadTextBox.Enabled = false;
            NombreTextBox.Enabled = false;
            TelefonoTextBox.Enabled = false;
            CorreoTextBox.Enabled = false;
            DireccionTextBox.Enabled = false;
            FechaNacimientoDateTimePicker.Enabled = false;
            EstaActivoCheckBox.Enabled = false;
            GuardarButton.Enabled = false;
            CancelarButton.Enabled = false;
            ModificarButton.Enabled = true;
        }

        private void LimpiarControles()
        {
            IdentidadTextBox.Clear();
            NombreTextBox.Clear();
            TelefonoTextBox.Clear();
            CorreoTextBox.Clear();
            DireccionTextBox.Clear();
            EstaActivoCheckBox.Checked = false;
        }

        private void NuevoButton_Click(object sender, EventArgs e)
        {
            IdentidadTextBox.Focus();
            HabilitarControles();
            tipoOperacion = "Nuevo";
        }

        private void CancelarButton_Click(object sender, EventArgs e)
        {
            DesabilitarControles();
            LimpiarControles();
        }

        private void GuardarButton_Click(object sender, EventArgs e)
        {
            if (tipoOperacion == "Nuevo")
            {
                if (string.IsNullOrEmpty(IdentidadTextBox.Text))
                {
                    errorProvider1.SetError(IdentidadTextBox, "Ingrese identidad");
                    IdentidadTextBox.Focus();
                    return;
                }
                errorProvider1.Clear();
                if (string.IsNullOrEmpty(NombreTextBox.Text))
                {
                    errorProvider1.SetError(NombreTextBox, "Ingrese un nombre");
                    NombreTextBox.Focus();
                    return;
                }
                errorProvider1.Clear();
                if (string.IsNullOrEmpty(TelefonoTextBox.Text))
                {
                    errorProvider1.SetError(TelefonoTextBox, "Ingrese un número de teléfono");
                    TelefonoTextBox.Focus();
                    return;
                }
                errorProvider1.Clear();
                if (string.IsNullOrEmpty(CorreoTextBox.Text))
                {
                    errorProvider1.SetError(CorreoTextBox, "Ingrese un correo");
                    CorreoTextBox.Focus();
                    return;
                }
                errorProvider1.Clear();
                if (string.IsNullOrEmpty(DireccionTextBox.Text))
                {
                    errorProvider1.SetError(DireccionTextBox, "Ingrese una dirección");
                    DireccionTextBox.Focus();
                    return;
                }
                errorProvider1.Clear();

                cliente.Identidad = IdentidadTextBox.Text;
                cliente.Nombre = NombreTextBox.Text;
                cliente.Telefono = TelefonoTextBox.Text;
                cliente.Correo = CorreoTextBox.Text;
                cliente.Direccion = DireccionTextBox.Text;
                cliente.FechaNacimiento = FechaNacimientoDateTimePicker.Value;
                cliente.EstaActivo = EstaActivoCheckBox.Checked;

                //Insertar en la base de datos
                bool inserto = ClienteDB.Insertar(cliente);
                if (inserto)
                {
                    DesabilitarControles();
                    LimpiarControles();
                    TraerClientes();
                    MessageBox.Show("Registro Guardado");
                }
                else
                {
                    MessageBox.Show("No se pudo guardar el registro");
                }

            }
            else if (tipoOperacion == "Modificar")
            {
                cliente.Identidad = IdentidadTextBox.Text;
                cliente.Nombre = NombreTextBox.Text;
                cliente.Telefono = TelefonoTextBox.Text;
                cliente.Correo = CorreoTextBox.Text;
                cliente.Direccion = DireccionTextBox.Text;
                cliente.FechaNacimiento = FechaNacimientoDateTimePicker.Value;
                cliente.EstaActivo = EstaActivoCheckBox.Checked;

                bool modifico = ClienteDB.Editar(cliente);
                if (modifico)
                {
                    LimpiarControles();
                    DesabilitarControles();
                    TraerClientes();
                    MessageBox.Show("Registro actualizado correctamente");
                }
                else
                {
                    MessageBox.Show("No se pudo actualizar el registro");
                }
            }
        }

        //Modificar registros
        private void ModificarButton_Click(object sender, EventArgs e)
        {
            tipoOperacion = "Modificar";
            if (ClientesDataGridView.SelectedRows.Count > 0)
            {
                IdentidadTextBox.Text = ClientesDataGridView.CurrentRow.Cells["Identidad"].Value.ToString();
                NombreTextBox.Text = ClientesDataGridView.CurrentRow.Cells["Nombre"].Value.ToString();
                TelefonoTextBox.Text = ClientesDataGridView.CurrentRow.Cells["Telefono"].Value.ToString();
                CorreoTextBox.Text = ClientesDataGridView.CurrentRow.Cells["Correo"].Value.ToString();
                DireccionTextBox.Text = ClientesDataGridView.CurrentRow.Cells["Direccion"].Value.ToString();
                FechaNacimientoDateTimePicker.Value = Convert.ToDateTime(ClientesDataGridView.CurrentRow.Cells["FechaNacimiento"].Value);
                EstaActivoCheckBox.Checked = Convert.ToBoolean(ClientesDataGridView.CurrentRow.Cells["EstaActivo"].Value);

                HabilitarControles();
            }
            else
            {
                MessageBox.Show("Debe seleccionar un registro");

            }

        }

        private void ClientesForm_Load(object sender, EventArgs e)
        {
            TraerClientes();
        }

        private void TraerClientes()
        {
            dt = ClienteDB.DevolverClientes();

            ClientesDataGridView.DataSource = dt;
        }

        //Eliminar registros
        private void EliminarButton_Click(object sender, EventArgs e)
        {
            if (ClientesDataGridView.SelectedRows.Count > 0)
            {
                //Validar si desea elminar el registro
                DialogResult resultado = MessageBox.Show("¿Está seguro de elminar el registro?", "Advertencia", MessageBoxButtons.YesNo);

                if (resultado == DialogResult.Yes)
                {
                    bool elimino = ClienteDB.Eliminar(ClientesDataGridView.CurrentRow.Cells["Identidad"].Value.ToString());

                    if (elimino)
                    {
                        LimpiarControles();
                        DesabilitarControles();
                        TraerClientes();
                        MessageBox.Show("Registro eliminado");
                    }
                    else
                    {
                        MessageBox.Show("No se pudo eliminar el registro");
                    }
                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar un registro");

            }

        }
    }
}
