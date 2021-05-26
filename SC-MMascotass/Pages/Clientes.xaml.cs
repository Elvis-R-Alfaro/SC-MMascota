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
{ public partial class Clientes : UserControl
    {
        private Cliente cliente = new Cliente();
        private List<Cliente> clientes;
        public Clientes()
        {
            InitializeComponent();
            ObtenerClientes();
        }

        private void btnNuevo_Click(object sender, RoutedEventArgs e)
        {
            FormCliente.ides = '0';
            FormCliente cliente = new FormCliente(false);          
           
            cliente.Show();
        }

        private void ObtenerClientes()
        {
            clientes = cliente.MonstrarCliente();
            dgClientes.SelectedValuePath = "IdCliente";
            dgClientes.ItemsSource = clientes;
        }

        private void btnEditar_Click(object sender, RoutedEventArgs e)
        {
            if (dgClientes.SelectedValue == null)
                MessageBox.Show("Por favor selecciona un Clientes");
            else
            {
                FormCliente.ides = Convert.ToInt32(dgClientes.SelectedValue);
                FormCliente cliente = new FormCliente(true);
                cliente.Show();
            }
        }

        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (dgClientes.SelectedValue == null)
                    MessageBox.Show("Por favor selecciona un Cliente desde el listad");
                else
                {
                    //Monstrar mensjae de confirmacion
                    MessageBoxResult result = MessageBox.Show("¿Deseas eliminar el cliente?", "Confirmar", MessageBoxButton.YesNo, MessageBoxImage.Warning);

                    if (result == MessageBoxResult.Yes)
                    {
                        //Eliminar la Clientes
                        cliente.EliminarCliente(Convert.ToInt32(dgClientes.SelectedValue));
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Ha ocurrido un error al eliminar el cliente...");
                Console.WriteLine(ex.Message);
            }
            finally
            {
                //Actualizar el listbox de Clientes
                ObtenerClientes();
            }
        }

        private void btnRefrescar_Click(object sender, RoutedEventArgs e)
        {
            ObtenerClientes();
        }
    }
}
