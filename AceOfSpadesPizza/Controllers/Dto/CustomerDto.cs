using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.ComponentModel.DataAnnotations;
using System.Web;
using System.Web.Http;
using AceOfSpadesPizza.Models;

namespace AceOfSpadesPizza.Controllers.Dto
{
    public class CustomerDto
    {

        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        public int PhoneNumber { get; set; }
        public DateTime DeliveryDate { get; set; }
        public int Quantity { get; set; }
    }
}