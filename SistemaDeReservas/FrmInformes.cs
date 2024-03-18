using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Windows.Forms.DataVisualization.Charting;
using BLL;
using BE;

namespace SistemaDeReservas
{
    public partial class FrmInformes : Form
    {
       

        public FrmInformes()
        {
            InitializeComponent();
            // Configurar el control Chart
            ConfigurarChart();
            
        }
        BLLClsCliente BLLcliente;
        private void ConfigurarChart()
        {
            BLLcliente = new BLLClsCliente();
            // Obtener los datos para el informe
            List<BEClsCliente> datosInforme = BLLcliente.ListarTodo();

            // Configurar el tipo de gráfico
            chart1.Series.Clear();
            chart1.Series.Add("Clientes");
            chart1.Series["Clientes"].ChartType = SeriesChartType.Column;

            // Agregar los datos al gráfico
            foreach (var dato in datosInforme)
            {
                chart1.Series["Clientes"].Points.AddXY(dato.Nombre, dato.Reservas.Count);
            }

            // Configurar el título y los ejes del gráfico
            chart1.Titles.Add("Informe de Clientes y Reservas");
            chart1.ChartAreas[0].AxisX.Title = "Clientes";
            chart1.ChartAreas[0].AxisY.Title = "Cantidad de Reservas";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                // Leer el archivo XML
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load("informes.xml");

                // Mostrar el contenido del archivo XML en el TextBox
                textBox1.Text = xmlDoc.OuterXml;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al leer el archivo XML: " + ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                // Leer el archivo XML
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load("informes.xml");

                // Obtener el texto a buscar
                string textoBusqueda = textBox2.Text;

                // Buscar el texto en el archivo XML
                XmlNodeList informes = xmlDoc.SelectNodes($"//Informe[contains(text(), '{textoBusqueda}')]");

                // Mostrar el resultado en el TextBox
                if (informes.Count > 0)
                {
                    StringBuilder sb = new StringBuilder();
                    foreach (XmlNode informe in informes)
                    {
                        sb.AppendLine(informe.InnerText);
                    }
                    textBox1.Text = sb.ToString();
                }
                else
                {
                    textBox1.Text = "No se encontraron informes que coincidan con la búsqueda.";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al buscar en el archivo XML: " + ex.Message);
            }
        }

        private void chart1_Click(object sender, EventArgs e)
        {
            // Aquí puedes agregar la lógica para manejar el evento Click del gráfico
        }
    }
}