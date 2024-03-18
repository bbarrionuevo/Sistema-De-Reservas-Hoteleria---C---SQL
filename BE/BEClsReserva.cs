using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class BEClsReserva : Entidad
    {

        
        public DateTime FechaCheckIn { get; set; }
        public DateTime FechaCheckOut { get; set; }
        public int Cant_Dias { get; set; }
        public int Cant_Inquilinos { get; set; }
        public BEClsHabitacion Habitacion { get; set; }
        public BEClsCliente Cliente { get; set; }
       
        public double Importe { get; set; }
        public BEClsReserva() {  }
        public BEClsReserva(int id)
        {
            ID = id;

        }
        public BEClsReserva(DateTime fechaCheckIn, DateTime fechaCheckOut, int cantidadDias)
        {
            FechaCheckIn = fechaCheckIn;
            FechaCheckOut = fechaCheckOut;
            Cant_Dias = cantidadDias;
            

        }
        public double CalcularImporte()
        {
            
                Importe = Habitacion.ValorNoche * Cant_Dias;
            
            return Importe;
        }

    }
}

