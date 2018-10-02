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
    public class AlumnoDAL
    {

        readonly string ConnectionString = ConfigurationManager.ConnectionStrings["AATEConnectionString"].ConnectionString;

        #region [ Alumno ]

        public List<Alumno> ObtenerAlumnos()
        {
            string spName = "[Alumno_GetAll]";
            List<Alumno> Alumnos = new List<Alumno>();

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
                        var Alumno = new Alumno
                        {

                            IdAlumno = Convert.ToInt32(reader["IdAlumno"]),
                            NroDocumento = reader["NroDocumento"].ToString(),
                            NombreCompleto = reader["NombreCompleto"].ToString(),
                            CodigoMatricula = Convert.ToInt32(reader["CodigoMatricula"]),
                            NroTelefono = Convert.ToInt32(reader["NroTelefono"]),
                            IdCursoPosgrado = Convert.ToInt32(reader["IdCursoPosgrado"]),
                            Sexo= reader["Sexo"].ToString(),
                            AnhoIngreso = Convert.ToInt32(reader["AnhoIngreso"])
                        };
                        Alumnos.Add(Alumno);

                    }

                }




            }

            return Alumnos;
        }

        public Alumno ObtenerAlumnoPorCodigo(string codigoAlumno)
        {

            string spName = "[Alumno_GetById]";

            List<Alumno> Alumnos = new List<Alumno>();
            Alumno item = null;


            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                con.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = spName;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdAlumno", codigoAlumno);
                cmd.Connection = con;


                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var Alumno = new Alumno
                        {

                            IdAlumno = Convert.ToInt32(reader["IdAlumno"]),
                            NroDocumento = reader["NroDocumento"].ToString(),
                            NombreCompleto = reader["NombreCompleto"].ToString(),
                            CodigoMatricula = Convert.ToInt32(reader["CodigoMatricula"]),
                            IdCursoPosgrado = Convert.ToInt32(reader["IdCursoPosgrado"]),
                            Nombres= reader["Nombres"].ToString(),
                            ApeMaterno = reader["ApeMaterno"].ToString(),
                            ApePaterno = reader["ApePaterno"].ToString(),
                            NroTelefono= Convert.ToInt32(reader["NroTelefono"]),
                            Sexo = reader["Sexo"].ToString(),
                            AnhoIngreso = Convert.ToInt32(reader["AnhoIngreso"]),
                        };

                        Alumnos.Add(Alumno);
                        item = Alumno;

                    }

                }

            }

            return item;
        }


        public bool SaveAlumno(Alumno Alumno)
        {
            string spName = "[Alumno_Save]";
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


                    cmd.Parameters.AddWithValue("@IdAlumno", Alumno.IdAlumno);
                    cmd.Parameters.AddWithValue("@NroDocumento", Alumno.NroDocumento);
                    cmd.Parameters.AddWithValue("@NombreCompleto", Alumno.NombreCompleto);
                    cmd.Parameters.AddWithValue("@CodigoMatricula", Alumno.CodigoMatricula);
                    cmd.Parameters.AddWithValue("@IdCursoPosgrado",Alumno.IdCursoPosgrado);
                    cmd.Parameters.AddWithValue("@Sexo", Alumno.Sexo);
                    cmd.Parameters.AddWithValue("@AnhoIngreso", Alumno.AnhoIngreso);

               





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


        public bool ActualizarAlumno(Alumno alumno)
        {
            string spName = "[gen].[usp_Alumno_Update]";
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

                    cmd.Parameters.AddWithValue("@IdAlumno", alumno.IdAlumno);
                    cmd.Parameters.AddWithValue("@NroDocumento", alumno.NroDocumento);
                    cmd.Parameters.AddWithValue("@NombreCompleto", alumno.NombreCompleto);
                    cmd.Parameters.AddWithValue("@CodigoMatricula", alumno.CodigoMatricula);
                    cmd.Parameters.AddWithValue("@ApeMaterno", alumno.ApeMaterno);
                    cmd.Parameters.AddWithValue("@ApePaterno", alumno.ApePaterno);
                    cmd.Parameters.AddWithValue("@Nombres", alumno.Nombres);
                    cmd.Parameters.AddWithValue("@IdCursoPosgrado", alumno.IdCursoPosgrado);
                    cmd.Parameters.AddWithValue("@NroTelefono", alumno.NroTelefono);
                    cmd.Parameters.AddWithValue("@Sexo", alumno.Sexo);
                    cmd.Parameters.AddWithValue("@AnhoIngreso", alumno.AnhoIngreso);
                    cmd.Parameters.AddWithValue("@IdOrganizacion",1);

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

        public bool RegistrarAlumno(Alumno alumno)
        {
            string spName = "[Alumno_Save]";
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


                    cmd.Parameters.AddWithValue("@IdAlumno", alumno.IdAlumno);
                    cmd.Parameters.AddWithValue("@NroDocumento", alumno.NroDocumento);
                    cmd.Parameters.AddWithValue("@NombreCompleto", alumno.ApePaterno+" "+alumno.ApeMaterno+" "+ alumno.Nombres);
                    cmd.Parameters.AddWithValue("@CodigoMatricula", alumno.CodigoMatricula);
                    cmd.Parameters.AddWithValue("@ApeMaterno", alumno.ApeMaterno);
                    cmd.Parameters.AddWithValue("@ApePaterno", alumno.ApePaterno);
                    cmd.Parameters.AddWithValue("@Nombres", alumno.Nombres);
                    cmd.Parameters.AddWithValue("@IdCursoPosgrado", alumno.IdCursoPosgrado);
                    cmd.Parameters.AddWithValue("@NroTelefono", alumno.NroTelefono);
                    cmd.Parameters.AddWithValue("@Sexo", alumno.Sexo);
                    cmd.Parameters.AddWithValue("@AnhoIngreso", alumno.AnhoIngreso);
                    cmd.Parameters.AddWithValue("@IdOrganizacion", 1);



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



        public bool EliminarAlumnoPorCodigo(string codigoAlumno)
        {

            string spName = "[Alumno_Delete]";

            List<Alumno> Alumnos = new List<Alumno>();
            var respuesta = false;


            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                con.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = spName;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdAlumno", codigoAlumno);
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
