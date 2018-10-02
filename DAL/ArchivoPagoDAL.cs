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
   public class ArchivoPagoDAL
    {
        readonly string ConnectionString = ConfigurationManager.ConnectionStrings["AATEConnectionString"].ConnectionString;

        #region [ ArchivoPago ]

        public List<ArchivoPago> ObtenerArchivoPagos()
        {
            string spName = "[ArchivoPago_GetAll]";
            List<ArchivoPago> ArchivoPagos = new List<ArchivoPago>();

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
                        var ArchivoPago = new ArchivoPago
                        {

                            IdArchivoPago = Convert.ToInt32(reader["IdArchivoPago"]),
                            NombreArchivo = reader["NombreArchivo"].ToString(),
                            Formato = reader["Formato"].ToString(),
                            Periodo = reader["Periodo"].ToString(),
                            FechaSubida = Convert.ToDateTime(reader["FechaSubida"] is DBNull ? 0 : reader["FechaSubida"]),
                            EstadoArchivo = Convert.ToInt32(reader["EstadoArchivo"]),
                            EstadoValidacion = Convert.ToInt32(reader["EstadoValidacion"]),
                        };
                        ArchivoPagos.Add(ArchivoPago);

                    }

                }




            }

            return ArchivoPagos;
        }

        public ArchivoPago ObtenerArchivoPagoPorCodigo(string codigoArchivoPago)
        {

            string spName = "[ArchivoPago_GetById]";

            List<ArchivoPago> ArchivoPagos = new List<ArchivoPago>();
            ArchivoPago item = null;


            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                con.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = spName;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdArchivoPago", codigoArchivoPago);
                cmd.Connection = con;


                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var ArchivoPago = new ArchivoPago
                        {

                            IdArchivoPago = Convert.ToInt32(reader["IdArchivoPago"]),
                            NombreArchivo = reader["NombreArchivo"].ToString(),
                            Formato = reader["Formato"].ToString(),
                            Periodo = reader["Periodo"].ToString(),
                            FechaSubida = Convert.ToDateTime(reader["FechaSubida"] is DBNull ? 0 : reader["FechaSubida"]),
                            EstadoArchivo = Convert.ToInt32(reader["EstadoArchivo"]),
                            EstadoValidacion = Convert.ToInt32(reader["EstadoValidacion"]),

                        };

                        ArchivoPagos.Add(ArchivoPago);
                        item = ArchivoPago;

                    }

                }

            }

            return item;
        }


        public ArchivoPago ObtenerArchivoPagoPorNombre(string nombreArchivoPago)
        {

            string spName = "[ArchivoPago_GetByNombre]";

            List<ArchivoPago> ArchivoPagos = new List<ArchivoPago>();
            ArchivoPago item = null;


            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                con.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = spName;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@NombreArchivoPago", nombreArchivoPago);
                cmd.Connection = con;


                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var ArchivoPago = new ArchivoPago
                        {

                            IdArchivoPago = Convert.ToInt32(reader["IdArchivoPago"]),
                            NombreArchivo = reader["NombreArchivo"].ToString(),
                            Formato = reader["Formato"].ToString(),
                            Periodo = reader["Periodo"].ToString(),
                            FechaSubida = Convert.ToDateTime(reader["FechaSubida"] is DBNull ? 0 : reader["FechaSubida"]),
                            EstadoArchivo = Convert.ToInt32(reader["EstadoArchivo"]),
                            EstadoValidacion = Convert.ToInt32(reader["EstadoValidacion"]),
                        };

                        ArchivoPagos.Add(ArchivoPago);
                        item = ArchivoPago;

                    }

                }

            }

            return item;
        }



        public bool SaveArchivoPago(ArchivoPago ArchivoPago)
        {
            string spName = "[ArchivoPago_Save]";
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

                    cmd.Parameters.AddWithValue("@IdArchivoPago", ArchivoPago.IdArchivoPago);
                    cmd.Parameters.AddWithValue("@NombreArchivo", ArchivoPago.NombreArchivo);
                    cmd.Parameters.AddWithValue("@Formato", ArchivoPago.Formato);
                    cmd.Parameters.AddWithValue("@Periodo", ArchivoPago.Periodo);
                    cmd.Parameters.AddWithValue("@FechaSubida", ArchivoPago.FechaSubida);
                    cmd.Parameters.AddWithValue("@EstadoArchivo", ArchivoPago.EstadoArchivo);
                    cmd.Parameters.AddWithValue("@EstadoValidacion", ArchivoPago.EstadoValidacion);

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

        public bool EliminarArchivoPagoPorCodigo(string codigoArchivoPago)
        {

            string spName = "[ArchivoPago_Delete]";

            List<ArchivoPago> ArchivoPagos = new List<ArchivoPago>();
            var respuesta = false;


            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                con.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = spName;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdArchivoPago", codigoArchivoPago);
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
