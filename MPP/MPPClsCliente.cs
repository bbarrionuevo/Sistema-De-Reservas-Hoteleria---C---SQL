using Abstraccion;
using BE;
using DAL;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPP
{
    public class MPPClsCliente : IGestor<BEClsCliente>
    {
        //defino el obejto datos 
        Acceso oDatos;
        BEClsCliente BECliente;
        BEClsHotel BEHotel;
        ArrayList AP;
        MPPClsReserva MPPReserva;
        public MPPClsCliente()
        {
            oDatos = new Acceso();
            BECliente = new BEClsCliente();
            BEHotel = new BEClsHotel();
            MPPReserva = new MPPClsReserva();
        }

        
        public bool Baja(BEClsCliente oBECliente)
        {
            AP = new ArrayList();
            string Consulta = "s_Cliente_Baja";
            if (!BECliente.Reservas.Any())
            {

                SqlParameter Param1 = new SqlParameter();
            Param1.ParameterName = "@IdCliente";
            Param1.Value = oBECliente.ID;
            Param1.SqlDbType = SqlDbType.Int;
             AP.Add(Param1);

            return oDatos.Escribir(Consulta, AP);
            }
            else
            { return false; }

        }

        //Agregar Cliente en BD

        public bool Guardar(BEClsCliente BECliente)
        {
            AP = new ArrayList();
            string Consulta = "s_Cliente_Crear";


            if (BECliente.ID != 0)
            {
                SqlParameter Param7 = new SqlParameter();
                Param7.ParameterName = "@IdCliente";
                Param7.Value = BECliente.ID;
                Param7.SqlDbType = SqlDbType.Int;
                AP.Add(Param7);
                Consulta = "s_Cliente_Modificar";
            }

            SqlParameter Param1 = new SqlParameter();
            Param1.ParameterName = "@Nombre";
            Param1.Value = BECliente.Nombre;
            Param1.SqlDbType = SqlDbType.VarChar;
            AP.Add(Param1);

            SqlParameter Param2 = new SqlParameter("@Apellido", BECliente.Apellido);
            AP.Add(Param2);

            SqlParameter Param3 = new SqlParameter("@DNI", BECliente.DNI);
            AP.Add(Param3);

            SqlParameter Param4 = new SqlParameter("@Nacionalidad", BECliente.Nacionalidad);
            AP.Add(Param4);

            SqlParameter Param5 = new SqlParameter("@Telefono", BECliente.Telefono);
            AP.Add(Param5);

            SqlParameter Param6 = new SqlParameter("@Mail", BECliente.Mail);
            AP.Add(Param6);

            return oDatos.Escribir(Consulta, AP); 

            

        }
        public List<BEClsCliente> ListarClientes()
        {
            
            List<BEClsCliente> clientes = new List<BEClsCliente>();

            DataTable dt = oDatos.Leer("S_Cliente_Listar", null);

            if (dt.Rows.Count > 0)
            {

                foreach (DataRow filaCliente in dt.Rows)
                {
                    BEClsCliente cliente = new BEClsCliente();

                    cliente.ID = Convert.ToInt32(filaCliente["ID"]);
                    cliente.Nombre = filaCliente["Nombre"].ToString();
                    cliente.Apellido = filaCliente["Apellido"].ToString();
                    cliente.DNI = filaCliente["DNI"].ToString();
                    cliente.Nacionalidad = filaCliente["Nacionalidad"].ToString();
                    cliente.Telefono = Convert.ToInt32(filaCliente["Telefono"]);
                    cliente.Mail = filaCliente["Mail"].ToString();


                    // cargar las reservas del cliente 
                    cliente.Reservas = MPPReserva.ObtenerReservasDelCliente(cliente);

                    clientes.Add(cliente);
                }

            }
            BEHotel.Clientes = clientes;
            return BEHotel.Clientes;
        }

        public BEClsCliente ListarObjeto(BEClsCliente Objeto)
        {
            throw new NotImplementedException();
        }

        public List<BEClsCliente> ListarTodo()
        {
            throw new NotImplementedException();
        }
    }
}
