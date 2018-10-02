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
    public class PagoDAL
    {

        readonly string ConnectionString = ConfigurationManager.ConnectionStrings["AATEConnectionString"].ConnectionString;

        #region [ Pago ]

        public List<Pago> ObtenerPagos()
        {
            string spName = "[Pago_GetAll]";
            List<Pago> Pagos = new List<Pago>();

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
                        var Pago = new Pago
                        {

                            IdPago = Convert.ToInt32(reader["IdPago"]),
                            //IdAlumno = Convert.ToInt32(reader["IdAlumno"]),
                            IdControlCuota = Convert.ToInt32(reader["IdControlCuota"]),
                            NroRecibo = Convert.ToInt32(reader["NroRecibo"]),
                            IdCursoPosgrado = Convert.ToInt32(reader["IdCursoPosgrado"]),
                            Monto = Convert.ToDecimal(reader["Monto"]),
                            FechaRegistro = Convert.ToDateTime(reader["FechaRegistro"]),
                            FechaPago = Convert.ToDateTime(reader["FechaPago"]),
                            UsuarioRegistro = reader["UsuarioRegistro"].ToString(),
                            Alumno = new Alumno()
                            {
                                IdAlumno = Convert.ToInt32(reader["IdAlumno"]),
                                NombreCompleto = reader["NombreCompleto"].ToString(),
                            },

                            ControlCuota = new ControlCuota()
                            {
                                IdControlCuota = Convert.ToInt32(reader["IdControlCuota"]),

                                cuota = new Cuota()
                                {
                                    IdCuota = Convert.ToInt32(reader["idcuota"]),
                                    NroCuota = Convert.ToInt32(reader["NroCuota"]),
                                    Descripcion = reader["Descripcion"].ToString(),

                                },
                                cursoPosgrado = new CursoPosgrado()
                                {
                                    IdCursoPosgrado = Convert.ToInt32(reader["idcursoposgrado"]),
                                    NombreCursoPosgrado = reader["nombrecurso"].ToString(),

                                }

                            },

                        };
                        Pagos.Add(Pago);

                    }

                }




            }

            return Pagos;
        }

        public Pago ObtenerPagoPorCodigo(string codigoPago)
        {

            string spName = "[Pago_GetById]";

            List<Pago> Pagos = new List<Pago>();
            Pago item = null;


            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                con.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = spName;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdPago", codigoPago);
                cmd.Connection = con;


                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var Pago = new Pago
                        {

                            IdPago = Convert.ToInt32(reader["IdPago"]),
                            IdAlumno = Convert.ToInt32(reader["IdAlumno"]),
                            IdControlCuota = Convert.ToInt32(reader["IdControlCuota"]),
                            NroRecibo = Convert.ToInt32(reader["NroRecibo"]),
                            IdCursoPosgrado = Convert.ToInt32(reader["IdCursoPosgrado"]),
                            Monto = Convert.ToDecimal(reader["Monto"]),
                            FechaRegistro = Convert.ToDateTime(reader["FechaRegistro"]),
                            FechaPago = Convert.ToDateTime(reader["FechaPago"]),
                            UsuarioRegistro = reader["UsuarioRegistro"].ToString(),
                            Alumno = new Alumno(){
                                IdAlumno = Convert.ToInt32(reader["IdAlumno"]),
                                NombreCompleto = reader["NombreCompleto"].ToString(),
                            },

                            ControlCuota = new ControlCuota()
                            {
                                IdControlCuota = Convert.ToInt32(reader["IdControlCuota"]),

                                cuota = new Cuota()
                                {
                                    IdCuota = Convert.ToInt32(reader["idcuota"]),
                                    NroCuota = Convert.ToInt32(reader["NroCuota"]),
                                    Descripcion = reader["Descripcion"].ToString(),
                                    
                                },
                                cursoPosgrado = new CursoPosgrado(){
                                    IdCursoPosgrado = Convert.ToInt32(reader["idcursoposgrado"]),
                                    NombreCursoPosgrado = reader["nombrecurso"].ToString(),

                                }

                            },
                       
                        };

                        Pagos.Add(Pago);
                        item = Pago;

                    }

                }

            }

            return item;
        }



        public Pago ObtenerPagoPorNroConcepto(string codigoPago)
        {

            string spName = "[Pago_GetBy_like]";

            List<Pago> Pagos = new List<Pago>();
            Pago item = null;


            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                con.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = spName;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@start", codigoPago);
                cmd.Connection = con;


                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var Pago = new Pago
                        {

                            IdPago = Convert.ToInt32(reader["IdPago"]),
                            IdAlumno = Convert.ToInt32(reader["IdAlumno"]),
                            IdControlCuota = Convert.ToInt32(reader["IdControlCuota"]),
                            NroRecibo = Convert.ToInt32(reader["NroRecibo"]),
                            IdCursoPosgrado = Convert.ToInt32(reader["IdCursoPosgrado"]),
                            Monto = Convert.ToDecimal(reader["Monto"]),
                            FechaRegistro = Convert.ToDateTime(reader["FechaRegistro"]),
                            FechaPago = Convert.ToDateTime(reader["FechaPago"]),
                            UsuarioRegistro = reader["UsuarioRegistro"].ToString(),
                       

                        };

                        Pagos.Add(Pago);
                        item = Pago;

                    }

                }

            }

            return item;
        }




        public int ObtenerUltimoPago()
        {

            string spName = "[PagoUltimoRegitro]";

            List<Pago> Pagos = new List<Pago>();
            Pago item = null;


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
                        var Pago = new Pago
                        {

                            IdPago = Convert.ToInt32(reader["IdPago"]),
                            IdControlCuota = Convert.ToInt32(reader["IdControlCuota"]),
                            NroRecibo = Convert.ToInt32(reader["NroRecibo"]),
                            IdCursoPosgrado = Convert.ToInt32(reader["IdCursoPosgrado"]),
                            Monto = Convert.ToDecimal(reader["Monto"]),

                        };

                        Pagos.Add(Pago);
                        item = Pago;

                    }

                }

            }

            return item.IdPago;
        }
        public bool SavePago(Pago Pago)
        {
            string spName = "[Pago_Save]";
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

                    cmd.Parameters.AddWithValue("@IdPago", Pago.IdPago);
                    cmd.Parameters.AddWithValue("@IdAlumno", Pago.IdAlumno);
                    cmd.Parameters.AddWithValue("@NroRecibo", Pago.NroRecibo);
                    cmd.Parameters.AddWithValue("@IdCursoPosgrado", Pago.IdCursoPosgrado);
                    cmd.Parameters.AddWithValue("@Monto", Pago.Monto);
                    cmd.Parameters.AddWithValue("@IdControlCuota", Pago.IdControlCuota);
                    cmd.Parameters.AddWithValue("@FechaPago", Pago.FechaPago);
                    cmd.Parameters.AddWithValue("@FechaRegistro", Pago.FechaRegistro);
                    cmd.Parameters.AddWithValue("@UsuarioRegistro", Pago.UsuarioRegistro);
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




        public bool EliminarPagoPorCodigo(string codigoPago)
        {

            string spName = "[Pago_Delete]";

            List<Pago> Pagos = new List<Pago>();
            var respuesta = false;


            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                con.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = spName;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdPago", codigoPago);
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
