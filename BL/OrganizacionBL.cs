using DAL;
using ET;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class OrganizacionBL
    {

        private OrganizacionDAL maestraDAL = new OrganizacionDAL();


        #region [ Organizacion ]

        public List<Organizacion> ObtenerOrganizacions()
        {
            return maestraDAL.ObtenerOrganizacions();
        }


        public Organizacion ObtenerOrganizacionPorCodigoBL(string codigoOrganizacion)
        {
            return maestraDAL.ObtenerOrganizacionPorCodigo(codigoOrganizacion);
        }


        public bool GuardarOrganizacion(Organizacion organizacion)
        {
            return maestraDAL.SaveOrganizacion(organizacion);

        }

        public bool EliminarUsuario(string codigoorga)
        {
            return maestraDAL.EliminarOrganizacionPorCodigo(codigoorga);

        }

        #endregion

    }
}
