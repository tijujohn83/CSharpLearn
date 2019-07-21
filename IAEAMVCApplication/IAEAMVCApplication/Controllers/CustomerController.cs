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
    public class CustomerController : Controller
    {
        private ICustomerRepository customerRepository;

        public CustomerController()
        {
            this.customerRepository = new CustomerRepository(new IAEADatabaseEntities());
        }

        public ActionResult Index()
        {
            var customerList = from customer in customerRepository.GetCustomers() select customer;
            var customers = new List<CustomerModel>();
            if (customerList.Any())
            {
                foreach (var boat in customerList)
                {
                    customers.Add(new CustomerModel()
                    {
                        CustomerID = boat.ID,
                        Name = boat.Name,
                    });
                }
            }

            return View(customers);
        }
        
        private CustomerModel GetCustomerDetails(int id)
        {
            var customerDetails = customerRepository.GetCustomerByID(id);
            var customer = new CustomerModel();
            if (customerDetails != null)
            {
                customer.CustomerID = customerDetails.ID;
                customer.Name = customerDetails.Name;
            }
            return customer;
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]        
        public ActionResult Create(Customer customer)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    customerRepository.InsertCustomer(customer);
                    return RedirectToAction("Index");
                }
                return View(customer);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index");
            }
        }

        public ActionResult Edit(int id = 0)
        {
            Customer customer = customerRepository.GetCustomerByID(id);
            if (customer != null)
            {
                return View(customer);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]        
        public ActionResult Edit(Customer customer)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    customerRepository.UpdateCustomer(customer);
                    return RedirectToAction("Index");
                }
                return View(customer);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index");
            }
        }

        public ActionResult Delete(int id = 0)
        {
            Customer customer = customerRepository.GetCustomerByID(id);
            if (customer != null)
            {
                return View(customer);
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
                var customer = GetCustomerDetails(id);
                if (customer != null)
                {
                    customerRepository.DeleteCustomer(id);
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