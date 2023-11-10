using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PartyProductMVC.Models
{
    public class Invoice
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int InvoiceId { get; set; }


        [Display(Name = "Party")]
        public int PartyId { get; set; }

        [ForeignKey("PartyId")]
        public Party Party { get; set; }


        [Display(Name = "Product")]
        public int ProductId { get; set; }

        [ForeignKey("ProductId")]
        public Product Product { get; set; }


        [Required]
        public int RateOfProduct { get; set; }


        [Required]
        public int Quantity { get; set; }

        [Required]
        public int Total { get; set; }
    }
}