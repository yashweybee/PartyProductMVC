using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PartyProductMVC.Models
{
    public class ProductRate
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProductRateId { get; set; }

        [Display(Name = "Product")]
        public int ProductId { get; set; }

        [ForeignKey("ProductId")]
        public Product Product { get; set; }

        [Required]
        [RegularExpression("([1-9][0-9]*)", ErrorMessage = "Rate must be in Numbers")]
        public int Rate { get; set; }

        [Required]
        public DateTime DateOfRate { get; set; }
    }
}