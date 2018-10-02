using ET;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
namespace DAL
{
    public class AlumnoMatriculaDAL
    {

        readonly string ConnectionString = ConfigurationManager.ConnectionStrings["AATEConnectionString"].ConnectionString;

        #region [ AlumnoMatricula ]

        public List<AlumnoMatricula> ObtenerAlumnoMatriculas()
        {
            string spName = "[AlumnoMatricula_GetAll]";
            List<AlumnoMatricula> AlumnoMatriculas = new List<AlumnoMatricula>();

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
                        var AlumnoMatricula = new AlumnoMatricula
                        {

                            IdAlumnoMatricula = Convert.ToInt32(reader["IdAlumnoMatriculado"]),
                            CodigoAlumno = Convert.ToInt32(reader["CodigoAlumno"]),
                            NombreAlumno = reader["NombreAlumno"].ToString(),
                            CreditoAlumno = Convert.ToInt32(reader["CreditoAlumno"]),
                            Especialidad = Convert.ToInt32(reader["Especialidad"]),
                            Sexo = reader["Sexo"].ToString(),
                            Ciclo = Convert.ToInt32(reader["Ciclo"]),
                            AnhoIngreso = Convert.ToInt32(reader["AnhoIngreso"]),
                            UsuarioRegistro = reader["UsuarioRegistro"].ToString(),
                            FechaMatricula = Convert.ToDateTime(reader["FechaMatricula"]),
                            FlagTercioSuperior = Convert.ToInt32(reader["FlagTercioSuperior"] is DBNull ? 0 : reader["FlagTercioSuperior"]),
                            FlagQuintoSuperior = Convert.ToInt32(reader["FlagQuintoSuperior"] is DBNull ? 0 : reader["FlagQuintoSuperior"]),
                            FlagCerrado = Convert.ToInt32(reader["FlagCerrado"] is DBNull ? 0 : reader["FlagCerrado"]),
                            Promedio = Convert.ToDecimal(reader["Promedio"] is DBNull ? 0 : reader["Promedio"]),
                            IdCiclo = Convert.ToInt32(reader["IdCiclo"]),
                            IdAlumno = Convert.ToInt32(reader["IdAlumno"] is DBNull ? 0 : reader["IdAlumno"]),
                            MontoCiclo = Convert.ToInt32(reader["MontoCiclo"]),
                            PrecioCredito = Convert.ToInt32(reader["PrecioCredito"]),
                         
                            CodigoSemestre= Convert.ToInt32(reader["CodigoSemestre"]),
                            IdPrograma = Convert.ToInt32(reader["IdPrograma"])

                        };
                        AlumnoMatriculas.Add(AlumnoMatricula);

                    }

                }


            }

            return AlumnoMatriculas;
        }

        public AlumnoMatricula ObtenerAlumnoMatriculaPorCodigo(string codigoAlumnoMatricula)
        {

            string spName = "[AlumnoMatricula_GetById]";

            List<AlumnoMatricula> AlumnoMatriculas = new List<AlumnoMatricula>();
            AlumnoMatricula item = null;


            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                con.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = spName;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdAlumnoMatriculado", codigoAlumnoMatricula);
                cmd.Connection = con;


                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var AlumnoMatricula = new AlumnoMatricula
                        {

                            IdAlumnoMatricula = Convert.ToInt32(reader["IdAlumnoMatriculado"]),
                            CodigoAlumno = Convert.ToInt32(reader["CodigoAlumno"]),
                            NombreAlumno = reader["NombreAlumno"].ToString(),
                            CreditoAlumno = Convert.ToInt32(reader["CreditoAlumno"]),
                            Especialidad = Convert.ToInt32(reader["Especialidad"]),
                            Sexo = reader["Sexo"].ToString(),
                            Ciclo = Convert.ToInt32(reader["Ciclo"]),
                            AnhoIngreso = Convert.ToInt32(reader["AnhoIngreso"]),
                            UsuarioRegistro = reader["UsuarioRegistro"].ToString(),
                            FechaMatricula = Convert.ToDateTime(reader["FechaMatricula"]),
                            FlagTercioSuperior = Convert.ToInt32(reader["FlagTercioSuperior"] is DBNull? 0:reader["FlagTercioSuperior"] ),
                            FlagQuintoSuperior = Convert.ToInt32(reader["FlagQuintoSuperior"] is DBNull? 0 : reader["FlagQuintoSuperior"]),
                            FlagCerrado = Convert.ToInt32(reader["FlagCerrado"] is DBNull ? 0 : reader["FlagCerrado"]),
                            Promedio = Convert.ToDecimal(reader["Promedio"] is DBNull ? 0 : reader["Promedio"]),
                            IdCiclo = Convert.ToInt32(reader["IdCiclo"]),
                            IdAlumno = Convert.ToInt32(reader["IdAlumno"] is DBNull ? 0 : reader["IdAlumno"]),
                            MontoCiclo = Convert.ToInt32(reader["MontoCiclo"]),
                            PrecioCredito = Convert.ToInt32(reader["PrecioCredito"]),
                            CodigoSemestre = Convert.ToInt32(reader["CodigoSemestre"]),
                            IdPrograma = Convert.ToInt32(reader["IdPrograma"])


                        };

                        AlumnoMatriculas.Add(AlumnoMatricula);
                        item = AlumnoMatricula;

                    }

                }

            }

            return item;
        }


        public bool SaveAlumnoMatricula(AlumnoMatricula alumnoMatricula)
        {
            string spName = "[AlumnoMatricula_Save]";
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

                    

                    cmd.Parameters.AddWithValue("@IdAlumnoMatriculado", alumnoMatricula.IdAlumnoMatricula);
                    cmd.Parameters.AddWithValue("@CodigoAlumno", alumnoMatricula.CodigoAlumno);
                    cmd.Parameters.AddWithValue("@NombreAlumno", alumnoMatricula.NombreAlumno);
                    cmd.Parameters.AddWithValue("@CreditoAlumno", alumnoMatricula.CreditoAlumno);
                    cmd.Parameters.AddWithValue("@Especialidad", alumnoMatricula.Especialidad);
                    cmd.Parameters.AddWithValue("@Sexo", alumnoMatricula.Sexo);
                    cmd.Parameters.AddWithValue("@Ciclo", alumnoMatricula.Ciclo);
                    cmd.Parameters.AddWithValue("@AnhoIngreso", alumnoMatricula.AnhoIngreso);
                    cmd.Parameters.AddWithValue("@UsuarioRegistro", alumnoMatricula.UsuarioRegistro);
                    cmd.Parameters.AddWithValue("@FechaMatricula", alumnoMatricula.FechaMatricula);
                    cmd.Parameters.AddWithValue("@FlagTercioSuperior", alumnoMatricula.FlagTercioSuperior);
                    cmd.Parameters.AddWithValue("@FlagQuintoSuperior", alumnoMatricula.FlagQuintoSuperior);
                    cmd.Parameters.AddWithValue("@FlagCerrado", alumnoMatricula.FlagCerrado);
                    cmd.Parameters.AddWithValue("@Promedio", alumnoMatricula.Promedio);
                    cmd.Parameters.AddWithValue("@IdCiclo", alumnoMatricula.IdCiclo);
                    cmd.Parameters.AddWithValue("@IdAlumno", alumnoMatricula.IdAlumno);
                    cmd.Parameters.AddWithValue("@MontoCiclo", alumnoMatricula.MontoCiclo);
                    cmd.Parameters.AddWithValue("@PrecioCredito", alumnoMatricula.PrecioCredito);
            
                    cmd.Parameters.AddWithValue("@CodigoSemestre", alumnoMatricula.CodigoSemestre);
                    cmd.Parameters.AddWithValue("@IdPrograma", alumnoMatricula.IdPrograma);







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


        public bool ActualizarAlumnoMatricula(AlumnoMatricula alumnoMatricula)
        {
            string spName = "[AlumnoMatricula_Save]";
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

                    cmd.Parameters.AddWithValue("@IdAlumnoMatriculado", alumnoMatricula.IdAlumnoMatricula);
                    cmd.Parameters.AddWithValue("@CodigoAlumno", alumnoMatricula.CodigoAlumno);
                    cmd.Parameters.AddWithValue("@NombreAlumno", alumnoMatricula.NombreAlumno);
                    cmd.Parameters.AddWithValue("@CreditoAlumno", alumnoMatricula.CreditoAlumno);
                    cmd.Parameters.AddWithValue("@Especialidad", alumnoMatricula.Especialidad);
                    cmd.Parameters.AddWithValue("@Sexo", alumnoMatricula.Sexo);
                    cmd.Parameters.AddWithValue("@Ciclo", alumnoMatricula.Ciclo);
                    cmd.Parameters.AddWithValue("@AnhoIngreso", alumnoMatricula.AnhoIngreso);
                    cmd.Parameters.AddWithValue("@UsuarioRegistro", alumnoMatricula.UsuarioRegistro);
                    cmd.Parameters.AddWithValue("@FechaMatricula", alumnoMatricula.FechaMatricula);
                    cmd.Parameters.AddWithValue("@FlagTercioSuperior", alumnoMatricula.FlagTercioSuperior);
                    cmd.Parameters.AddWithValue("@FlagQuintoSuperior", alumnoMatricula.FlagQuintoSuperior);
                    cmd.Parameters.AddWithValue("@FlagCerrado", alumnoMatricula.FlagCerrado);
                    cmd.Parameters.AddWithValue("@Promedio", alumnoMatricula.Promedio);
                    cmd.Parameters.AddWithValue("@IdCiclo", alumnoMatricula.IdCiclo);
                    cmd.Parameters.AddWithValue("@IdAlumno", alumnoMatricula.IdAlumno);
                    cmd.Parameters.AddWithValue("@MontoCiclo", alumnoMatricula.MontoCiclo);
                    cmd.Parameters.AddWithValue("@PrecioCredito", alumnoMatricula.PrecioCredito);
                    cmd.Parameters.AddWithValue("@CodigoSemestre", alumnoMatricula.CodigoSemestre);
                    cmd.Parameters.AddWithValue("@IdPrograma", alumnoMatricula.IdPrograma);



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

        public bool RegistrarAlumnoMatricula(AlumnoMatricula alumnoMatricula)
        {
            string spName = "[AlumnoMatricula_Save]";
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


                    cmd.Parameters.AddWithValue("@IdAlumnoMatricula", alumnoMatricula.IdAlumnoMatricula);
                    cmd.Parameters.AddWithValue("@CodigoAlumno", alumnoMatricula.CodigoAlumno);
                    cmd.Parameters.AddWithValue("@NombreAlumno", alumnoMatricula.NombreAlumno);
                    cmd.Parameters.AddWithValue("@CreditoAlumno", alumnoMatricula.CreditoAlumno);
                    cmd.Parameters.AddWithValue("@Especialidad", alumnoMatricula.Especialidad);
                    cmd.Parameters.AddWithValue("@Sexo", alumnoMatricula.Sexo);
                    cmd.Parameters.AddWithValue("@Ciclo", alumnoMatricula.Ciclo);
                    cmd.Parameters.AddWithValue("@AnhoIngreso", alumnoMatricula.AnhoIngreso);
                    cmd.Parameters.AddWithValue("@UsuarioRegistro", alumnoMatricula.UsuarioRegistro);
                    cmd.Parameters.AddWithValue("@FechaMatricula", alumnoMatricula.FechaMatricula);
                    cmd.Parameters.AddWithValue("@FlagTercioSuperior", alumnoMatricula.FlagTercioSuperior);
                    cmd.Parameters.AddWithValue("@FlagQuintoSuperior", alumnoMatricula.FlagQuintoSuperior);
                    cmd.Parameters.AddWithValue("@FlagCerrado", alumnoMatricula.FlagCerrado);
                    cmd.Parameters.AddWithValue("@Promedio", alumnoMatricula.Promedio);
                    cmd.Parameters.AddWithValue("@IdCiclo", alumnoMatricula.IdCiclo);
                    cmd.Parameters.AddWithValue("@IdAlumno", alumnoMatricula.IdAlumno);
                    cmd.Parameters.AddWithValue("@MontoCiclo", alumnoMatricula.MontoCiclo);
                    cmd.Parameters.AddWithValue("@PrecioCredito", alumnoMatricula.PrecioCredito);
   
                    cmd.Parameters.AddWithValue("@CodigoSemestre", alumnoMatricula.CodigoSemestre);
                    cmd.Parameters.AddWithValue("@IdPrograma", alumnoMatricula.IdPrograma);


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



        public bool EliminarAlumnoMatriculaPorCodigo(string codigoAlumnoMatricula)
        {

            string spName = "[AlumnoMatricula_Delete]";

            List<AlumnoMatricula> AlumnoMatriculas = new List<AlumnoMatricula>();
            var respuesta = false;


            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                con.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = spName;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdAlumnoMatricula", codigoAlumnoMatricula);
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







        public bool InsertarAlumnoMatriculaJson(List<AlumnoMatricula> Lista_alumnos)
        {

            string spName = "[INSERTAR_ALUMNO_MATRICULA_JSON]";

 
            var respuesta = false;
            var Listajson = JsonConvert.SerializeObject(Lista_alumnos);

            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                con.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = spName;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@json", Listajson);
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
