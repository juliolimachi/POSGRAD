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
    public class OrganizacionDAL
    {

        readonly string ConnectionString = ConfigurationManager.ConnectionStrings["AATEConnectionString"].ConnectionString;

        #region [ Organizacion ]

        public List<Organizacion> ObtenerOrganizacions()
        {
            string spName = "[Organizacion_GetAll]";
            List<Organizacion> Organizacions = new List<Organizacion>();

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
                        var Organizacion = new Organizacion
                        {
                            IdOrganizacion = Convert.ToInt32(reader["IdOrganizacion"]),
                            NombreOrganizacion =reader["NombreOrganizacion"].ToString(),
                            Estado = Convert.ToInt32(reader["Estado"]),
                            FechaCreacion = Convert.ToDateTime(reader["FechaCreacion"])

                        };
                        Organizacions.Add(Organizacion);

                    }

                }




            }

            return Organizacions;
        }

        public Organizacion ObtenerOrganizacionPorCodigo(string codigoOrganizacion)
        {

            string spName = "[Organizacion_GetById]";

            List<Organizacion> Organizacions = new List<Organizacion>();
            Organizacion item = null;


            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                con.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = spName;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdOrganizacion", codigoOrganizacion);
                cmd.Connection = con;


                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var Organizacion = new Organizacion
                        {

                            IdOrganizacion = Convert.ToInt32(reader["IdOrganizacion"]),
                            NombreOrganizacion = reader["NombreOrganizacion"].ToString(),
                            Estado = Convert.ToInt32(reader["Estado"]),
                            FechaCreacion = Convert.ToDateTime(reader["FechaCreacion"])


                        };

                        Organizacions.Add(Organizacion);
                        item = Organizacion;

                    }

                }

            }

            return item;
        }


        public bool SaveOrganizacion(Organizacion Organizacion)
        {
            string spName = "[Organizacion_Save]";
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

                    cmd.Parameters.AddWithValue("@IdOrganizacion", Organizacion.IdOrganizacion);
                    cmd.Parameters.AddWithValue("@NombreOrganizacion", Organizacion.NombreOrganizacion);
                    cmd.Parameters.AddWithValue("@Estado", Organizacion.Estado);
                    cmd.Parameters.AddWithValue("@FechaCreacion", Organizacion.FechaCreacion);
               
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




        public bool EliminarOrganizacionPorCodigo(string codigoOrganizacion)
        {

            string spName = "[Organizacion_Delete]";

            List<Organizacion> Organizacions = new List<Organizacion>();
            var respuesta = false;


            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                con.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = spName;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdOrganizacion", codigoOrganizacion);
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
