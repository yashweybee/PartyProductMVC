using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PartyProductMVC.Models
{
    public class Invoice
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int InvoiceId { get; set; }


        [Display(Name = "Party")]
        public string PartyName { get; set; }


        [Display(Name = "Product")]
        public string ProductName { get; set; }


        [Required]
        public int RateOfProduct { get; set; }


        [Required]
        public int Quantity { get; set; }

        [Required]
        public int Total { get; set; }
    }
}