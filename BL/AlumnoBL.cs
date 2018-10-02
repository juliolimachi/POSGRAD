using DAL;
using ET;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
   public  class AlumnoBL
    {

        private AlumnoDAL maestraDAL = new AlumnoDAL();


        #region [ Alumno ]

        public List<Alumno> ObtenerAlumnos()
        {
            return maestraDAL.ObtenerAlumnos();
        }


        public Alumno ObtenerAlumnoPorCodigoBL(string codigoAlumno)
        {
            return maestraDAL.ObtenerAlumnoPorCodigo(codigoAlumno);
        }


        public bool ActualizarAlumnoBL(Alumno Alumno)
        {
            return maestraDAL.ActualizarAlumno(Alumno);

        }

        public bool RegistrarAlumnoBL(Alumno Alumno)
        {
            return maestraDAL.RegistrarAlumno(Alumno);
        }



        public void ActivateAlumnoBL(int AlumnoId, bool isActive, string updatedBy)
        {
            ActivateAlumnoBL(AlumnoId, isActive, updatedBy);
        }


        public bool EliminarAlumno(string id)
        {

            return maestraDAL.EliminarAlumnoPorCodigo(id);

        }
        #endregion


    }
}
