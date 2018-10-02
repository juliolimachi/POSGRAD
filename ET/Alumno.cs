using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ET
{
   public  class Alumno
    {
        public int IdAlumno { get; set; }
        public string NroDocumento { get; set; }
        public string ApePaterno { get; set; }
        public string ApeMaterno { get; set; }
        public string Nombres { get; set; }
        public Nullable<int> NroTelefono { get; set; }
        public Nullable<int> IdOrganizacion { get; set; }
        public string ImagePath { get; set; }
        public Nullable<int> CodigoMatricula { get; set; }
        public string NombreCompleto { get; set; }
        public int IdCursoPosgrado { get; set;}

        public string Sexo { get; set; }
        public int AnhoIngreso { get; set; }

        

    }
}
