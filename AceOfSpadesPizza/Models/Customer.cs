using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AceOfSpadesPizza.Models
{
    public class Customer
    {
        public int Id { get; set; }
        //overriding convention
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        public int PhoneNumber { get; set; }
        public DateTime DeliveryDate { get; set; }
        public int Quantity { get; set; }
    }
}