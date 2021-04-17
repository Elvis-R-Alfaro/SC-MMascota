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
        //Variable Miembro
        private static string connectionString = ConfigurationManager.ConnectionStrings["SC_MMascotass.Properties.Settings.MascotasConnectionString"].ConnectionString;
        private SqlConnection sqlConnection = new SqlConnection(connectionString);

        //Propiedades
        public int IdCliente { get;  set; }
        public string NombreCliente { get; set; }
        public string Telefono { get; set; }

        //Constructor
        public Cliente() { }
        public Cliente(int idcliente, string nombrecliente, string telefono)
        {
            IdCliente = idcliente;
            NombreCliente = nombrecliente;
            Telefono = telefono;
        }

        //Metodos

        /// <summary>
        /// Inserta una Categoria
        /// </summary>
        /// <param name="categoria">La informacion de la categoria</param>
        public void CrearCliente(Cliente cliente)
        {
            try
            {
                //Query de insertar
                string query = @"INSERT INTO Veterinaria.Cliente (NombreCliente, Telefono) 
                            VALUES(@NombreCliente,@Telefono)";

                //Establecer la conexion
                sqlConnection.Open();

                //Crear el comando SQL
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);

                //Establecer los valores de los paramawtros
                sqlCommand.Parameters.AddWithValue("@NombreCliente", cliente.NombreCliente);
                sqlCommand.Parameters.AddWithValue("@Telefono", cliente.Telefono);

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

        /// <summary>
        /// Monstrar todas las categorias
        /// </summary>
        /// <returns>Listado de Categorias</returns>
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
                        clientes.Add(new Cliente { IdCliente = Convert.ToInt32(rdr["IdCliente"]), NombreCliente = rdr["NombreCliente"].ToString(), Telefono = rdr["Telefono"].ToString() });
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

        /// <summary>
        /// Obtiene una categoria
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Cliente BuscarCliente(int IdCliente)
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
                sqlCommand.Parameters.AddWithValue("@IdCliente", IdCliente);

                using (SqlDataReader rdr = sqlCommand.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        elCliente.IdCliente = Convert.ToInt32(rdr["IdCliente"]);
                        elCliente.NombreCliente = rdr["NombreCliente"].ToString();
                        elCliente.Telefono = rdr["Telefono"].ToString();

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
                                SET NombreCliente = @NombreCliente,
                                    Telefono =@Telefono
                                WHERE IdCliente = @IdCliente";

                //Strablecer la conexion
                sqlConnection.Open();

                //Crear el comando SQL
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);

                //Establecer los valores de los parametros
                sqlCommand.Parameters.AddWithValue("@IdCliente", cliente.IdCliente);
                sqlCommand.Parameters.AddWithValue("@NombreCliente", cliente.NombreCliente);
                sqlCommand.Parameters.AddWithValue("@Telefono", cliente.Telefono);

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

        public void EliminarCliente(int IdCliente)
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
                sqlCommand.Parameters.AddWithValue("@IdCliente", IdCliente);

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

        //static public List<string> GetData()
        //{
        //    List<string> data = new List<string>();

        //    data.Add("Comida para perros");
        //    data.Add("Comida para Gatos");
        //    data.Add("Juguetes");
        //    data.Add("Jarabes");
        //    data.Add("Pastillas");
        //    data.Add("Vitaminas");
        //    data.Add("Correas");
        //    data.Add("Camas");
        //    data.Add("Vacunas");
        //    data.Add("En latados");
        //    data.Add("Tazones");
        //    data.Add("Servicio");

        //    return data;
        //}
    }
}

