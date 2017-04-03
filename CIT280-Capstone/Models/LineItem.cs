using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIT280_Capstone.Models
{
    public class LineItem
    {
        public int ID { get; set; }
        public Order OrderID { get; set; }
        public Product ProductID { get; set; }
        public int Quantity { get; set; }
        public LineItem ParentLineItem { get; set; }

    }
}
