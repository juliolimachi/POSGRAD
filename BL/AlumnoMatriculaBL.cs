using DAL;
using ET;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class AlumnoMatriculaBL
    {


        private AlumnoMatriculaDAL maestraDAL = new AlumnoMatriculaDAL();


        #region [ AlumnoMatricula ]

        public List<AlumnoMatricula> ObtenerAlumnoMatriculas()
        {
            return maestraDAL.ObtenerAlumnoMatriculas();
        }


        public AlumnoMatricula ObtenerAlumnoMatriculaPorCodigoBL(string codigoAlumnoMatricula)
        {
            return maestraDAL.ObtenerAlumnoMatriculaPorCodigo(codigoAlumnoMatricula);
        }


        public bool ActualizarAlumnoMatriculaBL(AlumnoMatricula alumnoMatricula)
        {
            return maestraDAL.ActualizarAlumnoMatricula(alumnoMatricula);

        }

        public bool RegistrarAlumnoMatriculaBL(AlumnoMatricula alumnoMatricula)
        {
            return maestraDAL.RegistrarAlumnoMatricula(alumnoMatricula);
        }



        public void ActivateAlumnoMatriculaBL(int AlumnoMatriculaId, bool isActive, string updatedBy)
        {
            ActivateAlumnoMatriculaBL(AlumnoMatriculaId, isActive, updatedBy);
        }


        public bool EliminarAlumnoMatricula(string id)
        {

            return maestraDAL.EliminarAlumnoMatriculaPorCodigo(id);

        }


        public bool InsertarAlumnoMatricula(List<AlumnoMatricula> Lista_alumnos)
        {

            return maestraDAL.InsertarAlumnoMatriculaJson(Lista_alumnos);

        }
        #endregion



    }
}
