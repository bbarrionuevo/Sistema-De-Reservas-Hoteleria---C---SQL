using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using MPP;

namespace BLL
{
    public class BLLClsReserva
    {
        MPPClsReserva MPPReserva;
        BEClsHotel bEClsHotel;
        BLLClsHabitacion BLLHabitacion;
        public BLLClsReserva()
        {
            MPPReserva = new MPPClsReserva();
            bEClsHotel = new BEClsHotel();
            BLLHabitacion = new BLLClsHabitacion(); 
        }


        public bool AgregarReserva(BEClsReserva BEreserva, BEClsCliente Cliente, BEClsHabitacion Habitacion)
        {
            
            
            MPPReserva.ObtenerReservasDeHabitacion(Habitacion);
            if (Habitacion != null || Cliente != null)
            {
                // Verifica si la habitación está disponible para las fechas de la reserva
                if (BLLHabitacion.EsDisponible(Habitacion, BEreserva))
                {

                    BEreserva.Habitacion = Habitacion;
                    BEreserva.Cliente = Cliente;
                    BEreserva.CalcularImporte();
                    BEreserva.Cant_Inquilinos = Habitacion.Capacidad;

                    MPPReserva.AgregarReserva(BEreserva);

                    // Devuelve true para indicar que la reserva se realizó con éxito
                    return true;
                }
                else { return false; }
            }
            else { return false; }
            // Si la habitación no está disponible o no se encuentra, devuelve false

        }

        public void BajaReserva(BEClsReserva BEreserva)
        {
            try
            {

                MPPReserva.BajaReserva(BEreserva);

            }
            catch (Exception ex) { throw ex; }
        }

        public object RetornaListaReservasDeClientes(BEClsCliente BEcliente)
        {

            

            return (from r in MPPReserva.ObtenerReservasDelCliente(BEcliente) select new { Codigo_De_Reserva = r.ID, Codigo_De_Habitacion = r.Habitacion.ID, CheckIn = r.FechaCheckIn, CheckOut = r.FechaCheckOut, Cantidad_Dias = r.Cant_Dias, Camtidad_Inquilinos = r.Cant_Inquilinos, Codigo_Cliente = r.Cliente.ID, Importe_Total = r.Importe }).ToArray();

        }
    }
}
