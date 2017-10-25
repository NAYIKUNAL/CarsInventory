using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarsInventory.Models
{
    public class CarViewModel
    {
        public int inCarId { get; set; }
        public string stBrand { get; set; }
        public string stModel { get; set; }
        public Nullable<int> inYear { get; set; }
        public Nullable<decimal> dcPrice { get; set; }
        public Nullable<bool> flgIsNew { get; set; }

        public List<tblCar> loCarList { get; set; }

        public bool isPartialPage { get; set; }
        public string stSearch { get; set; }
        public string stSearchType { get; set; }
        public int inPageIndex { get; set; }
        public int inPageSize { get; set; }
        public string stSortColumn { get; set; }
        public string stSortDirection { get; set; }
    }
}