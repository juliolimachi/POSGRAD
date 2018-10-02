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
  public  class ConceptoPagoDAL
    {

        readonly string ConnectionString = ConfigurationManager.ConnectionStrings["AATEConnectionString"].ConnectionString;

        #region [ ConceptoPago ]

        public List<ConceptoPago> ObtenerConceptoPagos()
        {
            string spName = "[ConceptoPago_GetAll]";
            List<ConceptoPago> ConceptoPagos = new List<ConceptoPago>();

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
                        var ConceptoPago = new ConceptoPago
                        {

                            IdConceptoPago = Convert.ToInt32(reader["IdConceptoPago"]),
                            NroConcepto = reader["NroConcepto"].ToString(),
                            Descripcion = reader["Descripcion"].ToString(),
                            FechaCreacion = Convert.ToDateTime(reader["FechaCreacion"] is DBNull ? null : reader["FechaCreacion"]),
                            Estado = Convert.ToInt32(reader["Estado"]is DBNull ? 0 : reader["Estado"]),
                            
                          
                        };
                        ConceptoPagos.Add(ConceptoPago);

                    }

                }




            }

            return ConceptoPagos;
        }

        public ConceptoPago ObtenerConceptoPagoPorCodigo(string codigoConceptoPago)
        {

            string spName = "[ConceptoPago_GetById]";

            List<ConceptoPago> ConceptoPagos = new List<ConceptoPago>();
            ConceptoPago item = null;


            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                con.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = spName;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdConceptoPago", codigoConceptoPago);
                cmd.Connection = con;


                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var ConceptoPago = new ConceptoPago
                        {

                            IdConceptoPago = Convert.ToInt32(reader["IdConceptoPago"]),
                            NroConcepto = reader["NroConcepto"].ToString(),
                            Descripcion = reader["Descripcion"].ToString(),
                            FechaCreacion = Convert.ToDateTime(reader["FechaCreacion"] is DBNull ? null : reader["FechaCreacion"]),
                            Estado = Convert.ToInt32(reader["Estado"] is DBNull ? 0 : reader["Estado"]),
                
                        };

                        ConceptoPagos.Add(ConceptoPago);
                        item = ConceptoPago;

                    }

                }

            }

            return item;
        }



        public ConceptoPago ObtenerConceptoPagoPorNroConcepto(string codigoConceptoPago)
        {

            string spName = "[ConceptoPago_GetBy_like]";

            List<ConceptoPago> ConceptoPagos = new List<ConceptoPago>();
            ConceptoPago item = null;


            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                con.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = spName;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@start", codigoConceptoPago);
                cmd.Connection = con;


                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var ConceptoPago = new ConceptoPago
                        {

                            IdConceptoPago = Convert.ToInt32(reader["IdConceptoPago"]),
                            NroConcepto = reader["NroConcepto"].ToString(),
                      

                        };

                        ConceptoPagos.Add(ConceptoPago);
                        item = ConceptoPago;

                    }

                }

            }

            return item;
        }

        public bool SaveConceptoPago(ConceptoPago ConceptoPago)
        {
            string spName = "[ConceptoPago_Save]";
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

                    cmd.Parameters.AddWithValue("@IdConceptoPago", ConceptoPago.IdConceptoPago);
                    cmd.Parameters.AddWithValue("@NroConcepto", ConceptoPago.NroConcepto);
                    cmd.Parameters.AddWithValue("@Descripcion", ConceptoPago.Descripcion);
                    cmd.Parameters.AddWithValue("@FechaCreacion", ConceptoPago.FechaCreacion);
                    cmd.Parameters.AddWithValue("@Estado", ConceptoPago.Estado);
            
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




        public bool EliminarConceptoPagoPorCodigo(string codigoConceptoPago)
        {

            string spName = "[ConceptoPago_Delete]";

            List<ConceptoPago> ConceptoPagos = new List<ConceptoPago>();
            var respuesta = false;


            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                con.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = spName;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdConceptoPago", codigoConceptoPago);
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
