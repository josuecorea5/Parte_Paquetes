using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Enum
{
    public enum Tipo_Paquete
    {
        [Display(Name = "Accesorio")]
        Accesorio,
        [Display(Name = "Decoración")]
        Decoracion,
        [Display(Name = "Electrodoméstico")]
        Electrodomestico,
        [Display(Name = "Mueble")]
        Muebles,
        [Display(Name = "Vestimenta")]
        Vestimenta
    }
}
