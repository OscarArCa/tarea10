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
    public partial class Login : Form
    {
        ConectarBD conectarBD = new ConectarBD();
        public Login()
        {
            InitializeComponent();
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            AgregarPersonal personal = new AgregarPersonal();
            this.Hide();
            personal.ShowDialog();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            Personal personal = new Personal();
            personal.dni = txtUsuario.Text;

            if (conectarBD.ValidarPersonal(personal))
            {
                Asistencia asistencia = new Asistencia();
                asistencia.dni = txtUsuario.Text;
                MessageBox.Show("Bienvenido");
                MostrarAsistencia mostrarAsistencia = new MostrarAsistencia();
                if(conectarBD.RegistrarAsistencia(asistencia))
                {
                    this.Hide();
                    mostrarAsistencia.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Error al registrar asistencia");
                }
            }
            else
            {
                MessageBox.Show("Usuario no registrado");
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
