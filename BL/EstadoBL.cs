using DAL;
using ET;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class EstadoBL
    {


        private EstadoDAL EstadoDAL = new EstadoDAL();

        #region [ Estado ]

        public List<Estado> ObtenerEstados()
        {
            return EstadoDAL.ObtenerEstados();
        }


        public Estado ObtenerEstadoPorCodigoBL(string codigoEstado)
        {
            return EstadoDAL.ObtenerEstadoPorCodigo(codigoEstado);
        }

        public Estado ObtenerEstadoPorNroConceptoBL(string codigoEstado)
        {
            return EstadoDAL.ObtenerEstadoPorNroConcepto(codigoEstado);
        }


        public bool GuardarEstado(Estado Estado)
        {
            return EstadoDAL.SaveEstado(Estado);

        }

        public bool EliminarEstado(string codigoEstado)
        {
            return EstadoDAL.EliminarEstadoPorCodigo(codigoEstado);

        }

        #endregion


    }
}
