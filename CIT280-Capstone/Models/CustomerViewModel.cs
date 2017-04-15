using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIT280_Capstone.Models
{
    public class CustomerView
    {
        public Customer customer { get; set; }
        public Address deliveryAddress { get; set; }
        public Address mailingAddress { get; set; }
    }
}
