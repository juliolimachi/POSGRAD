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



    public class PagoCuotaDAL
    {
        readonly string ConnectionString = ConfigurationManager.ConnectionStrings["AATEConnectionString"].ConnectionString;

        #region [ PagoCuota ]

        //public List<PagoCuota> ObtenerPagoCuotas()
        //{
        //    string spName = "[PagoCuota_GetAll]";
        //    List<PagoCuota> PagoCuotas = new List<PagoCuota>();

        //    using (SqlConnection con = new SqlConnection(ConnectionString))
        //    {
        //        con.Open();

        //        SqlCommand cmd = new SqlCommand();
        //        cmd.CommandText = spName;
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.Connection = con;

        //        using (var reader = cmd.ExecuteReader())
        //        {
        //            while (reader.Read())
        //            {
        //                var PagoCuota = new PagoCuota
        //                {

        //                    IdPagoCuota = Convert.ToInt32(reader["IdPagoCuota"]),
        //                    NroConcepto = reader["NroConcepto"].ToString(),
        //                    Descripcion = reader["Descripcion"].ToString(),
        //                    FechaCreacion = Convert.ToDateTime(reader["FechaCreacion"]),
        //                    Estado = Convert.ToInt32(reader["Estado"] is DBNull ? 0 : reader["Estado"]),


        //                };
        //                PagoCuotas.Add(PagoCuota);

        //            }

        //        }




        //    }

        //    return PagoCuotas;
        //}

        //public PagoCuota ObtenerPagoCuotaPorCodigo(string codigoPagoCuota)
        //{

        //    string spName = "[PagoCuota_GetById]";

        //    List<PagoCuota> PagoCuotas = new List<PagoCuota>();
        //    PagoCuota item = null;


        //    using (SqlConnection con = new SqlConnection(ConnectionString))
        //    {
        //        con.Open();

        //        SqlCommand cmd = new SqlCommand();
        //        cmd.CommandText = spName;
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.Parameters.AddWithValue("@IdPagoCuota", codigoPagoCuota);
        //        cmd.Connection = con;


        //        using (var reader = cmd.ExecuteReader())
        //        {
        //            while (reader.Read())
        //            {
        //                var PagoCuota = new PagoCuota
        //                {

        //                    IdPagoCuota = Convert.ToInt32(reader["IdPagoCuota"]),
        //                    NroConcepto = reader["NroConcepto"].ToString(),
        //                    Descripcion = reader["Descripcion"].ToString(),
        //                    FechaCreacion = Convert.ToDateTime(reader["FechaCreacion"]),
        //                    Estado = Convert.ToInt32(reader["Estado"] is DBNull ? 0 : reader["Estado"]),

        //                };

        //                PagoCuotas.Add(PagoCuota);
        //                item = PagoCuota;

        //            }

        //        }

        //    }

        //    return item;
        //}



        //public PagoCuota ObtenerPagoCuotaPorNroConcepto(string codigoPagoCuota)
        //{

        //    string spName = "[PagoCuota_GetBy_like]";

        //    List<PagoCuota> PagoCuotas = new List<PagoCuota>();
        //    PagoCuota item = null;


        //    using (SqlConnection con = new SqlConnection(ConnectionString))
        //    {
        //        con.Open();

        //        SqlCommand cmd = new SqlCommand();
        //        cmd.CommandText = spName;
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.Parameters.AddWithValue("@start", codigoPagoCuota);
        //        cmd.Connection = con;


        //        using (var reader = cmd.ExecuteReader())
        //        {
        //            while (reader.Read())
        //            {
        //                var PagoCuota = new PagoCuota
        //                {

        //                    IdPagoCuota = Convert.ToInt32(reader["IdPagoCuota"]),
        //                    NroConcepto = reader["NroConcepto"].ToString(),


        //                };

        //                PagoCuotas.Add(PagoCuota);
        //                item = PagoCuota;

        //            }

        //        }

        //    }

        //    return item;
        //}

        public bool SavePagoCuota(int idalumno,int idcontrolcuota,int idpago)
        {
            string spName = "[PagoCuota_Save]";
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

                    cmd.Parameters.AddWithValue("@IdPagoCuota", 0);
                    cmd.Parameters.AddWithValue("@IdAlumno", idalumno);
                    cmd.Parameters.AddWithValue("@IdControlCuota", idcontrolcuota);
                    cmd.Parameters.AddWithValue("@IdPago", idpago);
           

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




        //public bool EliminarPagoCuotaPorCodigo(string codigoPagoCuota)
        //{

        //    string spName = "[PagoCuota_Delete]";

        //    List<PagoCuota> PagoCuotas = new List<PagoCuota>();
        //    var respuesta = false;


        //    using (SqlConnection con = new SqlConnection(ConnectionString))
        //    {
        //        con.Open();

        //        SqlCommand cmd = new SqlCommand();
        //        cmd.CommandText = spName;
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.Parameters.AddWithValue("@IdPagoCuota", codigoPagoCuota);
        //        cmd.Connection = con;


        //        cmd.ExecuteNonQuery();

        //        if (con.State != ConnectionState.Closed)
        //        {
        //            con.Close();
        //        }

        //        respuesta = true;
        //    }

        //    return respuesta;

        //}


        #endregion



    }

}
