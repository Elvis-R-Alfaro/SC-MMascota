using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SC_MMascotass.Pages
{
    /// <summary>
    /// Interaction logic for Vacunas.xaml
    /// </summary>
    public partial class Vacunas : UserControl
    {
        private HistorialVacunacion vacuna = new HistorialVacunacion();
        private Mascota mascota = new Mascota();
        private List<Mascota> mascotas;
        private List<HistorialVacunacion> vacunas;

        private static string connectionString = ConfigurationManager.ConnectionStrings["SC_MMascotass.Properties.Settings.MascotasConnectionString"].ConnectionString;
        private SqlConnection sqlConnection = new SqlConnection(connectionString);

        private vacunaciones Vacunaciones = new vacunaciones();
        private List<vacunaciones> vacunaciones;
        public Vacunas()
        {
            InitializeComponent();

            //Oculta el auto completar al iniiar el fomrulario

            var border = (autoCompleteCategorias.Parent as ScrollViewer).Parent as Border;
            border.Visibility = System.Windows.Visibility.Collapsed;

            //Cargar el combobox
            CargarVacunasCombo();
        }

        private void btnNuevoCliente_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtAuCliente.Text))
            {
                MessageBox.Show("Ingrese una mascota a buscar");
            }
            else
            {
                vacunas = vacuna.MonstrarRegistro(txtAuCliente.Text);
                dgVacunas.SelectedValuePath = "Mascota";
                dgVacunas.ItemsSource = vacunas;
            }
        }

        private void CargarVacunasCombo()
        {
            
            try
            {
                string query = "SELECT * FROM Veterinaria.Inventario INNER JOIN Veterinaria.Categoria ON Veterinaria.Categoria.IdCategoria = Veterinaria.Inventario.IdCategoria WHERE Veterinaria.Categoria.NombreCategoria = 'Vacunas'";

                sqlConnection.Open();

                //Crear el comando sql
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);

                SqlDataReader dr = sqlCommand.ExecuteReader();
                while (dr.Read())
                {
                    cmbVacuna.Items.Add(dr["NombreProducto"].ToString());
                    cmbVacuna.SelectedValuePath = dr["IdProducto"].ToString();
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                //Cerrar la conexion
                sqlConnection.Close();
            }

        }


        private bool VerificarValores()
        {
            if (string.IsNullOrWhiteSpace(txtAuCliente.Text))
            {
                MessageBox.Show("¡Ingrese el Nombre de la Mascota!");
                return false;
            }
            if (cmbVacuna.SelectedIndex.Equals(-1))
            {
                MessageBox.Show("Por favor seleccione una vacuna");
                return false;
            }

            return true;
        }

        private void btnAgregarVacuna_Click(object sender, RoutedEventArgs e)
        {
            if (VerificarValores())
            {


                try
                {
                    //Obtener los valores para la vacuna
                    mascota = mascota.BuscarMascotaNombre(txtAuCliente.Text);

                    Vacunaciones.IdMascota = mascota.IdMascota;
                    Vacunaciones.IdProducto = Convert.ToInt32(cmbVacuna.SelectedValuePath);
                    Vacunaciones.Fecha = DateTime.Now;

                    //Insertar los datos de la vacuna
                    Vacunaciones.CrearVacuna(Vacunaciones);

                    //Mensaje de inserccion exito
                    MessageBox.Show("Datos Insertados Correctamente", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ha ocurrido un error al momento de insertar la Vacuna....");
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    vacunas = vacuna.MonstrarRegistro(txtAuCliente.Text);
                    dgVacunas.SelectedValuePath = "Mascota";
                    dgVacunas.ItemsSource = vacunas;
                    cmbVacuna.Text = string.Empty;
                    txtAuCliente.Text = string.Empty;
                }
            }
        }

        private void txtAuCliente_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void txtAuCliente_KeyUp_1(object sender, KeyEventArgs e)
        {
            bool found = false;
            var border = (autoCompleteCategorias.Parent as ScrollViewer).Parent as Border;
            var data = Mascota.MonstrarMascotas23();


            string query = (sender as TextBox).Text;

            if (query.Length == 0)
            {
                // Clear   
                autoCompleteCategorias.Children.Clear();
                border.Visibility = System.Windows.Visibility.Collapsed;
            }
            else
            {
                border.Visibility = System.Windows.Visibility.Visible;
            }

            // Clear the list   
            autoCompleteCategorias.Children.Clear();

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
                autoCompleteCategorias.Children.Add(new TextBlock() { Text = "No se ha encontrado" });
            }
        }

        private void addItem(string text)
        {
            TextBlock block = new TextBlock();
            Label id = new Label();


            // Add the text   
            block.Text = text;

            // A little style...   
            block.Margin = new Thickness(2, 3, 2, 3);
            block.Cursor = Cursors.Hand;

            // Mouse events   
            block.MouseLeftButtonUp += (sender, e) =>
            {
                var border = (autoCompleteCategorias.Parent as ScrollViewer).Parent as Border;
                txtAuCliente.Text = (sender as TextBlock).Text;
                //cliente = cliente.BuscarClientID(txtAuCliente.Text);
                border.Visibility = System.Windows.Visibility.Collapsed;
                //ObtenerValoresFormulario();
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
            autoCompleteCategorias.Children.Add(block);
        }

        private void txtVacuna_KeyUp(object sender, KeyEventArgs e)
        {

        }
    }
}
