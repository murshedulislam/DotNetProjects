using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManagementSystemApp.Models
{
    class Search
    {
        public string Item { get; set; }
        public string Company { get; set; }
        public string Category { get; set; }
        public int AvailableQuantity { get; set; }
        public int ReorderLevel { get; set; }

    }
}
