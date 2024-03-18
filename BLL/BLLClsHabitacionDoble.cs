using Abstraccion;
using BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;

namespace BLL
{
    public class BLLClsHabitacionDoble : BLLClsHabitacion
    {
        BEClsHabitacionDoble BEHabitacion; 

          public BLLClsHabitacionDoble()
        { 
      
            BEHabitacion = new BEClsHabitacionDoble();
        }
        public override decimal CalcularImporte(int CantidadDias)
        {
            return (decimal)(BEHabitacion.ValorNoche * CantidadDias);

        }
    }
}
