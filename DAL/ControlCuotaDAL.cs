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
    public class ControlCuotaDAL
    {
        readonly string ConnectionString = ConfigurationManager.ConnectionStrings["AATEConnectionString"].ConnectionString;

        #region [ ControlCuota ]

        public List<ControlCuota> ObtenerControlCuotas()
        {
            string spName = "[ControlCuota_GetAll]";
            List<ControlCuota> ControlCuotas = new List<ControlCuota>();

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
                        var ControlCuota = new ControlCuota
                        {

                            IdControlCuota = Convert.ToInt32(reader["IdControlCuota"]),
                            Monto = Convert.ToDecimal( reader["Monto"]),
                            FlagFinal = Convert.ToInt32(reader["FlagFinal"]),
                            FechaVencimiento = Convert.ToDateTime(reader["FechaVencimiento"] is DBNull ? DateTime.MinValue : reader["FechaVencimiento"]),
                            Ciclo= reader["Ciclo"].ToString(),
                            FechaCreacion = Convert.ToDateTime(reader["FechaCreacion"] is DBNull ? DateTime.MinValue : reader["FechaCreacion"]),
                        
                            cursoPosgrado = new CursoPosgrado()
                            {
                                IdCursoPosgrado = Convert.ToInt32(reader["IdCursoPosgrado"]),
                                NombreCursoPosgrado = reader["NombreCursoPosgrado"].ToString(),
                               

                            },
                            cuota = new Cuota()
                            {
                                IdCuota = Convert.ToInt32(reader["IdCuota"]),
                                Descripcion = reader["Descripcion"].ToString(),

                            }


                        };
                        ControlCuotas.Add(ControlCuota);

                    }

                }




            }

            return ControlCuotas;
        }


        public List<ControlCuota> ObtenerControlCuotasValueText()
        {
            string spName = "[ControlCuota_GetAllValues]";
            List<ControlCuota> ControlCuotas = new List<ControlCuota>();

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
                        var ControlCuota = new ControlCuota
                        {

                            IdControlCuota = Convert.ToInt32(reader["IdControlCuota"]),
                            


                        };
                        ControlCuotas.Add(ControlCuota);

                    }

                }




            }

            return ControlCuotas;
        }

        public ControlCuota ObtenerControlCuotaPorCodigo(string codigoControlCuota)
        {

            string spName = "[ControlCuota_GetById]";

            List<ControlCuota> ControlCuotas = new List<ControlCuota>();
            ControlCuota item = null;


            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                con.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = spName;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdControlCuota", codigoControlCuota);
                cmd.Connection = con;


                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var ControlCuota = new ControlCuota
                        {

                            IdControlCuota = Convert.ToInt32(reader["IdControlCuota"]),
                            Monto = Convert.ToDecimal(reader["Monto"]),
                            FlagFinal = Convert.ToInt32(reader["FlagFinal"]),
                            FechaVencimiento = Convert.ToDateTime(reader["FechaVencimiento"] is DBNull ? DateTime.MinValue : reader["FechaVencimiento"]),
                            Ciclo = reader["Monto"].ToString(),
                            FechaCreacion = Convert.ToDateTime(reader["FechaCreacion"] is DBNull ? DateTime.MinValue : reader["FechaCreacion"]),

                            cursoPosgrado = new CursoPosgrado()
                            {
                                IdCursoPosgrado = Convert.ToInt32(reader["IdCursoPosgrado"]),
                                NombreCursoPosgrado = reader["NombreCursoPosgrado"].ToString(),


                            },
                            cuota = new Cuota()
                            {
                                IdCuota = Convert.ToInt32(reader["IdCuota"]),
                                Descripcion = reader["NroCuota"].ToString(),

                            }
                        };

                        ControlCuotas.Add(ControlCuota);
                        item = ControlCuota;

                    }

                }

            }

            return item;
        }


        public bool SaveControlCuota(ControlCuota ControlCuota)
        {
            string spName = "[ControlCuota_Save]";
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


                    cmd.Parameters.AddWithValue("@IdControlCuota", ControlCuota.IdControlCuota);
                    cmd.Parameters.AddWithValue("@IdCuota", ControlCuota.IdCuota);
                    cmd.Parameters.AddWithValue("@IdCursoPosgrado", ControlCuota.IdCursoPosgrado);
                    cmd.Parameters.AddWithValue("@Monto", ControlCuota.Monto);
                    cmd.Parameters.AddWithValue("@FlagFinal", ControlCuota.FlagFinal);
                    cmd.Parameters.AddWithValue("@FechaVencimiento ", ControlCuota.FechaVencimiento);
                    cmd.Parameters.AddWithValue("@Ciclo", ControlCuota.Ciclo);
                    cmd.Parameters.AddWithValue("@FechaCreacion", ControlCuota.FechaCreacion);
                 



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




        public bool EliminarControlCuotaPorCodigo(string codigoControlCuota)
        {

            string spName = "[ControlCuota_Delete]";

            List<ControlCuota> ControlCuotas = new List<ControlCuota>();
            var respuesta = false;


            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                con.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = spName;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdControlCuota", codigoControlCuota);
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
