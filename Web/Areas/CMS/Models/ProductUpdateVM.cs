using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using Data.Entities;

namespace Web.Areas.CMS.Models
{
    public class ProductUpdateVM
    {
        public string Name { get; set; }
        public string Year { get; set; }  
        public bool AirConditioner { get; set; }  
        public string GasType { get; set; }
        public string Gear { get; set; }  
        public string PhotoUrl { get; set; } 
        public IFormFile MainPhotoFile { get; set; }       
        public bool IsActive { get; set; }
    }
}
