using SC_MMascotass.Pages;
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

namespace SC_MMascotass
{
    /// <summary>
    /// Interaction logic for Categorias.xaml
    /// </summary>
    public partial class Categorias : UserControl
    {
        private Categoria categoria = new Categoria();
        private List<Categoria> categorias;
        public Categorias()
        {
            InitializeComponent();
        }

        private void btnNuevo_Click(object sender, RoutedEventArgs e)
        {
            FormCategorias categoria = new FormCategorias();
            categoria.Show();
        }
        
        private void ObtenerCategorias()
        {
            categorias = categoria.MonstrarCategorias();

            //var fuente = new BindingSource();
            //fuente.DataSource = categorias;
            //dgClientes.DataSource = fuente;
        }
    }
}
