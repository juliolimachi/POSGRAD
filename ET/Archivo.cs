using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ET
{
    public class Archivo
    {

        public int IdArchivo { get; set; }
        public string NombreArchivo { get; set; }
        public string Formato { get; set; }
        public string Periodo { get; set; }
        public DateTime FechaSubida { get; set; }
        public int EstadoArchivo { get; set; }
        public int EstadoValidacion { get; set; }

    }

}
