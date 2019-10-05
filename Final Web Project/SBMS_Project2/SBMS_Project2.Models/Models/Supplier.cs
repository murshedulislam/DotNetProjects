using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBMS_Project2.Models.Models
{
    public class Supplier
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Please enter Name")]
        [StringLength(10, MinimumLength = 3)]
        public string Code { get; set; }

        [Required(ErrorMessage = "Please enter Name")]
        [StringLength(50, MinimumLength = 3)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter Name")]
        [StringLength(30, MinimumLength = 3)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please enter Name")]
        [StringLength(30, MinimumLength = 3)]
        [Display(Name = "Contact Person")]
        public string ContactPerson { get; set; }

        public int Contact { get; set; }

        [Required(ErrorMessage = "Please enter Name")]
        [StringLength(50, MinimumLength = 3)]
        public string Address { get; set; }

        [NotMapped]
        public List<Supplier> Suppliers { get; set; }
    }
}
