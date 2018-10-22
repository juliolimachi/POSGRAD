using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using ET;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using Newtonsoft.Json;

namespace DAL
{
    public class PagoConsolidadoDAL
    {


        readonly string ConnectionString = ConfigurationManager.ConnectionStrings["AATEConnectionString"].ConnectionString;
        DateTime rngMin = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
        DateTime rngMax = (DateTime)System.Data.SqlTypes.SqlDateTime.MaxValue;

        #region [ PagoConsolidado ]

        public List<PagoConsolidado> ObtenerPagoConsolidados()
        {
            string spName = "[PagoConsolidado_GetAll]";
            List<PagoConsolidado> PagoConsolidados = new List<PagoConsolidado>();

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
                        var PagoConsolidado = new PagoConsolidado
                        {

                            IdPagoConsolidado = Convert.ToInt32(reader["IdPagoConsolidado"]),
                            NumDeposito = Convert.ToInt32(reader["NumDeposito"]),
                            CodigoAlumno = Convert.ToInt32(reader["CodigoAlumno"]),
                            Importe = Convert.ToInt32(reader["Importe"]),
                            FecharRegistro = Convert.ToDateTime( reader["FecharRegistro"] is DBNull ? rngMin: reader["FecharRegistro"]),
                            FechaPago = Convert.ToDateTime(reader["FechaPago"]),
                            CodigoMatricula = Convert.ToInt32(reader["CodigoMatricula"] is DBNull?0: reader["CodigoMatricula"]),
                            NroTesoreria= Convert.ToInt32(reader["NroTesoreria"] is DBNull ?0: reader["NroTesoreria"]),
                            DescuentoQuince = Convert.ToInt32(reader["DescuentoQuince"] is DBNull ? 0 : reader["DescuentoQuince"]),
                            DescuentoDiez = Convert.ToInt32(reader["DescuentoDiez"] is DBNull?0: reader["DescuentoDiez"]),

                            concepto = new ConceptoPago
                            {
                                NroConcepto = reader["NroConcepto"].ToString(),
                            }


                        };
                        PagoConsolidados.Add(PagoConsolidado);

                    }

                }




            }

            return PagoConsolidados;
        }

        public PagoConsolidado ObtenerPagoConsolidadoPorCodigo(string codigoPagoConsolidado)
        {

            string spName = "[PagoConsolidado_GetById]";

            List<PagoConsolidado> PagoConsolidados = new List<PagoConsolidado>();
            PagoConsolidado item = null;


            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                con.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = spName;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdPagoConsolidado", codigoPagoConsolidado);
                cmd.Connection = con;


                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var PagoConsolidado = new PagoConsolidado
                        {


                            IdPagoConsolidado = Convert.ToInt32(reader["IdPagoConsolidado"]),
                            NumDeposito = Convert.ToInt32(reader["NumDeposito"]),
                            CodigoAlumno = Convert.ToInt32(reader["CodigoAlumno"]),
                            Importe = Convert.ToInt32(reader["Importe"]),
                            FecharRegistro = Convert.ToDateTime(reader["FecharRegistro"] is DBNull ? rngMin : reader["FecharRegistro"]),
                            FechaPago = Convert.ToDateTime(reader["FechaPago"]),
                            CodigoMatricula = Convert.ToInt32(reader["CodigoMatricula"] is DBNull ? 0 : reader["CodigoMatricula"]),
                            NroTesoreria = Convert.ToInt32(reader["NroTesoreria"] is DBNull ? 0 : reader["NroTesoreria"]),
                            DescuentoQuince = Convert.ToInt32(reader["DescuentoQuince"] is DBNull ? 0 : reader["DescuentoQuince"]),
                            DescuentoDiez = Convert.ToInt32(reader["DescuentoDiez"] is DBNull ? 0 : reader["DescuentoDiez"]),

                            concepto = new ConceptoPago
                            {
                                NroConcepto = reader["NroConcepto"].ToString(),
                            }


                        };

                        PagoConsolidados.Add(PagoConsolidado);
                        item = PagoConsolidado;

                    }

                }

            }

            return item;
        }

        public bool SavePagoConsolidado(PagoConsolidado PagoConsolidado)
        {
            string spName = "[PagoConsolidado_Save]";
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

                   

                    cmd.Parameters.AddWithValue("@IdPagoConsolidado", PagoConsolidado.IdPagoConsolidado);
                    cmd.Parameters.AddWithValue("@NumDeposito", PagoConsolidado.NumDeposito);
                    cmd.Parameters.AddWithValue("@CodigoAlumno", PagoConsolidado.CodigoAlumno);
                    cmd.Parameters.AddWithValue("@Importe", PagoConsolidado.Importe);

                    cmd.Parameters.AddWithValue("@FecharRegistro", PagoConsolidado.FecharRegistro);
                    cmd.Parameters.AddWithValue("@FechaPago", Convert.ToDateTime(PagoConsolidado.FechaPago));
     
                    cmd.Parameters.AddWithValue("@NroConcepto", PagoConsolidado.concepto.NroConcepto);
                    cmd.Parameters.AddWithValue("@NroTesoreria", PagoConsolidado.NroTesoreria);
                    cmd.Parameters.AddWithValue("@DescuentoQuince", PagoConsolidado.DescuentoQuince);
                    cmd.Parameters.AddWithValue("@DescuentoDiez", PagoConsolidado.DescuentoDiez);
                    cmd.Parameters.AddWithValue("@CodigoMatricula", PagoConsolidado.CodigoMatricula);

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

        public bool EliminarPagoConsolidadoPorCodigo(string codigoPagoConsolidado)
        {

            string spName = "[PagoConsolidado_Delete]";

            List<PagoConsolidado> PagoConsolidados = new List<PagoConsolidado>();
            var respuesta = false;


            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                con.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = spName;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id_PagoConsolidado", codigoPagoConsolidado);
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
