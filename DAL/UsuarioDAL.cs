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
    public class UsuarioDAL
    {

        readonly string ConnectionString = ConfigurationManager.ConnectionStrings["AATEConnectionString"].ConnectionString;

        #region [ Usuario ]

        public List<Usuario> ObtenerUsuarios()
        {
            string spName = "[Usuario_GetAll]";
            List<Usuario> Usuarios = new List<Usuario>();

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
                        var Usuario = new Usuario
                        {

                            IdUsuario = Convert.ToInt32(reader["IdUsuario"]),
                            NroDocumento = Convert.ToInt32(reader["NroDocumento"]),
                            UserName = reader["UserName"].ToString(),
                            Oficina = reader["Oficina"].ToString(),
                            Estado = Convert.ToInt32(reader["Estado"]),
                            Password = reader["Password"].ToString(),
                            Rol = Convert.ToInt32(reader["Rol"] is DBNull ? 0 : reader["Rol"]),
                            FechaCreacion = Convert.ToDateTime(reader["FechaCreacion"])

                        };
                        Usuarios.Add(Usuario);

                    }

                }




            }

            return Usuarios;
        }

        public Usuario ObtenerUsuarioPorCodigo(string codigoUsuario)
        {

            string spName = "[Usuario_GetById]";

            List<Usuario> Usuarios = new List<Usuario>();
            Usuario item = null;


            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                con.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = spName;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdUsuario", codigoUsuario);
                cmd.Connection = con;


                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var Usuario = new Usuario
                        {

                            IdUsuario = Convert.ToInt32(reader["IdUsuario"]),
                            NroDocumento = Convert.ToInt32(reader["NroDocumento"]),
                            UserName = reader["UserName"].ToString(),
                            Oficina = reader["Oficina"].ToString(),
                            Estado = Convert.ToInt32(reader["Estado"]),
                            Password = reader["Password"].ToString(),
                            Rol = Convert.ToInt32(reader["Rol"] is DBNull ? 0:reader["Rol"]),
                            FechaCreacion = Convert.ToDateTime(reader["FechaCreacion"])

                                    
                        };

                        Usuarios.Add(Usuario);
                        item = Usuario;

                    }

                }

            }

            return item;
        }


        public bool SaveUsuario(Usuario usuario)
        {
            string spName = "[Usuario_Save]";
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


                    cmd.Parameters.AddWithValue("@IdUsuario", usuario.IdUsuario);
                    cmd.Parameters.AddWithValue("@NroDocumento", usuario.NroDocumento);
                    cmd.Parameters.AddWithValue("@UserName", usuario.UserName);
                    cmd.Parameters.AddWithValue("@Password", usuario.Password);
                    cmd.Parameters.AddWithValue("@FechaCreacion", usuario.FechaCreacion);
                    cmd.Parameters.AddWithValue("@Estado ", usuario.Estado);
                    cmd.Parameters.AddWithValue("@Rol", usuario.Rol);
                    cmd.Parameters.AddWithValue("@Oficina ", usuario.Oficina);


       

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


        public bool ActualizarUsuario(Usuario Usuario)
        {
            string spName = "[gen].[usp_Usuario_Update]";
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


                    //cmd.Parameters.AddWithValue("@UsuarioId", Usuario.intIdUsuario);
                    //cmd.Parameters.AddWithValue("@UsuarioCode", Usuario.strCodigo);
                    //cmd.Parameters.AddWithValue("@Nombre", Usuario.strNombre);

                    //cmd.Parameters.AddWithValue("@IsActive", Usuario.blnIsActive);
                    //cmd.Parameters.AddWithValue("@UpdatedBy", Usuario.UpdatedBy);


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

        public bool RegistrarUsuario(Usuario Usuario)
        {
            string spName = "[gen].[usp_Usuario_Add]";
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


                    //cmd.Parameters.AddWithValue("@UsuarioCode", Usuario.strCodigo);
                    //cmd.Parameters.AddWithValue("@Nombre", Usuario.strNombre);
                    //cmd.Parameters.AddWithValue("@IsActive", Usuario.blnIsActive);
                    //cmd.Parameters.AddWithValue("@UpdatedBy", Usuario.UpdatedBy);


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



        public bool EliminarUsuarioPorCodigo(string codigoUsuario)
        {

            string spName = "[Usuario_Delete]";

            List<Usuario> Usuarios = new List<Usuario>();
            var  respuesta = false;


            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                con.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = spName;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdUsuario", codigoUsuario);
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
