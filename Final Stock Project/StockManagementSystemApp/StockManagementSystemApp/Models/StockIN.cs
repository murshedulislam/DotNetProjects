using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManagementSystemApp.Models
{
    class StockIN
    {
        public string Item { get; set; }
        public int ItemID { get; set; }
        public DateTime Date { get; set; }
        public int Amount { get; set; }
        public int ID { get; set; }
    }
}
