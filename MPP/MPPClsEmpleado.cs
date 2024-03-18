using BE;
using DAL;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPP
{
    public class MPPClsEmpleado
    {
        //defino el obejto datos 
        Acceso oDatos;
        ArrayList AP;
        public MPPClsEmpleado()
        {
            oDatos = new Acceso();
        }
        public bool ValidarCredenciales(BEClsEmpleado BEEmpleado)
        {
            try
            {
                string consulta = "s_ValidarCredenciales";
                AP = new ArrayList();

                SqlParameter Param1 = new SqlParameter();
                Param1.ParameterName = "@Usuario";
                Param1.Value = BEEmpleado.Usuario;
                Param1.SqlDbType = SqlDbType.VarChar;
                AP.Add(Param1);

                SqlParameter Param2 = new SqlParameter();
                Param2.ParameterName = "@Contrasena";
                Param2.Value = BEEmpleado.Constraseña;
                Param2.SqlDbType = SqlDbType.VarChar;
                AP.Add(Param2);

                return oDatos.LeerScalar(consulta, AP);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
