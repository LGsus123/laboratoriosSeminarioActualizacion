using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Prj_JACV_DemoMVCApp01.Models;

namespace Prj_JACV_DemoMVCApp01.Controllers
{
    public class GradesSPController : Controller
    {
        private readonly DbDemoSesion05Context _Context;
        public GradesSPController(DbDemoSesion05Context context)
        {
            _Context = context;
        }
        public IActionResult Index()
        {
            var result = GetReport_Result();
            return View(result);
        }
        public List<GradeReport_Result> GetReport_Result()
        {
            string sql = "EXEC GetStudentGrades";
            var result = _Context.GradeReport_Results.FromSqlRaw(sql);
            return result.ToList();
        }
    }
}
