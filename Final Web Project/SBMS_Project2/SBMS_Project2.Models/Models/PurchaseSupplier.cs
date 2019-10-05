using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBMS_Project2.Models.Models
{
    public class PurchaseSupplier
    {
        public int ID { get; set; }
        [DataType(DataType.Date)]
        [Column(TypeName = "date")]
        public DateTime Date { get; set; }
        public string InvoiceNumber { get; set; }


        public int SupplierId { get; set; }
        public Supplier Supplier { get; set; }

        [NotMapped]
        public List<Purchase> Purchases { get; set; }

    }
}
