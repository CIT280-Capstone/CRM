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
        
        public int OrderID { get; set; }
        public Order Order { get; set; }
        public int ProductID { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
        public int ParentLineItemID { get; set; }
        public LineItem ParentLineItem { get; set; }

    }
}
