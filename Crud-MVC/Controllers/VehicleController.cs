using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using VehicleLibrary;

namespace Crud_MVC.Controllers
{

    public class VehicleController : Controller
    {
        VehicleRepository value;
        ILocationRepository _IlocationRepository;

        public VehicleController(IConfiguration configuration, ILocationRepository IlocationRepository)
        {
            value = new VehicleRepository(configuration);
            _IlocationRepository = IlocationRepository;
        }
        
        // GET: VehicleController
        public ActionResult Index()
         {
            var Modeldata =value.ShowAll();
            return View("Showall", Modeldata);
        }

        // GET: VehicleController/Details/5
        public ActionResult Details(int id)
        {
            var result = value.getbyid(id).FirstOrDefault();
            return View(result);
        }

        // GET: VehicleController/Create
        public ActionResult Create()
        {
            var locations = _IlocationRepository.ShowAll();

            var Veh = new VehicleModel();
            Veh.Locations = locations;
            return View("Create",Veh);
        }

        // POST: VehicleController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(VehicleModel refer)
        {
            try
            {
                var locations = _IlocationRepository.ShowAll();
                var Veh = new VehicleModel();
                Veh.Locations = locations;
                if(ModelState.IsValid)
                {
                    if(false)
                    {
                        ModelState.AddModelError("", "Email Already Exists");
                        return View("Create", Veh);
                    }
                    value.Insert(refer);
                    return RedirectToAction(nameof(Index));
                }else
                {
                    return View("Create", Veh);
                }
              //  value.Insert(refer);
               // return RedirectToAction(nameof(Index));
            }
            catch
            {
                throw;
            }
        }

        // GET: VehicleController/Edit/5
        public ActionResult Edit(int id)
        {
            var user = value.getbyid(id).FirstOrDefault();
            return View("Edit",user);
        }

        // POST: VehicleController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(VehicleModel vehicle)
        {
            try
            {
                var Id = vehicle.Id;
                var number = vehicle.ContactNumber;
                var drivername = vehicle.DriverName;
                value.Update(Id, number,drivername);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: VehicleController/Delete/5
        public ActionResult Delete(int id)
        {
            var user = value.getbyid(id).FirstOrDefault();
            return View("delete",user);
        }

        // POST: VehicleController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult delete(String VehicleNumber)
        {
            try
            {
                value.Remove(VehicleNumber);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
