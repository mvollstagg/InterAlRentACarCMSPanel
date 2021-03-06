using Microsoft.AspNetCore.Http;

namespace Web.Areas.CMS.Models
{
    public class SiteSettingsVM
    {
        public string AboutText { get; set; }
        public string MissionText { get; set; }
        public string Adress { get; set; }
        public string CopyrightText { get; set; }
        public string MapCode { get; set; }
        public string PhoneNumber { get; set; }
        public string LogoUrl { get; set; }
        public IFormFile MainPhotoFile { get; set; }
        public string LogoText { get; set; }
        public string GoogleAnalyticsCode { get; set; }
        public string FacebookPixel { get; set; }
        public string MetaTags { get; set; }
        public string SeoTitle { get; set; }
        public string SeoKeys { get; set; }
        public string SeoDesc { get; set; }    
        public string FacebookUrl { get; set; }
        public string InstagramUrl { get; set; } 
    }
}
