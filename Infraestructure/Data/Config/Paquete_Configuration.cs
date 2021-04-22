using ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Data.Config
{
    public class Paquete_Configuration : IEntityTypeConfiguration<Paquete>
    {
        public void Configure(EntityTypeBuilder<Paquete> builder)
        {
            builder.ToTable("Paquetes");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Nombre_Paquete)
                .HasMaxLength(150)
                .IsRequired();
            builder.Property(c => c.Fotografia);
            builder.Property(c => c.Tipo_Paquete)
                .IsRequired();
            builder.Property(c => c.Peso_Paquete)
                .IsRequired();
            builder.Property(c => c.Fecha_Entrega)
                .IsRequired();
            builder.Property(c => c.Envio_Especial)
                .IsRequired();
            builder.Property(c => c.Monto_Pagar_Prop)
                .IsRequired();
        }
    }
}
