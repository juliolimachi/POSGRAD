using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace ET
{
    public class Usuario
    {
        public int IdUsuario { get; set; }
        public Nullable<int> NroDocumento { get; set; }
        public string UserName { get; set; }
        
        
        public string Password { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        [DataType(DataType.Date)]
        public DateTime? FechaCreacion { get; set; }

        public Nullable<int> Estado { get; set; }
        public string Oficina { get; set; }
        public Nullable<int> Rol { get; set; }
        public string ImagePath { get; set; }


    }
}
