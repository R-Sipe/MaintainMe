using MaintainMe.Models.VehicleModel;
using MaintainMe.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MaintainMeMVC.Controllers
{
    [Authorize]
    public class VehicleController : Controller
    {
        // GET: Vehicle
        public ActionResult Index()
        {
            var vehicleService = CreateVehicleService();
            var vehicles = vehicleService.GetVehicles();
            return View(vehicles);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(VehicleCreate create)
        {
            if (!ModelState.IsValid) return View(create);

            var service = CreateVehicleService();

            if (service.CreateVehicle(create))
            {
                TempData["SaveResult"] = "The vehicle has been created.";
                return RedirectToAction("Index");
            };
            ModelState.AddModelError("", "The vehicle could not be created");
            return View(create);
        }

        private VehicleService CreateVehicleService()
        {
            var vehicleService = new VehicleService();
            return vehicleService;
        }
    }
}