using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBMS_Project2.Models.Models
{
    public class CustomerSale
    {
        public int ID { get; set; }

        [Column(TypeName = "date")]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        public double LoyaltyPoint { get; set; }

        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

        //public int GrandTotal { get; set; }
        public double GrandTotal { get; set; }

        //public int Discount { get; set; }
        public double Discount { get; set; }

        //public int DiscountAmount { get; set; }
        public double DiscountAmount { get; set; }

        //public int PayableAmount { get; set; }
        public double PayableAmount { get; set; }


        public List<ProductSale> ProductSales { get; set; }
    }
}
