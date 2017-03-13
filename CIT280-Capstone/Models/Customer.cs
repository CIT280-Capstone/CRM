using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIT280_Capstone.Models
{
    public class Customer
    {
        public string CFN { get; set; }
        //customer first name
        public string CLN { get; set; }
        //customer last name
        public string StrAddress { get; set; }
        //street address
        public string City { get; set; }
        public int ZipCode { get; set; }
        public int PhoneNumber { get; set; }
        public string email { get; set; }
        public bool RecievePromotions { get; set; }
        //Ask if they would like to recieve promotions


    }
}
