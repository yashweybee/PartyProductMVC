using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PartyProductMVC.Models
{
    public class Party
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(Order = 1)]
        public int PartyId { get; set; }

        [Required]
        [StringLength(255)]
        [Display(Name = "Party Name")]
        [RegularExpression("^[a-zA-Z0-9]*$", ErrorMessage = "Only Alphabets and Numbers allowed.")]
        public string PartyName { get; set; }
    }
}