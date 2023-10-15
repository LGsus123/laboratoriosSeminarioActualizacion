using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace Prj_JACV_BooksIdentityCoreMVCApp.Controllers
{
    [Authorize]
    public class StadisticsController : Controller
    {
        public IActionResult Identity()
        {
            return View();
        }
        [AllowAnonymous]
        public IActionResult Identity2()
        {
            return View();
        }
    }
}
