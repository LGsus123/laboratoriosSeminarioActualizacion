using Prj_JACV_MVCBibliotecaApp.Models;
using Microsoft.AspNetCore.Mvc;

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
                         join l in _context.Libros on p.Isbn equals l.Isbn
                         join u in _context.Usuarios on p.Idusuario equals u.Idusuario
                         select new Prestamo_Result
                         {
                             IdPrestamo = p.Idprestamo,
                             ISBN = p.Isbn,
                             IdUsuario = u.Idusuario,
                             Nombre = u.Nombre,
                             Apellido = u.Apellido,
                             Libro = l.Isbn,
                             Titulo = l.Titulo,
                             Autor = l.Autor,
                             Editorial = l.Editorial
                         }
                        );
            return View(query.ToList<Prestamo_Result>());
        }
    }
}
