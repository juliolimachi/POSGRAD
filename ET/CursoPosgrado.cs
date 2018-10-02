using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ET
{
    public class CursoPosgrado
    {

        public int IdCursoPosgrado { get; set; }
        public string NombreCursoPosgrado { get; set; }
        [Required(ErrorMessage = "Debe ingresar  un monto correcto.")]
        //[Range(0, 20000, ErrorMessage = "Debe ingresar una nota entre 0 a 20000.")]
        [DisplayFormat(DataFormatString = "{0:N}", ApplyFormatInEditMode = true)]
        public Nullable<decimal> MontoTotal { get; set; }
        public Nullable<int> Anio { get; set; }
        public Nullable<System.DateTime> FechaCreacion { get; set; }
        public Nullable<System.DateTime> FechaActualizacion { get; set; }
        public Nullable<int> IdControlCuota { get; set; }
        public Nullable<int> IdOrganizacion { get; set; }
        public Nullable<int> IdConceptopago { get; set; }
        public string UserCreacion { get; set; }
        public int IdEstado { get; set; }
        public bool chkActiveDeactive { get; set; }
        public Organizacion organizacion { get; set; }
        public ConceptoPago concepto { get; set; }
        public Estado estado { get; set; }
    }
}
