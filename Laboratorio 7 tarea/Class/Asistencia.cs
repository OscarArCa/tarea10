using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Org.BouncyCastle.Asn1.X509;

namespace Laboratorio_7_tarea.Class
{
     class Asistencia
    {
        public string dni { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public DateTime fecha { get; set; } = DateTime.Now;
        public TimeSpan hora_entrada { get; set; } = new TimeSpan(8,30,0);
        public TimeSpan hora_llegada { get; set; } = DateTime.Now.TimeOfDay ;
        public TimeSpan tardanza_set
        {
            get
            {
                return hora_llegada > hora_entrada ? hora_llegada - hora_entrada : TimeSpan.Zero;
            }
  
        }
        public TimeSpan tardanza_view { get; set;}
    }
}
