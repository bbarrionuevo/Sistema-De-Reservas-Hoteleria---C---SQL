using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using BE;
using System.Security.Cryptography;

namespace SistemaDeReservas
{
    public partial class FrmLogin : Form
    {
        BLLClsHotel BLLhotel;
        BEClsEmpleado BEEmpleado;
        BLLClsEmpleado BLLEmpleado;
        public FrmLogin()
        {
            InitializeComponent();
            BLLhotel = new BLLClsHotel();
            BEEmpleado = new BEClsEmpleado();
            BLLEmpleado = new BLLClsEmpleado();
            txtContraseña.UseSystemPasswordChar = true;
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string usuario = txtUsuario.Text;
            string contraseña = txtContraseña.Text;
            BEEmpleado.Usuario = usuario;
            BEEmpleado.Constraseña = EncriptarContraseña(contraseña);

            if (BLLEmpleado.ValidarCredenciales(BEEmpleado))
            {
                // Credenciales válidas, habilita los menús
                Menu menu = (Menu)MdiParent;
                menu.AbrirSistemaDeGestion(true); // Establece la propiedad en true
                MessageBox.Show("Inicio de sesión exitoso.");
                this.Close();
            }
            else
            {
                MessageBox.Show("Credenciales incorrectas. Inténtalo nuevamente.");
            }
        }

        private string EncriptarContraseña(string contraseña)
        {
            using (SHA1 sha1 = SHA1.Create())
            {
                byte[] bytesContraseña = Encoding.UTF8.GetBytes(contraseña);
                byte[] hash = sha1.ComputeHash(bytesContraseña);
                string contraseñaEncriptada = BitConverter.ToString(hash).Replace("-", "").ToLower();
                return contraseñaEncriptada;
            }
        }
    }
   }