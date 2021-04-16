using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Entities.Validator
{
    public class Paquete_Validator : AbstractValidator<Paquete>
    {
        public Paquete_Validator()
        {
            RuleFor(x => x.Id).NotNull();
            RuleFor(x => x.Nombre_Paquete).NotNull().WithMessage("Este campo no puede enviarse vacío.")
                .Length(2, 150).WithMessage("Este campo debe de contener de 2 a 255 caracteres.");
            RuleFor(x => x.Tipo_Paquete).IsInEnum().WithMessage("Este campo no puede enviarse vacío.");
            RuleFor(x => x.Peso_Paquete).NotNull().WithMessage("Este campo no puede enviarse vacío.");
            RuleFor(x => x.Envio_Especial).NotNull().WithMessage("Este campo no puede enviarse vacío.");
            RuleFor(x => x.Fecha_Entrega).NotNull().WithMessage("Este campo no puede enviarse vacío.");
            RuleFor(x => x.Monto_Pagar_Prop).NotNull().WithMessage("Este campo no puede enviarse vacío.");
        }
    }
}
