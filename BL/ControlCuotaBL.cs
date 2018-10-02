using DAL;
using ET;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
   public class ControlCuotaBL
    {


        private ControlCuotaDAL ControlCuotaDAL = new ControlCuotaDAL();

        #region [ ControlCuota ]

        public List<ControlCuota> ObtenerControlCuotas()
        {
            return ControlCuotaDAL.ObtenerControlCuotas();
        }


        public ControlCuota ObtenerControlCuotaPorCodigoBL(string codigoControlCuota)
        {
            return ControlCuotaDAL.ObtenerControlCuotaPorCodigo(codigoControlCuota);
        }

        //public ControlCuota ObtenerControlCuotaPorNroConceptoBL(string codigoControlCuota)
        //{
        //    return ControlCuotaDAL.ObtenerControlCuotaPorNroConcepto(codigoControlCuota);
        //}


        public bool GuardarControlCuota(ControlCuota ControlCuota)
        {
            return ControlCuotaDAL.SaveControlCuota(ControlCuota);
        }


        public bool EliminarControlCuota(string codigoControlCuota)
        {
            return ControlCuotaDAL.EliminarControlCuotaPorCodigo(codigoControlCuota);
        }



        #endregion

    }
}
