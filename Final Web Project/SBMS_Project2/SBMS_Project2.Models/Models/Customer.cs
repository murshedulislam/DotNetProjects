using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBMS_Project2.Models.Models
{
    public class Customer
    {
        public int ID { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public int Contact { get; set; }
        public double LoyaltyPoint { get; set; }

        [NotMapped]
        public List<Customer> Customers { get; set; }
    }
}
