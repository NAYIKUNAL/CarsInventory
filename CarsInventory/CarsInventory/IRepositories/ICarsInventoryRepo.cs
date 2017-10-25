using CarsInventory.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarsInventory.IRepositories
{
    public interface ICarsInventoryRepo
    {
        List<tblCar> getAllCarInventory(tblCar foRequest);
        tblCar getUniqueCarInformation(tblCar foRequest);
    }
}