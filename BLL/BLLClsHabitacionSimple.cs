using Abstraccion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;

namespace BLL
{
    public class BLLClsHabitacionSimple : BLLClsHabitacion
    {
        BEClsHabitacionSimple BEHabitacion;

        public BLLClsHabitacionSimple()
        {

            BEHabitacion = new BEClsHabitacionSimple();
        }
        public override decimal CalcularImporte(int CantidadDias)
        {
            return (decimal)(BEHabitacion.ValorNoche * CantidadDias);

        }
    }
}
