using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{
    public class TransactionDetail
    {
        public int TransactionDetailId { get; set; }
        public int TransactionId { get; set; }
        public int ThingId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public virtual Thing Thing { get; set; }
        public virtual Transaction Transaction { get; set; }
    }
}