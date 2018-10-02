using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ET
{
    public class PagoConsolidado
    {

        public int IdPagoConsolidado { get; set; }

        [Required(ErrorMessage ="Debe Ingresar número de depósito")]
        [MinLength(10)]
        public int NumDeposito { get; set; }

        [Required(ErrorMessage = "Debe Ingresar un código de alumno")]
        [MinLength(8)]
        public int CodigoAlumno { get; set; }


        [Required(ErrorMessage = "Debe Ingresar un importe")]
     
        public Decimal Importe { get; set; }

        [Required(ErrorMessage = "Debe Ingresar la Fecha de Pago")]
        public DateTime FechaPago { get; set; }
        public DateTime FecharRegistro { get; set; }


        [Required(ErrorMessage = "Debe Ingresar Semestre")]
        [MinLength(5)]
        public int CodigoMatricula { get; set; }


        [Required(ErrorMessage = "Debe Ingresar el número de Tesorería")]
        public int NroTesoreria { get; set; }
     

        public int DescuentoDiez { get; set; }
        public int DescuentoQuince { get; set; }

        [Required(ErrorMessage = "Debe Ingresar un código de concepto")]
        [StringLength(6)]

        public ConceptoPago concepto { get; set; }


    }
}
