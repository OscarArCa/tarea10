using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Laboratorio_7_tarea.Class
{
     class ConectarBD
    {

        MySqlConnection con = new MySqlConnection();
        MySqlCommand cmd = new MySqlCommand();
        MySqlDataReader dr = null;
        public void ConnectionString()
        {
            string server = "localhost";
            string puerto = "3306";
            string basededatos = "bdpersonal";
            string user = "root";
            string clave = "usbw";
            string cadena;
            cadena = "SERVER=" + server + ";" + "PORT=" + puerto + ";" + "DATABASE=" + basededatos +
                ";" + "UID=" + user + ";" + "PASSWORD=" + clave + ";";
            con = new MySqlConnection(cadena);
        }
        public Boolean ValidarPersonal(Personal per)
        {
            Boolean resultado = false;
            ConnectionString();
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "SELECT * FROM tbpersonal WHERE " + "" +
                "DNI='" + per.dni + "'";
            dr = cmd.ExecuteReader();
            if (dr != null)
            {
                if (dr.Read())
                {
                    resultado = true;
                }
                else resultado = false;
            }
            con.Close();
            return resultado;
        }
        public Boolean RegistrarPersonal(Personal per)
        {
            Boolean resultado = false;
            int res = -1;
            ConnectionString();
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "INSERT INTO tbpersonal(DNI,NOMBRE,APELLIDO) VALUES('" + per.dni + "','" + per.nombre + "','" + per.apellido + "')";
            res = cmd.ExecuteNonQuery();
            if (res > 0)
            {
                resultado = true;
            }
            else
            {
                resultado = false;
            }
            con.Close();
            return resultado;
        }
        public Boolean RegistrarAsistencia(Asistencia asis)
        {
            Boolean resultado = false;
            int res = -1;
            ConnectionString();
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "INSERT INTO tbingresos(DNI,FECHA,HORA,TARDANZA)" +
                " VALUES('" + asis.dni + "','" + asis.fecha.ToString("yyyy-MM-dd") + "','" + asis.hora_llegada.ToString() + "','" + asis.tardanza_set.ToString()+ "')";
            res = cmd.ExecuteNonQuery();
            if (res > 0)
            {
                resultado = true;
            }
            else
            {
                resultado = false;
            }
            con.Close();
            return resultado;
        }
        public List<Asistencia> MostrarAsistencia()
        {
            List<Asistencia> lista = new List<Asistencia>();
            ConnectionString();
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "SELECT p.DNI, p.NOMBRE, p.APELLIDO, i.FECHA, i.HORA, i.TARDANZA " +
                   "FROM tbingresos i " +
                   "JOIN tbpersonal p ON i.DNI = p.DNI " +
                   "WHERE i.FECHA = CURDATE() " +
                   "ORDER BY i.HORA DESC;";
            dr = cmd.ExecuteReader();
            if (dr != null) {
                while (dr.Read())
                {
                    lista.Add(new Asistencia
                    {
                        dni = dr.GetString(0),
                        nombre= dr.GetString(1),
                        apellido = dr.GetString(2),
                        fecha = dr.GetDateTime(3),
                        hora_llegada = TimeSpan.Parse(dr["HORA"].ToString()),
                        tardanza_view = TimeSpan.Parse(dr["TARDANZA"].ToString())
                    });
                }
            }
            con.Close();
            return lista;
        }
    }
}
