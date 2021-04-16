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
                                FROM Veterinaria.Categoria";

                //Establcer la coneccion
                sqlConnection.Open();

                //Crear el comando sql
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);

                //Obtener los datos de las categorias
                using (SqlDataReader rdr = sqlCommand.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        categorias.Add(new Categoria { Id = Convert.ToInt32(rdr["IdCategoria"]), NombreCategoria = rdr["NombreCategoria"].ToString() });
                    }
                }
                return categorias;
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
