using ET;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;


namespace DAL
{
    public class MatriculaDAL
    {


        readonly string ConnectionString = ConfigurationManager.ConnectionStrings["AATEConnectionString"].ConnectionString;

        #region [ Matricula ]

        public List<Matricula> ObtenerMatriculas()
        {
            string spName = "[Matricula_GetAll]";
            List<Matricula> Matriculas = new List<Matricula>();

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
                        var Matricula = new Matricula
                        {

                            Id_Matricula = Convert.ToInt32(reader["Id_Matricula"]),
                            CodigoMatricula = Convert.ToInt32(reader["CodigoMatricula"]),
                            Anho = Convert.ToInt32(reader["Anho"]),
                            Numero = Convert.ToInt32(reader["Numero"]),
                            Descripcion = reader["Descripcion"].ToString(),


                        };
                        Matriculas.Add(Matricula);

                    }

                }




            }

            return Matriculas;
        }

        public Matricula ObtenerMatriculaPorCodigo(string codigoMatricula)
        {

            string spName = "[Matricula_GetById]";

            List<Matricula> Matriculas = new List<Matricula>();
            Matricula item = null;


            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                con.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = spName;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id_Matricula", codigoMatricula);
                cmd.Connection = con;


                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var Matricula = new Matricula
                        {


                            Id_Matricula = Convert.ToInt32(reader["Id_Matricula"]),
                            CodigoMatricula = Convert.ToInt32(reader["CodigoMatricula"]),
                            Anho = Convert.ToInt32(reader["Anho"]),
                            Numero = Convert.ToInt32(reader["Numero"]),
                            Descripcion = reader["Descripcion"].ToString(),

                        };

                        Matriculas.Add(Matricula);
                        item = Matricula;

                    }

                }

            }

            return item;
        }


        public bool SaveMatricula(Matricula Matricula)
        {
            string spName = "[Matricula_Save]";
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

                    cmd.Parameters.AddWithValue("@Id_Matricula", Matricula.Id_Matricula);
                    cmd.Parameters.AddWithValue("@CodigoMatricula", Matricula.CodigoMatricula);
                    cmd.Parameters.AddWithValue("@Anho", Matricula.Anho);
                    cmd.Parameters.AddWithValue("@Numero", Matricula.Numero);
                    cmd.Parameters.AddWithValue("@Descripcion", Matricula.Descripcion);

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




        public bool EliminarMatriculaPorCodigo(string codigoMatricula)
        {

            string spName = "[Matricula_Delete]";

            List<Matricula> Matriculas = new List<Matricula>();
            var respuesta = false;

            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                con.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = spName;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id_Matricula", codigoMatricula);
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