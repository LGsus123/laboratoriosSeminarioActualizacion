using Microsoft.EntityFrameworkCore;

namespace Prj_JACV_MVCBibliotecaApp.Models
{
    [Keyless]
    public class PrestamosReport_Result
    {
        public int? Id { get; set; }
        public string? Apellido { get; set; }
        public string? Nombre { get; set; }
        public string? ISBN { get; set; }
        public string? Titulo { get; set; }
        public string? Autor { get; set; }
        public string? Editorial { get; set; }
        public DateTime? FechaPrestamo { get; set; }
        public DateTime? FechaDevolucion { get; set; }
    }
}
