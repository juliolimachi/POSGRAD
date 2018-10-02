using DAL;
using ET;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class UsuarioBL
    {
        private UsuarioDAL usuarioDAL = new UsuarioDAL();


        #region [ Usuario ]

        public List<Usuario> ObtenerUsuarios()
        {
            return usuarioDAL.ObtenerUsuarios();
        }


        public Usuario ObtenerUsuarioPorCodigoBL(string codigoUsuario)
        {
            return usuarioDAL.ObtenerUsuarioPorCodigo(codigoUsuario);
        }


        public bool GuardarUsuario(Usuario usuario)
        {
            return usuarioDAL.SaveUsuario(usuario);

        }

        public bool EliminarUsuario(string codigousuario)
        {
            return usuarioDAL.EliminarUsuarioPorCodigo(codigousuario);

        }


        //public void ActivateUsuarioBL(int UsuarioId, bool isActive, string updatedBy)
        //{
        //    ActivateUsuarioBL(UsuarioId,isActive,updatedBy);
        //}



        #endregion


      
    }
}
