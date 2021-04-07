
using System.Linq;
using System.Threading.Tasks;
using Data.DAL;
using Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web.Areas.CMS.Models;
using Utilities.Services;
using Microsoft.AspNetCore.Authorization;
using System;

namespace Web.Areas.CMS.Controllers
{
    [Area("CMS")]
    [Authorize(Roles = "Admin")]
    public class SiteSettingsController : Controller
    {
        private readonly MainContext _context;
        private readonly IImage _image;

        public SiteSettingsController(MainContext context, IImage image)
        {
            _context = context;
            _image = image;
        }
        
        [Route("/cms/saytparametrleri")]
        public async Task<IActionResult> Index()
        {            
            SiteSettings siteSettingsFromDb = await _context.SiteSettings.FirstOrDefaultAsync();
            SiteSettingsVM siteSettingsUpdateVM = new SiteSettingsVM();
            if (siteSettingsFromDb == null)
            {               
                siteSettingsFromDb = new SiteSettings();
                siteSettingsFromDb.LogoUrl = "logoUrl";
                await _context.SiteSettings.AddAsync(siteSettingsFromDb);
                await _context.SaveChangesAsync();
                
                return View(siteSettingsUpdateVM);
            }
            else
            {
                SiteSettingsVM settingsVM = new SiteSettingsVM
                {
                    AboutText = siteSettingsFromDb.AboutText,
                    MissionText = siteSettingsFromDb.MissionText,
                    Adress = siteSettingsFromDb.Adress,
                    CopyrightText = siteSettingsFromDb.CopyrightText,
                    MapCode = siteSettingsFromDb.MapCode,
                    PhoneNumber = siteSettingsFromDb.PhoneNumber,
                    LogoUrl = siteSettingsFromDb.LogoUrl,
                    LogoText = siteSettingsFromDb.LogoText,
                    GoogleAnalyticsCode = siteSettingsFromDb.GoogleAnalyticsCode,
                    FacebookPixel = siteSettingsFromDb.FacebookPixel,
                    MetaTags = siteSettingsFromDb.MetaTags,
                    SeoTitle = siteSettingsFromDb.SeoTitle,
                    SeoKeys = siteSettingsFromDb.SeoKeys,
                    SeoDesc = siteSettingsFromDb.SeoDesc
                };
                
                return View(settingsVM);
            } 
        }

        [Route("/cms/saytparametrleri/duzeliset")]
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Save(SiteSettingsVM siteSettingsUpdateVM)
        {
            
            SiteSettings siteSettingsFromDb = await _context.SiteSettings.FirstOrDefaultAsync();
            
            if (!ModelState.IsValid) return View(siteSettingsUpdateVM);
            if (siteSettingsUpdateVM.MainPhotoFile != null)
            {
                if(!String.IsNullOrEmpty(siteSettingsFromDb.LogoUrl))
                {
                    _image.Delete("files", "logo", siteSettingsFromDb.LogoUrl);
                    siteSettingsFromDb.LogoUrl = await _image.UploadAsync(siteSettingsUpdateVM.MainPhotoFile, "files", "logo");                                    
                    await _context.SaveChangesAsync();
                }
            }
            siteSettingsFromDb.AboutText = siteSettingsUpdateVM.AboutText;
            siteSettingsFromDb.MissionText = siteSettingsUpdateVM.MissionText;
            siteSettingsFromDb.Adress = siteSettingsUpdateVM.Adress;
            siteSettingsFromDb.CopyrightText = siteSettingsUpdateVM.CopyrightText;
            siteSettingsFromDb.MapCode = siteSettingsUpdateVM.MapCode;
            siteSettingsFromDb.PhoneNumber = siteSettingsUpdateVM.PhoneNumber;
            siteSettingsFromDb.LogoText = siteSettingsUpdateVM.LogoText;
            siteSettingsFromDb.GoogleAnalyticsCode = siteSettingsUpdateVM.GoogleAnalyticsCode;
            siteSettingsFromDb.FacebookPixel = siteSettingsUpdateVM.FacebookPixel;
            siteSettingsFromDb.MetaTags = siteSettingsUpdateVM.MetaTags;
            siteSettingsFromDb.SeoTitle = siteSettingsUpdateVM.SeoTitle;
            siteSettingsFromDb.SeoKeys = siteSettingsUpdateVM.SeoKeys;
            siteSettingsFromDb.SeoDesc = siteSettingsUpdateVM.SeoDesc;

            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "SiteSettings");             
        }
    
    }
}
