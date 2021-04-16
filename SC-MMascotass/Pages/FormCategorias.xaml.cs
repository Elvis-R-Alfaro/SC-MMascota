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
        public FormCategorias()
        {
            InitializeComponent();
        }

        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            if(txtCategoria.Text == string.Empty)
                MessageBox.Show("!Ingrese el Nombre de la Categoría¡");
            else
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
    }
}
