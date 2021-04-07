
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
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using System;

namespace Web.Areas.CMS.Controllers
{
    [Area("CMS")]
    [Authorize(Roles = "Admin")]
    public class ProductController : Controller
    {
        private readonly MainContext _context;
        private readonly IImage _image;

        public ProductController(MainContext context, IImage image)
        {
            _context = context;
            _image = image;
        }
        [Route("/cms/araclar")]
        public async Task<IActionResult> Index(int count = 100)
        {
            return View(await _context.Cars.OrderByDescending(x => x.RecordedAtDate).Take(count).ToListAsync());
        }

        [Route("/cms/araclar/yarat")]
        public IActionResult Create()
        {
            return View();
        }

        [Route("/cms/araclar/yarat")]
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProductCreateVM productCreateVM)
        {
            if (!ModelState.IsValid) return View(productCreateVM);
            if (!_image.IsImageValid(productCreateVM.MainPhotoFile))
            {
                ModelState.AddModelError("", "Fayl .jpg/jpeg formatında və maksimum 3MB həcmində olmalıdır !");
                return View(productCreateVM);
            }   

            Car newCar = new Car
            {
                Name = productCreateVM.Name.Trim(),
                Year = productCreateVM.Year,
                AirConditioner = productCreateVM.AirConditioner,
                GasType = productCreateVM.GasType.Trim(),
                Gear = productCreateVM.Gear.Trim(),
                PhotoUrl = await _image.UploadAsync(productCreateVM.MainPhotoFile, "files", "cars"),
                UrlId = _context.Cars.Count() + 1,
                IsActive = productCreateVM.IsActive
            };
            await _context.Cars.AddAsync(newCar);
            await _context.SaveChangesAsync();            

            return RedirectToAction("Index", "Product");
        }

        [Route("/cms/araclar/duzelt/{id}")]
        public async Task<IActionResult> Update(int id)
        {
            if (id == 0) return BadRequest();
            Car carFromDb = await _context.Cars.FirstOrDefaultAsync(x => x.Id == id);
            
            if (carFromDb == null) return NotFound();
            
            ProductUpdateVM productUpdateVM = new ProductUpdateVM
            {
                Name = carFromDb.Name,
                Year = carFromDb.Year,
                AirConditioner = carFromDb.AirConditioner,
                GasType = carFromDb.GasType,
                Gear = carFromDb.Gear,
                PhotoUrl = carFromDb.PhotoUrl,
                IsActive = carFromDb.IsActive
            };
            
            return View(productUpdateVM);
        }
        

        [Route("/cms/araclar/duzelt/{id}")]
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int id, ProductUpdateVM productUpdateVM)
        {
            if (id == 0) return BadRequest();
            Car carFromDb = await _context.Cars.FirstOrDefaultAsync(x => x.Id == id);
            if (carFromDb == null) return NotFound();

            if (!ModelState.IsValid) return View(productUpdateVM);
            
            if(productUpdateVM.MainPhotoFile != null)
            {
                _image.Delete("files", "cars", carFromDb.PhotoUrl);
                carFromDb.PhotoUrl = await _image.UploadAsync(productUpdateVM.MainPhotoFile, "files", "cars");
            }
                                                                                       
            carFromDb.Name = productUpdateVM.Name;
            carFromDb.Year = productUpdateVM.Year;
            carFromDb.AirConditioner = productUpdateVM.AirConditioner;
            carFromDb.GasType = productUpdateVM.GasType;
            carFromDb.Gear = productUpdateVM.Gear;
            carFromDb.IsActive = productUpdateVM.IsActive;
            await _context.SaveChangesAsync();            

            return RedirectToAction("Index", "Product");
        }

        [Route("/cms/araclar/kaldir/{id}")]
        // [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            if (id == 0) return BadRequest();
            Car carFromDb = await _context.Cars.FirstOrDefaultAsync(x => x.Id == id);
            _context.Remove(carFromDb);
            await _context.SaveChangesAsync(); 
            
            return RedirectToAction("Index", "Product");
        }
    }
}
