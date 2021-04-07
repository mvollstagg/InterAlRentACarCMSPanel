
using System.Linq;
using System.Threading.Tasks;
using Data.DAL;
using Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Utilities.Helpers;
using Web.Areas.CMS.Models;
using Utilities.Services;
using Microsoft.AspNetCore.Authorization;

namespace Web.Areas.CMS.Controllers
{
    [Area("CMS")]
    [Authorize(Roles = "Admin")]
    public class SliderController : Controller
    {
        private readonly MainContext _context;
        private readonly IImage _image;

        public SliderController(MainContext context, IImage image)
        {
            _context = context;
            _image = image;
        }

        [Route("/cms/slaydir")]
        public async Task<IActionResult> Index(int count = 100)
        {
            return View(await _context.Sliders.OrderByDescending(x => x.RecordedAtDate).Take(count).ToListAsync());
        }

        [Route("/cms/slaydir/olustur")]
        public IActionResult Create()
        {
            return View();
        }

        [Route("/cms/slaydir/olustur")]
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SliderCreateVM sliderCreateVM)
        {
            if (!ModelState.IsValid) return View(sliderCreateVM);

            if (!_image.IsImageValid(sliderCreateVM.MainPhotoFile))
            {
                ModelState.AddModelError("", "Fayl .jpg/jpeg formatında və maksimum 3MB həcmində olmalıdır !");
                return View(sliderCreateVM);
            }
            
            Slider newSlider = new Slider
            {
                PhotoUrl = await _image.UploadAsync(sliderCreateVM.MainPhotoFile, "files", "sliders"),
                UrlId = _context.Sliders.Count() + 1,
                IsActive = sliderCreateVM.IsActive
            };
            await _context.Sliders.AddAsync(newSlider);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index", "Slider");
        }

        [Route("/cms/slaydir/duzelt/{id}")]
        public async Task<IActionResult> Update(int id)
        {
            if (id == 0) return BadRequest();
            Slider sliderFromDb = await _context.Sliders.FirstOrDefaultAsync(x => x.Id == id);
            if (sliderFromDb == null) return NotFound();

            SliderUpdateVM sliderUpdateVM = new SliderUpdateVM
            {
                PhotoUrl = sliderFromDb.PhotoUrl,
                IsActive = sliderFromDb.IsActive
            };
            return View(sliderUpdateVM);
        }

        [Route("/cms/slaydir/duzelt/{id}")]
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int id, SliderUpdateVM sliderUpdateVM)
        {
            if (id == 0) return BadRequest();
            Slider sliderFromDb = await _context.Sliders.FirstOrDefaultAsync(x => x.Id == id);
            if (sliderFromDb == null) return NotFound();

            if (!ModelState.IsValid) return View(sliderUpdateVM);

            if (sliderUpdateVM.MainPhotoFile != null)
            {
                if (!_image.IsImageValid(sliderUpdateVM.MainPhotoFile))
                {
                    ModelState.AddModelError("", "Fayl .jpg/jpeg formatında və maksimum 3MB həcmində olmalıdır !");
                    return View(sliderUpdateVM);
                }
                else
                {
                    _image.Delete("files", "sliders", sliderFromDb.PhotoUrl);
                    sliderFromDb.PhotoUrl = await _image.UploadAsync(sliderUpdateVM.MainPhotoFile, "files", "sliders");
                    await _context.SaveChangesAsync();
                }
            }
            
            sliderFromDb.IsActive = sliderUpdateVM.IsActive;
            
            await _context.SaveChangesAsync();

            return RedirectToAction("Index", "Slider");
        }

        [Route("/cms/slaydir/kaldir/{id}")]
        // [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            if (id == 0) return BadRequest();
            Slider sliderFromDb = await _context.Sliders.FirstOrDefaultAsync(x => x.Id == id);
            _context.Remove(sliderFromDb);
            await _context.SaveChangesAsync(); 
            
            return RedirectToAction("Index", "Slider");
        }
    }
}
