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
    public class StockViewModel
    {
        
        [DataType(DataType.Date)]
        [Display(Name ="Order Date")]
        public DateTime StartDate { get; set; }

        [Column(TypeName = "date")]
        [DataType(DataType.Date)]
        [Display(Name = "End Date")]
        public DateTime EndDate { get; set; }

        [Display(Name = "Product")]
        public int ProductId { get; set; }

        [Display(Name = "Category")]
        public int CategoryId { get; set; }

        
        public IEnumerable<SelectListItem> ProductList { get; set; }
        public IEnumerable<SelectListItem> CategoryList { get; set; }
    }
}