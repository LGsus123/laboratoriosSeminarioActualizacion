using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Prj_JACV_Ejercicio_6.Models
{
    public class Punto
    {
        [Key]
        public int ID { get; set; }
        public int ID_Analista { get; set; }
        public Analista Analista { get; set; }
        public int ID_Talento { get; set; }
        public Talento Talento { get; set; }

        public int Puntos { get; set; }
    }
}
