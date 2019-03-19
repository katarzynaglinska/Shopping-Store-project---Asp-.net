using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace WebApplication2.Models
{
    [Bind(Exclude = "TransactionId")]
    public class Transaction
    {
         [ScaffoldColumn(false)]
        public int TransactionId { get; set; }
        [ScaffoldColumn(false)]
        public System.DateTime OrderDate { get; set; }
         [ScaffoldColumn(false)]
        public string Username { get; set; }
         [DisplayName("Imię")]
         [StringLength(160)]
        public string FirstName { get; set; }
         [DisplayName("Nazwisko")]
         [StringLength(160)]
        public string LastName { get; set; }
         [DisplayName("Email ")]
         [DataType(DataType.EmailAddress)]
         public string Email { get; set; }
         [DisplayName("Adres")]
         [StringLength(70)]
        public string Address { get; set; }
         [DisplayName("Miasto")]
         [StringLength(40)]
        public string City { get; set; }
         [DisplayName("Województwo")]
         [StringLength(40)] 
        public string State { get; set; }
         [DisplayName("Kod pocztowy")]
         [StringLength(10)]
        public string PostalCode { get; set; }
        [DisplayName("Kraj")]
         [StringLength(40)]
        public string Country { get; set; }
        [DisplayName("Telefon")]
         [StringLength(24)]
        public string Phone { get; set; }

        [ScaffoldColumn(false)]
        public decimal Total { get; set; }
        public List<TransactionDetail> TransactionDetails { get; set; }
    }
}