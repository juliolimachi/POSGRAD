using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ET
{
   public  class ControlCuota
    {
        public int IdControlCuota { get; set; }
        public int IdCursoPosgrado { get; set; }
        public int IdCuota { get; set; }
        public decimal Monto { get; set; }
        public int FlagFinal { get; set; }
        public DateTime FechaVencimiento { get; set; }
        public DateTime FechaCreacion { get; set; }
        public string Ciclo { get; set; }
       
        public CursoPosgrado cursoPosgrado { get; set; }
        public Cuota cuota { get; set; }

    }
}
