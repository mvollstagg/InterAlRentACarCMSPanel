using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Web.Areas.CMS.Models
{
    public class SliderCreateVM
    {
        [Required(ErrorMessage = "Doldurulmalıdır")]
        public IFormFile MainPhotoFile { get; set; }
        public bool IsActive { get; set; }
    }
}
