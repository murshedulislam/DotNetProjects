using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace SmallBusinessManagementSystemApp.Models.Models
{
    public class ProductSale
    {
        public int ID { get; set; }

        

        public int Quantity { get; set; }

        //public int UnitPrice { get; set; }
        public double UnitPrice { get; set; }

        //public int TotalPrice { get; set; }
        public double TotalPrice { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }

        public int CustomerSaleId { get; set; }
        public CustomerSale CustomerSale { get; set; }
    }
    
}
