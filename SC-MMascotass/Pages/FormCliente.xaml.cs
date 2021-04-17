using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SC_MMascotass.Pages
{
    public partial class FormCliente : Window
    {
        private Cliente cliente = new Cliente();
        public static int ides;
        public FormCliente(bool visible)
        {
            InitializeComponent();
            MonstrarBotones(visible);

            if (ides != 0)
            {              
                cliente = cliente.BuscarCliente(ides);
                txtNombre.Text = cliente.NombreCliente;
                txtTelefono.Text = cliente.Telefono;
                //txtCategoria.Text = categoria.NombreCategoria;
            }
        }

        private bool VerificarValores()
        {
            if (txtNombre.Text == string.Empty)
            {
                MessageBox.Show("!Ingrese el Nombre del Usuario¡");
                return false;
            }
            if (txtApellidos.Text == string.Empty)
            {
                MessageBox.Show("!Ingrese el Apellido del Usuario¡");
                return false;
            }
            if (txtTelefono.Text == string.Empty)
            {
                MessageBox.Show("!Ingrese el Telefono¡");
                return false;
            }
            return true;
        }

        private void ObtenerValoresFormulario()
        {
            cliente.NombreCliente = txtNombre.Text + ' ' + txtApellidos.Text;
            cliente.Telefono = txtTelefono.Text;
            cliente.IdCliente = Convert.ToInt32(ides);         
        }

        private void MonstrarBotones(bool visibles)
        {
            if (visibles)
            {
                spNuevaCategoria.Visibility = Visibility.Hidden;
                spButton1.Visibility = Visibility.Hidden;
                spEditarCategoria.Visibility = Visibility.Visible;
                spButton2.Visibility = Visibility.Visible;
            }
            else
            {
                spNuevaCategoria.Visibility = Visibility.Visible;
                spButton1.Visibility = Visibility.Visible;
                spEditarCategoria.Visibility = Visibility.Hidden;
                spButton2.Visibility = Visibility.Hidden;
            }
        }

        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            if (VerificarValores())
            {
                try
                {
                    //Obtener los valores para la habitacion
                    ObtenerValoresFormulario();

                    //Insertar los datos de la habitacion
                    cliente.CrearCliente(cliente);

                    //Mensaje de inserccion exito
                    MessageBox.Show("Datos insertados correctamente");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ha ocurrido un error al momento de insertar la habitacion....");
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    Limpiar();
                }
            }
        }

        private void Limpiar()
        {
            txtApellidos.Text = string.Empty;
            txtNombre.Text = string.Empty;
            txtTelefono.Text = string.Empty;
        }

        private void btnRestablecer_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnAceptar_Click(object sender, RoutedEventArgs e)
        {
            if (VerificarValores())
            {
                try
                {
                    //Obtener los valores para la habitacion desde el formulario
                    ObtenerValoresFormulario();

                    //Actualizar los valores en la base de datos
                    cliente.EditarCliente(cliente);

                    //Actualizar el lisbox de habitaciones

                    //Mensaje de actualizacion realizada
                    MessageBox.Show("Cliente modificada correctamente");

                    //Limpiar formulario
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al momento de actualizar la habitacion....");
                    Console.WriteLine(ex.Message);
                }
            }
        }

        private void btnRegresar_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
