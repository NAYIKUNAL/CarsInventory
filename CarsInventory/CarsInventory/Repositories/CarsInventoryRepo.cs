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
        //Here is the once-per-class call to initialize the log object
        private static readonly log4net.ILog mologger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private CarsInventoryEntities _Context = new CarsInventoryEntities();

        public List<tblCar> getAllCarInventory(CarViewModel foRequest)
        {
            List<tblCar> lotblCarList = new List<tblCar>();

            lotblCarList = _Context.tblCars
                                    //.Where(x =>
                                    //      !string.IsNullOrEmpty(foRequest.stSearchType) ? ((foRequest.stSearchType == "B" ? (x.stBrand) : (x.stModel)).Contains(foRequest.stSearch)) : true
                                    //    )
                                    //.OrderBy(x => x.inCarId)
                                    //.Skip(foRequest.inPageIndex * foRequest.inPageSize)
                                    //.Take(foRequest.inPageSize)
                                    .ToList();

            return lotblCarList;
        }

        public tblCar getUniqueCarInformation(int fiCarId)
        {
            return _Context.tblCars.Find(fiCarId);
        }

        public int saveCarInformation(tblCar foRequest)
        {
            int liResult = 0;

            try
            {
                if (foRequest != null)
                {
                    if (foRequest.inCarId > 0)  //Update Mode
                    {
                        _Context.Entry(foRequest).State = System.Data.Entity.EntityState.Modified;
                    }
                    else  //Insert Mode
                    {
                        foRequest = _Context.tblCars.Add(foRequest);
                    }

                    ///Finally Save Context into DB
                    liResult = _Context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                mologger.Error("Error error logging", ex);
            }

            return liResult;
        }

        public int deleteCarInformation(int fiCarID)
        {
            int liResult = 0;

            try
            {
                tblCar foRequest = _Context.tblCars.Find(fiCarID);

                if (foRequest != null)
                {
                    _Context.tblCars.Remove(foRequest);
                    liResult = _Context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                mologger.Error("Error error logging", ex);
            }

            return liResult;
        }
    }
}