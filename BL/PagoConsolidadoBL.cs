using DAL;
using ET;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
   public  class PagoConsolidadoBL
    {
        private PagoConsolidadoDAL maestraDAL = new PagoConsolidadoDAL();


        #region [ PagoConsolidado ]

        public List<PagoConsolidado> ObtenerPagoConsolidados()
        {
            return maestraDAL.ObtenerPagoConsolidados();
        }


        public PagoConsolidado ObtenerPagoConsolidadoPorCodigoBL(string codigoPagoConsolidado)
        {
            return maestraDAL.ObtenerPagoConsolidadoPorCodigo(codigoPagoConsolidado);
        }


        public bool ActualizarPagoConsolidadoBL(PagoConsolidado PagoConsolidado)
        {
            return maestraDAL.SavePagoConsolidado(PagoConsolidado);

        }

        public bool RegistrarPagoConsolidadoBL(PagoConsolidado PagoConsolidado)
        {
            return maestraDAL.SavePagoConsolidado(PagoConsolidado);
        }



        public void ActivatePagoConsolidadoBL(int PagoConsolidadoId, bool isActive, string updatedBy)
        {
            ActivatePagoConsolidadoBL(PagoConsolidadoId, isActive, updatedBy);
        }


        public bool EliminarPagoConsolidado(string id)
        {

            return maestraDAL.EliminarPagoConsolidadoPorCodigo(id);

        }






        #endregion

    }
}
