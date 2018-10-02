using DAL;
using ET;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
   public  class CursoPosgradoBL
    {


        private CursoPosgradoDAL CursoPosgradoDAL = new CursoPosgradoDAL();


        #region [ CursoPosgrado ]

        public List<CursoPosgrado> ObtenerCursoPosgrados()
        {
            return CursoPosgradoDAL.ObtenerCursoPosgrados();
        }

        public List<CursoPosgrado> ObtenerCursoPosgradoValues()
        {

            return CursoPosgradoDAL.ObtenerCursoPosgradosValueText();

        }

        public CursoPosgrado ObtenerCursoPosgradoPorCodigoBL(string codigoCursoPosgrado)
        {
            return CursoPosgradoDAL.ObtenerCursoPosgradoPorCodigo(codigoCursoPosgrado);
        }


        public bool GuardarCursoPosgrado(CursoPosgrado CursoPosgrado)
        {
            return CursoPosgradoDAL.SaveCursoPosgrado(CursoPosgrado);

        }

        public bool EliminarCursoPosgrado(string codigoCursoPosgrado)
        {
            return CursoPosgradoDAL.EliminarCursoPosgradoPorCodigo(codigoCursoPosgrado);

        }




        #endregion


    }
}
