using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Prj_JACV_Ejercicio_6.Models
{
    public class Analista
     {
        [Key]
        public int ID_Analista { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Email { get; set; }
        public ICollection<Punto> Puntos { get; set; }
    }
}
