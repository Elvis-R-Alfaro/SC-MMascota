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
        /// <returns>Los datos del usuario</returns>
        public Usuario BuscarUsuario(string username)
        {
            //Crear ibjeto que almacena la información de los resultados
            Usuario usuario = new Usuario();

            try
            {
                //Query de seleccion
                string query = @"SELECT * FROM Usuarios.usuario
                                WHERE username = @username";

                SqlConnection.Open();

                //Establecer los valores de los parámetros
                

                //Crear comando SQL
                SqlCommand sqlCommand = new SqlCommand(query, SqlConnection);
                sqlCommand.Parameters.AddWithValue("@username", username);

                using (SqlDataReader rdr = sqlCommand.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        //Obtener los valores del usuarios si la consulta retorna valores
                        usuario.Id = Convert.ToInt32(rdr["id"]);
                        usuario.NombreCompleto = rdr["nombreCompleto"].ToString();
                        usuario.Username = rdr["username"].ToString();
                        usuario.Password = rdr["password"].ToString();
                        usuario.Estado = Convert.ToBoolean(rdr["estado"]);
                    }

                }
                //retornar el usuario con los valores
                return usuario;
            }
            catch (Exception e)
            {

                throw e;
            }
            finally {
                //Cerrar la seccion
                SqlConnection.Close();
            }
        }

    }
}










//Please Bill Gates work :D

