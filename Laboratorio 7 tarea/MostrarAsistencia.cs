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
    public partial class MostrarAsistencia : Form
    {
        ConectarBD conectarBD = new ConectarBD();
        public MostrarAsistencia()
        {
            InitializeComponent();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login login = new Login();
            login.ShowDialog();
        }

        private void MostrarAsistencia_Load(object sender, EventArgs e)
        {
            dtgwAsistencia.DataSource = conectarBD.MostrarAsistencia();
            dtgwAsistencia.Columns["tardanza_set"].Visible = false;
            dtgwAsistencia.Columns["tardanza_view"].HeaderText = "Tiempo de tardanza";
            dtgwAsistencia.Columns["dni"].HeaderText = "Dni del personal";
            dtgwAsistencia.Columns["nombre"].HeaderText = "Nombre";
            dtgwAsistencia.Columns["apellido"].HeaderText = "Apellido";
            dtgwAsistencia.Columns["fecha"].HeaderText = "Fecha de hoy";
            dtgwAsistencia.Columns["hora_entrada"].HeaderText = "Hora de entrada al trabajo";
            dtgwAsistencia.Columns["hora_llegada"].HeaderText = "Hora de llegada del personal ";




        }
    }
}
