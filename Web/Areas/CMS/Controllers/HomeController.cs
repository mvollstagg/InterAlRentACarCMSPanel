using Microsoft.AspNetCore.Mvc;

namespace Web.Areas.CMS.Controllers
{
    [Area("CMS")]
    public class HomeController : Controller
    {
        [Route("/cms/anasayfa")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
