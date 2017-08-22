using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using AceOfSpadesPizza.Models;

namespace AceOfSpadesPizza.Controllers.Api
{
    public class CustomersController : ApiController
    {

        private ApplicationDbContext _context;
        private int id;

        public CustomersController()
        {
            _context= new ApplicationDbContext();
        }
        //GET API / Customers

        public IEnumerable<Customer> GetCustomers()
        {
            return _context.Customers.ToList();

        }

        //api/customer/1

        public Customer GetCustomer(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);
            
            return customer;
        }

     [System.Web.Mvc.HttpDelete]
        public void DeleteCustomer(int id)
        {
            var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customerInDb==null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            _context.Customers.Remove(customerInDb);
            _context.SaveChanges();
        }

    }
}
