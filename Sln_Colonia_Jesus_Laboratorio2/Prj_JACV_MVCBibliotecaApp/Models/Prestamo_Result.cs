using Microsoft.EntityFrameworkCore;
using Prj_JACV_MVCBibliotecaApp.Controllers;

namespace Prj_JACV_MVCBibliotecaApp.Models
{
    [Keyless]
    public class Prestamo_Result
    {        
        public int IDUsuario { get; set; }

        public string ISBN { get; set; }

        public string Nombre { get; set; }
        public string Apellido { get; set; }

        public string Titulo { get; set; }

        public string Autor { get; set; }

        public string Editorial { get; set; }

        public DateTime FechaPrestamo { get; set; }

        public DateTime FechaDevolucion { get; set; }
    }
}
