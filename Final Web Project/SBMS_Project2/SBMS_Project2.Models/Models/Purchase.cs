using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBMS_Project2.Models.Models
{
    public class Purchase
    {
        public int ID { get; set; }


        //[DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        //[Column(TypeName ="date")]
        //[DataType(DataType.Date)]
        //public DateTime Date { get; set; }

        //[Display(Name ="Invoice Number")]
        //[Required(ErrorMessage = "Please enter Invoice Number")]
        //[StringLength(100, MinimumLength = 3)]
        //public string InvoiceNumber { get; set; }

        //[Display(Name = "Code")]
        //[Required(ErrorMessage = "Please enter Product Code")]
        //[StringLength(100, MinimumLength = 3)]
        public string ProductCode { get; set; }

        //[Display(Name = "Manufactured Date")]
        //[Required(ErrorMessage = "Please enter Manufactured Date")]
        //[DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        [Column(TypeName = "date")]
        [DataType(DataType.Date)]
        public DateTime ManufacturedDate { get; set; }

        //[Display(Name = "Expire Date")]
        //[Required(ErrorMessage = "Please enter Expired Date")]
        //[DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        [Column(TypeName = "date")]
        [DataType(DataType.Date)]
        public DateTime ExpireDate { get; set; }

        //[Required(ErrorMessage = "Please enter Quantity")]
        public int Quantity { get; set; }

        //[Display(Name = "Unit Price")]
        //[Required(ErrorMessage = "Please enter Unit Price")]
        //public int UnitPrice { get; set; }
        public double UnitPrice { get; set; }
        //[Required(ErrorMessage = "Please enter Total Price")]
        //public int TotalPrice { get; set; }
        public double TotalPrice { get; set; }

        //[Required(ErrorMessage = "Please enter New MRP")]
        //public int NewMRP { get; set; }
        public double NewMRP { get; set; }

        //[Required(ErrorMessage = "Please enter Remarks")]
        //[StringLength(100, MinimumLength = 3)]
        public string Remarks { get; set; }


        public int PurchaseSupplierId { get; set; }
        public PurchaseSupplier PurchaseSupplier { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }



        //public int Id { get; set; }
        //public DateTime ManufactureDate { get; set; }
        //public DateTime ExpireDate { get; set; }
        //public int Quantity { get; set; }
        //public decimal UnitPrice { get; set; }
        //public decimal TotalPrice { get; set; }
        //public decimal NewMRP { get; set; }
        //public string Remark { get; set; }

        //public int ProductId { get; set; }
        //public virtual Product Product { get; set; }

    }
}
