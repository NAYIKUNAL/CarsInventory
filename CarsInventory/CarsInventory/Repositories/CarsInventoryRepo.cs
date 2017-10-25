using CarsInventory.IRepositories;
using CarsInventory.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarsInventory.Repositories
{
    public class CarsInventoryRepo : ICarsInventoryRepo
    {
        private CarsInventoryEntities _Context = new CarsInventoryEntities();

        public List<tblCar> getAllCarInventory(tblCar foRequest)
        {
            return new List<tblCar>();
        }

        public tblCar getUniqueCarInformation(tblCar foRequest)
        {
            return new tblCar();
        }
    }
}