using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace CIT280_Capstone.Models
{
    public class Address
    {
        public int ID { get; set; }
        [Required]
        public string Street { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string State { get; set; }
        [Required]
        [DisplayName("Zip Code")]
        [DataType(DataType.PostalCode)]
        public string ZipCode { get; set; }
    }
}
