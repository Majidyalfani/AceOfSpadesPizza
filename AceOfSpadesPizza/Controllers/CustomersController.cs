using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using AceOfSpadesPizza.Models;

namespace AceOfSpadesPizza.Controllers
{
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

        public ActionResult New()
        {
            return View("customerForm");
        }
    
        [HttpPost]
        public ActionResult Save(Customer customer)
        {
            

            if(customer.Id==0)
               _context.Customers.Add(customer);
            else
            {
                var customerInDb = _context.Customers.Single(c => c.Id == customer.Id);
                customerInDb.Name = customer.Name;
                customerInDb.PhoneNumber = customer.PhoneNumber;
                customerInDb.DeliveryDate = customer.DeliveryDate;
                customerInDb.Quantity = customer.Quantity;
            }
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