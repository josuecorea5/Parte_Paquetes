using ApplicationCore.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Entities
{
    public class Paquete
    {
        public int Id { get; set; }
        private double _Monto_A_Pagar;
        public string Nombre_Paquete { get; set; }
        public string Fotografia { get; set; }
        public string Nombre_Fotografia() {
            return Nombre_Paquete + '-' + Guid.NewGuid().ToString();
        }
        public Tipo_Paquete Tipo_Paquete { get; set; }
        public double Peso_Paquete { get; set; }
        public DateTime Fecha_Entrega { get; set; }
        //Envio_Especial significa un envío rápido, con una mayor tarifa al precio normal
        public bool Envio_Especial { get; set; }
        public double Monto_Pagar_Function()
        {
            double Limite_Peso;
            double Tarifa;
            if(Envio_Especial == true)
            {
                Tarifa = 30.79;
                Limite_Peso = 25;
                if (Peso_Paquete > Limite_Peso)
                {
                    for (int i = 0; i <= Peso_Paquete; i++)
                    {
                        if(i > Limite_Peso)
                            Tarifa += 1;
                    }
                    return Math.Round(Tarifa, 2);
                }
                else
                {
                    return Tarifa;
                }
            }
            else
            {
                Tarifa = 15.99;
                Limite_Peso = 12;
                if (Peso_Paquete > Limite_Peso)
                {
                    for (int i = 0; i <= Peso_Paquete; i++)
                    {
                        if(i > Limite_Peso)
                            Tarifa += 1.52;
                    }
                    return Math.Round(Tarifa, 2);
                }
                else
                {
                    return Tarifa;
                }
            }
        }
        public double Monto_Pagar_Prop {
            get
            {
                _Monto_A_Pagar = Monto_Pagar_Function();
                return _Monto_A_Pagar;
            }
            set
            {
                _Monto_A_Pagar = Monto_Pagar_Function();
            } 
        }
    }
}
