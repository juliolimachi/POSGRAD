using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ET
{
   public  class EstadoCuenta
    {
        
        public int CodigoAlumno { get; set; }
        public string NombreApellidos { get; set; }
        public string TipoPosgrado { get; set; }
        public string Concepto { get; set; }
        public int IngresoEsperado { get; set; }
        public int NumeroRecibo { get; set; }
        public DateTime FechaPago { get; set; }
        public Decimal IngresoRecaudado { get; set; }
        public int Ciclo { get; set; }
        public string Semestre { get; set; }
        public int NumeroCredito { get; set; }
        public Decimal Promedio { get; set; }


    }
}
