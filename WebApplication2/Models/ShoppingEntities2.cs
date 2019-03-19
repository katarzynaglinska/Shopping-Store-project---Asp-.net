using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace WebApplication2.Models
{
    public class ShoppingEntities2 : DbContext
    {
        public DbSet<Thing> Things { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Firm> Firms { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<TransactionDetail> TransactionDetails { get; set; }
    }
}