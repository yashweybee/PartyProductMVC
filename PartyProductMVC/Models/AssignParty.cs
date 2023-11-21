using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PartyProductMVC.Models
{
    public class AssignParty
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AsId { get; set; }



        [Display(Name = "Party")]
        //[ForeignKey("Party")]
        //[Column(Order = 1)]
        public int PartyId { get; set; }

        [ForeignKey("PartyId")]
        public Party Party { get; set; }



        [Display(Name = "Product")]
        //[ForeignKey("Product")]
        //[Column(Order = 1)]
        public int ProductId { get; set; }

        [ForeignKey("ProductId")]
        public Product Product { get; set; }
    }
}