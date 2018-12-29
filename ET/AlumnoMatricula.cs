using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ET
{
   public  class AlumnoMatricula
    {
        
        public int IdAlumnoMatricula { get; set; }



        public int CodigoAlumno { get; set; }
        public int CreditoAlumno { get; set; }
        public string NombreAlumno { get; set; }
        public string Sexo { get; set; }

        public int AnhoIngreso { get; set; }
   
        public int Especialidad { get; set; }

        public int Ciclo { get; set; }

        public DateTime FechaMatricula { get; set; }

        public int FlagTercioSuperior { get; set; }

        public int FlagQuintoSuperior { get; set; }

        public int FlagCerrado { get; set; }

        public Decimal Promedio { get; set; }

        public int MontoCiclo { get; set; }

        public int PrecioCredito { get; set; }

        public int IdAlumno { get; set; }

        public int IdCiclo { get; set; }

        public string UsuarioRegistro { get; set; }


        public int IdPrograma { get; set; }
        public int CodigoSemestre { get; set; }
        public string Semestre { get; set; }
        public string NombrePrograma { get; set; }

    }
}
