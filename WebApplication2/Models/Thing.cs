using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace WebApplication2.Models
{
    /*[Bind(Exclude = "ThingId")]*/
    public class Thing
    {
        [ScaffoldColumn(false)]
        public int ThingId { get; set; }
        [DisplayName("Kategoria")]
        public int CategoryId { get; set; }
        [DisplayName("Firma")]
        public int FirmId { get; set; }
        [Required(ErrorMessage = "Tytuł jest wymagany")]
        [StringLength(160)]
        public string Title { get; set; }
        [Required(ErrorMessage = "Cena jest wymagana")]
        [Range(0.1, 10000, ErrorMessage = "Cena musi być w przedziale od 1 do 10000")]
        public decimal Price { get; set; }
        [DisplayName("Adres url")]
        [StringLength(1024)]
        public string ItemArtUrl { get; set; }
        public virtual Category Category { get; set; }
        public virtual Firm Firm { get; set; }
        public virtual List<TransactionDetail> TransactionDetails { get; set; }
    }
}