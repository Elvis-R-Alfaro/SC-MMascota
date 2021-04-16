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
    /// Interaction logic for FormInventario.xaml
    /// </summary>
    public partial class FormInventario : Window
    {
        public FormInventario()
        {
            InitializeComponent();
        }

        private void txtAuCategoria_KeyUp(object sender, KeyEventArgs e)
        {
            bool found = false;
            var border = (autoCompleteCategorias.Parent as ScrollViewer).Parent as Border;
            var data = Categoria.GetData();

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

            // Add the text   
            block.Text = text;

            // A little style...   
            block.Margin = new Thickness(2, 3, 2, 3);
            block.Cursor = Cursors.Hand;

            // Mouse events   
            block.MouseLeftButtonUp += (sender, e) =>
            {
                txtAuCategoria.Text = (sender as TextBlock).Text;
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

        private void btnNuevoCliente_Click(object sender, RoutedEventArgs e)
        {
            //// Mostrar el formulario de ingreso de categorias
            //FormCategorias categorias = new FormCategorias();
            //categorias.Show();
        }
    }
}
