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

      
        public int NumDeposito { get; set; }

 
        public int CodigoAlumno { get; set; }


 
     
        public Decimal Importe { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        [DataType(DataType.Date)]
        public DateTime FechaPago { get; set; }
        public DateTime FecharRegistro { get; set; }


        public int CodigoMatricula { get; set; }



        public int NroTesoreria { get; set; }
     

        public int DescuentoDiez { get; set; }
        public int DescuentoQuince { get; set; }

     

        public ConceptoPago concepto { get; set; }


    }
}
