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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SC_MMascotass.Pages
{
    /// <summary>
    /// Interaction logic for Clientes.xaml
    /// </summary>
    public partial class Clientes : UserControl
    {
        private ClientesCS cliente = new ClientesCS();
        private List<ClientesCS> clientes;


        public Clientes()
        {
            ObtenerClientes();
            MessageBox.Show("ola");
            InitializeComponent();

        }
        private void ObtenerClientes()
        {
            clientes = cliente.MonstrarCliente();
            var message = string.Join(",",clientes);
            MessageBox.Show(message);
           // dgClientes.SelectedValuePath = "Id";
            dgClientes.ItemsSource = clientes;

            MessageBox.Show(clientes.ToString());
        }

        private void btnNuevo_Click(object sender, RoutedEventArgs e)
        {
            // Mostrar el formulario de menú principal
            FormCliente cliente = new FormCliente(true);
            cliente.Show();
        }

        private void btnEditar_Click(object sender, RoutedEventArgs e)
        {
            if (dgClientes.SelectedValue == null)
                MessageBox.Show("Por favor selecciona un cliente");
            else
            {
                FormCliente.ides = Convert.ToInt32(dgClientes.SelectedValue);
                FormCliente cliente = new FormCliente(false);
                cliente.Show();
            }
        }

        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (dgClientes.SelectedValue == null)
                    MessageBox.Show("Por favor selecciona una habitacion desde el listad");
                else
                {
                    //Monstrar mensjae de confirmacion
                    MessageBoxResult result = MessageBox.Show("¿Deseas eliminar la categoria?", "Confirmar", MessageBoxButton.YesNo, MessageBoxImage.Warning);

                    if (result == MessageBoxResult.Yes)
                    {
                        //Eliminar la habitacion
                        //clientes.EliminarClientes(Convert.ToInt32(dgClientes.SelectedValue));
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Ha ocurrido un error al eliminar la habitacion...");
                Console.WriteLine(ex.Message);
            }
            finally
            {
                //Actualizar el listbox de habitaciones
                //ObtenerCliente();
            }

        }

        private void btnRefrescar_Click(object sender, RoutedEventArgs e)
        {
            dgClientes.SelectedValuePath = string.Empty;
        }
    }
}
