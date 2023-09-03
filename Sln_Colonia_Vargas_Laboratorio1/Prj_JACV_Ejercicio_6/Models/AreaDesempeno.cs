using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Prj_JACV_Ejercicio_6.Models
{
    public class AreaDesempeno
    {
        [Key]
        public int ID_Area_Desempeno { get; set; }
        public string Nombre_Area { get; set; }
        public int Valor_Puntuacion { get; set; }

        public ICollection<Talento> Talentos { get; set; }
    }
}
