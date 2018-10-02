using DAL;
using ET;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public  class ArchivoPagoBL
    {

        private ArchivoPagoDAL maestraDAL = new ArchivoPagoDAL();


        #region [ ArchivoPago ]

        public List<ArchivoPago> ObtenerArchivoPagos()
        {
            return maestraDAL.ObtenerArchivoPagos();
        }


        public ArchivoPago ObtenerArchivoPagoPorCodigoBL(string codigoArchivoPago)
        {
            return maestraDAL.ObtenerArchivoPagoPorCodigo(codigoArchivoPago);
        }

        public ArchivoPago ObtenerArchivoPagoPorNombreBL(string nombreArchivoPago)
        {
            return maestraDAL.ObtenerArchivoPagoPorNombre(nombreArchivoPago);
        }


        public bool ActualizarArchivoPagoBL(ArchivoPago ArchivoPago)
        {
            return maestraDAL.SaveArchivoPago(ArchivoPago);
        }

        public bool RegistrarArchivoPagoBL(ArchivoPago ArchivoPago)
        {
            return maestraDAL.SaveArchivoPago(ArchivoPago);
        }



        public void ActivateArchivoPagoBL(int ArchivoPagoId, bool isActive, string updatedBy)
        {
            ActivateArchivoPagoBL(ArchivoPagoId, isActive, updatedBy);
        }


        public bool EliminarArchivoPago(string id)
        {

            return maestraDAL.EliminarArchivoPagoPorCodigo(id);

        }
        #endregion

    }
}
