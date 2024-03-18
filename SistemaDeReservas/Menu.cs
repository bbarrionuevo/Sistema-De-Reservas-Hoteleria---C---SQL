using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaDeReservas
{

    public partial class Menu : Form
    {

        private bool SistemaDeGestionAbierto = false;
        public Menu()
        {
            InitializeComponent();


        }

        public void AbrirSistemaDeGestion(bool x)
        {
            SistemaDeGestionAbierto = x;
            abrirSistemaDeGestionToolStripMenuItem.Enabled = SistemaDeGestionAbierto;

            if (SistemaDeGestionAbierto)
            {
                gestionToolStripMenuItem.Visible = true; // Muestra el botón "button1"
                informesToolStripMenuItem.Visible = true;// Muestra los demás botones relevantes de la misma manera
            }
        }

        private void iniciarSesionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmLogin frmLogin = new FrmLogin();
            frmLogin.MdiParent = this; // Establece el formulario MDI como padre
            frmLogin.Show(); // Muestra el formulario hijo
        }

        private void abrirSistemaDeGestionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
                Gestion gestion = new Gestion();
                gestion.MdiParent = this; // Establece el formulario MDI como padre
                gestion.Show(); // Muestra el formulario hijo

                
            
        }

        private void gestionToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void inicioToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void Menu_Load(object sender, EventArgs e)
        {
            abrirSistemaDeGestionToolStripMenuItem.Enabled = SistemaDeGestionAbierto;
            gestionToolStripMenuItem.Visible = false;
            informesToolStripMenuItem.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
                Application.Exit();
           

        }

        private void mostrarInformesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmInformes informes = new FrmInformes();
            informes.MdiParent = this; // Establece el formulario MDI como padre
            informes.Show(); // Muestra el formulario hijo



        }
    }
}