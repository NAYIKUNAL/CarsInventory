using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarsInventory.Models.Temp
{
    public class CarModel
    {
        public Int64 inCarID { get; set; }
        public string stBrand { get; set; }
        public string stModel { get; set; }
        public Int16 inYear { get; set; }
        public decimal dcPrice { get; set; }
        public bool flgIsNew { get; set; }
    }
}