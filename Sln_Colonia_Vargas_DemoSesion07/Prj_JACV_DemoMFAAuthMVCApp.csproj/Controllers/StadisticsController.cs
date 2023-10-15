using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Prj_JACV_DemoMFAAuthMVCApp.Controllers
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
