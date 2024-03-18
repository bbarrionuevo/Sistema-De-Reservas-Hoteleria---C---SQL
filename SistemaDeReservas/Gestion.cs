using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using BLL;
using BE;
using System.Xml.Linq;
using System.Xml;
using System.IO;

namespace SistemaDeReservas
{
    public partial class Gestion : Form
    {
        BLLClsHotel BLLhotel;
        BLLClsCliente BLLcliente;
        BLLClsReserva BLLreserva;
        BEClsHotel BEhotel;
        BEClsCliente BEcliente;
        BEClsReserva BEreserva;
        BLLClsHabitacion BLLHabitacion;
        Regex re;
        Regex re2;

        public Gestion()
        {
            InitializeComponent();

            BLLhotel = new BLLClsHotel();
            BLLcliente = new BLLClsCliente();
            BLLreserva = new BLLClsReserva();
            BEhotel = new BEClsHotel();
            BLLHabitacion = new BLLClsHabitacion();


        }
        public void Mostrar(DataGridView pDGV, object p0)
        {
            pDGV.DataSource = null; pDGV.DataSource = p0;


        }
        public void ActualizarListas()
        { Mostrar(dataGridView1, BLLcliente.ListarTodo()); }
        private void Form1_Load(object sender, EventArgs e)
        {
            Mostrar(dataGridView2, BLLHabitacion.RetornaListaHabitaciones());
            Mostrar(dataGridView1, BLLcliente.ListarTodo());

           
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
        //Boton ABM Cliente
        private void button7_Click(object sender, EventArgs e)
        {
            Frm_ABM_Clientes frmCliente = new Frm_ABM_Clientes();
            frmCliente.Show(); // Muestra el formulario
        }
      
        
        //Alta Reservas
        private void button4_Click(object sender, EventArgs e)
        {
            try
            {

                // Verifica si se ha seleccionado un cliente y una habitación

                if (dataGridView1.SelectedRows.Count == 0 || dataGridView2.SelectedRows.Count == 0)
                    throw new Exception("Selecciona un cliente y una habitación para realizar la reserva.");

                // Obtiene las fechas de check-in y check-out desde los controles DateTimePicker
                DateTime fechaCheckIn = dtpCheckIn.Value;
                DateTime fechaCheckOut = dtpCheckOut.Value;
                int cantidadDias = Convert.ToInt32((fechaCheckOut - fechaCheckIn).TotalDays); // Calcula la cantidad de días
                if (cantidadDias <= 0) throw new Exception("la reserva debe ser de minimo 1 noche");
                // Crea una instancia de Reserva
                BEClsReserva reserva = new BEClsReserva(fechaCheckIn, fechaCheckOut, cantidadDias);
                BEClsHabitacion Habitacion= new BEClsHabitacion(Convert.ToInt32(dataGridView2.SelectedRows[0].Cells[5].Value));
                Habitacion.ValorNoche= Convert.ToDouble(dataGridView2.SelectedRows[0].Cells[0].Value);
                Habitacion.Capacidad = Convert.ToInt32(dataGridView2.SelectedRows[0].Cells[3].Value);
                BEClsCliente Cliente = new BEClsCliente(Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[6].Value));
                // Agrega la reserva al hotel
                if (BLLreserva.AgregarReserva(reserva,Cliente, Habitacion))
                {
                    MessageBox.Show("Reserva realizada con éxito.");


                    BEClsCliente cliente = new BEClsCliente(Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[6].Value));

                    Mostrar(dataGridView3, BLLreserva.RetornaListaReservasDeClientes(cliente));
                    // Crear el informe de alta
                    string informe = $"Alta de reserva - ID: {reserva.ID}, Fecha: {DateTime.Now}";

                    // Guardar el informe en el archivo XML
                    GuardarInformeReserva(informe);
                }
                else

                    MessageBox.Show("La habitación no está disponible para las fechas seleccionadas.");

            }

            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
        //Modificar Reservas
        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView3.Rows.Count == 0) throw new Exception("No hay nada para modificar !!!");
                // Obtiene las fechas de check-in y check-out desde los controles DateTimePicker
                DateTime fechaCheckIn = dtpCheckIn.Value;
                DateTime fechaCheckOut = dtpCheckOut.Value;
                int cantidadDias = Convert.ToInt32((fechaCheckOut - fechaCheckIn).TotalDays); // Calcula la cantidad de días
                if (cantidadDias <= 0) throw new Exception("la reserva debe ser de minimo 1 noche");
                // Crea una instancia de Reserva
                BEClsReserva reserva = new BEClsReserva(fechaCheckIn, fechaCheckOut, cantidadDias);
                reserva.ID = Convert.ToInt32(dataGridView3.SelectedRows[0].Cells[0].Value);
                BEClsHabitacion Habitacion = new BEClsHabitacion(Convert.ToInt32(dataGridView2.SelectedRows[0].Cells[5].Value));
                Habitacion.ValorNoche = Convert.ToDouble(dataGridView2.SelectedRows[0].Cells[0].Value);
                Habitacion.Capacidad = Convert.ToInt32(dataGridView2.SelectedRows[0].Cells[3].Value);
                BEClsCliente Cliente = new BEClsCliente(Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[6].Value));
               
              
                if (BLLreserva.AgregarReserva(reserva, Cliente, Habitacion))
                {
                    MessageBox.Show("Reserva realizada con éxito.");
                    // Actualiza los DataGridViews
                    BEClsCliente cliente = new BEClsCliente(Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[6].Value));
                    
                    Mostrar(dataGridView3, BLLreserva.RetornaListaReservasDeClientes(cliente));
                    // Crear el informe de modificación
                    string informe = $"Modificación de reserva - ID: {reserva.ID}, Fecha: {DateTime.Now}";

                    // Guardar el informe en el archivo XML
                    GuardarInformeReserva(informe);

                }
                else

                    MessageBox.Show("La habitación no está disponible para las fechas seleccionadas.");

            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
        //Baja de Reserva
        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView3.Rows.Count == 0) throw new Exception("No hay nada para borrar !!!");
                BEClsReserva reserva = new BEClsReserva(Convert.ToInt32(dataGridView3.SelectedRows[0].Cells[0].Value));
                BLLreserva.BajaReserva(reserva);
                BEClsCliente cliente = new BEClsCliente(Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[6].Value));
                Mostrar(dataGridView3, BLLreserva.RetornaListaReservasDeClientes(cliente));

                // Crear el informe de baja
                string informe = $"Baja de reserva - ID: {reserva.ID}, Fecha: {DateTime.Now}";

                // Guardar el informe en el archivo XML
                GuardarInformeReserva(informe);
                throw new Exception("Baja de Reserva realizada con exito !!!");
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
        private void GuardarInformeReserva(string informe)
        {
            try
            {
                // Crear el archivo XML si no existe
                if (!File.Exists("informes.xml"))
                {
                    using (XmlWriter writer = XmlWriter.Create("informes.xml"))
                    {
                        writer.WriteStartDocument();
                        writer.WriteStartElement("Informes");
                        writer.WriteEndElement();
                        writer.WriteEndDocument();
                    }
                }

                // Agregar el informe al archivo XML
                XDocument doc = XDocument.Load("informes.xml");
                XElement informeElement = new XElement("Informe", informe);
                doc.Element("Informes").Add(informeElement);
                doc.Save("informes.xml");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar el informe en el archivo XML: " + ex.Message);
            }
        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }



        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int clienteID = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[6].Value);
                BEClsCliente cliente = new BEClsCliente(clienteID);

                Mostrar(dataGridView3, BLLreserva.RetornaListaReservasDeClientes(cliente));
                
            }
            catch (Exception) { }
        }






        private void dataGridView2_RowEnter(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView3_RowEnter(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Mostrar(dataGridView2, BLLHabitacion.RetornaListaHabitaciones());
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Frm_ABM_Habitacion frmHabitacion = new Frm_ABM_Habitacion();
            frmHabitacion.Show(); // Muestra el formulario
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
                Application.Exit();
          

        }
    }
}
