using BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using MPP;
using Abstraccion;

namespace BLL
{
    public class BLLClsHabitacion : IGestor<BEClsHabitacion>
    {

        MPPClsHabitacion MPPHabitacion;
        BEClsHotel BEHotel;
        public BLLClsHabitacion()
        {
            MPPHabitacion = new MPPClsHabitacion();
            BEHotel = new BEClsHotel();
        }
        

        public object RetornaListaHabitaciones()
        {

            return MPPHabitacion.ListarHabitaciones();
        }

        // Método para verificar la disponibilidad de la habitación para un rango de fechas
        public bool EsDisponible(BEClsHabitacion BEHabitacion, BEClsReserva BEReserva)
        {
            // Verifica si la habitación está ocupada en algún momento durante el rango de fechas
            return !BEHabitacion.Reservas.Any(r => (BEReserva.FechaCheckIn >= r.FechaCheckIn && BEReserva.FechaCheckIn < r.FechaCheckOut) ||
                                       (BEReserva.FechaCheckOut > r.FechaCheckIn && BEReserva.FechaCheckOut <= r.FechaCheckOut));
        }

        public virtual decimal CalcularImporte( int CantidadDias)
        {
            // Implementación genérica para el cálculo del importe 
            return 0;
        }

        public bool Guardar(BEClsHabitacion Objeto)
        {
            return MPPHabitacion.Guardar(Objeto);
        }

        public bool Baja(BEClsHabitacion Objeto)
        {
            return MPPHabitacion.Baja(Objeto);
        }

        public List<BEClsHabitacion> ListarTodo()
        {
            return MPPHabitacion.ListarHabitaciones();
        }

        public BEClsHabitacion ListarObjeto(BEClsHabitacion Objeto)
        {
            throw new NotImplementedException();
        }
    }
}
