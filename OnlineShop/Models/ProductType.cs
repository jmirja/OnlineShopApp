using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShop.Models
{
    public class ProductType
    {
        public int ID { get; set; }
        [Required]
        [Display(Name ="Product Type Name")]
        public string ProductTypeName { get; set; }
    }
}
