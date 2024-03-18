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
    public class MPPClsHabitacion : IGestor<BEClsHabitacion>
    {
        //defino el obejto datos 
        Acceso oDatos;
        BEClsHotel BEHotel;
        ArrayList AP;
        public MPPClsHabitacion()
        {
            oDatos = new Acceso();
            BEHotel = new BEClsHotel();
        }

        public bool Baja(BEClsHabitacion Objeto)
        {

            AP = new ArrayList();
            string Consulta = "s_Habitacion_Baja";
           
                SqlParameter Param1 = new SqlParameter();
                Param1.ParameterName = "@IdHabitacion";
                Param1.Value = Objeto.ID;
                Param1.SqlDbType = SqlDbType.Int;
                AP.Add(Param1);

                return oDatos.Escribir(Consulta, AP);
            
        }

        public bool Guardar(BEClsHabitacion Objeto)
        {
            string Consulta;
            if (Objeto.ID != 0)
            {
                Consulta = "s_ModificarHabitacion";
                AP = new ArrayList();

                SqlParameter Param1 = new SqlParameter();
                Param1.ParameterName = "@Id";
                Param1.Value = Objeto.ID;
                Param1.SqlDbType = SqlDbType.Int;
                AP.Add(Param1);

                SqlParameter Param2 = new SqlParameter();
                Param2.ParameterName = "@Numero_Habitacion";
                Param2.Value = Objeto.Numero_Habitacion;
                Param2.SqlDbType = SqlDbType.DateTime;
                AP.Add(Param2);

                SqlParameter Param3 = new SqlParameter();
                Param3.ParameterName = "@piso";
                Param3.Value = Objeto.Piso;
                Param3.SqlDbType = SqlDbType.DateTime;
                AP.Add(Param3);

                SqlParameter Param4 = new SqlParameter();
                Param4.ParameterName = "@Capacidad";
                Param4.Value = Objeto.Capacidad;
                Param4.SqlDbType = SqlDbType.Int;
                AP.Add(Param4);

                SqlParameter Param5 = new SqlParameter();
                Param5.ParameterName = "@CamaDoble";
                Param5.Value = Objeto.CamaDoble;
                Param5.SqlDbType = SqlDbType.Decimal;
                AP.Add(Param5);

                SqlParameter Param6 = new SqlParameter();
                Param6.ParameterName = "@ValorNoche";
                Param6.Value = Objeto.ValorNoche;
                Param6.SqlDbType = SqlDbType.Int;
                AP.Add(Param6);

            }
            else
            {
                Consulta = "s_InsertarReserva";
                AP = new ArrayList();

                SqlParameter Param2 = new SqlParameter();
                Param2.ParameterName = "@Numero_Habitacion";
                Param2.Value = Objeto.Numero_Habitacion;
                Param2.SqlDbType = SqlDbType.DateTime;
                AP.Add(Param2);

                SqlParameter Param3 = new SqlParameter();
                Param3.ParameterName = "@piso";
                Param3.Value = Objeto.Piso;
                Param3.SqlDbType = SqlDbType.DateTime;
                AP.Add(Param3);

                SqlParameter Param4 = new SqlParameter();
                Param4.ParameterName = "@Capacidad";
                Param4.Value = Objeto.Capacidad;
                Param4.SqlDbType = SqlDbType.Int;
                AP.Add(Param4);

                SqlParameter Param5 = new SqlParameter();
                Param5.ParameterName = "@CamaDoble";
                Param5.Value = Objeto.CamaDoble;
                Param5.SqlDbType = SqlDbType.Decimal;
                AP.Add(Param5);

                SqlParameter Param6 = new SqlParameter();
                Param6.ParameterName = "@ValorNoche";
                Param6.Value = Objeto.ValorNoche;
                Param6.SqlDbType = SqlDbType.Int;
                AP.Add(Param6);

            }

            return oDatos.Escribir(Consulta, AP);
        }

        public List<BEClsHabitacion> ListarHabitaciones()
        {
            
            string consultaHabitaciones = "s_ListarHabitaciones";
            DataTable dt = oDatos.Leer(consultaHabitaciones, null);

            List<BEClsHabitacion> habitaciones = new List<BEClsHabitacion>();

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow fila in dt.Rows)
                {
                    if (fila["CamaDoble"] is DBNull)
                    {
                        BEClsHabitacionSimple habitacionSimple = new BEClsHabitacionSimple();
                        habitacionSimple.ID = Convert.ToInt32(fila["ID"]);
                        habitacionSimple.ValorNoche = Convert.ToInt32(fila["ValorNoche"]);
                        habitacionSimple.Numero_Habitacion = fila["Numero_Habitacion"].ToString();
                        habitacionSimple.Piso = Convert.ToInt32(fila["Piso"]);
                        habitacionSimple.Capacidad = Convert.ToInt32(fila["Capacidad"]);
                        habitaciones.Add(habitacionSimple);
                    }
                    else
                    {
                        BEClsHabitacionDoble habitacionDoble = new BEClsHabitacionDoble();
                        habitacionDoble.ID = Convert.ToInt32(fila["ID"]);
                        habitacionDoble.ValorNoche = Convert.ToInt32(fila["ValorNoche"]);
                        habitacionDoble.Numero_Habitacion = fila["Numero_Habitacion"].ToString();
                        habitacionDoble.Piso = Convert.ToInt32(fila["Piso"]);
                        habitacionDoble.Capacidad = Convert.ToInt32(fila["Capacidad"]);
                        habitacionDoble.CamaDoble = true;
                        habitaciones.Add(habitacionDoble);
                    }
                }
            }
            BEHotel.Habitaciones = habitaciones;
            return habitaciones;
        }

        public BEClsHabitacion ListarObjeto(BEClsHabitacion Objeto)
        {
            throw new NotImplementedException();
        }

        public List<BEClsHabitacion> ListarTodo()
        {
            throw new NotImplementedException();
        }

        public BEClsHabitacion ObtenerHabitacionPorId(int idHabitacion)
        {
            BEClsHabitacion habitacion = null;
            AP = new ArrayList();
            string consultaHabitacion = "s_ObtenerHabitacionPorId";
            SqlParameter paramIdHabitacion = new SqlParameter("@IdHabitacion", idHabitacion);

            AP.Add(paramIdHabitacion);

            DataTable dtHabitacion = oDatos.Leer(consultaHabitacion, AP);

            if (dtHabitacion.Rows.Count > 0)
            {
                DataRow filaHabitacion = dtHabitacion.Rows[0];

                habitacion = new BEClsHabitacion();
                habitacion.ID = Convert.ToInt32(filaHabitacion["ID"]);
                habitacion.ValorNoche = Convert.ToDouble(filaHabitacion["ValorNoche"]);
                habitacion.Numero_Habitacion = filaHabitacion["Numero_Habitacion"].ToString();
                habitacion.Piso = Convert.ToInt32(filaHabitacion["Piso"]);
                habitacion.Capacidad = Convert.ToInt32(filaHabitacion["Capacidad"]);
                

            }

            return habitacion;
        }

    }
}
