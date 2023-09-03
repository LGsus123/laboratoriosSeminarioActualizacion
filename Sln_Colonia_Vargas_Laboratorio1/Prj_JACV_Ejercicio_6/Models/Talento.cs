using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Prj_JACV_Ejercicio_6.Models
{
    public class Talento
    {
        [Key]
        public int ID_Talento { get; set; }
        public string NombreTalento { get; set; }
        public int ID_Area { get; set; }
        public AreaDesempeno AreaDesempeno { get; set; }
        public ICollection<Punto> Puntos { get; set; }
    }
}
