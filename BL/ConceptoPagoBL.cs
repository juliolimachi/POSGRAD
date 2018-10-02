using DAL;
using ET;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class ConceptoPagoBL
    {

        private ConceptoPagoDAL conceptoPagoDAL = new ConceptoPagoDAL();

        #region [ ConceptoPago ]

        public List<ConceptoPago> ObtenerConceptoPagos()
        {
            return conceptoPagoDAL.ObtenerConceptoPagos();
        }


        public ConceptoPago ObtenerConceptoPagoPorCodigoBL(string codigoConceptoPago)
        {
            return conceptoPagoDAL.ObtenerConceptoPagoPorCodigo(codigoConceptoPago);
        }

        public ConceptoPago ObtenerConceptoPagoPorNroConceptoBL(string codigoConceptoPago)
        {
            return conceptoPagoDAL.ObtenerConceptoPagoPorNroConcepto(codigoConceptoPago);
        }


        public bool GuardarConceptoPago(ConceptoPago ConceptoPago)
        {
            return conceptoPagoDAL.SaveConceptoPago(ConceptoPago);

        }

        public bool EliminarConceptoPago(string codigoConceptoPago)
        {
            return conceptoPagoDAL.EliminarConceptoPagoPorCodigo(codigoConceptoPago);

        }


      



        #endregion


    }
}
