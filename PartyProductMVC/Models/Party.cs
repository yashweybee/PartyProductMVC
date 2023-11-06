using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PartyProductMVC.Models
{
    public class Party
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PartyId { get; set; }

        [Required]
        [StringLength(255)]
        [Display(Name = "Party Name")]
        public string PartyName { get; set; }
    }
}