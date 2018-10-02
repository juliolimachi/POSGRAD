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
    public  class EstadoDAL
    {
        readonly string ConnectionString = ConfigurationManager.ConnectionStrings["AATEConnectionString"].ConnectionString;

        #region [ Estado ]

        public List<Estado> ObtenerEstados()
        {
            string spName = "[Estado_GetAll]";
            List<Estado> Estados = new List<Estado>();

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
                        var Estado = new Estado
                        {

                            IdEstado = Convert.ToInt32(reader["IdEstado"]),
                            Descripcion = reader["Descripcion"].ToString(),
                            TipoTabla = Convert.ToInt32(reader["TipoTabla"]),
                        

                        };
                        Estados.Add(Estado);

                    }

                }




            }

            return Estados;
        }

        public Estado ObtenerEstadoPorCodigo(string codigoEstado)
        {

            string spName = "[Estado_GetById]";

            List<Estado> Estados = new List<Estado>();
            Estado item = null;


            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                con.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = spName;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdEstado", codigoEstado);
                cmd.Connection = con;


                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var Estado = new Estado
                        {

                            IdEstado = Convert.ToInt32(reader["IdEstado"]),
                            Descripcion = reader["Descripcion"].ToString(),
                            TipoTabla = Convert.ToInt32(reader["TipoTabla"]),
                         

                        };

                        Estados.Add(Estado);
                        item = Estado;

                    }

                }

            }

            return item;
        }



        public Estado ObtenerEstadoPorNroConcepto(string codigoEstado)
        {

            string spName = "[Estado_GetBy_like]";

            List<Estado> Estados = new List<Estado>();
            Estado item = null;


            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                con.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = spName;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@start", codigoEstado);
                cmd.Connection = con;


                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var Estado = new Estado
                        {

                            IdEstado = Convert.ToInt32(reader["IdEstado"]),
                            Descripcion = reader["Descripcion"].ToString(),
                            TipoTabla = Convert.ToInt32(reader["TipoTabla"]),
                      


                        };

                        Estados.Add(Estado);
                        item = Estado;

                    }

                }

            }

            return item;
        }

        public bool SaveEstado(Estado Estado)
        {
            string spName = "[Estado_Save]";
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

                    cmd.Parameters.AddWithValue("@IdEstado", Estado.IdEstado);
                    cmd.Parameters.AddWithValue("@Descripcion", Estado.Descripcion);
                    cmd.Parameters.AddWithValue("@TipoTabla", Estado.TipoTabla);

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




        public bool EliminarEstadoPorCodigo(string codigoEstado)
        {

            string spName = "[Estado_Delete]";

            List<Estado> Estados = new List<Estado>();
            var respuesta = false;


            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                con.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = spName;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdEstado", codigoEstado);
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
