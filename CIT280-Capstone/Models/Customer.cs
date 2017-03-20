using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace CIT280_Capstone.Models
{
    public class Customer
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [Phone]
        public int PhoneNumber { get; set; }
        public Address DeliveryAddress { get; set; }
        public Address MailiingAddress { get; set; }
        public bool TaxExempt { get; set; }

    }
}
