using System;
using System.Linq;
using System.Web.Mvc;
using IAEARepository.Repository;
using IAEARepository.Interface;
using IAEADataModel;
using System.Collections.Generic;
using IAEAMVCApplication.ViewModel;

namespace IAEAMVCApplication.Controllers
{
    public class RentController : Controller
    {
        IRentRepository rentRepository;

        public RentController()
        {
            this.rentRepository = new RentRepository(new IAEADatabaseEntities());
        }
        private IAEADatabaseEntities db = new IAEADatabaseEntities();

        public ActionResult Index()
        {
            var rentList = from rent in rentRepository.GetRentedBoats() select rent;
            var rents = new List<RentModel>();
            if (rentList.Any())
            {
                foreach (var rent in rentList)
                {
                    rents.Add(new RentModel()
                    {
                        RentID = rent.ID,
                        BoatID = rent.BoatID,
                        CustomerID = rent.CustomerID,
                        BoatName = rent.Boat.Name,
                        CustomerName = rent.Customer.Name,
                        DateRentStart = rent.DateRentStart,
                        DateRentEnd = null
                    });
                }
            }

            var availableList = from available in rentRepository.GetAvailableBoats() select available;
            var availableBoats = new List<BoatModel>();
            if (availableList.Any())
            {
                foreach (var available in availableList)
                {
                    availableBoats.Add(new BoatModel()
                    {
                        BoatID = available.ID,
                        Name = available.Name,
                        HourlyRate = available.HourlyRate,
                        IsRented = available.IsRented,
                        IsRegistered = available.IsRegistered
                    });
                }
            }

            var allList = new AllRentListModel();
            allList.AvailableBoats = availableBoats;
            allList.RentedBoats = rents;

            return View(allList);
        }

        public ActionResult Create()
        {
            ViewBag.BoatID = new SelectList(db.Boats.Where(b => b.IsRegistered == true && b.IsRented == false), "ID", "Name");
            ViewBag.CustomerID = new SelectList(db.Customers, "ID", "Name");
            return View();
        }

        [HttpPost]
        public ActionResult Create(Rent rent)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    rentRepository.RentBoat(rent);
                    return RedirectToAction("Index");
                }

                ViewBag.BoatID = new SelectList(db.Boats.Where(b => b.IsRegistered == true && b.IsRented == false), "ID", "Name", rent.BoatID);
                ViewBag.CustomerID = new SelectList(db.Customers, "ID", "Name", rent.CustomerID);
                return View(rent);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index");
            }
        }

        public ActionResult Edit(int id = 0)
        {
            Rent rent = rentRepository.GetRentByID(id);
            if (rent == null)
            {
                return HttpNotFound();
            }
            ViewBag.BoatID = new SelectList(db.Boats.Where(b => b.IsRegistered == true && b.IsRented == false), "ID", "Name", rent.BoatID);
            ViewBag.CustomerID = new SelectList(db.Customers, "ID", "Name", rent.CustomerID);
            return View(rent);
        }

        [HttpPost]
        public JsonResult EditWithAjax(Rent rent)
        {
            try
            {
                string success = string.Empty;
                if (ModelState.IsValid)
                {
                    success = rentRepository.ReturnRentedBoat(rent);
                }
                else
                {
                    success = "Invalid state error, correct validations and then try!";
                }
                ViewBag.BoatID = new SelectList(db.Boats.Where(b => b.IsRegistered == true && b.IsRented == false), "ID", "Name", rent.BoatID);
                ViewBag.CustomerID = new SelectList(db.Customers, "ID", "Name", rent.CustomerID);

                return Json(success, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(ex.Message, JsonRequestBehavior.AllowGet);
            }
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}