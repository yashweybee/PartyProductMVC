using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PartyProductMVC.Models
{
    public class AssignParty
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AsId { get; set; }



        [Display(Name = "Party")]
        public int PartyId { get; set; }

        [ForeignKey("PartyId")]
        public Party Party { get; set; }



        [Display(Name = "Product")]
        public int ProductId { get; set; }

        [ForeignKey("ProductId")]
        public Product Product { get; set; }
    }
}