namespace Prj_JACV_MVCBibliotecaApp.Models
{
    public class Prestamo_Result
    {
        public int IdPrestamo { get; set; }
        public int IdUsuario { get; set; }

        public string ISBN { get; set; }
        public string Libro { get; set; }

        public string Nombre { get; set; }
        public string Apellido { get; set; }

        public string Titulo { get; set; }

        public string Autor { get; set; }

        public string Editorial { get; set; }

        public DateTime FechaPrestamo { get; set; }

        public DateTime FechaDevolucion { get; set; }
    }
}
