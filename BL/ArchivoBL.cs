using DAL;
using ET;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
   public  class ArchivoBL
    {
        private ArchivoDAL maestraDAL = new ArchivoDAL();


        #region [ Archivo ]

        public List<Archivo> ObtenerArchivos()
        {
            return maestraDAL.ObtenerArchivos();
        }


        public Archivo ObtenerArchivoPorCodigoBL(string codigoArchivo)
        {
            return maestraDAL.ObtenerArchivoPorCodigo(codigoArchivo);
        }

        public Archivo ObtenerArchivoPorNombreBL(string nombreArchivo)
        {
            return maestraDAL.ObtenerArchivoPorNombre(nombreArchivo);
        }


        public bool ActualizarArchivoBL(Archivo Archivo)
        {
            return maestraDAL.SaveArchivo(Archivo);
        }

        public bool RegistrarArchivoBL(Archivo Archivo)
        {
            return maestraDAL.SaveArchivo(Archivo);
        }



        public void ActivateArchivoBL(int ArchivoId, bool isActive, string updatedBy)
        {
            ActivateArchivoBL(ArchivoId, isActive, updatedBy);
        }


        public bool EliminarArchivo(string id)
        {

            return maestraDAL.EliminarArchivoPorCodigo(id);

        }
        #endregion


    }
}
