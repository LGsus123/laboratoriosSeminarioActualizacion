using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Prj_JACV_MVCBibliotecaApp.Models;

namespace Prj_JACV_MVCBibliotecaApp.Controllers
{
    public class ObtenerPrestamosxUsuario : Controller
    {
        private readonly BdJacvLaboratorio2Context _Context;
        public ObtenerPrestamosxUsuario(BdJacvLaboratorio2Context context)
        {
            _Context = context;
        }

        public IActionResult Index()
        {
            var result = GetPrestamo();
            return View(result);
        }
        public List<Prestamo_Result> GetPrestamo()
        {
            string sql = "EXEC ObtenerPrestamosxUsuario";
            var result = _Context.Prestamo_Results.FromSqlRaw(sql);
            return result.ToList();
        }
    }
}
