using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Web.Areas.CMS.Models
{
    public class ProductCreateVM
    {
        [Required(ErrorMessage = "Doldurulmalıdır")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Doldurulmalıdır")]
        public string Year { get; set; }  
        [Required(ErrorMessage = "Doldurulmalıdır")]
        public bool AirConditioner { get; set; }  
        [Required(ErrorMessage = "Doldurulmalıdır")]
        public string GasType { get; set; }
        [Required(ErrorMessage = "Doldurulmalıdır")]
        public string Gear { get; set; }  
        [Required(ErrorMessage = "Doldurulmalıdır")]
        public IFormFile MainPhotoFile { get; set; }       
        public bool IsActive { get; set; }
    }
}
