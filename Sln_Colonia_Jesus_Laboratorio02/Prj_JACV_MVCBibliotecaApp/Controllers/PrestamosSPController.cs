using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Prj_JACV_MVCBibliotecaApp.Models;

namespace Prj_JACV_MVCBibliotecaApp.Controllers
{
    public class PrestamosSPController : Controller
    {
        private readonly BdJacvLaboratorio2Context _Context;
        public PrestamosSPController(BdJacvLaboratorio2Context context)
        {
            _Context = context;
        }

        public IActionResult Index()
        {
            var result = GetPrestamo();
            return View(result);
        }
        public List<PrestamosReport_Result> GetPrestamo()
        {
            string sql = "EXEC ObtenerPrestamosxUsuario";
            var result = _Context.PrestamosReport_Results.FromSqlRaw<PrestamosReport_Result>(sql);
            return result.ToList();
        }
    }
}
