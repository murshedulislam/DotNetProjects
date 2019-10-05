using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;
using SmallBusinessManagementSystemApp.Models.Models;
using System.ComponentModel.DataAnnotations.Schema;


namespace SmallBusinessManagementSystemApp.Models
{
    public class SalesViewModel
    {
       

        [Column(TypeName = "date")]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [Display(Name ="Loyalty Point")]
        public double LoyaltyPoint { get; set; }

        [Display(Name ="Customer")]
        public int CustomerId { get; set; }

        //public int GrandTotal { get; set; }
        public double GrandTotal { get; set; }

        //public int Discount { get; set; }
        public double Discount { get; set; }

        //public int DiscountAmount { get; set; }
        public double DiscountAmount { get; set; }

        //public int PayableAmount { get; set; }
        public double PayableAmount { get; set; }

        public List<ProductSale> ProductSales { get; set; }

        public IEnumerable<SelectListItem> CustomerList { get; set; }
        public IEnumerable<SelectListItem> ProductList { get; set; }

    }
}