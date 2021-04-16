using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Data.DAL;
using Data.Entities;
using Utilities.Helpers;
using Web.Models;
using Microsoft.EntityFrameworkCore;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly MainContext _context;

        public HomeController(ILogger<HomeController> logger,  MainContext context)
        {
            _logger = logger;
            _context = context;
        }

        [Route("/")]
        [Route("/anasayfa")]
        public async Task<IActionResult> Index()
        {
            HomeVM homeVM = new HomeVM
            {
                Cars = await _context.Cars.OrderByDescending(x => x.RecordedAtDate)
                                                    .Where(x => x.IsActive == true)
                                                    .ToListAsync(),

                Sliders = await _context.Sliders.OrderByDescending(x => x.RecordedAtDate)
                                                    .Where(x => x.IsActive == true)
                                                    .ToListAsync(),
                
                Settings = await _context.SiteSettings.FirstOrDefaultAsync()
            };
            return View(homeVM);
        }

        [Route("/anasayfa/iletisim")]
        public async Task<JsonResult> CreateApply(string fullName, string email, string subject, string message)
        {
            try
            {
                Letter newApply = new Letter
                {
                    FullName = fullName.Trim(),
                    Email = email.Trim(),
                    Subject = subject.Trim(),
                    Message = message.Trim(),
                    RecordedAtDate = DateTime.Now
                };

                await _context.Letters.AddAsync(newApply);
                await _context.SaveChangesAsync();
                return Json(new { status = 1, title = "İşlem Başarılı", message = "Kaydınız başarıyla alındı..." });
            }
            catch (System.Exception ex)
            {
                 return Json(new { status = -1, title = "İşlem Başarısız", message = "İşlem Sırasında Bir Sorunla Karşılaşıldı. Lütfen Bu Durumu Bize Bildiriniz.." });
            }
        }

    }
}
