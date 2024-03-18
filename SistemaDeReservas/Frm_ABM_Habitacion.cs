using BE;
using BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace SistemaDeReservas
{
    public partial class Frm_ABM_Habitacion : Form
    {
        Regex re2;
        BLLClsHabitacion BLLHabitacion;
        public Frm_ABM_Habitacion()
        {
            InitializeComponent();
            BLLHabitacion = new BLLClsHabitacion(); 
        }
        public void Mostrar(DataGridView pDGV, object p0)
        {
            pDGV.DataSource = null; pDGV.DataSource = p0;


        }
        //agregar habitacion
        private void Button2_Click(object sender, EventArgs e)
        {


            try
            {
                if (comboBox1.Text == "Simple")
                {
                    BEClsHabitacionSimple BEHabitacionSimple = new BEClsHabitacionSimple();
                    re2 = new Regex(@"\d{2}");
                    string num = TextBox1.Text;
                    if (!(re2.IsMatch(num) && num.Length == 2)) throw new Exception("El numero de Habitacion no posee el formato correcto !!!");
                    BEHabitacionSimple.Piso = int.Parse(textBox5.Text);
                    BEHabitacionSimple.Capacidad = int.Parse(textBox6.Text);
                    BEHabitacionSimple.ValorNoche = double.Parse(textBox4.Text);
                    BEHabitacionSimple.CamaDoble = false;
                    BLLHabitacion.Guardar(BEHabitacionSimple);
                    Mostrar(dataGridHabitacion, BLLHabitacion.ListarTodo());
                    MessageBox.Show("Alta de Cliente realizada con éxito.");
                }
                else
                {
                    BEClsHabitacionDoble BEHabitacionDoble = new BEClsHabitacionDoble();
                    re2 = new Regex(@"\d{2}");
                    string num = TextBox1.Text;
                    if (!(re2.IsMatch(num) && num.Length == 2)) throw new Exception("El numero de Habitacion no posee el formato correcto !!!");
                    BEHabitacionDoble.Piso = int.Parse(textBox5.Text);
                    BEHabitacionDoble.Capacidad = int.Parse(textBox6.Text);
                    BEHabitacionDoble.ValorNoche = double.Parse(textBox4.Text);
                    BEHabitacionDoble.CamaDoble = true;
                    BLLHabitacion.Guardar(BEHabitacionDoble);
                    Mostrar(dataGridHabitacion, BLLHabitacion.ListarTodo());
                    MessageBox.Show("Alta de Cliente realizada con éxito.");
                }
                
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
        //modificar habitacion
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridHabitacion.Rows.Count == 0) throw new Exception("No hay nada para modificar !!!");
                DataGridViewRow row = dataGridHabitacion.SelectedRows[0];
                int habitacionID = Convert.ToInt32(row.Cells["ID"].Value);

                if (comboBox1.Text == "Simple")
                {
                    BEClsHabitacionSimple habitacionSimple = new BEClsHabitacionSimple();
                    habitacionSimple.ID = habitacionID;
                    habitacionSimple.Numero_Habitacion = TextBox1.Text;
                    habitacionSimple.Piso = int.Parse(textBox5.Text);
                    habitacionSimple.Capacidad = int.Parse(textBox6.Text);
                    habitacionSimple.ValorNoche = double.Parse(textBox4.Text);
                    habitacionSimple.CamaDoble = false;
                    BLLHabitacion.Guardar(habitacionSimple);
                    Mostrar(dataGridHabitacion, BLLHabitacion.ListarTodo());
                    MessageBox.Show("Modificación de habitación realizada con éxito.");
                }
                else
                {
                    BEClsHabitacionDoble habitacionDoble = new BEClsHabitacionDoble();
                    habitacionDoble.ID = habitacionID;
                    habitacionDoble.Numero_Habitacion = TextBox1.Text;
                    habitacionDoble.Piso = int.Parse(textBox5.Text);
                    habitacionDoble.Capacidad = int.Parse(textBox6.Text);
                    habitacionDoble.ValorNoche = double.Parse(textBox4.Text);
                    habitacionDoble.CamaDoble = true;
                    BLLHabitacion.Guardar(habitacionDoble);
                    Mostrar(dataGridHabitacion, BLLHabitacion.ListarTodo());
                    MessageBox.Show("Modificación de habitación realizada con éxito.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridHabitacion.Rows.Count == 0) throw new Exception("No hay nada para borrar !!!");
                DataGridViewRow row = dataGridHabitacion.SelectedRows[0];
                int habitacionID = Convert.ToInt32(row.Cells["ID"].Value);
                BEClsHabitacion Habitacion = new BEClsHabitacion(habitacionID);
                BLLHabitacion.Baja(Habitacion);
                Mostrar(dataGridHabitacion, BLLHabitacion.ListarTodo());
                MessageBox.Show("Baja de habitación realizada con éxito.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Frm_ABM_Habitacion_Load(object sender, EventArgs e)
        {
            Mostrar(dataGridHabitacion, BLLHabitacion.ListarTodo());
        }
        private void dataGridHabitacion_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow f = dataGridHabitacion.SelectedRows[0];


                textBox6.Text = f.Cells[3].Value.ToString();
                TextBox1.Text = f.Cells[1].Value.ToString();
                textBox5.Text = f.Cells[2].Value.ToString();
                textBox4.Text = f.Cells[0].Value.ToString();
                



            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
    }
}
