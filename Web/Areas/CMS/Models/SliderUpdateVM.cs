using Microsoft.AspNetCore.Http;

namespace Web.Areas.CMS.Models
{
    public class SliderUpdateVM
    {
        public string PhotoUrl { get; set; }
        public IFormFile MainPhotoFile { get; set; }
        public bool IsActive { get; set; }
    }
}
