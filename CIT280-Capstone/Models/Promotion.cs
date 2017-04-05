using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIT280_Capstone.Models
{
    public class Promotion
    {
        public int id { get; set; }
        public string Description { get; set; }
        [DisplayName("Start Date")]
        [DataType(DataType.Date)]
        public DateTime StartTime { get; set; }
        [DisplayName("End Date")]
        [DataType(DataType.Date)]
        public DateTime EndTime { get; set; }
        public Product ProductID { get; set; }
    }
}
