using MaintainMe.Models.VehicleModel;
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
            var model = new VehicleListItem[0];
            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(VehicleCreate create)
        {
            if (ModelState.IsValid)
            {

            }
            return View(create);
        }
    }
}