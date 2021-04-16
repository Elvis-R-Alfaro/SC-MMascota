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
    /// <summary>
    /// Interaction logic for FormCliente.xaml
    /// </summary>


    public partial class FormCliente : Window
    {
        private ClientesCS cliente = new ClientesCS();
        public static int ides;
        public FormCliente(bool visible)
        {
            InitializeComponent();
            MonstrarBotones(visible);

            if (ides != 0)
            {
               //categoria = categoria.BuscarCategoria(ides);
              //  txtCategoria.Text = categoria.NombreCategoria;
            }

        }

        private void MonstrarBotones(bool visibles)
        {
            //if (visibles)
            //{
            //    spNuevaCategoria.Visibility = Visibility.Hidden;
            //    spButton1.Visibility = Visibility.Hidden;
            //    spEditarCategoria.Visibility = Visibility.Visible;
            //    spButton2.Visibility = Visibility.Visible;
            //}
            //else
            //{
            //    spNuevaCategoria.Visibility = Visibility.Visible;
            //    spButton1.Visibility = Visibility.Visible;
            //    spEditarCategoria.Visibility = Visibility.Hidden;
            //    spButton2.Visibility = Visibility.Hidden;
            //}
        }
        private bool VerificarValores()
        {
            if(txtNombre.Text == string.Empty)
            {
                MessageBox.Show("!Ingrese el Nombre de la Categoría¡");
                return false;
            }
            else if (txtApellidos.Text == string.Empty)
            {
                MessageBox.Show("Ingrese apellido");
                return false;
            }
            else if (txtTelefono.Text == string.Empty)
            {
                MessageBox.Show("ingrese un numero de telefono");
                return false;
            }
            return true;
        }
        private void ObtenerValoresFormulario()
        {
            cliente.NombreCliente = txtNombre.Text;
            cliente.Id = Convert.ToInt32(ides);
            cliente.NumeroTelefono = txtTelefono.Text;
        }


        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            if (VerificarValores())
            {
                try
                {
                    //Obtener los valores para la habitacion
                    cliente.NombreCliente = txtNombre.Text;
                    cliente.Id = Convert.ToInt32(ides);
                    cliente.NumeroTelefono = txtTelefono.Text;


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
                    txtNombre.Text = string.Empty;
                    txtApellidos.Text = string.Empty;
                    txtTelefono.Text = string.Empty;
                }
            }
        }

        private void btnRestablecer_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
