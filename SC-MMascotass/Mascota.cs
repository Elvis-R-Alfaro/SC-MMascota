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
    class Mascota
    {
        //Variable Miembro
        private static string connectionString = ConfigurationManager.ConnectionStrings["SC_MMascotass.Properties.Settings.MascotasConnectionString"].ConnectionString;
        private SqlConnection sqlConnection = new SqlConnection(connectionString);

        //Propiedades

        public int IdMascota { get; set; }
        public int IdCliente { get; set; }
        public string AliasMascota { get; set; }
        public string Especie { get; set; }
        public string Raza { get; set; }
        public string ColorPelo { get; set; }
        public DateTime Fecha { get; set; }

        //Constructor
        public Mascota() { }
        public Mascota(int idmascota, int idcliente, string aliasmascota, string especie, string raza, string colorpelo, DateTime fecha)
        {
            IdMascota = idmascota;
            IdCliente = idcliente;
            AliasMascota = aliasmascota;
            Especie = especie;
            Raza = raza;
            ColorPelo = colorpelo;
            Fecha = fecha;
        }

        //Metodos

        /// <summary>
        /// Inserta una Mascota
        /// </summary>
        /// <param name="categoria">La informacion de la categoria</param>
        public void CrearMascota(Mascota mascota)
        {
            try
            {
                //Query de insertar
                string query = @"INSERT INTO Veterinaria.Mascota
                                (IdCliente,AliasMascota,Especie
                                ,Raza,ColorPelo,Fecha)
                            VALUES
                                (@IdCliente,@AliasMascota,@Especie
                                ,@Raza,@ColorPelo,@Fecha)";

                //Establecer la conexion
                sqlConnection.Open();

                //Crear el comando SQL
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);

                //Establecer los valores de los paramawtros
                sqlCommand.Parameters.AddWithValue("@IdCliente", mascota.IdCliente);
                sqlCommand.Parameters.AddWithValue("@AliasMascota", mascota.IdMascota);
                sqlCommand.Parameters.AddWithValue("@Especie", mascota.Especie);
                sqlCommand.Parameters.AddWithValue("@Raza", mascota.Raza);
                sqlCommand.Parameters.AddWithValue("@ColorPelo", mascota.ColorPelo);
                sqlCommand.Parameters.AddWithValue("@Fecha", mascota.Fecha);

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
        public List<Mascota> MonstrarMascotas()
        {
            //Iniciamos la lista vacia de categorias
            List<Mascota> mascotas = new List<Mascota>();

            try
            {
                //Query de seleccion
                string query = @"SELECT *
                                FROM Veterinaria.Mascota";

                //Establcer la coneccion
                sqlConnection.Open();

                //Crear el comando sql
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);

                //Obtener los datos de las categorias
                using (SqlDataReader rdr = sqlCommand.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        mascotas.Add(new Mascota {  IdMascota = Convert.ToInt32(rdr["IdCliente"]),
                                                    IdCliente = Convert.ToInt32(rdr["IdCliente"]),
                                                    AliasMascota = rdr["AliasMascota"].ToString(),
                                                    Especie = rdr["Especie"].ToString(),
                                                    Raza = rdr["Raza"].ToString(),
                                                    ColorPelo = rdr["ColorPelo"].ToString(),
                                                    Fecha = (DateTime)rdr["Fecha"]});
                    }
                }
                return mascotas;
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
        public Mascota BuscarMascota(int id)
        {
            Mascota laMascota = new Mascota();

            try
            {
                //Query busqueda
                string query = @"SELECT * From Veterinaria.Mascota
                                WHERE IdMascota = @IdMascota";

                //Establecer la coneccion
                sqlConnection.Open();

                //Crear el comando SQL
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);

                //Establecer el valor del parametro
                sqlCommand.Parameters.AddWithValue("@IdMascota", id);

                using (SqlDataReader rdr = sqlCommand.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        laMascota.IdMascota = Convert.ToInt32(rdr["IdMascota"]);
                        laMascota.IdCliente = Convert.ToInt32(rdr["IdCliente"]);
                        laMascota.AliasMascota = rdr["AliasMascota"].ToString();
                        laMascota.Especie = rdr["Especie"].ToString();
                        laMascota.Raza = rdr["Raza"].ToString();
                        laMascota.ColorPelo = rdr["ColorPelo"].ToString();
                        laMascota.Fecha = (DateTime)rdr["Fecha"];
                    }
                }

                return laMascota;
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

        public void EditarMascota(Mascota mascota)
        {
            try
            {
                //Query de actualizacion
                string query = @"UPDATE Veterinaria.Mascota
                                SET IdCliente = @IdCliente,
                                    AliasMascota=  @AliasMascota,
                                    Especie = @Especie,
                                    Raza = @Raza,
                                    ColorPelo = @ColorPelo,
                                    Fecha = @Fecha                                  
                                WHERE IdMascota = @IdMascota";

                //Strablecer la conexion
                sqlConnection.Open();

                //Crear el comando SQL
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);

                //Establecer los valores de los parametros
                sqlCommand.Parameters.AddWithValue("@IdMascota", mascota.IdMascota);
                sqlCommand.Parameters.AddWithValue("@IdCliente", mascota.IdCliente);
                sqlCommand.Parameters.AddWithValue("@AliasMascota", mascota.AliasMascota);
                sqlCommand.Parameters.AddWithValue("@Especie", mascota.Especie);
                sqlCommand.Parameters.AddWithValue("@Raza", mascota.Raza);
                sqlCommand.Parameters.AddWithValue("@ColorPelo", mascota.ColorPelo);
                sqlCommand.Parameters.AddWithValue("@Fecha", mascota.Fecha);

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

        public void EliminarMascota(int id)
        {
            try
            {
                //Query de eliminar
                string query = @"DELETE FROM Veterinaria.Mascota
                                WHERE IdMascota = @IdMascota";

                //Establecer la conexion SQL
                sqlConnection.Open();

                //Establecer el valor del parametro
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);

                //Establecer el valor del parametro
                sqlCommand.Parameters.AddWithValue("@IdMascota", id);

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
