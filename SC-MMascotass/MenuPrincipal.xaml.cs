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

namespace SC_MMascotass
{
    /// <summary>
    /// Interaction logic for MenuPrincipal.xaml
    /// </summary>
    public partial class MenuPrincipal : Window
    {
        public MenuPrincipal()
        {
            InitializeComponent();
        }

        private void btnInicio_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void AgregarForm(UserControl control) 
        {
            this.spPrincipal.Children.Clear();
            this.spPrincipal.Children.Add(control);
        }

        private void btnClientes_Click(object sender, RoutedEventArgs e)
        {
            AgregarForm(new Pages.Clientes());
        }

        private void btnMascotas_Click(object sender, RoutedEventArgs e)
        {
            AgregarForm(new Pages.Mascotas());
        }
    }
}
