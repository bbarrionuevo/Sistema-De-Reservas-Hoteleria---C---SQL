using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abstraccion;

namespace BE
{
    public class BEClsCliente : BEClsPersona
    {
       
        

        public List<BEClsReserva> Reservas { get; set; }
        public BEClsCliente() 
        {
            Reservas = new List<BEClsReserva>();
        }
        public BEClsCliente(int id)
        {
            ID=id;
        }

    }
}

