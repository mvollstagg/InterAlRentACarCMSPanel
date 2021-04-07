using Utilities.BaseClasses;
using System.Collections.Generic;
using System;

namespace Data.Entities
{
    public class Car : BaseEntity
    {   
        public string Name { get; set; }
        public string Year { get; set; }  
        public bool AirConditioner { get; set; }
        public string GasType { get; set; } 
        public string Gear { get; set; }  
        public string PhotoUrl { get; set; }  
    }
}
