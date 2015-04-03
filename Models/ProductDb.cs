using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace InventoryManagement.Models
{
    public class ProductDb : DbContext
    {
        public ProductDb()
            : base("name=DefaultConnection")
        {
        }
        
        public DbSet<Product> Products { get; set; }
        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<Client> Clients { get; set; }

        public DbSet<Supplier> Suppliers { get; set; }
    }
}