using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Data.DAL;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Areas.CMS.Controllers
{
    [Area("CMS")]
    [Authorize(Roles = "Admin")]
    public class LetterController : Controller
    {
        private readonly MainContext _context;

        public LetterController(MainContext context)
        {
            _context = context;
        }

        [Route("/cms/basvurular")]
        public async Task<IActionResult> Index(int count = 100)
        {
            return View(await _context.Letters.OrderByDescending(x => x.RecordedAtDate).Take(count).ToListAsync());
        }
    }
}