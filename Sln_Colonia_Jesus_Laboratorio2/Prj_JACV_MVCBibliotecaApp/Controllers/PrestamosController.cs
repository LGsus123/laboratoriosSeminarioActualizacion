using Prj_JACV_MVCBibliotecaApp.Models;
using Microsoft.AspNetCore.Mvc;
using Prj_JACV_MVCBibliotecaApp.Controllers;

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
            var query = (from p in _context.Prestamos
                         join l in _context.Libros on p.ISBN equals l.Isbn
                         join u in _context.Usuarios on p.IDUsuario equals u.IDUsuario
                         select new Prestamo_Result
                         {                            
                             Apellido = u.Apellido,
                             Nombre = u.Nombre,
                             IDUsuario = u.IDUsuario,
                             ISBN = p.ISBN,
                             Titulo = l.Titulo,
                             Autor = l.Autor,
                             Editorial = l.Editorial,
                             //FechaPrestamo = l.AnioPublicacion,
                             //FechaDevolucion = l.AnioPublicacion
                         }
                        );
            return View(query.ToList<Prestamo_Result>());
        }
    }
}
