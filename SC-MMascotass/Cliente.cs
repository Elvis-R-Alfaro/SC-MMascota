using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Agregar los namespaces
using System.Data.SqlClient;
using System.Configuration;

namespace SC_MMascotass
{
    class Cliente
    {
        //creacion de Variables miembro
        private static string connectionString = ConfigurationManager.ConnectionStrings["SC_MMascotass.Properties.Settings.MascotasConnectionString"].ConnectionString;
        private SqlConnection sqlConnection = new SqlConnection(connectionString);

        //propiedades
        public int Id { get; set; }
        public string NombreCliente { get; set; }
        public string NumeroTelefono { get; set; }

        //creacion del metodo constructor
        public Cliente() { }
        public Cliente(int id, string nombrecliente, string numeroTelefono)
        {
            Id = id;
            NombreCliente = nombrecliente;
            NumeroTelefono = numeroTelefono;
        }

        //metodos
        public void CrearCliente(ClientesCS cliente)
        {
            try
            {
                //Query de insertar
                string query = @"INSERT INTO Veterinaria.Cliente (NombreCliente, Telefono)
                            VALUES(@NombreCliente, @Telefono)";

                //Establecer la conexion
                sqlConnection.Open();

                //Crear el comando SQL
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);

                //Establecer los valores de los paramawtros
                sqlCommand.Parameters.AddWithValue("@NombreCliente", cliente.NombreCliente);
                sqlCommand.Parameters.AddWithValue("@Telefono", cliente.NumeroTelefono);

                //ejecutar el comando insertado
                sqlCommand.ExecuteNonQuery();
            }
            catch (Exception e)
            {

                throw e;
            }
            finally
            {
                //Cerrar la conexion
                sqlConnection.Close();
            }
        }


        public List<Cliente> MonstrarCliente()
        {

            //Iniciamos la lista vacia de categorias
            List<Cliente> clientes = new List<Cliente>();

            try
            {
                //Query de seleccion
                string query = @"SELECT IdCliente, NombreCliente, Telefono
                                FROM Veterinaria.Cliente";

                //Establcer la coneccion
                sqlConnection.Open();

                //Crear el comando sql
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);

                //Obtener los datos de las categorias
                using (SqlDataReader rdr = sqlCommand.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        clientes.Add(new Cliente { Id = Convert.ToInt32(rdr["IdCliente"]), NombreCliente = rdr["NombreCliente"].ToString(), NumeroTelefono = rdr["Telefono"].ToString() });
                    }
                }
                return clientes;
            }
            catch (Exception e)
            {

                throw e;
            }
            finally
            {
                //Cerrar la conexion
                sqlConnection.Close();
            }
        }

        public Cliente BuscarCliente(int id)
        {
            Cliente elCliente = new Cliente();

            try
            {
                //Query busqueda
                string query = @"SELECT * From Veterinaria.Cliente
                                WHERE IdCliente = @IdCliente";

                //Establecer la coneccion
                sqlConnection.Open();

                //Crear el comando SQL
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);

                //Establecer el valor del parametro
                sqlCommand.Parameters.AddWithValue("@id", id);

                using (SqlDataReader rdr = sqlCommand.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        elCliente.Id = Convert.ToInt32(rdr["IdCliente"]);
                        elCliente.NombreCliente = rdr["NombreCliente"].ToString();
                    }
                }

                return elCliente;
            }
            catch (Exception e)
            {

                throw e;
            }
            finally
            {
                //Cerrar la conexio
                sqlConnection.Close();
            }
        }

        public void EditarCliente(Cliente cliente)
        {
            try
            {
                //Query de actualizacion
                string query = @"UPDATE Veterinaria.Cliente
                                SET NombreCliente = @NombreCliente
                                WHERE IdCliente = @IdCliente";

                //Strablecer la conexion
                sqlConnection.Open();

                //Crear el comando SQL
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);

                //Establecer los valores de los parametros
                sqlCommand.Parameters.AddWithValue("@IdCliente", cliente.Id);
                sqlCommand.Parameters.AddWithValue("@NombreCliente", cliente.NombreCliente);

                //Ejecutar el comando de actualizar
                sqlCommand.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                //Cerrar conexcion
                sqlConnection.Close();
            }
        }
        public void EliminarCliente(int id)
        {
            try
            {
                //Query de eliminar
                string query = @"DELETE FROM Veterinaria.Cliente
                                WHERE IdCliente = @IdCliente";

                //Establecer la conexion SQL
                sqlConnection.Open();

                //Establecer el valor del parametro
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);

                //Establecer el valor del parametro
                sqlCommand.Parameters.AddWithValue("@IdCliente", id);

                //Ejecutar el comando de eliminacion
                sqlCommand.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                //CErrar conexion
                sqlConnection.Close();
            }
        }

        static public List<string> GetData()
        {
            List<string> data = new List<string>();

            data.Add("Afzaal");
            data.Add("Ahmad");
            data.Add("Zeeshan");
            data.Add("Daniyal");
            data.Add("Rizwan");
            data.Add("John");
            data.Add("Doe");
            data.Add("Johanna Doe");
            data.Add("Pakistan");
            data.Add("Microsoft");
            data.Add("Programming");
            data.Add("Visual Studio");
            data.Add("Sofiya");
            data.Add("Rihanna");
            data.Add("Eminem");

            return data;
        }
    }
}
