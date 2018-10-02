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
    public  class CursoPosgradoDAL
    {

        readonly string ConnectionString = ConfigurationManager.ConnectionStrings["AATEConnectionString"].ConnectionString;

        #region [ CursoPosgrado ]

        public List<CursoPosgrado> ObtenerCursoPosgrados()
        {
            string spName = "[CursoPosgrado_GetAll]";
            List<CursoPosgrado> CursoPosgrados = new List<CursoPosgrado>();

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
                        var CursoPosgrado = new CursoPosgrado
                        {
                             
                            IdCursoPosgrado = Convert.ToInt32(reader["IdCursoPosgrado"]),
                            NombreCursoPosgrado =reader["NombreCursoPosgrado"].ToString(),
                            MontoTotal = Convert.ToDecimal( reader["MontoTotal"]),
                            Anio =Convert.ToInt32(reader["Anio"]),
                            IdOrganizacion = Convert.ToInt32(reader["IdOrganizacion"]),
                            IdConceptopago = Convert.ToInt32(reader["IdConceptopago"] is DBNull ? 0 : reader["IdConceptopago"]),
                            IdEstado = Convert.ToInt32(reader["IdEstado"]),
                            FechaCreacion = Convert.ToDateTime(reader["FechaCreacion"] is DBNull ? DateTime.MinValue : reader["FechaCreacion"]),
                            FechaActualizacion = Convert.ToDateTime(reader["FechaActualizacion"] is DBNull ? DateTime.MinValue : reader["FechaActualizacion"]),
                            chkActiveDeactive = Convert.ToBoolean(reader["chkActiveDeactive"] is DBNull ? 0 : reader["chkActiveDeactive"]),
                            concepto = new ConceptoPago()
                            {
                                IdConceptoPago= Convert.ToInt32(reader["IdConceptoPago"]),
                                Descripcion = reader["Descripcion"].ToString(),
                                NroConcepto = reader["NroConcepto"].ToString(),

                            }


                        };
                        CursoPosgrados.Add(CursoPosgrado);

                    }

                }




            }

            return CursoPosgrados;
        }


        public List<CursoPosgrado> ObtenerCursoPosgradosValueText()
        {
            string spName = "[CursoPosgrado_GetAllValues]";
            List<CursoPosgrado> CursoPosgrados = new List<CursoPosgrado>();

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
                        var CursoPosgrado = new CursoPosgrado
                        {

                            IdCursoPosgrado = Convert.ToInt32(reader["IdCursoPosgrado"]),
                            NombreCursoPosgrado = reader["NombreCursoPosgrado"].ToString(),
                   


                        };
                        CursoPosgrados.Add(CursoPosgrado);

                    }

                }




            }

            return CursoPosgrados;
        }

        public CursoPosgrado ObtenerCursoPosgradoPorCodigo(string codigoCursoPosgrado)
        {

            string spName = "[CursoPosgrado_GetById]";

            List<CursoPosgrado> CursoPosgrados = new List<CursoPosgrado>();
            CursoPosgrado item = null;


            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                con.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = spName;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdCursoPosgrado", codigoCursoPosgrado);
                cmd.Connection = con;


                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var CursoPosgrado = new CursoPosgrado
                        {

                            IdCursoPosgrado = Convert.ToInt32(reader["IdCursoPosgrado"]),
                            NombreCursoPosgrado = reader["NombreCursoPosgrado"].ToString(),
                            MontoTotal = Convert.ToDecimal(reader["MontoTotal"]),
                            Anio = Convert.ToInt32(reader["Anio"]),
                            IdEstado = Convert.ToInt32(reader["IdEstado"]),
                            IdOrganizacion = Convert.ToInt32(reader["IdOrganizacion"]),
                            IdConceptopago = Convert.ToInt32(reader["IdConceptopago"] is DBNull ? 0 : reader["IdConceptopago"]),
                            FechaCreacion = Convert.ToDateTime(reader["FechaCreacion"] is DBNull ? DateTime.MinValue : reader["FechaCreacion"]),
                            FechaActualizacion = Convert.ToDateTime(reader["FechaActualizacion"] is DBNull ? DateTime.MinValue : reader["FechaActualizacion"]),
                            chkActiveDeactive = Convert.ToBoolean(reader["chkActiveDeactive"] is DBNull ? 0 : reader["chkActiveDeactive"]),

                        };

                        CursoPosgrados.Add(CursoPosgrado);
                        item = CursoPosgrado;

                    }

                }

            }

            return item;
        }


        public bool SaveCursoPosgrado(CursoPosgrado CursoPosgrado)
        {
            string spName = "[CursoPosgrado_Save]";
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


                    cmd.Parameters.AddWithValue("@IdCursoPosgrado", CursoPosgrado.IdCursoPosgrado);
                    cmd.Parameters.AddWithValue("@NombreCursoPosgrado", CursoPosgrado.NombreCursoPosgrado);
                    cmd.Parameters.AddWithValue("@MontoTotal", CursoPosgrado.MontoTotal);
                    cmd.Parameters.AddWithValue("@Anio", CursoPosgrado.Anio);
                    cmd.Parameters.AddWithValue("@IdOrganizacion", CursoPosgrado.IdOrganizacion);
                    cmd.Parameters.AddWithValue("@IdConceptopago ", CursoPosgrado.IdConceptopago);
                    cmd.Parameters.AddWithValue("@UserCreacion", CursoPosgrado.UserCreacion);
                    cmd.Parameters.AddWithValue("@FechaCreacion", CursoPosgrado.FechaCreacion);
                    cmd.Parameters.AddWithValue("@Estado", CursoPosgrado.IdEstado);
                    cmd.Parameters.AddWithValue("@checkEstado", CursoPosgrado.chkActiveDeactive);


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




        public bool EliminarCursoPosgradoPorCodigo(string codigoCursoPosgrado)
        {

            string spName = "[CursoPosgrado_Delete]";

            List<CursoPosgrado> CursoPosgrados = new List<CursoPosgrado>();
            var respuesta = false;


            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                con.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = spName;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdCursoPosgrado", codigoCursoPosgrado);
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
