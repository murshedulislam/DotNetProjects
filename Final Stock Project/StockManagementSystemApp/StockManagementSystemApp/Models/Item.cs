using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManagementSystemApp.Models
{
    class Item
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int ReorderLevel { get; set; }
        public int AvailableQuantity { get; set; }
        public int CategorySL { get; set; }
        public int CompanySL { get; set; }
    }
}
