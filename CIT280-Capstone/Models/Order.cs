using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIT280_Capstone.Models
{
    public class Order
    {
        public int ID { get; set; }
        public int CustomerID { get; set; }
        [DisplayName("Customer ID")]
        public Customer Customer { get; set; }
        [DisplayName("Order Date")]
        [DataType(DataType.Date)]
        [Required]
        public DateTime OrderDate { get; set; }
        [Required]
        [DisplayName("Delivery?")]
        public bool IsDelivery { get; set; }
        public int DeliveryAddressID { get; set; }
        [DisplayName("Delivery Address")]
        public Address DeliveryAddress { get; set; }
    }
}
