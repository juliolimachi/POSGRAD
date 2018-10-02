using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ET
{
    public class Organizacion
    {
        public int IdOrganizacion { get; set; }
        public string NombreOrganizacion { get; set; }
        public Nullable<System.DateTime> FechaCreacion { get; set; }
        public Nullable<int> Estado { get; set; }
    }
}
