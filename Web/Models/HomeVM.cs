using Data.Entities;
using System.Collections.Generic;

namespace Web.Models
{
    public class HomeVM
    {
        public IEnumerable<Car> Cars { get; set; }
        public IEnumerable<Slider> Sliders { get; set; }
        public SiteSettings Settings { get; set; }
    }
}
