using Microsoft.AspNetCore.Mvc;
using Prj_JACV_DemoMVCApp01.Models;

namespace Prj_JACV_DemoMVCApp01.Controllers
{
    public class GradesController : Controller
    {
        private readonly DbDemoSesion05Context _context;
        public GradesController(DbDemoSesion05Context context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var query = (from g in _context.Grades
                         join sc in _context.StudentCourses on g.StudentCourseId equals sc.Id
                         join s in _context.Students on sc.StudentId equals s.Id
                         join c in _context.Courses on sc.CourseId equals c.Id
                         select new GradeReport_Result
                         {
                                Code = s.Code,
                                LastName = s.LastName,
                                FirstName = s.FirstName,
                                Course  = c.Name,
                                Year = sc.Year,
                                Term = sc.Term,
                                Grade = g.Grade1
                          }
                         );
            return View(query.ToList<GradeReport_Result>());
        }
    }
}
