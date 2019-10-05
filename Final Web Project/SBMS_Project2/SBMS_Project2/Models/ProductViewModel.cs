using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SBMS_Project2.Models
{
    public class ProductViewModel
    {
        public string ProductName { get; set; }
        public string CategoryName { get; set; }

        [DataType(DataType.Date)]
        public DateTime StratDate { get; set; }
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }
        [DataType(DataType.Date)]
        public DateTime ExpireDate { get; set; }
        public int Quantity { get; set; }
        public int ReorderLevel { get; set; }
        public string Code { get; set; }

    }
}