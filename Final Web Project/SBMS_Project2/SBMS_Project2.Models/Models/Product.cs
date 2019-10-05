using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBMS_Project2.Models.Models
{
    public class Product
    {
        public int ID { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public int ReorderLevel { get; set; }
        public string Description { get; set; }
        [Display(Name = "Category")]
        public int CategoryId { get; set; }
        public Category Category { get; set; }

        [NotMapped]
        public List<Category> Categories { get; set; }
        [NotMapped]
        public List<Product> Products { get; set; }
        [NotMapped]
        public string CategoryName { get; set; }
        [NotMapped]
        public string ProductName { get; set; }
    }
}
