using ET;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;


namespace DAL
{
    public class CuotaDAL
    {


        readonly string ConnectionString = ConfigurationManager.ConnectionStrings["AATEConnectionString"].ConnectionString;

        #region [ Cuota ]

        public List<Cuota> ObtenerCuotas()
        {
            string spName = "[Cuota_GetAll]";
            List<Cuota> Cuotas = new List<Cuota>();

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
                        var Cuota = new Cuota
                        {

                            IdCuota = Convert.ToInt32(reader["IdCuota"]),
                            NroCuota = Convert.ToInt32(reader["NroCuota"]),
                            Descripcion = reader["Descripcion"].ToString(),
                        

                        };
                        Cuotas.Add(Cuota);

                    }

                }




            }

            return Cuotas;
        }

        public Cuota ObtenerCuotaPorCodigo(string codigoCuota)
        {

            string spName = "[Cuota_GetById]";

            List<Cuota> Cuotas = new List<Cuota>();
            Cuota item = null;


            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                con.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = spName;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdCuota", codigoCuota);
                cmd.Connection = con;


                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var Cuota = new Cuota
                        {

                            IdCuota = Convert.ToInt32(reader["IdCuota"]),
                            NroCuota = Convert.ToInt32(reader["NroCuota"]),
                            Descripcion = reader["Descripcion"].ToString(),


                        };

                        Cuotas.Add(Cuota);
                        item = Cuota;

                    }

                }

            }

            return item;
        }


        public bool SaveCuota(Cuota Cuota)
        {
            string spName = "[Cuota_Save]";
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

                    cmd.Parameters.AddWithValue("@IdCuota", Cuota.IdCuota);
                    cmd.Parameters.AddWithValue("@NroCuota", Cuota.NroCuota);
                    cmd.Parameters.AddWithValue("@Descripcion", Cuota.Descripcion);
                    

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




        public bool EliminarCuotaPorCodigo(string codigoCuota)
        {

            string spName = "[Cuota_Delete]";

            List<Cuota> Cuotas = new List<Cuota>();
            var respuesta = false;


            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                con.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = spName;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdCuota", codigoCuota);
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
