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
    class HistorialVacunacion
    {
        //Variable Miembro
        private static string connectionString = ConfigurationManager.ConnectionStrings["SC_MMascotass.Properties.Settings.MascotasConnectionString"].ConnectionString;
        private SqlConnection sqlConnection = new SqlConnection(connectionString);

        //Propiedades
        public int IdHistorialVacunacion { get; set; }
        public int IdMascota { get; set; }

        public string Mascota { get; set; }
        public int IdProducto { get; set; }
        public string Producto { get; set; }
        public DateTime Fecha { get; set; }

        public HistorialVacunacion() { }
        public HistorialVacunacion(int idhistorialvacunacion, int idmascota, int idproducto, DateTime fecha)
        {
            IdHistorialVacunacion = idhistorialvacunacion;
            IdMascota = idmascota;
            IdProducto = idproducto;
            Fecha = fecha;

        }

        public void CrearVacuna(HistorialVacunacion producto)
        {
            try
            {
                //Query de insertar
                string query = @"INSERT INTO Veterinaria.HistorialVacunacion(IdMascota, IdProducto, Fecha) VALUES
                         (@IdMascota, @IdProducto, @Fecha)";

                

                //Establecer la conexion
                sqlConnection.Open();

                //Crear el comando SQL
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);

                //Establecer los valores de los paramawtros
                sqlCommand.Parameters.AddWithValue("@IdMascota", producto.IdMascota);

                sqlCommand.Parameters.AddWithValue("@IdProducto", producto.IdProducto);

                sqlCommand.Parameters.AddWithValue("@Fecha", producto.Fecha);

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

        public List<HistorialVacunacion> MonstrarRegistro(string nombre)
        {
            //Iniciamos la lista vacia de categorias
            List<HistorialVacunacion> historialVacunacions = new List<HistorialVacunacion>();

            try
            {
                //Query de seleccion
                string query = @"SELECT Veterinaria.Mascota.AliasMascota, Veterinaria.Inventario.NombreProducto, Veterinaria.HistorialVacunacion.Fecha, Veterinaria.HistorialVacunacion.IdHistorialVacunacion
                        FROM     Veterinaria.Mascota INNER JOIN
                                          Veterinaria.HistorialVacunacion ON Veterinaria.Mascota.IdMascota = Veterinaria.HistorialVacunacion.IdMascota INNER JOIN
                                          Veterinaria.Inventario ON Veterinaria.HistorialVacunacion.IdProducto = Veterinaria.Inventario.IdProducto INNER JOIN
                                          Veterinaria.Categoria ON Veterinaria.Inventario.IdCategoria = Veterinaria.Categoria.IdCategoria
                        WHERE  Veterinaria.Mascota.AliasMascota = @nombre  AND Veterinaria.Categoria.IdCategoria = '5'";

                //Establcer la coneccion
                sqlConnection.Open();

                //Crear el comando sql
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);

                //Establecer los valores de los paramawtros
                sqlCommand.Parameters.AddWithValue("@nombre", nombre);

                //Obtener los datos de las categorias
                using (SqlDataReader rdr = sqlCommand.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        historialVacunacions.Add(new HistorialVacunacion
                        {
                            
                            Mascota = rdr["AliasMascota"].ToString(),
                            Producto =rdr["NombreProducto"].ToString(),
                            Fecha = (DateTime)rdr["Fecha"]
                        });
                    }
                }
                return historialVacunacions;
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
    }
}
