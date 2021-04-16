using ApplicationCore.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Specification.Filters
{
    public class Paquete_Filter : BaseFilter
    {
        public string Nombre_Paquete { get; set; }
        public Tipo_Paquete Tipo_Paquete { get; set; }
        public float Peso_Paquete { get; set; }
    }
}
