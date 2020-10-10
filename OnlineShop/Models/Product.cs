using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShop.Models
{
    public class Product
    {
        public int ID { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public decimal Price { get; set; }

        public string Image { get; set; }

        [Display(Name ="Available")]
        public bool IsAvailable { get; set; }

        [Required]
        [Display(Name ="Product Type")]
        public int ProductTypeID { get; set; }

        [ForeignKey("ProductTypeID")]
        public ProductType ProductType { get; set; }

        [Required]
        [Display(Name ="Special Tags")]
        public int SpecialTagID { get; set; }

        [ForeignKey("SpecialTagID")]
        public SpecialTag SpecialTag { get; set; }
    }
}
