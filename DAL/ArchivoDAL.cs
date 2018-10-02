using ET;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
  public  class ArchivoDAL

    {


        readonly string ConnectionString = ConfigurationManager.ConnectionStrings["AATEConnectionString"].ConnectionString;

        #region [ Archivo ]

        public List<Archivo> ObtenerArchivos()
        {
            string spName = "[Archivo_GetAll]";
            List<Archivo> Archivos = new List<Archivo>();

            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                con.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = spName;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = con;

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var Archivo = new Archivo
                        {

                            IdArchivo = Convert.ToInt32(reader["IdArchivo"]),
                            NombreArchivo= reader["NombreArchivo"].ToString(),
                            Formato = reader["Formato"].ToString(),
                            Periodo= reader["Periodo"].ToString(),
                            FechaSubida= Convert.ToDateTime(reader["FechaSubida"] is DBNull?0 : reader["FechaSubida"]),

                        };
                        Archivos.Add(Archivo);

                    }

                }




            }

            return Archivos;
        }

        public Archivo ObtenerArchivoPorCodigo(string codigoArchivo)
        {

            string spName = "[Archivo_GetById]";

            List<Archivo> Archivos = new List<Archivo>();
            Archivo item = null;


            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                con.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = spName;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdArchivo", codigoArchivo);
                cmd.Connection = con;


                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var Archivo = new Archivo
                        {

                            IdArchivo = Convert.ToInt32(reader["IdArchivo"]),
                            NombreArchivo = reader["NombreArchivo"].ToString(),
                            Formato = reader["Formato"].ToString(),
                            Periodo = reader["Periodo"].ToString(),
                            FechaSubida = Convert.ToDateTime(reader["FechaSubida"] is DBNull ? 0 : reader["FechaSubida"]),


                        };

                        Archivos.Add(Archivo);
                        item = Archivo;

                    }

                }

            }

            return item;
        }


        public Archivo ObtenerArchivoPorNombre(string nombreArchivo)
        {

            string spName = "[Archivo_GetByNombre]";

            List<Archivo> Archivos = new List<Archivo>();
            Archivo item = null;


            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                con.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = spName;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@NombreArchivo", nombreArchivo);
                cmd.Connection = con;


                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var Archivo = new Archivo
                        {

                            IdArchivo = Convert.ToInt32(reader["IdArchivo"]),
                            NombreArchivo = reader["NombreArchivo"].ToString(),
                            Formato = reader["Formato"].ToString(),
                            Periodo = reader["Periodo"].ToString(),
                            FechaSubida = Convert.ToDateTime(reader["FechaSubida"] is DBNull ? 0 : reader["FechaSubida"]),



                        };

                        Archivos.Add(Archivo);
                        item = Archivo;

                    }

                }

            }

            return item;
        }



        public bool SaveArchivo(Archivo Archivo)
        {
            string spName = "[Archivo_Save]";
            bool respuesta = false;


            try
            {
                using (SqlConnection con = new SqlConnection(ConnectionString))
                {
                    con.Open();

                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandText = spName;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = con;

                    cmd.Parameters.AddWithValue("@IdArchivo", Archivo.IdArchivo);
                    cmd.Parameters.AddWithValue("@NombreArchivo", Archivo.NombreArchivo);
                    cmd.Parameters.AddWithValue("@Formato", Archivo.Formato);
                    cmd.Parameters.AddWithValue("@Periodo", Archivo.Periodo);
                    cmd.Parameters.AddWithValue("@FechaSubida", Archivo.FechaSubida);
                    cmd.Parameters.AddWithValue("@EstadoArchivo", Archivo.EstadoArchivo);


                    cmd.ExecuteNonQuery();
                    respuesta = true;

                }
            }
            catch (Exception)
            {
                throw;
            }


            return respuesta;
        }

        public bool EliminarArchivoPorCodigo(string codigoArchivo)
        {

            string spName = "[Archivo_Delete]";

            List<Archivo> Archivos = new List<Archivo>();
            var respuesta = false;


            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                con.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = spName;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdArchivo", codigoArchivo);
                cmd.Connection = con;


                cmd.ExecuteNonQuery();

                if (con.State != ConnectionState.Closed)
                {
                    con.Close();
                }

                respuesta = true;
            }

            return respuesta;

        }

        #endregion

    }
}
