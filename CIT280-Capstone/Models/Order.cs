using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIT280_Capstone.Models
{
    public class Order
    {
        private double _total;
        private Promotion _promo;

        public int ID { get; set; }
        public int CustomerID { get; set; }
        public int PromotionID { get; set; }
        public string StrAddress { get; set; }
        public string City { get; set; }
        public int ZipCode { get; set; }
        public List<Tuple<string, double>> OrderItems { get; set; }
        public double SubTotal { get; set; }
        public double TaxRate { get { return 1.6d; } }
        public double Tax { get { return SubTotal * TaxRate; } }
        public double Total { get { return SubTotal + Tax; } }
        public bool PromoUsed { get; set; }
        

        public Order()
        {
            
        }
    }
}
