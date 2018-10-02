using DAL;
using ET;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class MatriculaBL
    {

        private MatriculaDAL maestraDAL = new MatriculaDAL();


        #region [ Matricula ]

        public List<Matricula> ObtenerMatriculas()
        {
            return maestraDAL.ObtenerMatriculas();
        }


        public Matricula ObtenerMatriculaPorCodigoBL(string codigoMatricula)
        {
            return maestraDAL.ObtenerMatriculaPorCodigo(codigoMatricula);
        }


        public bool ActualizarMatriculaBL(Matricula Matricula)
        {
            return maestraDAL.SaveMatricula(Matricula);

        }

        public bool RegistrarMatriculaBL(Matricula Matricula)
        {
            return maestraDAL.SaveMatricula(Matricula);
        }



        public void ActivateMatriculaBL(int MatriculaId, bool isActive, string updatedBy)
        {
            ActivateMatriculaBL(MatriculaId, isActive, updatedBy);
        }


        public bool EliminarMatricula(string id)
        {

            return maestraDAL.EliminarMatriculaPorCodigo(id);

        }
        #endregion

    }
}
