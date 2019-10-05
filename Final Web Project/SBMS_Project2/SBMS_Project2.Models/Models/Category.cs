using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBMS_Project2.Models.Models
{
    public class Category
    {
        public int ID { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public List<Product> Products { get; set; }

        [NotMapped]
        public List<Category> Categories { get; set; }
    }
}
