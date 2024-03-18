using BE;
using MPP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BLLClsEmpleado
    {
        MPPClsEmpleado MPPEmpleado;
        public BLLClsEmpleado()
        {
            MPPEmpleado = new MPPClsEmpleado();
        }
        public bool ValidarCredenciales(BEClsEmpleado BEEmpleado)
        {
            if (MPPEmpleado.ValidarCredenciales(BEEmpleado)) { return true; }
            else { return false; }
        }
    }
}
