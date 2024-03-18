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
    public class MPPClsReserva
    {
        //defino el obejto datos 
        Acceso oDatos;
        ArrayList AP;
        MPPClsHabitacion MPPHabitacion;
        public MPPClsReserva()
        {
            oDatos = new Acceso();

            MPPHabitacion = new MPPClsHabitacion();
        }

        //Agregar reserva en BD
        public bool AgregarReserva(BEClsReserva BEReserva)
        {
            string Consulta;
            if (BEReserva.ID != 0)
            {
                Consulta = "s_ActualizarReserva";
                AP = new ArrayList();

                SqlParameter Param1 = new SqlParameter();
                Param1.ParameterName = "@IdReserva";
                Param1.Value = BEReserva.ID;
                Param1.SqlDbType = SqlDbType.Int;
                AP.Add(Param1);

                SqlParameter Param2 = new SqlParameter();
                Param2.ParameterName = "@FechaCheckIn";
                Param2.Value = BEReserva.FechaCheckIn;
                Param2.SqlDbType = SqlDbType.DateTime;
                AP.Add(Param2);

                SqlParameter Param3 = new SqlParameter();
                Param3.ParameterName = "@FechaCheckOut";
                Param3.Value = BEReserva.FechaCheckOut;
                Param3.SqlDbType = SqlDbType.DateTime;
                AP.Add(Param3);

                SqlParameter Param4 = new SqlParameter();
                Param4.ParameterName = "@CantDias";
                Param4.Value = BEReserva.Cant_Dias;
                Param4.SqlDbType = SqlDbType.Int;
                AP.Add(Param4);

                SqlParameter Param5 = new SqlParameter();
                Param5.ParameterName = "@Importe";
                Param5.Value = BEReserva.Importe;
                Param5.SqlDbType = SqlDbType.Decimal;
                AP.Add(Param5);

                SqlParameter Param6 = new SqlParameter();
                Param6.ParameterName = "@CantInquilinos";
                Param6.Value = BEReserva.Cant_Inquilinos;
                Param6.SqlDbType = SqlDbType.Int;
                AP.Add(Param6);

                SqlParameter Param7 = new SqlParameter();
                Param7.ParameterName = "@IdHabitacion";
                Param7.Value = BEReserva.Habitacion.ID;
                Param7.SqlDbType = SqlDbType.Int;
                AP.Add(Param7);

                SqlParameter Param8 = new SqlParameter();
                Param8.ParameterName = "@IdCliente";
                Param8.Value = BEReserva.Cliente.ID;
                Param8.SqlDbType = SqlDbType.Int;
                AP.Add(Param8);
            }
            else
            {
                Consulta = "s_InsertarReserva";
                AP = new ArrayList();

                SqlParameter Param1 = new SqlParameter();
                Param1.ParameterName = "@FechaCheckIn";
                Param1.Value = BEReserva.FechaCheckIn;
                Param1.SqlDbType = SqlDbType.DateTime;
                AP.Add(Param1);

                SqlParameter Param2 = new SqlParameter();
                Param2.ParameterName = "@FechaCheckOut";
                Param2.Value = BEReserva.FechaCheckOut;
                Param2.SqlDbType = SqlDbType.DateTime;
                AP.Add(Param2);

                SqlParameter Param3 = new SqlParameter();
                Param3.ParameterName = "@CantDias";
                Param3.Value = BEReserva.Cant_Dias;
                Param3.SqlDbType = SqlDbType.Int;
                AP.Add(Param3);

                SqlParameter Param4 = new SqlParameter();
                Param4.ParameterName = "@Importe";
                Param4.Value = BEReserva.Importe;
                Param4.SqlDbType = SqlDbType.Decimal;
                AP.Add(Param4);

                SqlParameter Param5 = new SqlParameter();
                Param5.ParameterName = "@CantInquilinos";
                Param5.Value = BEReserva.Cant_Inquilinos;
                Param5.SqlDbType = SqlDbType.Int;
                AP.Add(Param5);

                SqlParameter Param6 = new SqlParameter();
                Param6.ParameterName = "@IdHabitacion";
                Param6.Value = BEReserva.Habitacion.ID;
                Param6.SqlDbType = SqlDbType.Int;
                AP.Add(Param6);

                SqlParameter Param7 = new SqlParameter();
                Param7.ParameterName = "@IdCliente";
                Param7.Value = BEReserva.Cliente.ID;
                Param7.SqlDbType = SqlDbType.Int;
                AP.Add(Param7);
            }

            return oDatos.Escribir(Consulta, AP);
        }


        public List<BEClsReserva> ObtenerReservasDelCliente(BEClsCliente BECliente)
        {
            AP = new ArrayList();
            DataTable DsReservas;
            string ConsultaReservas = "s_ObtenerReservasDelCliente";
            List<BEClsReserva> reservas = new List<BEClsReserva>();

            SqlParameter Param1 = new SqlParameter();
            Param1.ParameterName = "@IdCliente";
            Param1.Value = BECliente.ID;
            Param1.SqlDbType = SqlDbType.Int;

            AP.Add(Param1);

            DsReservas = oDatos.Leer(ConsultaReservas, AP);

            if (DsReservas.Rows.Count > 0)
            {
                foreach (DataRow filaReserva in DsReservas.Rows)
                {
                    BEClsReserva reserva = new BEClsReserva();
                    reserva.ID = Convert.ToInt32(filaReserva["ID"]);
                    reserva.FechaCheckIn = Convert.ToDateTime(filaReserva["FechaCheckIn"]);
                    reserva.FechaCheckOut = Convert.ToDateTime(filaReserva["FechaCheckOut"]);
                    reserva.Cant_Dias = Convert.ToInt32(filaReserva["Cant_Dias"]);
                    reserva.Cant_Inquilinos = Convert.ToInt32(filaReserva["Cant_Inquilinos"]);
                    reserva.Importe = Convert.ToInt32(filaReserva["Importe"]);
                    reserva.Cliente = BECliente;

                    // Obtener la habitación de la reserva
                    int idHabitacion = Convert.ToInt32(filaReserva["ID_Habitacion"]);
                    BEClsHabitacion habitacion = MPPHabitacion.ObtenerHabitacionPorId(idHabitacion); 
                    reserva.Habitacion = habitacion;

                    reservas.Add(reserva);
                }
            }
            BECliente.Reservas = reservas;
            return reservas;
        }
        public List<BEClsReserva> ObtenerReservasDeHabitacion(BEClsHabitacion Habitacion)
        {

            AP = new ArrayList();
            DataTable DsReservas;
            string ConsultaReservas = "s_ObtenerReservasDeHabitacion";
            List<BEClsReserva> reservas = new List<BEClsReserva>();

            SqlParameter Param1 = new SqlParameter();
            Param1.ParameterName = "@IdHabitacion";
            Param1.Value = Habitacion.ID;
            Param1.SqlDbType = SqlDbType.Int;

            
            AP.Add(Param1);

            DsReservas = oDatos.Leer(ConsultaReservas, AP);

            if (DsReservas.Rows.Count > 0)
            {
                foreach (DataRow filaReserva in DsReservas.Rows)
                {
                    BEClsReserva reserva = new BEClsReserva();
                    reserva.ID = Convert.ToInt32(filaReserva["ID"]);
                    reserva.FechaCheckIn = Convert.ToDateTime(filaReserva["FechaCheckIn"]);
                    reserva.FechaCheckOut = Convert.ToDateTime(filaReserva["FechaCheckOut"]);
                    reserva.Cant_Dias = Convert.ToInt32(filaReserva["Cant_Dias"]);
                    reserva.Importe = Convert.ToInt32(filaReserva["Importe"]);
                    reserva.Cant_Inquilinos = Convert.ToInt32(filaReserva["Cant_Inquilinos"]);
                    

                    reservas.Add(reserva);
                }
            }
            Habitacion.Reservas = reservas;
            return Habitacion.Reservas;
        }
        public bool BajaReserva(BEClsReserva BEReserva)
        {
            string Consulta = "s_BajaReserva";
            AP = new ArrayList();

            SqlParameter Param1 = new SqlParameter();
            Param1.ParameterName = "@IdReserva";
            Param1.Value = BEReserva.ID;
            Param1.SqlDbType = SqlDbType.Int;
            AP.Add(Param1);

            return oDatos.Escribir(Consulta, AP);
        }


    }
}
