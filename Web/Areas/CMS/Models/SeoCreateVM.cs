
using System.ComponentModel.DataAnnotations;

namespace Web.Areas.CMS.Models
{
    public class SeoCreateVM
    {
        [Required(ErrorMessage = "Doldurulmalıdır")]
        public string Page { get; set; }
        [Required(ErrorMessage = "Doldurulmalıdır")]
        public string TitleAZ { get; set; }
        [Required(ErrorMessage = "Doldurulmalıdır")]
        public string KeysAZ { get; set; }
        [Required(ErrorMessage = "Doldurulmalıdır")]
        public string DescAZ { get; set; }
        [Required(ErrorMessage = "Doldurulmalıdır")]
        public string TitleRU { get; set; }
        [Required(ErrorMessage = "Doldurulmalıdır")]
        public string KeysRU { get; set; }
        [Required(ErrorMessage = "Doldurulmalıdır")]
        public string DescRU { get; set; }
        [Required(ErrorMessage = "Doldurulmalıdır")]
        public string TitleEN { get; set; }
        [Required(ErrorMessage = "Doldurulmalıdır")]
        public string KeysEN { get; set; }
        [Required(ErrorMessage = "Doldurulmalıdır")]
        public string DescEN { get; set; }
    }
}
