using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using IAEARepository.Repository;
using IAEARepository.Interface;
using IAEADataModel;
using IAEAMVCApplication.ViewModel;

namespace IAEAMVCApplication.Controllers
{
    public class BoatController : Controller
    {
        IBoatRepository boatRepository;

        public BoatController()
        {
            this.boatRepository = new BoatRepository(new IAEADatabaseEntities());
        }

        public ActionResult Index()
        {
            var boatList = from boat in boatRepository.GetBoats() select boat;
            var boats = new List<BoatModel>();
            if (boatList.Any())
            {
                foreach (var boat in boatList)
                {
                    boats.Add(new BoatModel()
                    {
                        BoatID = boat.ID,
                        Name = boat.Name,
                        HourlyRate = boat.HourlyRate,
                        IsRegistered = boat.IsRegistered,
                        IsRented = boat.IsRented
                    });
                }
            }

            return View(boats);
        }

        private BoatModel GetBoatDetails(int id)
        {
            var boatDetails = boatRepository.GetBoatByID(id);
            var boat = new BoatModel();
            if (boatDetails != null)
            {
                boat.BoatID = boatDetails.ID;
                boat.Name = boatDetails.Name;
                boat.HourlyRate = boatDetails.HourlyRate;
                boat.IsRegistered = boatDetails.IsRegistered;
                boat.IsRented = boatDetails.IsRented;
            }
            return boat;
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]        
        public ActionResult Create(Boat boat)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    boat.IsRegistered = true;
                    boat.IsRented = false;
                    boatRepository.InsertBoat(boat);
                    return RedirectToAction("Index");
                }
                return View(boat);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index");
            }
        }

        public ActionResult Edit(int id = 0)
        {
            Boat boat = boatRepository.GetBoatByID(id);
            if (boat != null)
            {
                return View(boat);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]       
        public ActionResult Edit(Boat boat)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    boatRepository.UpdateBoat(boat);
                    return RedirectToAction("Index");
                }
                return View(boat);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index");
            }
        }

        public ActionResult Delete(int id = 0)
        {
            Boat boat = boatRepository.GetBoatByID(id);
            if (boat != null)
            {
                return View(boat);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        [HttpPost, ActionName("Delete")]        
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                var boat = GetBoatDetails(id);
                if (boat != null)
                {
                    boatRepository.DeleteBoat(id);
                }

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index");
            }
        }
    }
}