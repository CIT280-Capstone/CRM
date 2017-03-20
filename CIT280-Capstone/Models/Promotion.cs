﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIT280_Capstone.Models
{
    public class Promotion
    {
        public int id { get; set; }
        public string Description { get; set; }
        public DateTime StatrtTime { get; set; }
        public DateTime EndTime { get; set; }
        public Product ProductID { get; set; }
    }
}
