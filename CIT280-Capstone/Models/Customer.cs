using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace CIT280_Capstone.Models
{
    public class Customer
    {
        public int ID { get; set; }
        [DisplayName("First Name")]
        [Required]
        public string FirstName { get; set; }
        [DisplayName("Last Name")]
        [Required]
        public string LastName { get; set; }
        [DataType(DataType.PhoneNumber)]        
        [DisplayName("Phone Number")]
        [Required]
        [DisplayFormat(DataFormatString = "{0:###-####}")]
        public string PhoneNumber { get; set; }
        public int? DeliveryAddressID { get; set; }
        [DisplayName("Delivery Address")]
        public Address DeliveryAddress { get; set; }
        public int? MailingAddressID { get; set; }
        [DisplayName("Mailing Address")]
        public Address MailingAddress { get; set; }
        [DisplayName("Tax Exemption Status")]
        public bool TaxExempt { get; set; }

    }
}
