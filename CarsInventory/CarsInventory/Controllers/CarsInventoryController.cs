using CarsInventory.IRepositories;
using CarsInventory.Models;
using CarsInventory.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

[assembly: log4net.Config.XmlConfigurator(ConfigFile = "Web.config", Watch = true)]
namespace CarsInventory.Controllers
{
    public class CarsInventoryController : Controller
    {
        //Here is the once-per-class call to initialize the log object
        private static readonly log4net.ILog mologger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        ICarsInventoryRepo _repo = new CarsInventoryRepo();

        // GET: CarsInventory
        public ActionResult Index()
        {
            try
            {

            }
            catch (Exception ex)
            {
                mologger.Debug("Debug error logging", ex);
                mologger.Info("Info error logging", ex);
                mologger.Warn("Warn error logging", ex);
                mologger.Error("Error error logging", ex);
                mologger.Fatal("Fatal error logging", ex);
            }

            return View();
        }
    }
}