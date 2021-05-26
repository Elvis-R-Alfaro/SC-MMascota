﻿using System;
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
    public partial class FormCliente : Window
    {
        private Cliente cliente = new Cliente();

        //Variable de id
        public static int ides;
        public FormCliente(bool visible)
        {
            InitializeComponent();
            MonstrarBotones(visible);

            //Validacion de cargar datos
            if (ides != 0)
            {
                cliente = cliente.BuscarCliente(ides);
                txtNombre.Text = cliente.NombreCliente;
                txtTelefono.Text = cliente.Telefono;
                
            }
        }

        private bool VerificarValores()
        {
            if (txtNombre.Text == string.Empty)
            {
                MessageBox.Show("¡Ingrese el Nombre del Usuario!");
                return false;
            }
            if (txtTelefono.Text == string.Empty && txtTelefono.MaxLength == 8)
            {
                MessageBox.Show("¡Ingrese el Telefono Corectamente!");
                return false;
            }
            return true;
        }

        //Obtener datos del formulario
        private void ObtenerValoresFormulario()
        {
            cliente.NombreCliente = txtNombre.Text + ' ' + txtApellidos.Text;
            cliente.Telefono = txtTelefono.Text;
            cliente.IdCliente = Convert.ToInt32(ides);         
        }

        //Vibilidad de los botones
        private void MonstrarBotones(bool visibles)
        {
            if (visibles)
            {
                spNuevaCategoria.Visibility = Visibility.Hidden;
                spButton1.Visibility = Visibility.Hidden;
                spEditarCategoria.Visibility = Visibility.Visible;
                spButton2.Visibility = Visibility.Visible;
                txtApellidos.Visibility = Visibility.Hidden;
                lblapellido.Visibility = Visibility.Hidden;
            }
            else
            {
                spNuevaCategoria.Visibility = Visibility.Visible;
                spButton1.Visibility = Visibility.Visible;
                spEditarCategoria.Visibility = Visibility.Hidden;
                spButton2.Visibility = Visibility.Hidden;
                txtApellidos.Visibility = Visibility.Visible;
                lblapellido.Visibility = Visibility.Visible;
            }
        }

        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            if (VerificarValores())
            {
                try
                {
                    //Obtener los valores para el cliente
                    ObtenerValoresFormulario();

                    //Insertar los datos de el cliente
                    cliente.CrearCliente(cliente);

                    //Mensaje de inserccion exito
                    MessageBox.Show("Datos insertados correctamente","Exito",MessageBoxButton.OK,MessageBoxImage.Information);

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ha ocurrido un error al momento de insertar el Cliente....");
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    Limpiar();
                    this.Close();             
                }
            }
        }

        //Metodo Limpiar
        private void Limpiar()
        {
            txtApellidos.Text = string.Empty;
            txtNombre.Text = string.Empty;
            txtTelefono.Text = string.Empty;
        }

        private void btnRestablecer_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();        
        }

        private void btnAceptar_Click(object sender, RoutedEventArgs e)
        {
            if (VerificarValores())
            {
                try
                {
                    //Obtener los valores para el cliente desde el formulario
                    ObtenerValoresFormulario();

                    //Actualizar los valores en la base de datos
                    cliente.EditarCliente(cliente);

                    //Mensaje de actualizacion realizada
                    MessageBox.Show("Datos modificados correctamente", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);

                    //Limpiar formulario
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al momento de actualizar el Cliente....");
                    Console.WriteLine(ex.Message);
                }
            }
        }

        private void btnRegresar_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
