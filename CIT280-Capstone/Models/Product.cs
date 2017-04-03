using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIT280_Capstone.Models
{
    public class Product
    {
        public int ID { get; set; }
        public string Name { get; set; }
        [DataType(DataType.Currency)]
        [DisplayName("Unit Price")]
        public decimal UnitPrice { get; set; }
        public bool IsSubProduct { get; set; }
    }
}
