using DAL;
using ET;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class PagoBL
    {

        private PagoDAL PagoDAL = new PagoDAL();
        private PagoCuotaDAL pagocuotaDAL = new PagoCuotaDAL();
        #region [ Pago ]

        public List<Pago> ObtenerPagos()
        {
            return PagoDAL.ObtenerPagos();
        }


        public Pago ObtenerPagoPorCodigoBL(string codigoPago)
        {
            return PagoDAL.ObtenerPagoPorCodigo(codigoPago);
        }

        public Pago ObtenerPagoPorNroConceptoBL(string codigoPago)
        {
            return PagoDAL.ObtenerPagoPorNroConcepto(codigoPago);
        }


        public bool GuardarPago(Pago pago )
        {

            bool flag2 = PagoDAL.SavePago(pago);

            int Idpago = PagoDAL.ObtenerUltimoPago();

            pago.IdPago = Idpago;
            bool flag = pagocuotaDAL.SavePagoCuota(pago.IdAlumno,pago.IdControlCuota,pago.IdPago);
         



            if (flag&&flag2)
            {
                return true;

            }else
            {

                return false;
            }


            

        }

        public bool EliminarPago(string codigoPago)
        {
            return PagoDAL.EliminarPagoPorCodigo(codigoPago);

        }






        #endregion
    }
}
