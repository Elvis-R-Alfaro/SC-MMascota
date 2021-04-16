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
    class Categoria
    {
        //Variable Miembro
        private static string connectionString = ConfigurationManager.ConnectionStrings["SC_MMascotass.Properties.Settings.MascotasConnectionString"].ConnectionString;
        private SqlConnection sqlConnection = new SqlConnection(connectionString);

        //Propiedades

        public int Id { get; set; }
        public string NombreCategoria { get; set; }

        //Constructor
        public Categoria() { }
        public Categoria(int id, string nombrecategoria) 
        {
            Id = id;
            NombreCategoria = nombrecategoria;
        }

        //Metodos

        /// <summary>
        /// Inserta una Categoria
        /// </summary>
        /// <param name="categoria">La informacion de la categoria</param>
        public void CrearCategoria(Categoria categoria)
        {
            try
            {
                //Query de insertar
                string query = @"INSERT INTO Veterinaria.Categoria (NombreCategoria) 
                            VALUES(@nombrecategoria)";

                //Establecer la conexion
                sqlConnection.Open();

                //Crear el comando SQL
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);

                //Establecer los valores de los paramawtros
                sqlCommand.Parameters.AddWithValue("@nombrecategoria", categoria.NombreCategoria);

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
        public List<Categoria> MonstrarCategorias()
        {
            //Iniciamos la lista vacia de categorias
            List<Categoria> categorias = new List<Categoria>();

            try
            {
                //Query de seleccion
                string query = @"SELECT id, descripcion
                                FROM habitaciones.habitacion";

                //Establcer la coneccion
                sqlConnection.Open();

                //Crear el comando sql
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);

                //Obtener los datos de las habitaciones
                using (SqlDataReader rdr = sqlCommand.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        categorias.Add(new Categoria { NombreCategoria = rdr["NombreCategoria"].ToString() });
                    }
                }
                return categorias;
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Obtiene una categoria
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Categoria BuscarCategoria(int id)
        {
            Categoria laCategoria = new Categoria();

            try
            {
                //Query busqueda
                string query = @"SELECT * From Veterinaria.Categorias
                                WHERE id = @id";

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
                        laCategoria.Id = Convert.ToInt32(rdr["id"]);
                        laCategoria.NombreCategoria = rdr["NombreCategoria"].ToString();
                    }
                }

                return laCategoria;
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

        public void EditarCategoria(Categoria categoria)
        {
            try
            {
                //Query de actualizacion
                string query = @"UPDATE Veterinaria.Categoria
                                SET NombreCategoria = @nombrecategoria
                                WHERE id = @id";

                //Strablecer la conexion
                sqlConnection.Open();

                //Crear el comando SQL
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);

                //Establecer los valores de los parametros
                sqlCommand.Parameters.AddWithValue("@id", categoria.Id);
                sqlCommand.Parameters.AddWithValue("@nombrecategoria", categoria.NombreCategoria);

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

        static public List<string> GetData()
        {
            List<string> data = new List<string>();

            data.Add("Comida para perros");
            data.Add("Comida para Gatos");
            data.Add("Juguetes");
            data.Add("Jarabes");
            data.Add("Pastillas");
            data.Add("Vitaminas");
            data.Add("Correas");
            data.Add("Camas");
            data.Add("Vacunas");
            data.Add("En latados");
            data.Add("Tazones");
            data.Add("Servicio");

            return data;
        }
    }
}
