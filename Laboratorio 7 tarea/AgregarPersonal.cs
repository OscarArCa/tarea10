using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Laboratorio_7_tarea.Class;

namespace Laboratorio_7_tarea
{
    public partial class AgregarPersonal : Form
    {
        ConectarBD conectarbd = new ConectarBD();
        public AgregarPersonal()
        {
            InitializeComponent();
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            Personal per = new Personal();
            per.dni = txtDNI.Text;
            per.nombre = txtNombre.Text;
            per.apellido = txtApellido.Text;
            if (conectarbd.RegistrarPersonal(per))
            {
                MessageBox.Show("Personal registrado");
                txtDNI.Clear();
                txtNombre.Clear();
                txtApellido.Clear();
                
            }
            else
            { 
                MessageBox.Show("Error al registrar el personal");
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login login = new Login();
            login.ShowDialog();
        }
    }
}
