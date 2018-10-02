using DAL;
using ET;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
   public  class CuotaBL
    {
        private CuotaDAL CuotaDAL = new CuotaDAL();

        #region [ Cuota ]

        public List<Cuota> ObtenerCuotas()
        {
            return CuotaDAL.ObtenerCuotas();
        }


        public Cuota ObtenerCuotaPorCodigoBL(string codigoCuota)
        {
            return CuotaDAL.ObtenerCuotaPorCodigo(codigoCuota);
        }


        public bool GuardarCuota(Cuota Cuota)
        {
            return CuotaDAL.SaveCuota(Cuota);

        }

        public bool EliminarCuota(string codigoCuota)
        {
            return CuotaDAL.EliminarCuotaPorCodigo(codigoCuota);

        }






        #endregion


    }
}
