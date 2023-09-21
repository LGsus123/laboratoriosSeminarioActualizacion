using Microsoft.AspNetCore.Mvc;
using Prj_JACV_MVCBibliotecaApp.Models;

namespace Prj_JACV_MVCBibliotecaApp.Controllers
{
    public class PrestamosController : Controller
    {
        private readonly BdJacvLaboratorio2Context _context;

        public PrestamosController(BdJacvLaboratorio2Context context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var query = (
                    from p in _context.Prestamos
                    join l in _context.Libros on p.Isbn equals l.Isbn
                    join u in _context.Usuarios on p.Idusuario equals u.Idusuario
                    select new PrestamosReport_Result
                    {
                        ISBN = p.Isbn,
                        Id = u.Idusuario,
                        Apellido = u.Apellido,
                        Nombre = u.Nombre,
                        Titulo = l.Titulo,
                        Autor = l.Autor,
                        Editorial = l.Editorial,
                        FechaPrestamo = p.FechaPrestamo,
                        FechaDevolucion = p.FechaDevolucion
                    }
                );
            return View(query.ToList<PrestamosReport_Result>());
        }
    }
}
