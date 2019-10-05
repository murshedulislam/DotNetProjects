using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManagementSystemApp.Models
{
    class View
    {

        public string Item { get; set; }
        public string Company { get; set; }
        public int Amount { get; set; }
        public string StockCondition { get; set; }
        public DateTime Date { get; set; }
    }
}
