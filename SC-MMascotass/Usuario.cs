using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Agregar los namespaces de conexion con SQL server
using System.Data.SqlClient;
using System.Configuration;

namespace SC_MMascotass
{
    class Usuario
    {
        //Variable miembro
        private static string connectionString = ConfigurationManager.ConnectionStrings["SC_MMascotass.Properties.Settings.MascotasConnectionString"].ConnectionString;
        private SqlConnection SqlConnection = new SqlConnection(connectionString);

        //Propiedades
        public int Id { get; set; }

        public string NombreCompleto { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }
        public bool Estado { get; set; }

        //Constructores
        public Usuario() { }

        public Usuario(string nombreCompleto, string username, string password, bool estado) 
        {
            NombreCompleto = nombreCompleto;
            Username = username;
            Password = password;
            Estado = estado;
        }

        //Metodos

        /// <summary>
        /// Verifica si las credenciales de inicio de sesion son correctas.
        /// </summary>
        /// <param name="username">El nombre del usuario</param>
        /// <param name="password">La contrasña del usuario</param>
        /// <returns>Los datos del usuario</returns>
        //public Usuario IniciarSesion(string username, string password)
        //{
            // Crear ibjeto que almacena la información de los resultados
        //    Usuario usuario = new Usuario();

         //   try
         //   {
                //Query de seleccion
        //        string query = @"SELECT * FROM"
        //    }
        //    catch (Exception e)
        //    {

        //        throw e;
         //   }
        //}

    }
}










//Please Bill Gates work :D

