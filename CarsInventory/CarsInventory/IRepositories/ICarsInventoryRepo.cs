using CarsInventory.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarsInventory.IRepositories
{
    public interface ICarsInventoryRepo
    {
        List<tblCar> getAllCarInventory(CarViewModel foRequest);
        tblCar getUniqueCarInformation(int fiCarId);
        int saveCarInformation(tblCar foRequest);
        int deleteCarInformation(int fiCarID);
    }
}