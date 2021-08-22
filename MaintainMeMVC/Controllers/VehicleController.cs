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

        public ActionResult Details(int id)
        {
            var svc = CreateVehicleService();
            var model = svc.GetVehicleById(id);

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var service = CreateVehicleService().GetVehicleById(id);
            var model =
                new VehicleEdit
                {
                    Make = service.Make,
                    Model = service.Model,
                    Year = service.Year,
                    Type = service.Type
                };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, VehicleEdit edit)
        {
            if (!ModelState.IsValid) return View(edit);

            if(edit.Id != id)
            {
                ModelState.AddModelError("", "Id does not match");
                return View(edit);
            }

            var service = CreateVehicleService();
            //DO AFTER SERVICE
            if (service.UpdateVehicle(edit))
            {
                TempData["SaveResult"] = "The Vehicle was updated.";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "The Vehicle could not be updated, try again in a few seconds.");
            return View(edit);
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateVehicleService().GetVehicleById(id);
            return View(svc);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteById(int id)
        {
            var service = CreateVehicleService();
            service.DeleteVehicle(id);

            TempData["SaveResult"] = "The vehicle was removed.";
            return RedirectToAction("Index");
        }



        private VehicleService CreateVehicleService()
        {
            var vehicleService = new VehicleService();
            return vehicleService;
        }
    }
}