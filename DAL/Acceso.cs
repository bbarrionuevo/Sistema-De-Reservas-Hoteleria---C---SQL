using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Collections;

namespace DAL
{
    public class Acceso
    {
        string CadenaC = @"Data Source = .\SQLEXPRESS; Initial Catalog = GestionReservas; Integrated Security = True";
        private SqlConnection oCnn = new SqlConnection(@"Data Source = .\SQLEXPRESS; Initial Catalog = GestionReservas; Integrated Security = True");
        //Creo el objeto command
        SqlCommand cmd;
        //declaro el objeto transacction
        private SqlTransaction Tranx;

        // creo una funcion para saber el estado de la conexion
        public string TestConnection()
        {
            oCnn.Open();
          
            if (oCnn.State == ConnectionState.Open)
            {
                return "Conexion a la BD OK";
            }
            else
            {
                return "No se pudo conectar a la BD";
            }
        }



        //Metodo Generico para leer que devuelve un datatable
        public DataTable Leer(string consulta, ArrayList Parametros)
        {
            DataTable Dt = new DataTable();
            SqlDataAdapter Da;
            // Paso la consulta y el objeto connection en el constructor
            cmd = new SqlCommand(consulta, oCnn);
            cmd.CommandType = CommandType.StoredProcedure;

            try
            {
                Da = new SqlDataAdapter(cmd);

                if (Parametros != null)
                {
                    // Si el ArrayList no está vacío
                    foreach (SqlParameter parametro in Parametros)
                    {
                        // Agrego los parámetros al comando
                        cmd.Parameters.AddWithValue(parametro.ParameterName, parametro.Value);
                    }
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            Da.Fill(Dt);
            return Dt;
        }

        public bool LeerScalar(string Consulta, ArrayList Parametros)
        {
            oCnn.Open();
            //uso el constructor del objeto Command
            cmd = new SqlCommand(Consulta, oCnn);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                if ((Parametros != null))
                {
                    foreach (SqlParameter dato in Parametros)
                    {
                        
                        cmd.Parameters.AddWithValue(dato.ParameterName, dato.Value);
                    }
                }

                int Respuesta = Convert.ToInt32(cmd.ExecuteScalar());
                oCnn.Close();
                if (Respuesta > 0)
                { return true; }
                else
                { return false; }
            }
            catch (SqlException ex)
            { throw ex; }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public bool Escribir(string Consulta, ArrayList Parametros)
        {

            if (oCnn.State == ConnectionState.Closed)
            {
                oCnn.ConnectionString = CadenaC;
                oCnn.Open();
            }

            try
            {
                Tranx = oCnn.BeginTransaction();
               
                cmd = new SqlCommand(Consulta, oCnn, Tranx);
                
                cmd.CommandType = CommandType.StoredProcedure;

                if ((Parametros != null))
                {
                    foreach (SqlParameter dato in Parametros)
                    {
                        
                        cmd.Parameters.AddWithValue(dato.ParameterName, dato.Value);
                    }
                }

                int respuesta = cmd.ExecuteNonQuery();
                Tranx.Commit();
                return true;

            }

            catch (SqlException ex)
            {
                Tranx.Rollback();
                return false;
            }
            catch (Exception ex)
            {
                
                Tranx.Rollback();
                return false;
            }
            finally
            { oCnn.Close(); }


        }

    }
}
