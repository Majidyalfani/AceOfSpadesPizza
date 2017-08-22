using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using AceOfSpadesPizza.Models;

namespace AceOfSpadesPizza.Controllers
{
    // get customer from database
    public class CustomersController : Controller
    {
        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // to create form and add customer
        public ActionResult New()
        {
            return View("customerForm");
        }
    // this acction is using for send data from form into database
        [HttpPost]
        public ActionResult Save(Customer customer)
        {
            
            //if id = 0 that means this is a new customer
            if(customer.Id==0)
               _context.Customers.Add(customer);
            else
            {
                //if id!=0 update just update-data
                var customerInDb = _context.Customers.Single(c => c.Id == customer.Id);
                customerInDb.Name = customer.Name;
                customerInDb.PhoneNumber = customer.PhoneNumber;
                customerInDb.DeliveryDate = customer.DeliveryDate;
                customerInDb.Quantity = customer.Quantity;
            }
            //add data into database
            _context.SaveChanges();
            return RedirectToAction("Index","Customers");
        }

        public ViewResult Index()
        {
            var customers = _context.Customers.ToList();

            return View(customers);
        }


        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);
            return View("CustomerForm", customer);
        }
        
    }
}