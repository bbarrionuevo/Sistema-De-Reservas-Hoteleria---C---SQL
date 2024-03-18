using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class BEClsHotel : Entidad
    {
        #region Propiedades del hotel

        public List<BEClsCliente> Clientes { get; set; }
        //public List<BEClsEmpleado> Empleados { get; set; }
        public List<BEClsHabitacion> Habitaciones { get; set; }
        

        #endregion

        public BEClsHotel()
        {
            Clientes = new List<BEClsCliente>();
            Habitaciones = new List<BEClsHabitacion>();
            

        }
    }
}
