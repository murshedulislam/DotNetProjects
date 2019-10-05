using SBMS_Project2.Models.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SBMS_Project2.Models
{
    public class PurchaseViewModel
    {
        [DataType(DataType.Date)]

        public DateTime Date { get; set; }

        [Display(Name = "Invoice Number")]
        //[Required(ErrorMessage = "Please enter Invoice Number")]
        //[StringLength(100, MinimumLength = 3)]
        public string InvoiceNumber { get; set; }

        [Display(Name = "Supplier")]
        public int SupplierId { get; set; }


        public IEnumerable<SelectListItem> SupplierList { get; set; }

        public IEnumerable<SelectListItem> ProductList { get; set; }

        public List<Purchase> Purchases { get; set; }
    }
}