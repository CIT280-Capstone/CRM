using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIT280_Capstone.Models
{
    public class Order
    {
        public int ID { get; set; }
        public Customer CustomerID { get; set; }
        public DateTime OrderDate { get; set; }
        public bool IsDelivery { get; set; }
        public Address DeliveryAddress { get; set; }
    }
}
