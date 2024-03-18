using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using Abstraccion;
using MPP;


namespace BLL
{
    public class BLLClsCliente : IGestor<BEClsCliente>
    {

        public BLLClsCliente() 
        {
            MPPCliente = new MPPClsCliente();
            MPPReserva = new MPPClsReserva();
        }
        MPPClsCliente MPPCliente;
        MPPClsReserva MPPReserva;





        

        public bool Guardar(BEClsCliente BEcliente)
        {
            return MPPCliente.Guardar(BEcliente);
        }

        public bool Baja(BEClsCliente BECliente)
        {
            
            if (!MPPCliente.Baja(BECliente))
            {
                throw new Exception("El Cliente cuenta con reservas pendientes, Cancele las mismas antes de realizar Baja de cliente");
            }
            return true;
        }

        public List<BEClsCliente> ListarTodo()
        {
            return MPPCliente.ListarClientes();
        }

        public BEClsCliente ListarObjeto(BEClsCliente Objeto)
        {
            throw new NotImplementedException();
        }
    }
}
