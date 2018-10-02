using System;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ET
{
    public class Pago
    {
        public int IdPago { get; set; }
        public int NroRecibo { get; set; }
        public int IdAlumno { get; set; }
        public int IdCursoPosgrado { get; set; }
        public Decimal Monto { get; set; }
        public DateTime FechaPago { get; set; }
        public DateTime FechaRegistro { get; set; }
        public string UsuarioRegistro { get; set; }
        public ControlCuota ControlCuota { get; set; }
        public int IdControlCuota { get; set; }
        public Alumno Alumno { get; set; }
    }
}
