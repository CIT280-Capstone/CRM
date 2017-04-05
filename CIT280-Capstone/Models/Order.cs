﻿using System;
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
        [DisplayName("Customer ID")]
        public Customer CustomerID { get; set; }
        [DisplayName("Order Date")]
        [DataType(DataType.Date)]
        public DateTime OrderDate { get; set; }
        [DisplayName("Delivery?")]
        public bool IsDelivery { get; set; }
        [DisplayName("Delivery Address")]
        public Address DeliveryAddress { get; set; }
    }
}
