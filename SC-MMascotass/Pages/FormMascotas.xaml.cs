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
    /// Interaction logic for FormMascotas.xaml
    /// </summary>
    public partial class FormMascotas : Window
    {
        private Mascota mascota = new Mascota();
        public static int ides;
        public FormMascotas(bool visible)
        {
            InitializeComponent();

            var border = (resultStack.Parent as ScrollViewer).Parent as Border;
            border.Visibility = System.Windows.Visibility.Collapsed;

            if (ides != 0)
            {
                //mascota = mascota.BuscarMascota(ides);
                //txtAuCliente.Text = mascota.IdCliente;
            }
        }


        //Autocompletar TextBox
        private void txtAuCliente_KeyUp(object sender, KeyEventArgs e)
        {
            bool found = false;
            var border = (resultStack.Parent as ScrollViewer).Parent as Border;
            var data = Mascota.MonstrarMascotas22();
          

            string query = (sender as TextBox).Text;

            if (query.Length == 0)
            {
                // Clear   
                resultStack.Children.Clear();
                border.Visibility = System.Windows.Visibility.Collapsed;
            }
            else
            {
                border.Visibility = System.Windows.Visibility.Visible;
            }

            // Clear the list   
            resultStack.Children.Clear();

            // Add the result   
            foreach (var obj in data)
            {
                if (obj.ToLower().StartsWith(query.ToLower()))
                {
                    // The word starts with this... Autocomplete must work   
                    addItem(obj);
                    found = true;
                }
            }

            if (!found)
            {
                resultStack.Children.Add(new TextBlock() { Text = "No se ha encontrado" });
            }
        }

        private void addItem(string text)
        {
            TextBlock block = new TextBlock();

            // Add the text   
            block.Text = text;

            // A little style...   
            block.Margin = new Thickness(2, 3, 2, 3);
            block.Cursor = Cursors.Hand;

            // Mouse events   
            block.MouseLeftButtonUp += (sender, e) =>
            {
                var border = (resultStack.Parent as ScrollViewer).Parent as Border;
                txtAuCliente.Text = (sender as TextBlock).Text;
                border.Visibility = System.Windows.Visibility.Collapsed;
                ObtenerValoresFormulario();
            };

            block.MouseEnter += (sender, e) =>
            {
                TextBlock b = sender as TextBlock;
                b.Background = Brushes.PeachPuff;
            };

            block.MouseLeave += (sender, e) =>
            {
                TextBlock b = sender as TextBlock;
                b.Background = Brushes.Transparent;
            };

            // Add to the panel   
            resultStack.Children.Add(block);
        }

        private void btnNuevoCliente_Click(object sender, RoutedEventArgs e)
        {
            // Mostrar el formulario de menú principal
            FormCliente cliente = new FormCliente();
            cliente.Show();
        }

        private bool VerificarValores()
        {
            if (txtAuCliente.Text == string.Empty)
            {
                MessageBox.Show("!Ingrese el Nombre del Cliente¡");
                return false;
            }
            else if (txtAliasMascota.Text == string.Empty)
            {
                MessageBox.Show("!Ingrese el Nombre de la Mascota¡");
                return false;
            }
            else if (txtColorPelo.Text == string.Empty)
            {
                MessageBox.Show("!Ingrese el Color de Pelo de la mascota¡");
                return false;
            }
            else if (txtEspecie.Text == string.Empty)
            {
                MessageBox.Show("!Ingrese la especie de la Mascota¡");
                return false;
            }
            else if (txtRaza.Text == string.Empty)
            {
                MessageBox.Show("!Ingrese la raza de la Mascota¡");
                return false;
            }
            return true;
        }

        private void ObtenerValoresFormulario()
        {
            //categoria.NombreCategoria = txtCategoria.Text;
            mascota = mascota.ObtenerID(txtAuCliente.Text);
            MessageBox.Show(mascota);
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
                    //categoria.CrearCategoria(categoria);

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
                    //txtCategoria.Text = string.Empty;
                }
            }
        }
    }
}
