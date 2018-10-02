using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ET
{
    public class ConceptoPago
    {

        public int IdConceptoPago { get; set; }
        public string NroConcepto { get; set; }
        public string Descripcion { get; set; }
        public Nullable<System.DateTime> FechaCreacion { get; set; }
        public Nullable<int> Estado { get; set; }
    }
}
