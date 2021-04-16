using System;
using System.Collections.Generic;
using System.Linq;
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
    /// Interaction logic for FormCategorias.xaml
    /// </summary>
    public partial class FormCategorias : Window
    {
        private Categoria categoria = new Categoria();
        public static int ides;
        public FormCategorias(bool visible)
        {
            InitializeComponent();
            MonstrarBotones(visible);

            if (ides != 0)
            {
                categoria = categoria.BuscarCategoria(ides);
                txtCategoria.Text = categoria.NombreCategoria;
            }
               
        }

        private bool VerificarValores()
        {
            if (txtCategoria.Text == string.Empty)
            {
                MessageBox.Show("!Ingrese el Nombre de la Categoría¡");
                return false;
            }
            return true;
        }

        private void ObtenerValoresFormulario()
        {
            categoria.NombreCategoria = txtCategoria.Text;
            categoria.Id = Convert.ToInt32(ides);
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
                    categoria.NombreCategoria = txtCategoria.Text;

                    //Insertar los datos de la habitacion
                    categoria.CrearCategoria(categoria);

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
                    txtCategoria.Text=string.Empty;
                }
            }
        }

        private void btnRestablecer_Click(object sender, RoutedEventArgs e)
        {
            txtCategoria.Text = string.Empty;
        }

        private void bntAceptar_Click(object sender, RoutedEventArgs e)
        {
            if (VerificarValores())
            {
                try
                {
                    //Obtener los valores para la habitacion desde el formulario
                    ObtenerValoresFormulario();

                    //Actualizar los valores en la base de datos
                    categoria.EditarCategoria(categoria);

                    //Actualizar el lisbox de habitaciones

                    //Mensaje de actualizacion realizada
                    MessageBox.Show("Habitacion modificada correctamente");

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

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
